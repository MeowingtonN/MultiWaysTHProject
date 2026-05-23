using MiniExcelLibs;
using Wang.MTHHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.DataConvertLib;
using Wang.ModbusTCPLib;
using Wang.MTHBLL;
using Wang.MTHControlLib;
using Wang.MTHModels;
using System.Timers;

namespace Wang.MTHProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            naviButtons.Add(this.navi_Monitor);
            naviButtons.Add(this.navi_ParamSet);
            naviButtons.Add(this.navi_Recipe);
            naviButtons.Add(this.navi_HistoryLog);
            naviButtons.Add(this.navi_HistoryTrend);
            naviButtons.Add(this.navi_UserManage);

            actualAlarmList.CollectionChanged += ActualAlarmList_CollectionChanged;

            storeActualDataTimer.Interval = 1000;
            storeActualDataTimer.AutoReset = true;
            storeActualDataTimer.Elapsed += StoreActualDataTimer_Elapsed;
            storeActualDataTimer.Start();

            // Load事件，在第一次显示窗体前发生。
            this.Load += MainForm_Load;

            this.FormClosing += MainForm_FormClosing;
        }

        /// <summary>
        /// 关闭窗体前触发执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = new FrmMsgBoxWithAck("是否确认要退出系统？", "退出系统").ShowDialog();
            if(dialogResult == DialogResult.OK)
            {
                storeActualDataTimer.Stop();
                CommonMethods.Modbus?.DisConnect();
                cts?.Cancel();
            }
            else
            {
                // 取消主窗体退出事件
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 主窗体退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 定时器达到定时间隔时，触发执行该方法，写入数据到实时数据表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StoreActualDataTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // 更新当前时间和通信状态显示，注意跨线程访问。
            this.Invoke(new Action(() =>
            {
                this.lbl_CurrentTime.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToString("HH:mm:ss");
                if(CommonMethods.Device != null)
                    this.led_Conn.Value = CommonMethods.Device.IsConnected;
            }));

            if(CommonMethods.Device != null && CommonMethods.Device.IsConnected)
            {
                // 判断
                bool result = CommonMethods.Device["模块1温度"] != null;
                result &= CommonMethods.Device["模块1湿度"] != null;
                result &= CommonMethods.Device["模块2温度"] != null;
                result &= CommonMethods.Device["模块2湿度"] != null;
                result &= CommonMethods.Device["模块3温度"] != null;
                result &= CommonMethods.Device["模块3湿度"] != null;
                result &= CommonMethods.Device["模块4温度"] != null;
                result &= CommonMethods.Device["模块4湿度"] != null;
                result &= CommonMethods.Device["模块5温度"] != null;
                result &= CommonMethods.Device["模块5湿度"] != null;
                result &= CommonMethods.Device["模块6温度"] != null;
                result &= CommonMethods.Device["模块6湿度"] != null;

                if(result)
                {
                    try
                    {
                        bool res = actualDataManage.AddActualData(new ActualData()
                        {
                            InsertTime = CurrentTime,
                            Station1Temp = CommonMethods.Device["模块1温度"].ToString(),
                            Station1Humidity = CommonMethods.Device["模块1湿度"].ToString(),
                            Station2Temp = CommonMethods.Device["模块2温度"].ToString(),
                            Station2Humidity = CommonMethods.Device["模块2湿度"].ToString(),
                            Station3Temp = CommonMethods.Device["模块3温度"].ToString(),
                            Station3Humidity = CommonMethods.Device["模块3湿度"].ToString(),
                            Station4Temp = CommonMethods.Device["模块4温度"].ToString(),
                            Station4Humidity = CommonMethods.Device["模块4湿度"].ToString(),
                            Station5Temp = CommonMethods.Device["模块5温度"].ToString(),
                            Station5Humidity = CommonMethods.Device["模块5湿度"].ToString(),
                            Station6Temp = CommonMethods.Device["模块6温度"].ToString(),
                            Station6Humidity = CommonMethods.Device["模块6湿度"].ToString()
                        });
                        if (!res)
                        {
                            CommonMethods.AddLog(2, "向实时数据表插入数据时失败！");
                        }
                    }
                    catch (Exception ex)
                    {
                        CommonMethods.AddLog(2, "向实时数据表插入数据时失败！原因：" + ex.Message);
                    }
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 更新用户名称显示
            this.lbl_CurrentAdmin.Text = CommonMethods.CurrentAdmin.LoginName;

            // 打开集中监控窗体
            CommonNaviBtn_Click(this.navi_Monitor, null);

            // 在显示主窗体前就读取INI文件和Excel文件以加载变量信息、通信组信息和设备信息
            CommonMethods.Device = CommonMethods.LoadDevice(m_devPath, m_groupPath, m_variablePath);

            if(CommonMethods.Device != null)
            {
                // 调用CommonMethods中的AddLog委托，它已绑定到具体方法
                CommonMethods.AddLog(0, "登录成功，设备信息加载成功");

                cts = new CancellationTokenSource();

                // 处理报警触发/消除事件。在子线程解析变量并更新时会在处理到启用上升沿或下降沿报警的变量
                // 并在检测到触发或消除报警时调用Device_AlarmTrigEvent方法（AlarmTrigEvent?.Invoke）。
                CommonMethods.Device.AlarmTrigEvent += Device_AlarmTrigEvent;

                // 启用线程执行读取【所有】有关的PLC寄存器数据任务，并解析变量，存储在设备变量键值对中。
                Task.Run(new Action(() =>
                {
                    DeviceCommunication();
                }), cts.Token);
            }
            else
            {
                CommonMethods.AddLog(2, "设备信息加载失败，请先配置相关文件后【重启】软件使用！");
            }
        }

        /// <summary>
        /// actualAlarmList的CollectionChanged事件处理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActualAlarmList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // 注意跨线程访问控件，将委托投递给UI线程执行。
            this.Invoke(new Action(() =>
            {
                // 根据actualAlarmList集合中元素的数量进行处理
                switch (actualAlarmList.Count)
                {
                    case 0:
                        this.scrollingAlarm.Text = "当前系统无报警";
                        break;
                    default:
                        // 连接actualAlarmList各元素的内容，并以"   "为间隔组成一个字符串。
                        this.scrollingAlarm.Text = string.Join("   ", actualAlarmList);
                        break;
                }
            }));
        }

        /// <summary>
        /// 处理报警触发/消除事件，在读取线程中调用UpdateVariable方法时可触发执行。
        /// </summary>
        /// <param name="ackType"></param>
        /// <param name="variable"></param>
        private void Device_AlarmTrigEvent(bool ackType, Variable variable)
        {
            // ackType为true表示报警触发
            if(ackType)
            {
                CommonMethods.AddLog(1, variable.Remark + " 触发。");

                try
                {
                    // 存储报警触发信息到日志数据表
                    sysLogManage.AddSysLog(new SysLog()
                    {
                        InsertTime = CurrentTime,
                        Note = variable.Remark,
                        AlarmType = "触发",
                        Operator = CommonMethods.CurrentAdmin.LoginName,
                        VarName = variable.VarName
                    });
                }
                catch (Exception ex)
                {
                    CommonMethods.AddLog(2, "存储报警触发信息到日志数据表失败，原因：" + ex.Message);
                }
                
                if (!this.actualAlarmList.Contains(variable.Remark))
                {
                    this.actualAlarmList.Add(variable.Remark);    // 会触发actualAlarmList的CollectionChanged事件。
                }
            }
            // ackType为false表示报警消除
            else
            {
                CommonMethods.AddLog(0, variable.Remark + " 消除。");
                try
                {
                    // 存储报警消除信息到日志数据表
                    sysLogManage.AddSysLog(new SysLog()
                    {
                        InsertTime = CurrentTime,
                        Note = variable.Remark,
                        AlarmType = "消除",
                        Operator = CommonMethods.CurrentAdmin.LoginName,
                        VarName = variable.VarName
                    });
                }
                catch (Exception ex)
                {
                    CommonMethods.AddLog(2, "存储报警消除信息到日志数据表失败，原因：" + ex.Message);
                }
                
                if (this.actualAlarmList.Contains(variable.Remark))
                {
                    this.actualAlarmList.Remove(variable.Remark); // 会触发actualAlarmList的CollectionChanged事件。
                }
            }
        }

        /// <summary>
        /// 设备执行的实际任务（子线程实际执行的任务）。
        /// （不将CommonMethods.Device作为入参传入。因为FrmParamSet界面修改IP地址或端口号后会new一个新的Device对象赋给CommonMethods.Device，
        ///  若使用函数入参引用，则此时仍然引用到旧的Device对象，故此时该方法读取的关于Device对象的成员均为旧值且与CommonMethods.Device独立。）
        /// </summary>
        private void DeviceCommunication()
        {
            if(CommonMethods.Device == null) return;

            while (!cts.IsCancellationRequested)    // cts未置取消则循环执行
            {
                // 线程循环检测设备是否处于连接状态（IsConnected是否置为true），若不处于连接状态则尝试去连接。
                if (CommonMethods.Device.IsConnected)
                {
                    // 通信读取。遍历设备的所有组。
                    foreach (Group gp in CommonMethods.Device.GroupList)
                    {
                        byte[] data = null;    // 存储Modbus报文中的数据部分
                        int reqLength = 0;
                        short errno = 0;

                        if(gp.StoreArea == "输入线圈" || gp.StoreArea == "输出线圈")
                        {
                            try
                            {
                                switch (gp.StoreArea)
                                {
                                    case "输入线圈":
                                        data = CommonMethods.Modbus.ReadInputCoils(gp.StartAddress, gp.Length, ref errno);
                                        reqLength = ShortLib.GetByteLengthFromBoolLength(gp.Length);
                                        break;
                                    case "输出线圈":
                                        data = CommonMethods.Modbus.ReadOutputCoils(gp.StartAddress, gp.Length, ref errno);
                                        reqLength = ShortLib.GetByteLengthFromBoolLength(gp.Length);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                // 数据获取失败，则重连
                                CommonMethods.Device.IsConnected = false;
                                CommonMethods.AddLog(1, "读取数据时发生异常，异常原因：" + ex.Message + "需要重连。正在重连中...");
                                break;
                            }
                            
                            if(data != null && data.Length == reqLength)
                            {
                                // 数据成功获取，则进行数据（变量）解析。
                                // 遍历组的所有变量并对应赋值更新。
                                foreach (Variable variable in gp.VariableList)
                                {
                                    DataType dataType = (DataType)Enum.Parse(typeof(DataType), variable.DataType, true);
                                    switch(dataType)
                                    {
                                        case DataType.Bool:
                                            // 更新对应变量
                                            variable.VarValue = BitLib.GetBitFromByteArray(data, variable.Start, variable.OffsetOrLength);
                                            break;
                                        default:
                                            break;
                                    }

                                    // 遍历组的所有变量，解析后，处理解析后的数据（更新设备的变量字典）
                                    CommonMethods.Device.UpdateVariable(variable);    // 在设备的变量字典中更新对应的变量键值对记录
                                }
                            }
                            else
                            {
                                // 数据获取失败，则重连
                                CommonMethods.Device.IsConnected = false;
                                CommonMethods.AddLog(1, "读取数据时发生异常，错误码：" + errno + "。需要重连。正在重连中...");
                                break;
                            }
                        }
                        else
                        {
                            try
                            {
                                switch (gp.StoreArea)
                                {
                                    case "输入寄存器":
                                        data = CommonMethods.Modbus.ReadInputRegisters(gp.StartAddress, gp.Length, ref errno);
                                        reqLength = gp.Length * 2;
                                        break;
                                    case "输出寄存器":
                                        data = CommonMethods.Modbus.ReadOutputRegisters(gp.StartAddress, gp.Length, ref errno);
                                        reqLength = gp.Length * 2;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                // 数据获取失败，则重连
                                CommonMethods.Device.IsConnected = false;
                                CommonMethods.AddLog(1, "读取数据时发生异常，异常原因：" + ex.Message + "需要重连。正在重连中...");
                                break;
                            }

                            if (data != null && data.Length == reqLength)
                            {
                                // 数据成功获取，则进行数据（变量）解析
                                foreach (Variable variable in gp.VariableList)
                                {
                                    DataType dataType = (DataType)Enum.Parse(typeof(DataType), variable.DataType, true);
                                    // variable.Start为组内变量起始字索引；一个寄存器有2个字节，故将其乘2，才得到组内变量起始字节地址，即字节数组索引。
                                    int start = variable.Start * 2;
                                    switch (dataType)
                                    {
                                        case DataType.Bool:
                                            // 这里处理在寄存器中存储布尔值的情况。
                                            // GetBitFrom2BytesArray方法入参中的大小端指的是单个寄存器（2个字节/1个字）内字节存储的大小端。
                                            variable.VarValue = BitLib.GetBitFrom2BytesArray(data, start, variable.OffsetOrLength, CommonMethods.dataFormat == DataFormat.BADC || CommonMethods.dataFormat == DataFormat.DCBA);
                                            break;
                                        case DataType.Byte:
                                            // 这里处理一个寄存器只存储一字节数据的情况。（常见地，一个寄存器的高字节存储在低地址处，即PLC寄存器按照大端序存储；Modbus报文承载寄存器数据时，也按照大端序传输。）
                                            variable.VarValue = ByteLib.GetByteFromByteArray(data, CommonMethods.dataFormat == DataFormat.BADC || CommonMethods.dataFormat == DataFormat.DCBA ? start : start + 1);
                                            break;
                                        case DataType.Short:
                                            // Modbus报文承载寄存器数据时是按照大端序的话，如果想要得到正确的short类型值（单寄存器值），需要传入的dataFormat应为ABCD或CDAB。
                                            variable.VarValue = ShortLib.GetShortFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.UShort:
                                            variable.VarValue = UShortLib.GetUShortFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.Int:
                                            variable.VarValue = IntLib.GetIntFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.UInt:
                                            variable.VarValue = UIntLib.GetUIntFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.Float:
                                            variable.VarValue = FloatLib.GetFloatFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.Double:
                                            variable.VarValue = DoubleLib.GetDoubleFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.Long:
                                            variable.VarValue = LongLib.GetLongFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.ULong:
                                            variable.VarValue = ULongLib.GetULongFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.String:
                                            variable.VarValue = StringLib.GetStringFromByteArrayByEncoding(data, start, variable.OffsetOrLength, Encoding.ASCII);
                                            break;
                                        case DataType.ByteArray:
                                            variable.VarValue = ByteArrayLib.GetByteArrayFromByteArray(data, start, variable.OffsetOrLength);
                                            break;
                                        case DataType.HexString:
                                            variable.VarValue = StringLib.GetHexStringFromByteArray(data, start, variable.OffsetOrLength);
                                            break;
                                        default:
                                            break;
                                    }

                                    // 处理解析后的数据（更新设备的变量字典）
                                    // 先做线性转换！
                                    variable.VarValue = MigrationLib.GetMigrationValue(variable.VarValue, variable.Scale.ToString(), variable.Offset.ToString()).Content;
                                    CommonMethods.Device.UpdateVariable(variable);
                                }
                            }
                            else
                            {
                                // 数据获取失败，则重连
                                CommonMethods.Device.IsConnected = false;
                                CommonMethods.AddLog(1, "读取数据时发生异常，错误码：" + errno + "。需要重连。正在重连中...");
                                break;
                            }
                        }
                    }
                }
                else
                {
                    // 非首次连接，需要延时
                    if (CommonMethods.Device.ReConnectSign)
                    {
                        CommonMethods.Modbus?.DisConnect();
                        Thread.Sleep(CommonMethods.Device.ReConnectTime);
                    }
                    // 通信连接
                    CommonMethods.Modbus = new ModbusTCP();
                    try
                    {
                        CommonMethods.Device.IsConnected = CommonMethods.Modbus.Connect(CommonMethods.Device.IPAddress, CommonMethods.Device.Port);
                    }
                    catch (Exception ex)
                    {
                        CommonMethods.Device.IsConnected = false;
                        CommonMethods.AddLog(2, "控制器尝试连接失败，原因：" + ex.Message);
                    }

                    if (CommonMethods.Device.ReConnectSign)
                    {
                        CommonMethods.AddLog(CommonMethods.Device.IsConnected ? 0 : 1, CommonMethods.Device.IsConnected ? "控制器重连成功！" : "控制器重连失败。");
                    }
                    else
                    {
                        // 一次尝试连接完成后，将重连标志位置为true。
                        CommonMethods.Device.ReConnectSign = true;
                        if (CommonMethods.Device.IsConnected)
                        {
                            CommonMethods.AddLog(0, "控制器连接成功！");
                        }
                    }
                }
            }
        }

        #region 通信参数配置文件路径、通信组文件路径、变量文件路径
        /// <summary>
        /// 通信参数配置文件路径、通信组文件路径、变量文件路径
        /// </summary>
        private readonly string m_devPath = Application.StartupPath + "\\Config\\Device.ini";
        private readonly string m_groupPath = Application.StartupPath + "\\Config\\Group.xlsx";
        private readonly string m_variablePath = Application.StartupPath + "\\Config\\Variable.xlsx";
        #endregion

        /// <summary>
        /// 取消线程源
        /// </summary>
        private CancellationTokenSource cts;

        /// <summary>
        /// 报警集合
        /// </summary>
        private readonly ObservableCollection<string> actualAlarmList = new ObservableCollection<string>();

        /// <summary>
        /// 日志数据表管理业务
        /// </summary>
        private readonly SysLogManage sysLogManage = new SysLogManage();

        /// <summary>
        /// 实时数据表管理业务
        /// </summary>
        private readonly ActualDataManage actualDataManage = new ActualDataManage();

        /// <summary>
        /// 用于定时更新显示时间、通信状态和存储实时数据到数据表
        /// </summary>
        private readonly System.Timers.Timer storeActualDataTimer = new System.Timers.Timer();

        /// <summary>
        /// 当前显示的窗体页面索引（集中监控、参数设置、配方管理、报警追溯、历史趋势、用户管理）
        /// </summary>
        private int CurrentNaviIndex = 0;

        /// <summary>
        /// 主窗体中所有的导航按钮
        /// </summary>
        private readonly List<NaviButton> naviButtons = new List<NaviButton>();

        /// <summary>
        /// 获取当前时间并统一指定字符串表示格式
        /// </summary>
        private string CurrentTime
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        /// <summary>
        /// 大小端问题/字节序问题。其中A、B、C、D各代表一个字节。
        /// 默认为ABCD，即大端序（自然顺序，高字节数据在低地址，先传输；高字也在低地址，先传输）；
        /// BADC，是单字反转（一个字内，高字节在高地址，低字节在低地址；但高字在低地址，先传输）；
        /// CDAB，是双字反转（一个字内，高字节在低地址，低字节在高地址；但高字在高地址，后传输）；
        /// DCBA，是小端序（低字节数据在低地址，先传输；高字也在高地址，后传输）。
        /// 这个dataFormat表示，实际数据在字节数组（Modbus报文）中是以怎样的形式存储的，故默认为ABCD。
        /// （但请注意，Modbus数据传输只保证了单个寄存器的“高字节在前”，没有保证多寄存器的“高字在前”。）
        /// </summary>
        //private DataFormat dataFormat = DataFormat.ABCD;

        /// <summary>
        /// 通用导航按钮Click事件处理方法（窗体切换方法）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommonNaviBtn_Click(object sender, EventArgs e)
        {
            if(sender is NaviButton navi)
            {
                // 如果navi.ContentName对应在FormNames内的枚举名存在（要提前设置NaviButton的ContentName属性与枚举名一致）
                if (Enum.IsDefined(typeof(FormNames), navi.ContentName))    // Enum.IsDefined
                {
                    // 获取导航按钮对应的窗体枚举值（Enum.Parse）
                    FormNames formName = (FormNames)Enum.Parse(typeof(FormNames), navi.ContentName, true);

                    // 用户权限处理
                    switch (formName)
                    {
                        case FormNames.参数设置:
                            if (!CommonMethods.CurrentAdmin.ParamSet)
                            {
                                new FrmMsgBoxWithoutAck("用户权限不足，请切换用户访问！","用户权限不足").ShowDialog();
                                return;
                            }
                            break;
                        case FormNames.配方管理:
                            if (!CommonMethods.CurrentAdmin.Recipe)
                            {
                                new FrmMsgBoxWithoutAck("用户权限不足，请切换用户访问！", "用户权限不足").ShowDialog();
                                return;
                            }
                            break;
                        case FormNames.报警追溯:
                            if (!CommonMethods.CurrentAdmin.HistoryLog)
                            {
                                new FrmMsgBoxWithoutAck("用户权限不足，请切换用户访问！", "用户权限不足").ShowDialog();
                                return;
                            }
                            break;
                        case FormNames.历史趋势:
                            if (!CommonMethods.CurrentAdmin.HistoryTrend)
                            {
                                new FrmMsgBoxWithoutAck("用户权限不足，请切换用户访问！", "用户权限不足").ShowDialog();
                                return;
                            }
                            break;
                        case FormNames.用户管理:
                            if (!CommonMethods.CurrentAdmin.UserManage)
                            {
                                new FrmMsgBoxWithoutAck("用户权限不足，请切换用户访问！", "用户权限不足").ShowDialog();
                                return;
                            }
                            break;
                        default:
                            break;
                    }

                    // 窗体切换
                    OpenForm(this.MainPanel, formName);

                    // 设置CurrentName
                    SetCurrentName(this.lbl_CurrentName, formName);

                    // 设置导航按钮选中样式
                    SetNaviButtonSelected(this.TopPanel, navi);
                }
            }
        }

        /// <summary>
        /// 通用打开窗体辅助方法
        /// </summary>
        /// <param name="mainPanel">容器控件（用作窗体的父控件）</param>
        /// <param name="formName">窗体枚举值</param>
        private void OpenForm(Panel mainPanel, FormNames formName)
        {
            int total = mainPanel.Controls.Count;
            // 统计关闭的窗体数
            int closeCount = 0;
            bool isFind = false;
            for(int i = 0; i < total; i++)
            {
                Control ct = mainPanel.Controls[i - closeCount];    // mainPanel.Controls
                // 在mainPanel容器中找Form类型的组件
                if (ct is Form frm)
                {
                    // 判断当前Form是不是我们需要操作的窗体（要提前设置Form的Text属性与枚举名一致）
                    if(frm.Text == formName.ToString())
                    {
                        frm.BringToFront();
                        isFind = true;
                        break;
                    }
                    // 如果当前Form不是我们需要操作的窗体，则判断是否为固定窗体，若不是则关闭该窗口（Close即销毁窗体，下一次打开需重新构造该窗体）
                    else if ((FormNames)Enum.Parse(typeof(FormNames), frm.Text, true) >= FormNames.临界窗体)
                    {
                        // 若mainPanel容器中没有想要打开的窗体，则会先关闭其它非固定窗体，后在下面构造相应窗体并显示。
                        frm.Close();
                        closeCount++;
                    }
                }
            }

            if (!isFind)
            {
                // isFind为false表示要打开的窗体是一个新的窗体，故先创建
                Form frm = null;
                switch (formName)
                {
                    case FormNames.集中监控:
                        frm = new FrmMonitor();
                        // 将CommonMethods中的AddLog委托绑定到FrmMonitor的成员方法AddLog。
                        CommonMethods.AddLog = ((FrmMonitor)frm).AddLog;
                        break;
                    case FormNames.参数设置:
                        frm = new FrmParamSet(m_devPath, m_groupPath, m_variablePath);
                        break;
                    case FormNames.配方管理:
                        frm = new FrmRecipe(m_devPath);
                        break;
                    case FormNames.报警追溯:
                        frm = new FrmAlarm();
                        break;
                    case FormNames.历史趋势:
                        frm = new FrmHistory();
                        break;
                    case FormNames.用户管理:
                        frm = new FrmUserManager();
                        break;
                    default:
                        break;
                }

                if (frm != null)
                {
                    // 设置为非顶层窗体
                    frm.TopLevel = false;
                    // 设置窗体无边框
                    frm.FormBorderStyle = FormBorderStyle.None;
                    // 设置控件停靠方式为填充
                    frm.Dock = DockStyle.Fill;
                    // 设置父容器（将frm添加到mainPanel的控件集合中）
                    frm.Parent = mainPanel;
                    // 设置置前显示
                    frm.BringToFront();
                    // 显示
                    frm.Show();
                }
            }
        }

        /// <summary>
        /// 设置CurrentName
        /// </summary>
        /// <param name="label">标签</param>
        /// <param name="formName">窗体枚举值</param>
        private void SetCurrentName(Label label, FormNames formName)
        {
            label.Text = formName.ToString();
        }

        /// <summary>
        /// 设置对应导航按钮选中样式
        /// </summary>
        /// <param name="topPanel">存放NaviButton的容器</param>
        /// <param name="naviButton">要设置为选中的导航按钮</param>
        private void SetNaviButtonSelected(Panel topPanel, NaviButton naviButton)
        {
            // 使用topPanel.Controls.OfType<NaviButton>()在容器topPanel中找类型为NaviButton的控件
            foreach (NaviButton item in topPanel.Controls.OfType<NaviButton>())
            {
                item.IsSelected = false;
            }

            naviButton.IsSelected = true;
        }

        #region 减少窗体加载过程中的闪烁
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        #endregion

        #region 自定义无边框窗体拖动（Drag）
        private Point mPoint;

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            // 拿到当前点击本窗体的位置
            mPoint = new Point(e.X, e.Y);
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // this.Location表示以屏幕坐标表示的该窗体左上角的点的坐标。
                // e.X - mPoint.X 和 e.Y - mPoint.Y 表示了鼠标左键按下后的位移。
                this.Location = new Point(this.Location.X + (e.X - mPoint.X), this.Location.Y + (e.Y - mPoint.Y));
            }
        }
        #endregion

        #region 左右切换显示页面
        private void btn_Left_Click(object sender, EventArgs e)
        {
            CurrentNaviIndex--;
            if (CurrentNaviIndex >= 0)
            {
                // 窗体切换
                CommonNaviBtn_Click(naviButtons[CurrentNaviIndex], null);
            }
            else
            {
                CurrentNaviIndex++;
            }
        }

        private void btn_Right_Click(object sender, EventArgs e)
        {
            CurrentNaviIndex++;
            if (CurrentNaviIndex < naviButtons.Count)
            {
                // 窗体切换
                CommonNaviBtn_Click(naviButtons[CurrentNaviIndex], null);
            }
            else
            {
                CurrentNaviIndex--;
            }
        }
        #endregion
    }
}
