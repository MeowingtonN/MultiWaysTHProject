using Wang.MTHHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wang.MTHControlLib;

namespace Wang.MTHProject
{
    public partial class FrmParamSet : Form
    {
        public FrmParamSet(string _devPath, string _groupPath, string _variablePath)
        {
            InitializeComponent();

            devPath = _devPath;
            groupPath = _groupPath;
            variablePath = _variablePath;

            InitParam();

            updateTimer.Interval = 500;
            updateTimer.Tick += UpdateTimer_Tick;
            this.FormClosing += (sender, e) =>
            {
                updateTimer.Stop();
            };

            updateTimer.Start();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            // 定时器定时从设备变量键值对获取限值和是否报警数据。
            GetLimitParam();
        }

        /// <summary>
        /// 读取限值数据和是否报警数据。
        /// 从Device的变量键值对中读取 温度/湿度的高限/低限数值 和 温度/湿度是否因不满足高限/低限而报警
        /// （若发生温度/湿度过高/过低而需要报警，设备会将相应位置位，软件只需读取设备的这个位即可）。
        /// </summary>
        private void GetLimitParam()
        {
            if (CommonMethods.Device != null && CommonMethods.Device.IsConnected)
            {
                foreach (TextSet item in this.PanelMain.Controls.OfType<TextSet>())
                {
                    // 获取BindVarName变量名称对应的变量值，并赋给控件的CurrentValue以显示数值。
                    if (item.BindVarName != null && item.BindVarName.ToString().Length > 0)
                    {
                        item.CurrentValue = CommonMethods.Device[item.BindVarName.ToString()]?.ToString();
                    }
                    // 获取AlarmVarName变量名称对应的变量值，并赋给控件的IsAlarm以让LED灯显示是否报警。
                    if (item.AlarmVarName != null && item.AlarmVarName.ToString().Length > 0)
                    {
                        // 读取指定变量的值以确定设备是否处于报警状态。（Device缓存的变量键值对中的数值也是从设备中读取过来的）
                        // 这里读取的数据更准确的含义是“当前温湿度是否超过限值”。
                        item.IsAlarm = CommonMethods.Device[item.AlarmVarName]?.ToString() == "True";
                    }
                }
            }
        }

        /// <summary>
        /// 获取是否启用温度/湿度报警数据，仅在窗体构造方法中调用一次。
        /// </summary>
        private void GetAlarmParam()
        {
            if(CommonMethods.Device != null && CommonMethods.Device.IsConnected)
            {
                foreach (CheckBoxEx item in this.PanelMain.Controls.OfType<CheckBoxEx>())
                {
                    if(item.Tag != null && item.Tag.ToString().Length > 0)
                    {
                        // 在这里修改多选框选中状态时，需先解绑多选框的CheckedChanged事件处理方法，防止错误的“当前配方”写入设备配置文件。
                        //（同时也避免了写入PLC寄存器带来的开销，窗体切换的开销减少，UI变化更自然。）
                        item.CheckedChanged -= Common_CheckedChanged;
                        // 在寄存器中存储的值是1表示启用报警，0表示不启用报警。
                        item.Checked = CommonMethods.Device[item.Tag.ToString()]?.ToString() == "1";
                        item.CheckedChanged += Common_CheckedChanged;
                    }
                }
            }
        }

        #region 相关配置文件的路径
        private readonly string devPath = string.Empty;
        private readonly string groupPath = string.Empty;
        private readonly string variablePath = string.Empty;
        #endregion

        /// <summary>
        /// 定时器
        /// </summary>
        private Timer updateTimer = new Timer();

        #region 通信配置
        /// <summary>
        /// 初始化显示的设备参数（CommonMethods.Device在显示主窗体前就通过INI文件创建了），并读取限值数据和是否报警数据以及是否启用报警数据。
        /// </summary>
        private void InitParam()
        {
            this.txt_IPAddress.Text = IniConfigHelper.ReadIniData("设备参数", "IP地址", "127.0.0.1", devPath);
            this.txt_Port.Text = IniConfigHelper.ReadIniData("设备参数", "端口号", "502", devPath);

            GetLimitParam();
            GetAlarmParam();
        }

        private void btn_GroupConfig_Click(object sender, EventArgs e)
        {
            new FrmGroupConfig(devPath, groupPath, variablePath).ShowDialog();
        }

        private void btn_VariableConfig_Click(object sender, EventArgs e)
        {
            new FrmVariableConfig(devPath, groupPath, variablePath).ShowDialog();
        }

