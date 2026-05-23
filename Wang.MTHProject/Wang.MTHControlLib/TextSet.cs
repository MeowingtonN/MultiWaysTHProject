using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wang.MTHControlLib
{
    [DefaultEvent("ControlDoubleClick")]
    public partial class TextSet : UserControl
    {
        public TextSet()
        {
            InitializeComponent();

            // 供控件所使用，减少控件闪烁
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);  // 让控件忽略特定窗口消息以减少闪烁
            this.SetStyle(ControlStyles.DoubleBuffer, true);  // 双缓冲防止因重绘控件而引起的闪烁
            // 设置控件样式
            this.SetStyle(ControlStyles.ResizeRedraw, true);  // 在调整窗口大小时重绘控件
            this.SetStyle(ControlStyles.Selectable, true);    // 设置控件可选
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);  // 设置控件支持模拟透明度
        }

        private string titleName = "1#站点温度高限";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示标题名称")]
        public string TitleName
        {
            get { return titleName; }
            set 
            { 
                titleName = value; 
                this.lbl_Title.Text = titleName;
            }
        }

        private string unit = "℃";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示数值单位")]
        public string Unit
        {
            get { return unit; }
            set
            {
                unit = value;
                this.lbl_Unit.Text = unit;
            }
        }

        private string bindVarName = "模块1温度高限";
        /// <summary>
        /// 设置绑定的变量名称，如“模块1温度高限”，用于依据变量名称(BindVarName)读取或设置变量数值(CurrentValue)。
        /// </summary>
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置绑定的变量名称，如“模块1温度高限”，用于依据变量名称(BindVarName)读取或设置变量数值(CurrentValue)")]
        public string BindVarName
        {
            get { return bindVarName; }
            set
            {
                bindVarName = value;
            }
        }

        private string currentValue = "0.0";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示当前数值")]
        public string CurrentValue
        {
            get { return currentValue; }
            set 
            { 
                if(currentValue != value)
                {
                    currentValue = value;
                    this.lbl_Value.Text = currentValue;
                }
            }
        }

        private string alarmVarName = "模块1温度高";
        /// <summary>
        /// 设置绑定的用于报警的变量名称，如“模块1温度高”，用于依据变量名称(AlarmVarName)读取变量数值(IsAlarm)，改变LED灯的显示。
        /// 当温湿度超过限值时设备的相应位便会置位，即此时设备就处于了报警状态。
        /// 至于“控制控制器是否启用温湿度报警”数据，指的是控制控制器的蜂鸣器报警，改变该值不会影响“温湿度是否超过限值”这个数据。
        /// </summary>
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置绑定的用于报警的变量名称，如“模块1温度高”，用于依据变量名称(AlarmVarName)读取变量数值(IsAlarm)，改变LED灯的显示")]
        public string AlarmVarName
        {
            get { return alarmVarName; }
            set
            {
                alarmVarName = value;
            }
        }

        private bool isAlarm;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示当前报警状态")]
        public bool IsAlarm
        {
            get { return isAlarm; }
            set 
            { 
                if (isAlarm != value)
                {
                    isAlarm = value;
                    this.led_Alarm.Value = isAlarm;
                }
            }
        }
        [Browsable(true)]
        [Category("自定义事件")]
        [Description("控件双击事件")]
        public event EventHandler ControlDoubleClick;
        private void lbl_Value_DoubleClick(object sender, EventArgs e)
        {
            // 通过系统已有的双击事件来触发执行ControlDoubleClick自定义事件。
            ControlDoubleClick?.Invoke(this, e);
        }
    }
}
