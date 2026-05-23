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
    public partial class THMControl : UserControl
    {
        public THMControl()
        {
            InitializeComponent();

            // 减少控件闪烁
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);  // 让控件忽略特定窗口消息以减少闪烁
            this.SetStyle(ControlStyles.DoubleBuffer, true);  // 双缓冲防止因重绘控件而引起的闪烁
            // 设置控件样式
            this.SetStyle(ControlStyles.ResizeRedraw, true);  // 在调整窗口大小时重绘控件
            this.SetStyle(ControlStyles.Selectable, true);    // 设置控件可选
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);  // 设置控件支持模拟透明度
        }

        private string title = "1#站点";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置标题名称")]
        public string Title
        {
            get { return title; }
            set 
            { 
                title = value; 
                this.lbl_Title.Text = title;
            }
        }

        private string temp = "0.0";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置温度值")]
        public string Temp
        {
            get { return temp; }
            set
            {
                if(value != temp)
                {
                    temp = value;
                    this.lbl_Temp.Text = temp;

                    if(float.TryParse(temp, out float val))
                    {
                        this.dialPlate.Temperature = val;
                    }
                    else
                    {
                        this.dialPlate.Temperature = 0.0f;
                    }
                }
            }
        }

        private string humidity = "0.0";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置湿度值")]
        public string Humidity
        {
            get { return humidity; }
            set
            {
                if(value != humidity)
                {
                    humidity = value;
                    this.lbl_Humidity.Text = humidity;

                    if(float.TryParse(humidity, out float val))
                    {
                        this.dialPlate.Humidity = val;
                    }
                    else
                    {
                        this.dialPlate.Humidity = 0.0f;
                    }
                }
            }
        }

        private bool moduleError = false;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置模块是否发生错误，会影响本控件标题标签颜色")]
        public bool ModuleError
        {
            get { return moduleError; }
            set
            {
                moduleError = value;
                this.lbl_Title.BackColor = moduleError ? Color.Red : Color.FromArgb(36,184,196);
            }
        }

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置温度绑定变量名称")]
        public string TempVarName { get; set; } = string.Empty;

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置湿度绑定变量名称")]
        public string HumidityVarName { get; set; } = string.Empty;

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置控件状态绑定变量名称")]
        public string StateVarName { get; set; } = string.Empty;
    }
}
