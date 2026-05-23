using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Wang.ModbusTCPLib
{
    public sealed class ModbusTCP : IDisposable
    {
        #region IDisposable Support
        private int _disposeState = 0;  // 检测Dispose方法冗余调用；0 = 未释放，1 = 已释放。
        /// <summary>
        /// 该方法线程安全。
        /// 根据 "所有权链" 原则：如果一个类持有实现了 IDisposable 的成员，且该成员的生命周期与类实例绑定，
        /// 那么这个类也必须实现 IDisposable，并在自己的 Dispose 方法中调用成员的 Dispose。
        /// </summary>
        /// <param name="disposing">是否释放托管对象</param>
        private void Dispose(bool disposing)
        {
            if (Interlocked.CompareExchange(ref _disposeState, 1, 0) == 0)    // 原子操作
            {
                // 多线程调用Dispose方法，只有一个线程能执行到这里
                if (disposing)
                {
                    // TODO:释放托管状态(托管对象)。
                }

                // TODO:释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO:将大型字段设置为null。
                if (hybridLock != null)
                {
                    hybridLock.Dispose();
                    hybridLock = null;
                }
                if (this.socket != null)
                {
                    this.socket.Dispose();
                    this.socket = null;
                }
            }
        }

        // TODO:仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // 终结器的调用方：GC的终结器线程（在对象被垃圾回收时）。
        //~ModbusRTU()
        //{
        //    // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //    Dispose(false);
        //}

        // 添加此代码以正确实现可处置模式。
        /// <summary>
        /// 释放资源。Dispose方法由开发者显式调用，而非由GC调用。该方法线程安全。
        /// </summary>
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO:如果在以上内容中替代了终结器，则取消注释以下行。
            //GC.SuppressFinalize(this);    // 告诉垃圾回收器（GC）不要调用该对象的终结器。
        }
        #endregion

        /// <summary>
        /// Socket对象
        /// </summary>
        private Socket socket = null;

        #region 相关字段和属性
        /// <summary>
        /// socket通信对象是否由用户主动打开连接或关闭连接，默认为false。
        /// </summary>
        private bool _isOpen = false;
        /// <summary>
        /// ModbusTCP内部socket通信对象是否处于连接状态。在连接打开后该属性置为true，在连接关闭前该属性置为false。默认为false。
        /// 该属性主要反映通信对象是否由用户主动打开连接或关闭连接（所谓主动，即为是否通过调用Connect或DisConnect方法来连接或断开连接）。
        /// </summary>
        public bool IsOpen { get { return _isOpen; } }

        /// <summary>
        /// 发送超时时间
        /// </summary>
        public int SendTimeOut { get; set; } = 2000;

        /// <summary>
        /// 接收超时时间
        /// </summary>
        public int ReceiveTimeOut { get; set; } = 2000;

        /// <summary>
        /// 锁对象
        /// </summary>
        private SimpleHybridLock hybridLock = new SimpleHybridLock();

        /// <summary>
        /// 每次接收报文前的延时时间，保证对端发送的报文已传至本机。
        /// </summary>
        public int SleepTimeBeforeReceive { get; set; } = 20;

        /// <summary>
        /// 一次发送后最大【等待对端应答】次数
        /// </summary>
        public int MaxWaitTimes { get; set; } = 10;

        /// <summary>
        /// 单元标识符（从站地址；在ModbusTCP中被弱化，定位则主要使用IP地址）
        /// </summary>
        public byte SlaveID { get; set; } = 0x01;
        #endregion

        #region 连接检测方法，通过发送测试报文判断套接字连接状态（考虑多线程情况，通过加锁保证线程安全）
        /// <summary>
        /// 连接检测方法，通过发送测试报文判断套接字连接状态。（考虑多线程情况，通过加锁保证线程安全）
        /// </summary>
        /// <returns>返回true表示处于连接状态，返回false表示不处于连接状态或套接字对象为null或锁对象为null。</returns>
        public bool IsSocketConnected()
        {
            if (this.socket == null || hybridLock == null)
            {
                return false;
            }

            // 加锁（不可在SendAndReceive私有方法内部调用该方法，会导致死锁，原因就是这两个方法都要获取同一把锁）
            hybridLock.Enter();
            // 记录原阻塞状态
            bool blockingState = this.socket.Blocking;
            try
            {
                byte[] tmp = new byte[1];
                // 非阻塞发送0字节数据，通过异常判断连接状态
                this.socket.Blocking = false;
                this.socket.Send(tmp, 0, 0);
                return true; // 发送成功，仍处于连接状态
            }
            catch (SocketException e)
            {
                // 10035 == WSAEWOULDBLOCK，表示操作会阻塞，但连接是正常的
                if (e.NativeErrorCode.Equals(10035))
                    return true;
                else
                    return false; // 其他错误，连接已断开
            }
            finally
            {
                this.socket.Blocking = blockingState; // 恢复原设置
                // 在finally块中解锁
                hybridLock.Leave();
            }
        }
        #endregion

        #region 建立连接与断开连接
        /// <summary>
        /// 通过以太网连接对端方法。
        /// </summary>
        /// <param name="address">目标主机的IP地址或域名</param>
        /// <param name="port">目标端口号</param>
        /// <returns>连接成功返回true，连接失败抛出异常。</returns>
        /// <exception cref="Exception">使用套接字连接时可能抛出异常，捕获后重抛出</exception>
        public bool Connect(string address, int port)
        {
            // Socket实例化（IPv4，字节流，TCP协议）
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // 给Socket对象设置相关参数
            this.socket.SendTimeout = SendTimeOut;
            this.socket.ReceiveTimeout = ReceiveTimeOut;

            try
            {
                // 尝试能否将address转为IP地址
                if (IPAddress.TryParse(address, out IPAddress ipAddress))
                {
                    // 若能，则使用IP地址连接对端（使用IP地址和端口号连接对端）
                    this.socket.Connect(ipAddress, port);
                    _isOpen = true;
                }
                else
                {
                    // 若不能，则尝试以域名方式连接对端（使用域名和端口号连接对端）
                    this.socket.Connect(address, port);
                    _isOpen = true;
                }
            }
            catch (Exception ex)
            {
                _isOpen = false;
                throw new Exception(ex.Message);
            }

            return true;
        }

        /// <summary>
        /// 断开套接字连接方法。
        /// </summary>
        /// <param name="isJudgeConnected">若需要判断套接字是否处于连接状态（以发送测试报文的方式）则传true，否则传false。默认为false。</param>
        /// <returns>返回0表示断开连接成功；返回-1表示已不处于连接状态，无需再断开（只有当isJudgeConnected为true时才可能返回-1）；
        /// 返回-2表示套接字对象为null。</returns>
        public int DisConnect(bool isJudgeConnected = false)
        {
            if (this.socket == null)
            {
                return -2;
            }
            if (!isJudgeConnected || IsSocketConnected())  // 在多线程情况下，IsSocketConnected内部可能因获取锁而等待，这可能影响断开连接的实时性。
            {
                _isOpen = false;
                // 关闭套接字连接和释放所有关联资源
                this.socket.Close();
                // 若在此处将this.socket置空，则在多线程情况下，需要在发送和接收报文方法中额外做判空处理，否则容易抛出空引用异常。

                return 0;
            }
            return -1;
        }
        #endregion

        #region 私有通用辅助方法：比较字节数组
        /// <summary>
        /// 比较两个字节数组方法
        /// </summary>
        /// <param name="b1">字节数组1</param>
        /// <param name="b2">字节数组2</param>
        /// <returns>返回true表示两个字节数组相等，返回false表示两个字节数组中有为空的数组或两个字节数组不相等。</returns>
        private bool ByteArrayEquals(byte[] b1, byte[] b2)
        {
            if (b1 == null || b2 == null || b1.Length <= 0 || b2.Length <= 0) { return false; }
            if (b1.Length != b2.Length) { return false; }

            return BitConverter.ToString(b1) == BitConverter.ToString(b2);
        }
        #endregion

        #region 预置多线圈辅助方法：将布尔数组转换成字节数组
        /// <summary>
        /// 在预置多线圈时，将布尔数组转换成字节数组
        /// </summary>
        /// <param name="values">布尔数组</param>
        /// <returns>字节数组</returns>
        private byte[] GetByteArrayFromBoolArray(bool[] values)
        {
            if (values == null || values.Length <= 0) { return null; }

            // 字节计数
            int byteLength = values.Length % 8 == 0 ? values.Length / 8 : values.Length / 8 + 1;

            // 默认初始化数组元素均为0
            byte[] result = new byte[byteLength];

            for (int i = 0; i < result.Length; i++)
            {
                // 计算该字节中要更新的位数
                int bitsInByte = values.Length < 8 * (i + 1) ? values.Length - 8 * i : 8;

                // j表示要赋值的位的位置（从0开始计；j等于0表示该字节的最低位）
                for (int j = 0; j < bitsInByte; j++)
                {
                    result[i] = SetBitValue(result[i], j, values[8 * i + j]);
                }
            }
            return result;
        }
        #endregion

        #region 私有通用辅助方法：为字节中的某一位赋值
        /// <summary>
        /// 为字节中的某一位赋值
        /// </summary>
        /// <param name="src">源字节</param>
        /// <param name="bitPos">要赋值的位的位置（从0开始计；bitPos等于0表示该字节的最低位）</param>
        /// <param name="value">对该位要赋的值（true/false）</param>
        /// <returns>返回修改了位之后的字节</returns>
        private byte SetBitValue(byte src, int bitPos, bool value)
        {
            return value ? (byte)(src | (byte)Math.Pow(2, bitPos)) : (byte)(src & ~(byte)Math.Pow(2, bitPos));
        }
        #endregion

        #region 私有通用辅助方法：发送报文并接收应答报文（考虑多线程情况，通过加锁保证线程安全）
        /// <summary>
        /// 发送报文并接收应答报文方法（考虑多线程情况，通过加锁保证线程安全）
        /// </summary>
        /// <param name="send">发送的报文</param>
        /// <param name="receive">应答报文（ref）</param>
        /// <param name="errno">错误码（ref）</param>
        /// <returns>过程执行成功返回true，否则返回false。ref receive用于接收应答报文，
        /// ref errno用于接收错误码。错误码为-2表示获取对端应答报文超时，-3表示参数校验不通过。</returns>
        /// <exception cref="Exception">发送报文或接收报文时可能抛出异常，捕获后重抛出</exception>
        private bool SendAndReceive(byte[] send, ref byte[] receive, ref short errno)
        {
            if (send == null || send.Length <= 0 || socket == null || hybridLock == null)
            {
                errno = -3;
                return false;
            }

            try
            {
                // 加锁
                hybridLock.Enter();

                // 用户缓冲区
                byte[] buffer = new byte[1024];
                // 开辟一块内存
                MemoryStream stream = new MemoryStream();

                // 使用套接字向对端发送报文
                socket.Send(send, send.Length, SocketFlags.None);

                // 记录循环的次数
                int times = 1;

                while (true)
                {
                    // 每次读取前等待一段时间，保证对端发送的数据到达本机Socket的输入缓冲区。
                    Thread.Sleep(SleepTimeBeforeReceive);

                    // 从对端接收的、可供读取的数据的字节数大于0时
                    if (socket.Available > 0)
                    {
                        // 读取对端发送的数据，也就是报文，存入用户缓冲区buffer
                        int count = socket.Receive(buffer, SocketFlags.None);

                        // 将buffer中的数据存入之前开辟的内存
                        stream.Write(buffer, 0, count);
                    }
                    else
                    {
                        if (stream.Length > 0)
                        {
                            // 第一次读到，第二次没有读到，就认为是读完了
                            break;
                        }
                        else if (times <= MaxWaitTimes)
                        {
                            times++;
                        }
                        else if (times > MaxWaitTimes)
                        {
                            // 获取对端应答报文超时
                            errno = -2;
                            return false;
                        }
                    }
                }
                // 获取读取的保存在内存中的应答报文（字节数组）
                receive = stream.ToArray();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                // 在finally块中解锁
                hybridLock.Leave();
            }
        }
        #endregion

        #region 功能码01H：读取输出线圈
        /// <summary>
        /// 读取输出线圈方法（对应功能码01H）
        /// </summary>
        /// <param name="startAddress">要读取的起始线圈地址</param>
        /// <param name="coilsCount">要读取的线圈数量</param>
        /// <param name="errno">错误码（ref）</param>
        /// <returns>读取成功则以字节数组形式返回应答报文中的实际数据部分，读取失败则返回null。可通过异常信息和错误码查看失败原因，
        /// 错误码为-2表示获取对端应答报文超时，-3表示参数校验不通过，-4表示应答报文校验不通过。</returns>
        /// <exception cref="Exception">发送和接收报文时可能抛出异常，捕获后重抛出</exception>
        public byte[] ReadOutputCoils(ushort startAddress, ushort coilsCount, ref short errno)
        {
            // 第①步：拼接ModbusTCP报文
            ByteArray SendCommand = new ByteArray();
            // 发送报文格式：
            // 事务处理标识符 + 协议标识符 + 长度 + 单元标识符 + 功能码 + 起始线圈地址 + 要读取的线圈个数
            //（其中的“长度”是“长度”之后的部分的长度）
            SendCommand.Add(0x00, 0x00, 0x00, 0x00);     // 事务处理标识符 + 协议标识符
            SendCommand.Add(0x00, 0x06, SlaveID, 0x01);  // 长度（2个字节） + 单元标识符 + 功能码
            SendCommand.Add(startAddress);               // 起始线圈地址
            SendCommand.Add(coilsCount);                 // 要读取的线圈个数

            // 第②步：发送报文并接收应答报文
            byte[] receive = null;
            try
            {
                if (SendAndReceive(SendCommand.Array, ref receive, ref errno))
                {
                    // 计算应答报文中应有的数据字节计数
                    int byteLength = coilsCount % 8 == 0 ? coilsCount / 8 : coilsCount / 8 + 1;

                    // 第③步：校验应答报文
                    if ((receive.Length == 9 + byteLength) && ((receive[4] << 8) + receive[5] == 3 + byteLength)
                         && receive[6] == SlaveID && receive[7] == 0x01 && receive[8] == byteLength)
                    {
                        // 第④步：解析应答报文
                        byte[] result = new byte[byteLength];
                        // 提取应答报文中的实际数据部分
                        Array.Copy(receive, 9, result, 0, byteLength);
                        // 返回应答报文中的实际数据部分
                        return result;
                    }
                    // 应答报文校验不通过，错误码置-4
                    errno = -4;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return null;
        }
        #endregion

        #region 功能码02H：读取输入线圈
        /// <summary>
        /// 读取输入线圈方法（对应功能码02H）
        /// </summary>
        /// <param name="startAddress">要读取的起始线圈地址</param>
        /// <param name="coilsCount">要读取的线圈数量</param>
        /// <param name="errno">错误码（ref）</param>
        /// <returns>读取成功则以字节数组形式返回应答报文中的实际数据部分，读取失败则返回null。可通过异常信息和错误码查看失败原因，
        /// 错误码为-2表示获取对端应答报文超时，-3表示参数校验不通过，-4表示应答报文校验不通过。</returns>
        /// <exception cref="Exception">发送和接收报文时可能抛出异常，捕获后重抛出</exception>
        public byte[] ReadInputCoils(ushort startAddress, ushort coilsCount, ref short errno)
        {
            // 第①步：拼接ModbusTCP报文
            ByteArray SendCommand = new ByteArray();
            // 发送报文格式：
            // 事务处理标识符 + 协议标识符 + 长度 + 单元标识符 + 功能码 + 起始线圈地址 + 要读取的线圈个数
            //（其中的“长度”是“长度”之后的部分的长度）
            SendCommand.Add(0x00, 0x00, 0x00, 0x00);     // 事务处理标识符 + 协议标识符
            SendCommand.Add(0x00, 0x06, SlaveID, 0x02);  // 长度（2个字节） + 单元标识符 + 功能码
            SendCommand.Add(startAddress);               // 起始线圈地址
            SendCommand.Add(coilsCount);                 // 要读取的线圈个数

            // 第②步：发送报文并接收应答报文
            byte[] receive = null;
            try
            {
                if (SendAndReceive(SendCommand.Array, ref receive, ref errno))
                {
                    // 计算应答报文中应有的数据字节计数
                    int byteLength = coilsCount % 8 == 0 ? coilsCount / 8 : coilsCount / 8 + 1;

                    // 第③步：校验应答报文
                    if ((receive.Length == 9 + byteLength) && ((receive[4] << 8) + receive[5] == 3 + byteLength)
                         && receive[6] == SlaveID && receive[7] == 0x02 && receive[8] == byteLength)
                    {
                        // 第④步：解析应答报文
                        byte[] result = new byte[byteLength];
                        // 提取应答报文中的实际数据部分
                        Array.Copy(receive, 9, result, 0, byteLength);
                        // 返回应答报文中的实际数据部分
                        return result;
                    }
                    // 应答报文校验不通过，错误码置-4
                    errno = -4;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return null;
        }
        #endregion

        #region 功能码03H：读取输出寄存器
        /// <summary>
        /// 读取输出寄存器方法（对应功能码03H）
        /// </summary>
        /// <param name="startAddress">要读取的起始寄存器地址</param>
        /// <param name="registersCount">要读取的寄存器数量</param>
        /// <param name="errno">错误码（ref）</param>
        /// <returns>读取成功则以字节数组形式返回应答报文中的实际数据部分，读取失败则返回null。可通过异常信息和错误码查看失败原因，
        /// 错误码为-2表示获取对端应答报文超时，-3表示参数校验不通过，-4表示应答报文校验不通过。</returns>
        /// <exception cref="Exception">发送和接收报文时可能抛出异常，捕获后重抛出</exception>
        public byte[] ReadOutputRegisters(ushort startAddress, ushort registersCount, ref short errno)
        {
            // 第①步：拼接ModbusTCP报文
            ByteArray SendCommand = new ByteArray();
            // 发送报文格式：
            // 事务处理标识符 + 协议标识符 + 长度 + 单元标识符 + 功能码 + 起始寄存器地址 + 要读取的寄存器个数
            //（其中的“长度”是“长度”之后的部分的长度）
            SendCommand.Add(0x00, 0x00, 0x00, 0x00);     // 事务处理标识符 + 协议标识符
            SendCommand.Add(0x00, 0x06, SlaveID, 0x03);  // 长度（2个字节） + 单元标识符 + 功能码
            SendCommand.Add(startAddress);               // 起始寄存器地址
            SendCommand.Add(registersCount);             // 要读取的寄存器个数

            // 第②步：发送报文并接收应答报文
            byte[] receive = null;
            try
            {
                if (SendAndReceive(SendCommand.Array, ref receive, ref errno))
                {
                    // 计算应答报文中应有的数据字节计数
                    int byteLength = 2 * registersCount;

                    // 第③步：校验应答报文
                    if ((receive.Length == 9 + byteLength) && ((receive[4] << 8) + receive[5] == 3 + byteLength)
                         && receive[6] == SlaveID && receive[7] == 0x03 && receive[8] == byteLength)
                    {
                        // 第④步：解析应答报文
                        byte[] result = new byte[byteLength];
                        // 提取应答报文中的实际数据部分
                        Array.Copy(receive, 9, result, 0, byteLength);
                        // 返回应答报文中的实际数据部分
                        return result;
                    }
                    // 应答报文校验不通过，错误码置-4
                    errno = -4;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return null;
        }
        #endregion

        #region 功能码04H：读取输入寄存器
        /// <summary>
        /// 读取输入寄存器方法（对应功能码04H）
        /// </summary>
        /// <param name="startAddress">要读取的起始寄存器地址</param>
        /// <param name="registersCount">要读取的寄存器数量</param>
        /// <param name="errno">错误码（ref）</param>
        /// <returns>读取成功则以字节数组形式返回应答报文中的实际数据部分，读取失败则返回null。可通过异常信息和错误码查看失败原因，
        /// 错误码为-2表示获取对端应答报文超时，-3表示参数校验不通过，-4表示应答报文校验不通过。</returns>
        /// <exception cref="Exception">发送和接收报文时可能抛出异常，捕获后重抛出</exception>
        public byte[] ReadInputRegisters(ushort startAddress, ushort registersCount, ref short errno)
        {
            // 第①步：拼接ModbusTCP报文
            ByteArray SendCommand = new ByteArray();
            // 发送报文格式：
            // 事务处理标识符 + 协议标识符 + 长度 + 单元标识符 + 功能码 + 起始寄存器地址 + 要读取的寄存器个数
            //（其中的“长度”是“长度”之后的部分的长度）
            SendCommand.Add(0x00, 0x00, 0x00, 0x00);     // 事务处理标识符 + 协议标识符
            SendCommand.Add(0x00, 0x06, SlaveID, 0x04);  // 长度（2个字节） + 单元标识符 + 功能码
            SendCommand.Add(startAddress);               // 起始寄存器地址
            SendCommand.Add(registersCount);             // 要读取的寄存器个数

            // 第②步：发送报文并接收应答报文
            byte[] receive = null;
            try
            {
                if (SendAndReceive(SendCommand.Array, ref receive, ref errno))
                {
                    // 计算应答报文中应有的数据字节计数
                    int byteLength = 2 * registersCount;

                    // 第③步：校验应答报文
                    if ((receive.Length == 9 + byteLength) && ((receive[4] << 8) + receive[5] == 3 + byteLength)
                         && receive[6] == SlaveID && receive[7] == 0x04 && receive[8] == byteLength)
                    {
                        // 第④步：解析应答报文
                        byte[] result = new byte[byteLength];
                        // 提取应答报文中的实际数据部分
                        Array.Copy(receive, 9, result, 0, byteLength);
                        // 返回应答报文中的实际数据部分
                        return result;
                    }
                    // 应答报文校验不通过，错误码置-4
                    errno = -4;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return null;
        }
        #endregion

        #region 功能码05H：预置单线圈
        /// <summary>
        /// 预置单线圈方法（对应功能码05H）
        /// </summary>
        /// <param name="address">要置值的线圈的地址</param>
        /// <param name="value">要置的值</param>
        /// <param name="errno">错误码（ref）</param>
        /// <returns>设置成功则返回true，否则返回false。可通过异常信息和错误码查看失败原因，
        /// 错误码为-2表示获取对端应答报文超时，-3表示参数校验不通过，-4表示应答报文校验不通过。</returns>
        /// <exception cref="Exception">发送和接收报文时可能抛出异常，捕获后重抛出</exception>
        public bool PreSetSingleCoil(ushort address, bool value, ref short errno)
        {
            // 第①步：拼接报文
            ByteArray SendCommand = new ByteArray();
            // 发送报文格式：
            // 事务处理标识符 + 协议标识符 + 长度 + 单元标识符 + 功能码 + 线圈地址 + 线圈值
            SendCommand.Add(0x00, 0x00, 0x00, 0x00);    // 事务处理标识符 + 协议标识符
            SendCommand.Add(0x00, 0x06, SlaveID, 0x05); // 长度 + 单元标识符 + 功能码
            SendCommand.Add(address);                   // 线圈地址
            // 预置单线圈中，置位（true）则报文中传递的要更新的值为0xFF00，复位（false）则报文中传递的要更新的值为0x0000.
            SendCommand.Add(value ? (byte)0xFF : (byte)0x00, 0x00);

            // 第②步：发送报文并接收应答报文
            byte[] receive = null;
            try
            {
                if (SendAndReceive(SendCommand.Array, ref receive, ref errno))
                {
                    // 第③步：校验应答报文
                    if (ByteArrayEquals(SendCommand.Array, receive))
                    {
                        return true;
                    }
                    // 应答报文校验不通过，错误码置-4
                    errno = -4;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return false;
        }
        #endregion

        #region 功能码06H：预置单寄存器
        /// <summary>
        /// 预置单寄存器方法（对应功能码06H）
        /// </summary>
        /// <param name="address">要置值的寄存器的地址</param>
        /// <param name="value">要置的值</param>
        /// <param name="errno">错误码（ref）</param>
        /// <returns>设置成功则返回true，否则返回false。可通过异常信息和错误码查看失败原因，
        /// 错误码为-2表示获取对端应答报文超时，-3表示参数校验不通过，-4表示应答报文校验不通过。</returns>
        /// <exception cref="Exception">发送和接收报文时可能抛出异常，捕获后重抛出</exception>
        public bool PreSetSingleRegister(ushort address, byte[] value, ref short errno)
        {
            // 第①步：拼接报文
            ByteArray SendCommand = new ByteArray();
            // 发送报文格式：
            // 事务处理标识符 + 协议标识符 + 长度 + 单元标识符 + 功能码 + 寄存器地址 + 寄存器值
            SendCommand.Add(0x00, 0x00, 0x00, 0x00);    // 事务处理标识符 + 协议标识符
            SendCommand.Add(0x00, 0x06, SlaveID, 0x06); // 长度 + 单元标识符 + 功能码
            SendCommand.Add(address);                   // 寄存器地址
            SendCommand.Add(value);                     // 值

            // 第②步：发送报文并接收应答报文
            byte[] receive = null;
            try
            {
                if (SendAndReceive(SendCommand.Array, ref receive, ref errno))
                {
                    // 第③步：校验应答报文
                    if (ByteArrayEquals(SendCommand.Array, receive))
                    {
                        return true;
                    }
                    // 应答报文校验不通过，错误码置-4
                    errno = -4;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return false;
        }

        /// <summary>
        /// 预置单寄存器方法（对应功能码06H）
        /// </summary>
        /// <param name="address">要置值的寄存器的地址</param>
        /// <param name="value">要置的值</param>
        /// <param name="errno">错误码（ref）</param>
        /// <returns>设置成功则返回true，否则返回false。可通过异常信息和错误码查看失败原因，
        /// 错误码为-2表示获取对端应答报文超时，-3表示参数校验不通过，-4表示应答报文校验不通过。</returns>
        /// <exception cref="Exception">发送和接收报文时可能抛出异常，捕获后重抛出</exception>
        public bool PreSetSingleRegister(ushort address, ushort value, ref short errno)
        {
            try
            {
                return PreSetSingleRegister(address, BitConverter.GetBytes(value).Reverse().ToArray(), ref errno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 预置单寄存器方法（对应功能码06H）
        /// </summary>
        /// <param name="address">要置值的寄存器的地址</param>
        /// <param name="value">要置的值</param>
        /// <param name="errno">错误码（ref）</param>
        /// <returns>设置成功则返回true，否则返回false。可通过异常信息和错误码查看失败原因，
        /// 错误码为-2表示获取对端应答报文超时，-3表示参数校验不通过，-4表示应答报文校验不通过。</returns>
        /// <exception cref="Exception">发送和接收报文时可能抛出异常，捕获后重抛出</exception>
        public bool PreSetSingleRegister(ushort address, short value, ref short errno)
        {
            try
            {
                return PreSetSingleRegister(address, BitConverter.GetBytes(value).Reverse().ToArray(), ref errno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region 功能码0FH：预置多线圈
        /// <summary>
        /// 预置多线圈方法（对应功能码0FH）
        /// </summary>
        /// <param name="startAddress">要置值的线圈的起始地址</param>
        /// <param name="values">要置的值（bool数组）</param>
        /// <param name="errno">错误码（ref）</param>
        /// <returns>设置成功则返回true，否则返回false。可通过异常信息和错误码查看失败原因，
        /// 错误码为-2表示获取对端应答报文超时，-3表示参数校验不通过，-4表示应答报文校验不通过。</returns>
        /// <exception cref="Exception">发送和接收报文时可能抛出异常，捕获后重抛出</exception>
        public bool PerSetMultiCoils(ushort startAddress, bool[] values, ref short errno)
        {
            if (values == null || values.Length <= 0)
            {
                errno = -3;
                return false;
            }

            // 依据传入的bool数组，转换成对应的字节数组
            byte[] setArray = GetByteArrayFromBoolArray(values);

            // 第①步：拼接发送报文
            ByteArray SendCommand = new ByteArray();
            // 发送报文格式：
            // 事务处理标识符 + 协议标识符 + 长度 + 单元标识符 + 功能码 + 起始线圈地址 + 线圈数量 + 字节计数 + 字节数据
            SendCommand.Add(0x00, 0x00, 0x00, 0x00);        // 事务处理标识符 + 协议标识符
            SendCommand.Add((ushort)(7 + setArray.Length)); // 长度
            SendCommand.Add(SlaveID, 0x0F);                 // 单元标识符 + 功能码
            SendCommand.Add(startAddress);                  // 起始线圈地址
            SendCommand.Add((ushort)values.Length);         // 线圈数量
            SendCommand.Add((byte)setArray.Length);         // 字节计数
            SendCommand.Add(setArray);                      // 字节数据

            // 第②步：发送报文并接收应答报文
            byte[] receive = null;
            try
            {
                if (SendAndReceive(SendCommand.Array, ref receive, ref errno))
                {
                    // 第③步：校验应答报文
                    byte[] send = new byte[12];
                    Array.Copy(SendCommand.Array, 0, send, 0, 12);
                    send[4] = 0x00;
                    send[5] = 0x06;
                    if (ByteArrayEquals(send, receive))
                    {
                        return true;
                    }
                    // 应答报文校验不通过，错误码置-4
                    errno = -4;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return false;
        }
        #endregion

        #region 功能码10H：预置多寄存器
        /// <summary>
        /// 预置多寄存器方法（对应功能码10H；需要注意传入的字节数组的元素个数的奇偶性）
        /// </summary>
        /// <param name="startAddress">要置值的寄存器的起始地址</param>
        /// <param name="values">要置的值（byte数组；若values字节数组的元素个数为奇数，则默认在拼接报文时末尾添0x00。）</param>
        /// <param name="errno">错误码（ref）</param>
        /// <returns>设置成功则返回true，否则返回false。可通过异常信息和错误码查看失败原因，
        /// 错误码为-2表示获取对端应答报文超时，-3表示参数校验不通过，-4表示应答报文校验不通过。</returns>
        /// <exception cref="Exception">发送和接收报文时可能抛出异常，捕获后重抛出</exception>
        public bool PerSetMultiRegisters(ushort startAddress, byte[] values, ref short errno)
        {
            if (values == null || values.Length <= 0)
            {
                errno = -3;
                return false;
            }

            // 要置值的寄存器的数量
            int registersCount = values.Length % 2 == 0 ? values.Length / 2 : values.Length / 2 + 1;

            byte[] _values = null;
            if (values.Length % 2 == 1)
            {
                // 若values字节数组的元素个数为奇数，则默认在末尾添0x00。
                _values = new byte[values.Length + 1];
                Array.Copy(values, 0, _values, 0, values.Length - 1);
                _values[values.Length - 1] = values[values.Length - 1];
                _values[values.Length] = 0x00;
            }
            else
            {
                _values = values;
            }

            // 第①步：拼接发送报文
            ByteArray SendCommand = new ByteArray();
            // 发送报文格式：
            // 事务处理标识符 + 协议标识符 + 长度 + 单元标识符 + 功能码 + 起始寄存器地址 + 寄存器数量 + 字节计数 + 字节数据
            SendCommand.Add(0x00, 0x00, 0x00, 0x00);        // 事务处理标识符 + 协议标识符
            SendCommand.Add((ushort)(7 + _values.Length));  // 长度
            SendCommand.Add(SlaveID, 0x10);                 // 单元标识符 + 功能码
            SendCommand.Add(startAddress);                  // 起始寄存器地址
            SendCommand.Add((ushort)registersCount);        // 寄存器数量
            SendCommand.Add((byte)_values.Length);          // 字节计数
            SendCommand.Add(_values);                       // 字节数据

            // 第②步：发送报文并接收应答报文
            byte[] receive = null;
            try
            {
                if (SendAndReceive(SendCommand.Array, ref receive, ref errno))
                {
                    // 第③步：校验应答报文
                    byte[] send = new byte[12];
                    Array.Copy(SendCommand.Array, 0, send, 0, 12);
                    send[4] = 0x00;
                    send[5] = 0x06;
                    if (ByteArrayEquals(send, receive))
                    {
                        return true;
                    }
                    // 应答报文校验不通过，错误码置-4
                    errno = -4;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return false;
        }
        #endregion
    }
}
