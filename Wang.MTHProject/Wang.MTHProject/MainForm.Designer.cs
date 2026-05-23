namespace Wang.MTHProject
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TopPanel = new System.Windows.Forms.Panel();
            this.navi_UserManage = new Wang.MTHControlLib.NaviButton();
            this.navi_HistoryTrend = new Wang.MTHControlLib.NaviButton();
            this.navi_HistoryLog = new Wang.MTHControlLib.NaviButton();
            this.navi_Recipe = new Wang.MTHControlLib.NaviButton();
            this.navi_ParamSet = new Wang.MTHControlLib.NaviButton();
            this.navi_Monitor = new Wang.MTHControlLib.NaviButton();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.lbl_LogoName = new System.Windows.Forms.Label();
            this.pictureBox_Logo = new System.Windows.Forms.PictureBox();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.MiddlePanel = new System.Windows.Forms.Panel();
            this.led_Conn = new SeeSharpTools.JY.GUI.LED();
            this.label1 = new System.Windows.Forms.Label();
            this.AlarmPanel = new System.Windows.Forms.Panel();
            this.scrollingAlarm = new SeeSharpTools.JY.GUI.ScrollingText();
            this.lbl_CurrentName = new System.Windows.Forms.Label();
            this.btn_Right = new System.Windows.Forms.Button();
            this.btn_Left = new System.Windows.Forms.Button();
            this.lbl_CurrentTime = new System.Windows.Forms.Label();
            this.lbl_Welcome = new System.Windows.Forms.Label();
            this.lbl_CurrentAdmin = new System.Windows.Forms.Label();
            this.pictureBox_User = new System.Windows.Forms.PictureBox();
            this.CorePanel = new Wang.MTHControlLib.PanelEx();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Logo)).BeginInit();
            this.MiddlePanel.SuspendLayout();
            this.AlarmPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_User)).BeginInit();
            this.CorePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.Transparent;
            this.TopPanel.Controls.Add(this.navi_UserManage);
            this.TopPanel.Controls.Add(this.navi_HistoryTrend);
            this.TopPanel.Controls.Add(this.navi_HistoryLog);
            this.TopPanel.Controls.Add(this.navi_Recipe);
            this.TopPanel.Controls.Add(this.navi_ParamSet);
            this.TopPanel.Controls.Add(this.navi_Monitor);
            this.TopPanel.Controls.Add(this.btn_Exit);
            this.TopPanel.Controls.Add(this.lbl_LogoName);
            this.TopPanel.Controls.Add(this.pictureBox_Logo);
            this.TopPanel.Controls.Add(this.lbl_Title);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1440, 133);
            this.TopPanel.TabIndex = 0;
            this.TopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.TopPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // navi_UserManage
            // 
            this.navi_UserManage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("navi_UserManage.BackgroundImage")));
            this.navi_UserManage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.navi_UserManage.ContentName = "用户管理";
            this.navi_UserManage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.navi_UserManage.IsLeft = false;
            this.navi_UserManage.IsSelected = false;
            this.navi_UserManage.Location = new System.Drawing.Point(1262, 73);
            this.navi_UserManage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.navi_UserManage.Name = "navi_UserManage";
            this.navi_UserManage.Size = new System.Drawing.Size(129, 43);
            this.navi_UserManage.TabIndex = 9;
            this.navi_UserManage.Click += new System.EventHandler(this.CommonNaviBtn_Click);
            // 
            // navi_HistoryTrend
            // 
            this.navi_HistoryTrend.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("navi_HistoryTrend.BackgroundImage")));
            this.navi_HistoryTrend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.navi_HistoryTrend.ContentName = "历史趋势";
            this.navi_HistoryTrend.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.navi_HistoryTrend.IsLeft = false;
            this.navi_HistoryTrend.IsSelected = false;
            this.navi_HistoryTrend.Location = new System.Drawing.Point(1115, 73);
            this.navi_HistoryTrend.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.navi_HistoryTrend.Name = "navi_HistoryTrend";
            this.navi_HistoryTrend.Size = new System.Drawing.Size(129, 43);
            this.navi_HistoryTrend.TabIndex = 8;
            this.navi_HistoryTrend.Click += new System.EventHandler(this.CommonNaviBtn_Click);
            // 
            // navi_HistoryLog
            // 
            this.navi_HistoryLog.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("navi_HistoryLog.BackgroundImage")));
            this.navi_HistoryLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.navi_HistoryLog.ContentName = "报警追溯";
            this.navi_HistoryLog.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.navi_HistoryLog.IsLeft = false;
            this.navi_HistoryLog.IsSelected = false;
            this.navi_HistoryLog.Location = new System.Drawing.Point(967, 73);
            this.navi_HistoryLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.navi_HistoryLog.Name = "navi_HistoryLog";
            this.navi_HistoryLog.Size = new System.Drawing.Size(129, 43);
            this.navi_HistoryLog.TabIndex = 7;
            this.navi_HistoryLog.Click += new System.EventHandler(this.CommonNaviBtn_Click);
            // 
            // navi_Recipe
            // 
            this.navi_Recipe.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("navi_Recipe.BackgroundImage")));
            this.navi_Recipe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.navi_Recipe.ContentName = "配方管理";
            this.navi_Recipe.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.navi_Recipe.IsLeft = true;
            this.navi_Recipe.IsSelected = false;
            this.navi_Recipe.Location = new System.Drawing.Point(341, 73);
            this.navi_Recipe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.navi_Recipe.Name = "navi_Recipe";
            this.navi_Recipe.Size = new System.Drawing.Size(129, 43);
            this.navi_Recipe.TabIndex = 6;
            this.navi_Recipe.Click += new System.EventHandler(this.CommonNaviBtn_Click);
            // 
            // navi_ParamSet
            // 
            this.navi_ParamSet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("navi_ParamSet.BackgroundImage")));
            this.navi_ParamSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.navi_ParamSet.ContentName = "参数设置";
            this.navi_ParamSet.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.navi_ParamSet.IsLeft = true;
            this.navi_ParamSet.IsSelected = false;
            this.navi_ParamSet.Location = new System.Drawing.Point(187, 73);
            this.navi_ParamSet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.navi_ParamSet.Name = "navi_ParamSet";
            this.navi_ParamSet.Size = new System.Drawing.Size(129, 43);
            this.navi_ParamSet.TabIndex = 5;
            this.navi_ParamSet.Click += new System.EventHandler(this.CommonNaviBtn_Click);
            // 
            // navi_Monitor
            // 
            this.navi_Monitor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("navi_Monitor.BackgroundImage")));
            this.navi_Monitor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.navi_Monitor.ContentName = "集中监控";
            this.navi_Monitor.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.navi_Monitor.IsLeft = true;
            this.navi_Monitor.IsSelected = false;
            this.navi_Monitor.Location = new System.Drawing.Point(39, 73);
            this.navi_Monitor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.navi_Monitor.Name = "navi_Monitor";
            this.navi_Monitor.Size = new System.Drawing.Size(129, 43);
            this.navi_Monitor.TabIndex = 4;
            this.navi_Monitor.Click += new System.EventHandler(this.CommonNaviBtn_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackgroundImage = global::Wang.MTHProject.Properties.Resources.Exit;
            this.btn_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Exit.FlatAppearance.BorderSize = 0;
            this.btn_Exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Exit.Location = new System.Drawing.Point(1326, 11);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(102, 40);
            this.btn_Exit.TabIndex = 3;
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // lbl_LogoName
            // 
            this.lbl_LogoName.AutoSize = true;
            this.lbl_LogoName.Font = new System.Drawing.Font("微软雅黑", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_LogoName.ForeColor = System.Drawing.Color.White;
            this.lbl_LogoName.Location = new System.Drawing.Point(58, 15);
            this.lbl_LogoName.Name = "lbl_LogoName";
            this.lbl_LogoName.Size = new System.Drawing.Size(214, 36);
            this.lbl_LogoName.TabIndex = 1;
            this.lbl_LogoName.Text = "IM A LEARNER";
            // 
            // pictureBox_Logo
            // 
            this.pictureBox_Logo.Image = global::Wang.MTHProject.Properties.Resources.logo;
            this.pictureBox_Logo.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_Logo.Name = "pictureBox_Logo";
            this.pictureBox_Logo.Size = new System.Drawing.Size(42, 42);
            this.pictureBox_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Logo.TabIndex = 0;
            this.pictureBox_Logo.TabStop = false;
            // 
            // lbl_Title
            // 
            this.lbl_Title.Font = new System.Drawing.Font("微软雅黑", 23.25F, System.Drawing.FontStyle.Bold);
            this.lbl_Title.ForeColor = System.Drawing.Color.White;
            this.lbl_Title.Location = new System.Drawing.Point(523, 32);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(394, 65);
            this.lbl_Title.TabIndex = 2;
            this.lbl_Title.Text = "多路温湿度采集监控系统";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MiddlePanel
            // 
            this.MiddlePanel.BackColor = System.Drawing.Color.Transparent;
            this.MiddlePanel.Controls.Add(this.led_Conn);
            this.MiddlePanel.Controls.Add(this.label1);
            this.MiddlePanel.Controls.Add(this.AlarmPanel);
            this.MiddlePanel.Controls.Add(this.lbl_CurrentName);
            this.MiddlePanel.Controls.Add(this.btn_Right);
            this.MiddlePanel.Controls.Add(this.btn_Left);
            this.MiddlePanel.Controls.Add(this.lbl_CurrentTime);
            this.MiddlePanel.Controls.Add(this.lbl_Welcome);
            this.MiddlePanel.Controls.Add(this.lbl_CurrentAdmin);
            this.MiddlePanel.Controls.Add(this.pictureBox_User);
            this.MiddlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MiddlePanel.Location = new System.Drawing.Point(0, 133);
            this.MiddlePanel.Name = "MiddlePanel";
            this.MiddlePanel.Size = new System.Drawing.Size(1440, 65);
            this.MiddlePanel.TabIndex = 1;
            // 
            // led_Conn
            // 
            this.led_Conn.BlinkColor = System.Drawing.Color.Lime;
            this.led_Conn.BlinkInterval = 1000;
            this.led_Conn.BlinkOn = false;
            this.led_Conn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.led_Conn.Interacton = SeeSharpTools.JY.GUI.LED.InteractionStyle.Indicator;
            this.led_Conn.Location = new System.Drawing.Point(1376, 20);
            this.led_Conn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.led_Conn.Name = "led_Conn";
            this.led_Conn.OffColor = System.Drawing.Color.Red;
            this.led_Conn.OnColor = System.Drawing.Color.Lime;
            this.led_Conn.Size = new System.Drawing.Size(24, 24);
            this.led_Conn.Style = SeeSharpTools.JY.GUI.LED.LedStyle.Circular;
            this.led_Conn.TabIndex = 0;
            this.led_Conn.Value = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1284, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "通信状态";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AlarmPanel
            // 
            this.AlarmPanel.BackgroundImage = global::Wang.MTHProject.Properties.Resources.Alarm;
            this.AlarmPanel.Controls.Add(this.scrollingAlarm);
            this.AlarmPanel.Location = new System.Drawing.Point(930, 8);
            this.AlarmPanel.Name = "AlarmPanel";
            this.AlarmPanel.Padding = new System.Windows.Forms.Padding(5, 5, 1, 5);
            this.AlarmPanel.Size = new System.Drawing.Size(324, 49);
            this.AlarmPanel.TabIndex = 9;
            // 
            // scrollingAlarm
            // 
            this.scrollingAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.scrollingAlarm.BorderColor = System.Drawing.Color.Transparent;
            this.scrollingAlarm.BorderVisible = true;
            this.scrollingAlarm.Cursor = System.Windows.Forms.Cursors.Default;
            this.scrollingAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollingAlarm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.scrollingAlarm.ForeColor = System.Drawing.Color.White;
            this.scrollingAlarm.Location = new System.Drawing.Point(5, 5);
            this.scrollingAlarm.Name = "scrollingAlarm";
            this.scrollingAlarm.ScrollDirection = SeeSharpTools.JY.GUI.ScrollingText.TextDirection.RightToLeft;
            this.scrollingAlarm.ScrollSpeed = 25;
            this.scrollingAlarm.Size = new System.Drawing.Size(318, 39);
            this.scrollingAlarm.TabIndex = 0;
            this.scrollingAlarm.Text = "当前系统无报警";
            this.scrollingAlarm.VerticleAligment = SeeSharpTools.JY.GUI.ScrollingText.TextVerticalAlignment.Center;
            // 
            // lbl_CurrentName
            // 
            this.lbl_CurrentName.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_CurrentName.ForeColor = System.Drawing.Color.White;
            this.lbl_CurrentName.Image = global::Wang.MTHProject.Properties.Resources.Current;
            this.lbl_CurrentName.Location = new System.Drawing.Point(626, 8);
            this.lbl_CurrentName.Name = "lbl_CurrentName";
            this.lbl_CurrentName.Size = new System.Drawing.Size(184, 49);
            this.lbl_CurrentName.TabIndex = 8;
            this.lbl_CurrentName.Text = "集中监控";
            this.lbl_CurrentName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Right
            // 
            this.btn_Right.BackgroundImage = global::Wang.MTHProject.Properties.Resources.right;
            this.btn_Right.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Right.FlatAppearance.BorderSize = 0;
            this.btn_Right.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Right.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Right.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Right.Location = new System.Drawing.Point(855, 12);
            this.btn_Right.Name = "btn_Right";
            this.btn_Right.Size = new System.Drawing.Size(38, 40);
            this.btn_Right.TabIndex = 7;
            this.btn_Right.UseVisualStyleBackColor = true;
            this.btn_Right.Click += new System.EventHandler(this.btn_Right_Click);
            // 
            // btn_Left
            // 
            this.btn_Left.BackgroundImage = global::Wang.MTHProject.Properties.Resources.left;
            this.btn_Left.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Left.FlatAppearance.BorderSize = 0;
            this.btn_Left.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Left.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Left.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Left.Location = new System.Drawing.Point(545, 12);
            this.btn_Left.Name = "btn_Left";
            this.btn_Left.Size = new System.Drawing.Size(46, 40);
            this.btn_Left.TabIndex = 4;
            this.btn_Left.UseVisualStyleBackColor = true;
            this.btn_Left.Click += new System.EventHandler(this.btn_Left_Click);
            // 
            // lbl_CurrentTime
            // 
            this.lbl_CurrentTime.AutoSize = true;
            this.lbl_CurrentTime.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.lbl_CurrentTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(233)))), ((int)(((byte)(255)))));
            this.lbl_CurrentTime.Location = new System.Drawing.Point(318, 21);
            this.lbl_CurrentTime.Name = "lbl_CurrentTime";
            this.lbl_CurrentTime.Size = new System.Drawing.Size(213, 22);
            this.lbl_CurrentTime.TabIndex = 6;
            this.lbl_CurrentTime.Text = "2026年04月28日 13:55:20";
            this.lbl_CurrentTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Welcome
            // 
            this.lbl_Welcome.AutoSize = true;
            this.lbl_Welcome.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.lbl_Welcome.ForeColor = System.Drawing.Color.White;
            this.lbl_Welcome.Location = new System.Drawing.Point(141, 21);
            this.lbl_Welcome.Name = "lbl_Welcome";
            this.lbl_Welcome.Size = new System.Drawing.Size(175, 22);
            this.lbl_Welcome.TabIndex = 5;
            this.lbl_Welcome.Text = "欢迎登录！现在时间是:";
            this.lbl_Welcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_CurrentAdmin
            // 
            this.lbl_CurrentAdmin.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.lbl_CurrentAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(233)))), ((int)(((byte)(255)))));
            this.lbl_CurrentAdmin.Location = new System.Drawing.Point(45, 12);
            this.lbl_CurrentAdmin.Name = "lbl_CurrentAdmin";
            this.lbl_CurrentAdmin.Size = new System.Drawing.Size(91, 41);
            this.lbl_CurrentAdmin.TabIndex = 4;
            this.lbl_CurrentAdmin.Text = "管理员";
            this.lbl_CurrentAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox_User
            // 
            this.pictureBox_User.Image = global::Wang.MTHProject.Properties.Resources.user;
            this.pictureBox_User.Location = new System.Drawing.Point(21, 22);
            this.pictureBox_User.Name = "pictureBox_User";
            this.pictureBox_User.Size = new System.Drawing.Size(20, 20);
            this.pictureBox_User.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_User.TabIndex = 4;
            this.pictureBox_User.TabStop = false;
            // 
            // CorePanel
            // 
            this.CorePanel.BackColor = System.Drawing.Color.Transparent;
            this.CorePanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(79)))), ((int)(((byte)(150)))));
            this.CorePanel.BorderWidth = 3;
            this.CorePanel.BottomGap = 10;
            this.CorePanel.Controls.Add(this.MainPanel);
            this.CorePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CorePanel.LeftGap = 20;
            this.CorePanel.Location = new System.Drawing.Point(0, 198);
            this.CorePanel.Name = "CorePanel";
            this.CorePanel.Padding = new System.Windows.Forms.Padding(23, 13, 23, 13);
            this.CorePanel.RightGap = 20;
            this.CorePanel.Size = new System.Drawing.Size(1440, 762);
            this.CorePanel.TabIndex = 2;
            this.CorePanel.TopGap = 10;
            // 
            // MainPanel
            // 
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(23, 13);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1394, 736);
            this.MainPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Wang.MTHProject.Properties.Resources.Main;
            this.ClientSize = new System.Drawing.Size(1440, 960);
            this.Controls.Add(this.CorePanel);
            this.Controls.Add(this.MiddlePanel);
            this.Controls.Add(this.TopPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "多路温湿度采集监控系统";
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Logo)).EndInit();
            this.MiddlePanel.ResumeLayout(false);
            this.MiddlePanel.PerformLayout();
            this.AlarmPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_User)).EndInit();
            this.CorePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel MiddlePanel;
        private System.Windows.Forms.PictureBox pictureBox_Logo;
        private System.Windows.Forms.Label lbl_LogoName;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.PictureBox pictureBox_User;
        private System.Windows.Forms.Label lbl_CurrentAdmin;
        private System.Windows.Forms.Label lbl_Welcome;
        private System.Windows.Forms.Label lbl_CurrentTime;
        private System.Windows.Forms.Button btn_Left;
        private System.Windows.Forms.Button btn_Right;
        private System.Windows.Forms.Label lbl_CurrentName;
        private System.Windows.Forms.Panel AlarmPanel;
        private System.Windows.Forms.Label label1;
        private MTHControlLib.NaviButton navi_Monitor;
        private MTHControlLib.NaviButton navi_ParamSet;
        private MTHControlLib.NaviButton navi_Recipe;
        private MTHControlLib.NaviButton navi_UserManage;
        private MTHControlLib.NaviButton navi_HistoryTrend;
        private MTHControlLib.NaviButton navi_HistoryLog;
        private MTHControlLib.PanelEx CorePanel;
        private System.Windows.Forms.Panel MainPanel;
        private SeeSharpTools.JY.GUI.ScrollingText scrollingAlarm;
        private SeeSharpTools.JY.GUI.LED led_Conn;
    }
}

