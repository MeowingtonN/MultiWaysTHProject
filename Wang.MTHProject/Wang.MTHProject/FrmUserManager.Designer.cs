namespace Wang.MTHProject
{
    partial class FrmUserManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserManager));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.title1 = new Wang.MTHControlLib.Title();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_LoginName = new System.Windows.Forms.TextBox();
            this.txt_LoginPwd2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_LoginPwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.title2 = new Wang.MTHControlLib.Title();
            this.chk_ParamSet = new Wang.MTHControlLib.CheckBoxEx();
            this.chk_Recipe = new Wang.MTHControlLib.CheckBoxEx();
            this.chk_HistoryTrend = new Wang.MTHControlLib.CheckBoxEx();
            this.chk_HistoryLog = new Wang.MTHControlLib.CheckBoxEx();
            this.chk_UserManage = new Wang.MTHControlLib.CheckBoxEx();
            this.btn_SelectAll = new System.Windows.Forms.Button();
            this.title3 = new Wang.MTHControlLib.Title();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Modify = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.dgv_UserManage = new System.Windows.Forms.DataGridView();
            this.LoginName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoginPwd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParamSet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recipe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HistoryLog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HistoryTrend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserManage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoginId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_UserManage)).BeginInit();
            this.SuspendLayout();
            // 
            // title1
            // 
            this.title1.BackColor = System.Drawing.Color.Transparent;
            this.title1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("title1.BackgroundImage")));
            this.title1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.title1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title1.Location = new System.Drawing.Point(13, 14);
            this.title1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(109, 31);
            this.title1.TabIndex = 0;
            this.title1.TitleName = "用户信息";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(30, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 25);
            this.label2.TabIndex = 35;
            this.label2.Text = "用户名称：";
            // 
            // txt_LoginName
            // 
            this.txt_LoginName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(85)))));
            this.txt_LoginName.Font = new System.Drawing.Font("微软雅黑", 14.25F);
            this.txt_LoginName.ForeColor = System.Drawing.Color.White;
            this.txt_LoginName.Location = new System.Drawing.Point(133, 58);
            this.txt_LoginName.Name = "txt_LoginName";
            this.txt_LoginName.Size = new System.Drawing.Size(233, 33);
            this.txt_LoginName.TabIndex = 36;
            this.txt_LoginName.Enter += new System.EventHandler(this.txt_LoginName_Enter);
            // 
            // txt_LoginPwd2
            // 
            this.txt_LoginPwd2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(85)))));
            this.txt_LoginPwd2.Font = new System.Drawing.Font("微软雅黑", 14.25F);
            this.txt_LoginPwd2.ForeColor = System.Drawing.Color.White;
            this.txt_LoginPwd2.Location = new System.Drawing.Point(133, 177);
            this.txt_LoginPwd2.Name = "txt_LoginPwd2";
            this.txt_LoginPwd2.PasswordChar = '*';
            this.txt_LoginPwd2.Size = new System.Drawing.Size(233, 33);
            this.txt_LoginPwd2.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(30, 180);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 37;
            this.label1.Text = "确认密码：";
            // 
            // txt_LoginPwd
            // 
            this.txt_LoginPwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(85)))));
            this.txt_LoginPwd.Font = new System.Drawing.Font("微软雅黑", 14.25F);
            this.txt_LoginPwd.ForeColor = System.Drawing.Color.White;
            this.txt_LoginPwd.Location = new System.Drawing.Point(133, 117);
            this.txt_LoginPwd.Name = "txt_LoginPwd";
            this.txt_LoginPwd.PasswordChar = '*';
            this.txt_LoginPwd.Size = new System.Drawing.Size(233, 33);
            this.txt_LoginPwd.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(30, 121);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 25);
            this.label3.TabIndex = 39;
            this.label3.Text = "用户密码：";
            // 
            // title2
            // 
            this.title2.BackColor = System.Drawing.Color.Transparent;
            this.title2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("title2.BackgroundImage")));
            this.title2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.title2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title2.Location = new System.Drawing.Point(13, 274);
            this.title2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title2.Name = "title2";
            this.title2.Size = new System.Drawing.Size(109, 31);
            this.title2.TabIndex = 41;
            this.title2.TitleName = "权限配置";
            // 
            // chk_ParamSet
            // 
            this.chk_ParamSet.BackColor = System.Drawing.Color.Transparent;
            this.chk_ParamSet.CheckBtnBackColor = System.Drawing.Color.White;
            this.chk_ParamSet.CheckBtnBorderColor = System.Drawing.Color.LightGray;
            this.chk_ParamSet.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_ParamSet.DefaultCheckButtonWidth = 20;
            this.chk_ParamSet.ForeColor = System.Drawing.Color.White;
            this.chk_ParamSet.Location = new System.Drawing.Point(54, 322);
            this.chk_ParamSet.Name = "chk_ParamSet";
            this.chk_ParamSet.Size = new System.Drawing.Size(130, 31);
            this.chk_ParamSet.TabIndex = 42;
            this.chk_ParamSet.Tag = "";
            this.chk_ParamSet.Text = "参数设置";
            this.chk_ParamSet.UseVisualStyleBackColor = false;
            // 
            // chk_Recipe
            // 
            this.chk_Recipe.BackColor = System.Drawing.Color.Transparent;
            this.chk_Recipe.CheckBtnBackColor = System.Drawing.Color.White;
            this.chk_Recipe.CheckBtnBorderColor = System.Drawing.Color.LightGray;
            this.chk_Recipe.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_Recipe.DefaultCheckButtonWidth = 20;
            this.chk_Recipe.ForeColor = System.Drawing.Color.White;
            this.chk_Recipe.Location = new System.Drawing.Point(220, 322);
            this.chk_Recipe.Name = "chk_Recipe";
            this.chk_Recipe.Size = new System.Drawing.Size(130, 31);
            this.chk_Recipe.TabIndex = 43;
            this.chk_Recipe.Tag = "";
            this.chk_Recipe.Text = "配方管理";
            this.chk_Recipe.UseVisualStyleBackColor = false;
            // 
            // chk_HistoryTrend
            // 
            this.chk_HistoryTrend.BackColor = System.Drawing.Color.Transparent;
            this.chk_HistoryTrend.CheckBtnBackColor = System.Drawing.Color.White;
            this.chk_HistoryTrend.CheckBtnBorderColor = System.Drawing.Color.LightGray;
            this.chk_HistoryTrend.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_HistoryTrend.DefaultCheckButtonWidth = 20;
            this.chk_HistoryTrend.ForeColor = System.Drawing.Color.White;
            this.chk_HistoryTrend.Location = new System.Drawing.Point(220, 368);
            this.chk_HistoryTrend.Name = "chk_HistoryTrend";
            this.chk_HistoryTrend.Size = new System.Drawing.Size(130, 31);
            this.chk_HistoryTrend.TabIndex = 45;
            this.chk_HistoryTrend.Tag = "";
            this.chk_HistoryTrend.Text = "历史趋势";
            this.chk_HistoryTrend.UseVisualStyleBackColor = false;
            // 
            // chk_HistoryLog
            // 
            this.chk_HistoryLog.BackColor = System.Drawing.Color.Transparent;
            this.chk_HistoryLog.CheckBtnBackColor = System.Drawing.Color.White;
            this.chk_HistoryLog.CheckBtnBorderColor = System.Drawing.Color.LightGray;
            this.chk_HistoryLog.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_HistoryLog.DefaultCheckButtonWidth = 20;
            this.chk_HistoryLog.ForeColor = System.Drawing.Color.White;
            this.chk_HistoryLog.Location = new System.Drawing.Point(54, 368);
            this.chk_HistoryLog.Name = "chk_HistoryLog";
            this.chk_HistoryLog.Size = new System.Drawing.Size(130, 31);
            this.chk_HistoryLog.TabIndex = 44;
            this.chk_HistoryLog.Tag = "";
            this.chk_HistoryLog.Text = "报警追溯";
            this.chk_HistoryLog.UseVisualStyleBackColor = false;
            // 
            // chk_UserManage
            // 
            this.chk_UserManage.BackColor = System.Drawing.Color.Transparent;
            this.chk_UserManage.CheckBtnBackColor = System.Drawing.Color.White;
            this.chk_UserManage.CheckBtnBorderColor = System.Drawing.Color.LightGray;
            this.chk_UserManage.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_UserManage.DefaultCheckButtonWidth = 20;
            this.chk_UserManage.ForeColor = System.Drawing.Color.White;
            this.chk_UserManage.Location = new System.Drawing.Point(54, 415);
            this.chk_UserManage.Name = "chk_UserManage";
            this.chk_UserManage.Size = new System.Drawing.Size(130, 31);
            this.chk_UserManage.TabIndex = 46;
            this.chk_UserManage.Tag = "";
            this.chk_UserManage.Text = "用户管理";
            this.chk_UserManage.UseVisualStyleBackColor = false;
            // 
            // btn_SelectAll
            // 
            this.btn_SelectAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_SelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SelectAll.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.btn_SelectAll.ForeColor = System.Drawing.Color.White;
            this.btn_SelectAll.Location = new System.Drawing.Point(220, 415);
            this.btn_SelectAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_SelectAll.Name = "btn_SelectAll";
            this.btn_SelectAll.Size = new System.Drawing.Size(117, 31);
            this.btn_SelectAll.TabIndex = 47;
            this.btn_SelectAll.Text = "全选/全不选";
            this.btn_SelectAll.UseVisualStyleBackColor = false;
            this.btn_SelectAll.Click += new System.EventHandler(this.btn_SelectAll_Click);
            // 
            // title3
            // 
            this.title3.BackColor = System.Drawing.Color.Transparent;
            this.title3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("title3.BackgroundImage")));
            this.title3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.title3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title3.Location = new System.Drawing.Point(13, 509);
            this.title3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title3.Name = "title3";
            this.title3.Size = new System.Drawing.Size(109, 31);
            this.title3.TabIndex = 48;
            this.title3.TitleName = "用户操作";
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.btn_Add.ForeColor = System.Drawing.Color.White;
            this.btn_Add.Location = new System.Drawing.Point(47, 559);
            this.btn_Add.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(135, 44);
            this.btn_Add.TabIndex = 49;
            this.btn_Add.Text = "添加用户";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Modify
            // 
            this.btn_Modify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_Modify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Modify.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.btn_Modify.ForeColor = System.Drawing.Color.White;
            this.btn_Modify.Location = new System.Drawing.Point(218, 559);
            this.btn_Modify.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Modify.Name = "btn_Modify";
            this.btn_Modify.Size = new System.Drawing.Size(135, 44);
            this.btn_Modify.TabIndex = 50;
            this.btn_Modify.Text = "修改用户";
            this.btn_Modify.UseVisualStyleBackColor = false;
            this.btn_Modify.Click += new System.EventHandler(this.btn_Modify_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Clear.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.btn_Clear.ForeColor = System.Drawing.Color.White;
            this.btn_Clear.Location = new System.Drawing.Point(218, 637);
            this.btn_Clear.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(135, 44);
            this.btn_Clear.TabIndex = 52;
            this.btn_Clear.Text = "清空文本框信息";
            this.btn_Clear.UseVisualStyleBackColor = false;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delete.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.btn_Delete.ForeColor = System.Drawing.Color.White;
            this.btn_Delete.Location = new System.Drawing.Point(47, 637);
            this.btn_Delete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(135, 44);
            this.btn_Delete.TabIndex = 51;
            this.btn_Delete.Text = "删除用户";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // dgv_UserManage
            // 
            this.dgv_UserManage.AllowUserToAddRows = false;
            this.dgv_UserManage.AllowUserToDeleteRows = false;
            this.dgv_UserManage.AllowUserToResizeColumns = false;
            this.dgv_UserManage.AllowUserToResizeRows = false;
            this.dgv_UserManage.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            this.dgv_UserManage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_UserManage.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_UserManage.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_UserManage.ColumnHeadersHeight = 45;
            this.dgv_UserManage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_UserManage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LoginName,
            this.LoginPwd,
            this.ParamSet,
            this.Recipe,
            this.HistoryLog,
            this.HistoryTrend,
            this.UserManage,
            this.LoginId});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(40)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_UserManage.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_UserManage.EnableHeadersVisualStyles = false;
            this.dgv_UserManage.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(146)))), ((int)(((byte)(235)))));
            this.dgv_UserManage.Location = new System.Drawing.Point(391, 14);
            this.dgv_UserManage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgv_UserManage.Name = "dgv_UserManage";
            this.dgv_UserManage.ReadOnly = true;
            this.dgv_UserManage.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(40)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(40)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_UserManage.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_UserManage.RowHeadersWidth = 50;
            this.dgv_UserManage.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_UserManage.RowTemplate.Height = 40;
            this.dgv_UserManage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_UserManage.Size = new System.Drawing.Size(976, 673);
            this.dgv_UserManage.TabIndex = 53;
            this.dgv_UserManage.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_UserManage_CellClick);
            this.dgv_UserManage.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_UserManage_CellFormatting);
            this.dgv_UserManage.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_UserManage_EditingControlShowing);
            this.dgv_UserManage.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_UserManage_RowPostPaint);
            // 
            // LoginName
            // 
            this.LoginName.DataPropertyName = "LoginName";
            this.LoginName.HeaderText = "用户名";
            this.LoginName.Name = "LoginName";
            this.LoginName.ReadOnly = true;
            this.LoginName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LoginName.Width = 170;
            // 
            // LoginPwd
            // 
            this.LoginPwd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LoginPwd.DataPropertyName = "LoginPwd";
            this.LoginPwd.HeaderText = "用户密码";
            this.LoginPwd.Name = "LoginPwd";
            this.LoginPwd.ReadOnly = true;
            this.LoginPwd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ParamSet
            // 
            this.ParamSet.DataPropertyName = "ParamSet";
            this.ParamSet.HeaderText = "参数设置";
            this.ParamSet.Name = "ParamSet";
            this.ParamSet.ReadOnly = true;
            this.ParamSet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ParamSet.Width = 115;
            // 
            // Recipe
            // 
            this.Recipe.DataPropertyName = "Recipe";
            this.Recipe.HeaderText = "配方管理";
            this.Recipe.Name = "Recipe";
            this.Recipe.ReadOnly = true;
            this.Recipe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Recipe.Width = 115;
            // 
            // HistoryLog
            // 
            this.HistoryLog.DataPropertyName = "HistoryLog";
            this.HistoryLog.HeaderText = "报警追溯";
            this.HistoryLog.Name = "HistoryLog";
            this.HistoryLog.ReadOnly = true;
            this.HistoryLog.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HistoryLog.Width = 115;
            // 
            // HistoryTrend
            // 
            this.HistoryTrend.DataPropertyName = "HistoryTrend";
            this.HistoryTrend.HeaderText = "历史趋势";
            this.HistoryTrend.Name = "HistoryTrend";
            this.HistoryTrend.ReadOnly = true;
            this.HistoryTrend.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HistoryTrend.Width = 115;
            // 
            // UserManage
            // 
            this.UserManage.DataPropertyName = "UserManage";
            this.UserManage.HeaderText = "用户管理";
            this.UserManage.Name = "UserManage";
            this.UserManage.ReadOnly = true;
            this.UserManage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UserManage.Width = 115;
            // 
            // LoginId
            // 
            this.LoginId.DataPropertyName = "LoginId";
            this.LoginId.HeaderText = "用户ID";
            this.LoginId.Name = "LoginId";
            this.LoginId.ReadOnly = true;
            this.LoginId.Visible = false;
            // 
            // FrmUserManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Wang.MTHProject.Properties.Resources.BackGround;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1394, 736);
            this.Controls.Add(this.dgv_UserManage);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Modify);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.title3);
            this.Controls.Add(this.btn_SelectAll);
            this.Controls.Add(this.chk_UserManage);
            this.Controls.Add(this.chk_HistoryTrend);
            this.Controls.Add(this.chk_HistoryLog);
            this.Controls.Add(this.chk_Recipe);
            this.Controls.Add(this.chk_ParamSet);
            this.Controls.Add(this.title2);
            this.Controls.Add(this.txt_LoginPwd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_LoginPwd2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_LoginName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.title1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "FrmUserManager";
            this.Text = "用户管理";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_UserManage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MTHControlLib.Title title1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_LoginName;
        private System.Windows.Forms.TextBox txt_LoginPwd2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_LoginPwd;
        private System.Windows.Forms.Label label3;
        private MTHControlLib.Title title2;
        private MTHControlLib.CheckBoxEx chk_ParamSet;
        private MTHControlLib.CheckBoxEx chk_Recipe;
        private MTHControlLib.CheckBoxEx chk_HistoryTrend;
        private MTHControlLib.CheckBoxEx chk_HistoryLog;
        private MTHControlLib.CheckBoxEx chk_UserManage;
        private System.Windows.Forms.Button btn_SelectAll;
        private MTHControlLib.Title title3;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Modify;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.DataGridView dgv_UserManage;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoginName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoginPwd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParamSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recipe;
        private System.Windows.Forms.DataGridViewTextBoxColumn HistoryLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn HistoryTrend;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserManage;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoginId;
    }
}