        /// <summary>
        /// 将配置通信参数写入ini文件并更新全局Device记录的配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AckConfig_Click(object sender, EventArgs e)
        {
            try
            {
                bool result;
                // 将配置通信参数写入ini文件。若不存在ini文件，则会自动创建一个。
                result = IniConfigHelper.WriteIniData("设备参数", "IP地址", this.txt_IPAddress.Text.Trim(), devPath);
                result &= IniConfigHelper.WriteIniData("设备参数", "端口号", this.txt_Port.Text.Trim(), devPath);
                if (result)
                {
                    // 更新全局Device记录的配置
                    CommonMethods.Device = CommonMethods.LoadDevice(devPath, groupPath, variablePath);
                    if (CommonMethods.Device != null)
                    {
                        // 调用CommonMethods中的AddLog委托，它已绑定到具体方法
                        CommonMethods.AddLog(0, "设备信息加载成功。");

                        DialogResult dialogResult = new FrmMsgBoxWithAck("通信参数设置成功，已保存到：" + devPath + "。是否立即重连以生效配置？", "通信参数配置").ShowDialog();
                        if (dialogResult == DialogResult.OK)
                        {
                            // 重连以生效配置
                            CommonMethods.Device.ReConnectSign = true;
                            CommonMethods.Device.IsConnected = false;
                        }
                    }
                    else
                    {
                        CommonMethods.AddLog(2, "获取当前设备引用时是空引用，设备信息加载失败。");
                    }
                }
                else
                {
                    if (File.Exists(devPath))
                    {
                        File.Delete(devPath);
                    }
                    CommonMethods.AddLog(2, "设备通信参数设置失败。");
                    new FrmMsgBoxWithoutAck("通信参数设置失败！", "通信参数配置").ShowDialog();
                }
            }
            catch (Exception ex)
            {
                CommonMethods.AddLog(2, "配置设备通信参数时发生异常，信息如下：" + ex.Message);
                new FrmMsgBoxWithoutAck("配置设备通信参数时发生异常，信息如下：" + ex.Message, "通信参数配置").ShowDialog();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if(CommonMethods.Device == null)
            {
                return;
            }

            this.txt_IPAddress.Text = CommonMethods.Device.IPAddress;
            this.txt_Port.Text = CommonMethods.Device.Port.ToString();
        }

        #endregion

        /// <summary>
        /// TextSet控件双击事件处理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Common_ControlDoubleClick(object sender, EventArgs e)
        {
            if(sender is TextSet textSet)
            {
                if(textSet.BindVarName != null && textSet.BindVarName.ToString().Length > 0)
                {
                    string titleName = textSet.TitleName;
                    string bindVarName = textSet.BindVarName;
                    string currentValue = textSet.CurrentValue;

                    FrmParamModify frmParamModify = new FrmParamModify(titleName, bindVarName, currentValue, devPath);
                    frmParamModify.ShowDialog();
                }
            }
        }

        /// <summary>
        /// 温湿度报警启用多选框选中/取消选中方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Common_CheckedChanged(object sender, EventArgs e)
        {
            if(sender is CheckBoxEx checkBox)
            {
                if(checkBox.Tag != null && checkBox.Tag.ToString().Length > 0)
                {
                    short errno = 0;
                    bool result = false;
                    try
                    {
                        // 向控制器的指定寄存器地址写入数据，能控制控制器是否启用温湿度报警。
                        // 这里的设置会影响设备是否发出蜂鸣声报警，但不会影响设备中存储的“当前温湿度是否超过限值”布尔数据。
                        result = CommonMethods.CommonWrite(checkBox.Tag.ToString(), checkBox.Checked ? "1" : "0", ref errno);
                        IniConfigHelper.WriteIniData("配方参数", "当前配方", "", devPath);
                        CommonMethods.Device.CurrentRecipeName = "";
                    }
                    catch (Exception ex)
                    {
                        CommonMethods.AddLog(2, "温湿度报警启用/禁用失败，原因：" + ex.Message);

                        // 先取消更改选中框选中状态事件处理方法的绑定，防止操作又触发执行本方法。
                        checkBox.CheckedChanged -= Common_CheckedChanged;
                        checkBox.Checked = !checkBox.Checked;
                        checkBox.CheckedChanged += Common_CheckedChanged;

                        return;
                    }

                    if(result == false)
                    {
                        CommonMethods.AddLog(2, "温湿度报警启用/禁用失败，错误码：" + errno);

                        checkBox.CheckedChanged -= Common_CheckedChanged;
                        checkBox.Checked = !checkBox.Checked;
                        checkBox.CheckedChanged += Common_CheckedChanged;
                    }
                }
            }
        }
    }
}
