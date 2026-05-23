using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wang.MTHBLL;
using Wang.MTHModels;

namespace Wang.MTHProject
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 业务层对象
        /// </summary>
        private readonly SysAdminManage sysAdminManage = new SysAdminManage();

        private void btn_Login_Click(object sender, EventArgs e)
        {
            // 验证界面输入数据
            if(this.txt_LoginName.Text.Trim().Length <= 0)
            {
                new FrmMsgBoxWithoutAck("请填写登录用户名！", "登录提示").ShowDialog();
                this.txt_LoginName.Focus();
                return;
            }
            if (this.txt_Pwd.Text.Trim().Length <= 0)
            {
                new FrmMsgBoxWithoutAck("请填写登录密码！", "登录提示").ShowDialog();
                this.txt_Pwd.Focus();
                return;
            }

            SysAdmin sysAdmin = new SysAdmin() 
            { 
                LoginName = this.txt_LoginName.Text.Trim(),
                LoginPwd = this.txt_Pwd.Text.Trim()
            };

            try
            {
                sysAdmin = sysAdminManage.AdminLogin(sysAdmin);

                if (sysAdmin == null)
                {
                    new FrmMsgBoxWithoutAck("用户名或密码不正确！", "登录提示").ShowDialog();
                    this.txt_LoginName.Focus();
                }
                else
                {
                    // 更新当前全局登录用户信息
                    CommonMethods.CurrentAdmin = sysAdmin;

                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                new FrmMsgBoxWithoutAck("登录时发生异常：" + ex.Message, "登录提示").ShowDialog();
                this.txt_LoginName.Focus();
            }
        }

        #region 减少窗体加载过程中的闪烁
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        #endregion

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

        private void txt_LoginName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.txt_Pwd.Focus();
            }
        }

        private void txt_Pwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Login_Click(null, null);
            }
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 启用软键盘
        private void StartKeyBoard()
        {
            //打开软键盘
            try
            {
                if (!System.IO.File.Exists(Environment.SystemDirectory + "\\osk.exe"))
                {
                    new FrmMsgBoxWithoutAck("软件盘可执行文件不存在！", "唤起软键盘").ShowDialog();
                    return;
                }

                softKey = System.Diagnostics.Process.Start(Environment.SystemDirectory + "\\osk.exe");
                // 上面的语句在打开软键盘后，系统还没用立刻把软键盘的窗口创建出来了。所以下面的代码用循环来查询窗口是否创建，只有创建了窗口，
                // FindWindow才能找到窗口句柄，才可以移动窗口的位置和设置窗口的大小。这里是关键。
                IntPtr intptr = IntPtr.Zero;
                while (IntPtr.Zero == intptr)
                {
                    System.Threading.Thread.Sleep(100);
                    intptr = FindWindow(null, "屏幕键盘");
                }


                // 获取屏幕尺寸
                int iActulaWidth = Screen.PrimaryScreen.Bounds.Width;
                int iActulaHeight = Screen.PrimaryScreen.Bounds.Height;


                // 设置软键盘的显示位置，底部居中
                int posX = (iActulaWidth - 1000) / 2;
                int posY = (iActulaHeight - 300);


                //设定键盘显示位置
                MoveWindow(intptr, posX, posY, 1000, 300, true);


                //设置软键盘到前端显示
                SetForegroundWindow(intptr);
            }
            catch (System.Exception ex)
            {
                new FrmMsgBoxWithoutAck("打开软键盘时发生异常：" + ex.Message, "打开软键盘").ShowDialog();
            }
        }


        // 申明要使用的dll和api
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "MoveWindow")]
        public static extern bool MoveWindow(System.IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);


        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);


        private System.Diagnostics.Process softKey;

        #endregion

        private void txt_LoginName_DoubleClick(object sender, EventArgs e)
        {
            // 启用软键盘
            StartKeyBoard();
        }

        private void txt_Pwd_DoubleClick(object sender, EventArgs e)
        {
            // 启用软键盘
            StartKeyBoard();
        }
    }
}
