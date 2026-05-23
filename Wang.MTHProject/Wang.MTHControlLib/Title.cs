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
    public partial class Title : UserControl
    {
        public Title()
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

        private string titleName = "标题名称";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置标题名称")]
        public string TitleName
        {
            get { return titleName; }
            set 
            { 
                titleName = value; 
                this.lbl_Title.Text = titleName;
            }
        }

    }
}
