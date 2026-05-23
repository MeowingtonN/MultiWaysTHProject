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
    public partial class TextSetNum : UserControl
    {
        public TextSetNum()
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

        private float currentValue = 0.0f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示当前数值")]
        public float CurrentValue
        {
            get 
            { 
                currentValue = Convert.ToSingle(this.num_Value.Value);
                return currentValue;
            }
            set 
            { 
                if(currentValue != value)
                {
                    currentValue = value;
                    this.num_Value.Value = Convert.ToDecimal(currentValue);
                }
            }
        }
    }
}
