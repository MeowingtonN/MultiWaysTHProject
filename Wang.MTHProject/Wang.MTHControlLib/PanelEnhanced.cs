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
    /// 改进Panel使其内部控件展示不闪烁
    /// </summary>
    public partial class PanelEnhanced : Panel
    {
        public PanelEnhanced()
        {
            InitializeComponent();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // 重载基类的背景擦除方法

            // 解决窗体刷新，放大和闪烁
            return;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // 使用双缓冲
            this.DoubleBuffered = true;

            if(this.BackgroundImage != null)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                // 不在OnPaintBackground方法中绘制背景，而在OnPaint方法中绘制背景图片，是为了防止闪烁。
                //（缩短背景绘制和控件绘制之间的时间，使得背景和控件近乎一起出现在屏幕上，改进观感）
                e.Graphics.DrawImage(this.BackgroundImage,
                                     new Rectangle(0, 0, this.Width, this.Height),
                                     0, 0, this.BackgroundImage.Width, this.BackgroundImage.Height,
                                     GraphicsUnit.Pixel);
            }

            base.OnPaint(e);
        }
    }
}
