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
    /// <summary>
    /// 扩展CheckBox。
    /// 在已有控件上进行扩展开发（不是控件+控件，而是要对控件的属性进行修改或添加或重绘控件但保留大致功能不变），
    /// 可使用组件开发（继承已有控件）。
    /// </summary>
    public partial class CheckBoxEx : CheckBox
    {
        public CheckBoxEx()
        {
            InitializeComponent();

            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;

            // 减少控件闪烁
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);  // 让控件忽略特定窗口消息以减少闪烁
            this.SetStyle(ControlStyles.DoubleBuffer, true);  // 双缓冲防止因重绘控件而引起的闪烁
            // 设置控件样式
            this.SetStyle(ControlStyles.ResizeRedraw, true);  // 在调整窗口大小时重绘控件
            this.SetStyle(ControlStyles.Selectable, true);    // 设置控件可选
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);  // 设置控件支持模拟透明度
        }

        // 绘制文本的布局信息
        private StringFormat stringFormat = new StringFormat();

        /// <summary>
        /// 选中框的宽度（选中框是正方形）
        /// </summary>
        private int defaultCheckButtonWidth = 20;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置选中框的宽度（选中框是正方形）")]
        public int DefaultCheckButtonWidth
        {
            get { return defaultCheckButtonWidth; }
            set 
            { 
                defaultCheckButtonWidth = value; 
                this.Invalidate();
            }
        }

        /// <summary>
        /// 选中框中“√”的颜色
        /// </summary>
        private Color checkColor = Color.FromArgb(3,25,66);
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置选中框中“√”的绘制颜色")]
        public Color CheckColor
        {
            get { return checkColor; }
            set 
            { 
                checkColor = value; 
                this.Invalidate();
            }
        }

        private Color checkBtnBackColor = Color.White;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置选中框的背景颜色")]
        public Color CheckBtnBackColor
        {
            get { return checkBtnBackColor; }
            set
            {
                checkBtnBackColor = value;
                this.Invalidate();
            }
        }

        private Color checkBtnBorderColor = Color.LightGray;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置选中框的边框颜色")]
        public Color CheckBtnBorderColor
        {
            get { return checkBtnBorderColor; }
            set
            {
                checkBtnBorderColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// 绘制时触发执行该函数
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            base.OnPaintBackground(e);  // 绘制控件的背景，由此达到清空控件已绘制的内容的目的

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Rectangle checkRect, textRect;
            CalculateRect(out checkRect, out textRect);

            // 绘制选择框矩形
            // 用于填充图形形状的画笔
            SolidBrush solidBrush = new SolidBrush(checkBtnBackColor);
            graphics.FillRectangle(solidBrush, checkRect);  // 填充一个矩形出来
            // 用于绘制图形形状（边框）的画笔
            Pen pen = new Pen(checkBtnBorderColor);
            graphics.DrawRectangle(pen, checkRect);

            if(this.CheckState == CheckState.Checked)
            {
                // 在选择框中画一个勾
                DrawCheckedFlag(graphics, checkRect, checkColor);
            }

            // 绘制文本
            graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), textRect, this.stringFormat);
        }

        /// <summary>
        /// 计算多选框中的选择框矩形和文本矩形
        /// </summary>
        /// <param name="checkRect">输出选择框矩形</param>
        /// <param name="textRect">输出文本矩形</param>
        private void CalculateRect(out Rectangle checkRect, out Rectangle textRect)
        {
            checkRect = new Rectangle(3, (this.Height - this.defaultCheckButtonWidth) / 2, this.defaultCheckButtonWidth, this.defaultCheckButtonWidth);
            textRect = new Rectangle(checkRect.Right + 3, 0, this.Width - checkRect.Right - 6, this.Height);
        }

        /// <summary>
        /// 在正方形中绘制“√”
        /// </summary>
        /// <param name="graphics">Graphics对象</param>
        /// <param name="rectangle">矩形，最好是正方形</param>
        /// <param name="color">绘制“√”所使用的颜色</param>
        private void DrawCheckedFlag(Graphics graphics, Rectangle rectangle, Color color)
        {
            // 要绘制一个“√”，首先需要找到三个点，然后将相邻点连接起来，就可以形成一个“√”。
            PointF[] pointFs = new PointF[3];

            pointFs[0] = new PointF(rectangle.X + rectangle.Width / 4.5f, rectangle.Y + rectangle.Height / 2.5f);
            pointFs[1] = new PointF(rectangle.X + rectangle.Width / 2.5f, rectangle.Bottom - rectangle.Height / 3.0f);
            pointFs[2] = new PointF(rectangle.Right - rectangle.Width / 4.0f, rectangle.Y + rectangle.Height / 4.5f);

            Pen pen = new Pen(color, 2.0f);
            graphics.DrawLines(pen, pointFs);
        }
    }
}
