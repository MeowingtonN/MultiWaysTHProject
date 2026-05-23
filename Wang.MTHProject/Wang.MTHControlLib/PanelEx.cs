using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wang.MTHControlLib
{
    public partial class PanelEx : Panel
    {
        public PanelEx()
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

        private int topGap = 1;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置要绘制的矩形顶部外边框与当前控件Panel之间的间隙宽度")]
        public int TopGap
        {
            get { return topGap; }
            set 
            { 
                topGap = value; 
                // 使控件整个图面无效并导致重绘控件
                this.Invalidate();
            }
        }

        private int bottomGap = 1;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置要绘制的矩形底部外边框与当前控件Panel之间的间隙宽度")]
        public int BottomGap
        {
            get { return bottomGap; }
            set 
            { 
                bottomGap = value;
                this.Invalidate();
            }
        }

        private int leftGap = 1;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置要绘制的矩形左部外边框与当前控件Panel之间的间隙宽度")]
        public int LeftGap
        {
            get { return leftGap; }
            set 
            { 
                leftGap = value; 
                this.Invalidate();
            }
        }

        private int rightGap = 1;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置要绘制的矩形右部外边框与当前控件Panel之间的间隙宽度")]
        public int RightGap
        {
            get { return rightGap; }
            set 
            { 
                rightGap = value; 
                this.Invalidate();
            }
        }

        private int borderWidth = 2;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置要绘制的矩形的边框宽度")]
        public int BorderWidth
        {
            get { return borderWidth; }
            set 
            { 
                borderWidth = value;
                this.Invalidate();
            }
        }

        private Color borderColor = Color.FromArgb(35, 255, 253);
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置要绘制的矩形的边框颜色")]
        public Color BorderColor
        {
            get { return borderColor; }
            set 
            { 
                borderColor = value;
                this.Invalidate();
            }
        }

        // 要绘制控件时触发执行该方法
        protected override void OnPaint(PaintEventArgs e)    // 重写OnPaint方法
        {
            base.OnPaint(e);  // 先执行基类的OnPaint方法

            // 拿到画布（绘图图面）
            Graphics graphics = e.Graphics;

            // 构造画笔
            Pen pen = new Pen(borderColor, borderWidth);

            // 计算要绘制的矩形的参数
            float x = leftGap + borderWidth * 0.5f;
            float y = topGap + borderWidth * 0.5f;
            float width = this.Width - leftGap - rightGap - borderWidth;
            float height = this.Height - topGap - bottomGap - borderWidth;

            // GDI绘制矩形
            graphics.DrawRectangle(pen, x, y, width, height);
        }
    }
}
