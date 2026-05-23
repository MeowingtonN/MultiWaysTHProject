using Wang.MTHHelper;
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
    public partial class FrmParamModify : Form
    {
        /// <summary>
        /// 限值参数修改窗体构造函数
        /// </summary>
        /// <param name="titleName"></param>
        /// <param name="bindVarName">要修改的变量的名称</param>
        /// <param name="currentValue"></param>
        public FrmParamModify(string titleName, string bindVarName, string currentValue, string devPath)
        {
            InitializeComponent();

            this.lbl_Title.Text = titleName;
            this.bindVarName = bindVarName;
            this.lbl_CurrentValue.Text = currentValue;

            this.devPath = devPath;

            this.txt_SetValue.Focus();
        }

        /// <summary>
        /// 要修改的变量的名称
        /// </summary>
        private readonly string bindVarName = string.Empty;

        /// <summary>
        /// 设备配置文件路径
        /// </summary>
        private readonly string devPath = string.Empty;

        private void btn_Ack_Click(object sender, EventArgs e)
        {
            short errno = 0;
            bool result = false;
            try
            {
                result = CommonMethods.CommonWrite(this.bindVarName, this.txt_SetValue.Text.Trim(), ref errno);
                IniConfigHelper.WriteIniData("配方参数", "当前配方", "", devPath);
                CommonMethods.Device.CurrentRecipeName = "";
            }
            catch (Exception ex)
            {
                CommonMethods.AddLog(2, "参数修改失败，原因：" + ex.Message);
                new FrmMsgBoxWithoutAck("参数修改失败，原因：" + ex.Message + "请检查参数！", "参数修改").ShowDialog();
                return;
            }

            if (result)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                CommonMethods.AddLog(2, "参数修改失败，错误码：" + errno);
                new FrmMsgBoxWithoutAck("参数修改失败，错误码：" + errno + "。请检查参数！", "参数修改").ShowDialog();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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
            if (e.Button == MouseButtons.Left)
            {
                // this.Location表示以屏幕坐标表示的该窗体左上角的点的坐标。
                // e.X - mPoint.X 和 e.Y - mPoint.Y 表示了鼠标左键按下后的位移。
                this.Location = new Point(this.Location.X + (e.X - mPoint.X), this.Location.Y + (e.Y - mPoint.Y));
            }
        }
        #endregion

        /// <summary>
        /// 添加快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_SetValue_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.btn_Ack_Click(null, null);
            }
        }
    }
}
