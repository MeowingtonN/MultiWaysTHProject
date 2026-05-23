using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wang.MTHProject
{
    public partial class FrmMsgBoxWithoutAck : Form
    {
        public FrmMsgBoxWithoutAck(string content, string title)
        {
            InitializeComponent();

            // 设置本窗体应为最顶层窗体
            this.TopMost = true;

            this.lbl_Content.Text = content;
            this.lbl_Title.Text = title;
        }

        private void btn_Ack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 自定义无边框窗体拖动（Drag）
        private Point mPoint;

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            // 拿到当前点击本窗体的位置
            mPoint = new Point(e.X, e.Y);
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                // this.Location表示以屏幕坐标表示的该窗体左上角的点的坐标。
                // e.X - mPoint.X 和 e.Y - mPoint.Y 表示了鼠标左键按下后的位移。
                this.Location = new Point(this.Location.X + (e.X - mPoint.X), this.Location.Y + (e.Y - mPoint.Y));
            }
        }
        #endregion
    }
}
