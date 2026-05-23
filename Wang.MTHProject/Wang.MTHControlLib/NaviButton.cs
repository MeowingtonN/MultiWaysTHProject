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
    [DefaultEvent("Click")]    // 设置自定义控件的默认事件
    public partial class NaviButton : UserControl
    {
        public NaviButton()
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

        private bool isSelected = false;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置导航按钮样式是否是选中状态")]
        public bool IsSelected
        {
            get { return isSelected; }
            set 
            { 
                isSelected = value; 
                UpdateImage();
            }
        }

        private bool isLeft = true;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置导航按钮样式是否是靠左的状态")]
        public bool IsLeft
        {
            get { return isLeft; }
            set 
            { 
                isLeft = value;
                UpdateImage();
            }
        }

        private string contentName = "导航按钮";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置导航按钮文本显示内容")]
        public string ContentName
        {
            get { return contentName; }
            set 
            { 
                contentName = value; 
                this.lbl_Content.Text = contentName;
            }
        }

        [Browsable(true)]
        [Category("自定义事件")]
        [Description("自定义NaviButton的Click事件")]
        public new EventHandler Click;  // 在自定义控件中定义事件（EventHandler类型），在使用自定义控件的窗体中定义事件处理方法并关联到该事件。
        // 点击lbl_Content标签事件处理方法
        private void lbl_Content_Click(object sender, EventArgs e)
        {
            // 触发本自定义控件的Click事件（事件传递）
            this.Click?.Invoke(this, e);
        }

        /// <summary>
        /// 统一更新导航按钮背景图片
        /// </summary>
        private void UpdateImage()
        {
            if (this.isLeft)
            {
                this.BackgroundImage = this.isSelected ? Properties.Resources.LeftSelected : Properties.Resources.LeftUnSelected;
            }
            else
            {
                this.BackgroundImage = this.isSelected ? Properties.Resources.RightSelected : Properties.Resources.RightUnSelected;
            }
        }
    }
}
