using MiniExcelLibs;
using Wang.MTHHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thinger.DataConvertLib;
using Wang.ModbusTCPLib;
using Wang.MTHModels;

namespace Wang.MTHProject
{
    /// <summary>
    /// 项目通用静态属性或对象
    /// </summary>
    public class CommonMethods
    {
        /// <summary>
        /// 当前登录用户的信息
        /// </summary>
        public static SysAdmin CurrentAdmin { get; set; }

        // 一个静态设备对象
        public static Device Device { get; set; }

        // 静态系统委托对象，用于不同窗口向Monitor窗口的系统日志ListView中添加日志
        public static Action<int, string> AddLog;    // Action系统委托是无返回值的

        /// <summary>
        /// 在CommonMethods中确定大小端。这个dataFormat表示，实际数据在字节数组（Modbus报文）中是以怎样的形式存储的，故默认为ABCD。
        /// </summary>
        public static DataFormat dataFormat = DataFormat.ABCD;

        #region 加载通信组信息及设备信息
        /// <summary>
        /// 加载设备信息
        /// </summary>
        /// <param name="devicePath"></param>
        /// <param name="groupPath"></param>
        /// <param name="variablePath"></param>
        /// <returns></returns>
        public static Device LoadDevice(string devicePath, string groupPath, string variablePath)
        {
            // 判断文件是否存在
            if (!File.Exists(devicePath))
            {
                CommonMethods.AddLog(1, "设备通信配置文件不存在");
                return null;
            }
            // 要先加载通信组信息
            List<Group> gpList = LoadGroup(groupPath, variablePath);
            // 只有设备配置文件、通信组Excel文件和变量Excel文件三者均存在且有有效合法内容，才能成功创建Device对象并返回。
            if (gpList != null && gpList.Count > 0)
            {
                try
                {
                    return new Device()
                    {
                        IPAddress = IniConfigHelper.ReadIniData("设备参数", "IP地址", "127.0.0.1", devicePath),
                        Port = Convert.ToInt32(IniConfigHelper.ReadIniData("设备参数", "端口号", "502", devicePath)),
                        CurrentRecipeName = IniConfigHelper.ReadIniData("配方参数", "当前配方", "", devicePath),
                        GroupList = gpList
                    };
                }
                catch (Exception ex)
                {
                    // 日志写入
                    CommonMethods.AddLog(2, "加载设备信息失败！原因：" + ex.Message);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 加载通信组信息（将属于该通信组的通信变量组成一个集合赋给相应组的变量集合成员），并返回通信组集合。
        /// </summary>
        /// <param name="groupPath"></param>
        /// <param name="variablePath"></param>
        /// <returns></returns>
        private static List<Group> LoadGroup(string groupPath, string variablePath)
        {
            // 判断文件是否存在
            if (!File.Exists(groupPath))
            {
                CommonMethods.AddLog(1, "通信组文件不存在");
                return null;
            }
            if (!File.Exists(variablePath))
            {
                CommonMethods.AddLog(1, "通信变量文件不存在");
                return null;
            }

            // 解析通信组Excel文件和变量Excel文件
            List<Group> GpList = null;
            try
            {
                GpList = MiniExcel.Query<Group>(groupPath).ToList();
            }
            catch (Exception ex)
            {
                CommonMethods.AddLog(1, "通信组加载失败：" + ex.Message);
                return null;
            }
            List<Variable> VarList = null;
            try
            {
                VarList = MiniExcel.Query<Variable>(variablePath).ToList();
            }
            catch (Exception ex)
            {
                CommonMethods.AddLog(1, "通信变量加载失败：" + ex.Message);
                return null;
            }

            // 开始分类，为每一个通信组的变量集合成员赋值
            if (GpList != null && VarList != null)
            {
                foreach (Group group in GpList)
                {
                    group.VariableList = VarList.FindAll(c => c.GroupName == group.GroupName).ToList();
                }
                return GpList;
            }
            else
            {
                return null;
            }
        }
        #endregion

        /// <summary>
        /// ModbusTCP通信对象
        /// </summary>
        public static ModbusTCP Modbus {  get; set; }

        /// <summary>
        /// 通过变量名称找对应的Variable对象
        /// </summary>
        /// <param name="varName"></param>
        /// <returns></returns>
        private static Variable FindVariable(string varName, ref ushort groupStartAddress)
        {
            foreach (Group item in Device.GroupList)
            {
                var res = item.VariableList.Find(c => c.VarName == varName);
                if (res != null)
                {
                    groupStartAddress = item.StartAddress;
                    return res;
                }
            }
            return null;
        }

        /// <summary>
        /// 通用变量写入方法
        /// </summary>
        /// <param name="varName">要写入的变量的名称</param>
        /// <param name="varValue">要写入的值</param>
        /// <param name="errno">错误码</param>
        /// <returns>false表示写入失败，否则成功。抛出异常表示写入失败。</returns>
        /// <exception cref="Exception"></exception>
        public static bool CommonWrite(string varName, string varValue, ref short errno)
        {
            ushort groupStartAddress = 0;    // 变量所在组的起始硬件地址
            // 第一步：先找到变量对象以及变量所在组的起始地址
            Variable variable = FindVariable(varName, ref groupStartAddress);
            if (variable == null) return false;

            // 第二步：获取变量类型
            DataType dataType = (DataType)Enum.Parse(typeof(DataType), variable.DataType, true);

            // 第三步：获取要进行写入的数据（先进行线性转换）
            var result = MigrationLib.SetMigrationValue(varValue, dataType, variable.Scale.ToString(), variable.Offset.ToString());
            if(!result.IsSuccess) return false;

            // 第四步：写入数据
            try
            {
                switch (dataType)
                {
                    case DataType.Bool:
                        // 这里是线圈情况。对于线圈地址，每一个线圈就有一个地址，相邻线圈的地址值差1。
                        return Modbus.PreSetSingleCoil((ushort)(groupStartAddress + 8 * variable.Start + variable.OffsetOrLength),
                                                       Convert.ToBoolean(result.Content), ref errno);
                    case DataType.Short:
                        return Modbus.PreSetSingleRegister((ushort)(groupStartAddress + variable.Start), Convert.ToInt16(result.Content), ref errno);
                    case DataType.UShort:
                        return Modbus.PreSetSingleRegister((ushort)(groupStartAddress + variable.Start), Convert.ToUInt16(result.Content), ref errno);
                    case DataType.Int:
                        return Modbus.PerSetMultiRegisters((ushort)(groupStartAddress + variable.Start),
                                                            ByteArrayLib.GetByteArrayFromInt(Convert.ToInt32(result.Content), dataFormat), ref errno);
                    case DataType.UInt:
                        return Modbus.PerSetMultiRegisters((ushort)(groupStartAddress + variable.Start),
                                                            ByteArrayLib.GetByteArrayFromUInt(Convert.ToUInt32(result.Content), dataFormat), ref errno);
                    case DataType.Float:
                        return Modbus.PerSetMultiRegisters((ushort)(groupStartAddress + variable.Start),
                                                            ByteArrayLib.GetByteArrayFromFloat(Convert.ToSingle(result.Content), dataFormat), ref errno);
                    case DataType.Double:
                        return Modbus.PerSetMultiRegisters((ushort)(groupStartAddress + variable.Start),
                                                            ByteArrayLib.GetByteArrayFromDouble(Convert.ToDouble(result.Content), dataFormat), ref errno);
                    case DataType.Long:
                        return Modbus.PerSetMultiRegisters((ushort)(groupStartAddress + variable.Start),
                                                            ByteArrayLib.GetByteArrayFromLong(Convert.ToInt64(result.Content), dataFormat), ref errno);
                    case DataType.ULong:
                        return Modbus.PerSetMultiRegisters((ushort)(groupStartAddress + variable.Start),
                                                            ByteArrayLib.GetByteArrayFromULong(Convert.ToUInt64(result.Content), dataFormat), ref errno);
                    case DataType.String:
                        return Modbus.PerSetMultiRegisters((ushort)(groupStartAddress + variable.Start),
                                                            ByteArrayLib.GetByteArrayFromString(result.Content, Encoding.ASCII), ref errno);
                    case DataType.ByteArray:
                        return Modbus.PerSetMultiRegisters((ushort)(groupStartAddress + variable.Start),
                                                            ByteArrayLib.GetByteArrayFromHexString(result.Content), ref errno);
                    case DataType.HexString:
                        return Modbus.PerSetMultiRegisters((ushort)(groupStartAddress + variable.Start),
                                                            ByteArrayLib.GetByteArrayFromHexString(result.Content), ref errno);
                    default:
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
