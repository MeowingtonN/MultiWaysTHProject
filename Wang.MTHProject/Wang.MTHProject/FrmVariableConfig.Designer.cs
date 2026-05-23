namespace Wang.MTHProject
{
    partial class FrmVariableConfig
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVariableConfig));
            this.panelEnhanced1 = new Wang.MTHControlLib.PanelEnhanced();
            this.panelEx1 = new Wang.MTHControlLib.PanelEx();
            this.num_Offset = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.num_Scale = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.chk_NegAlarm = new Wang.MTHControlLib.CheckBoxEx();
            this.chk_PosAlarm = new Wang.MTHControlLib.CheckBoxEx();
            this.num_OffsetOrLength = new System.Windows.Forms.NumericUpDown();
            this.num_Start = new System.Windows.Forms.NumericUpDown();
            this.txt_VarName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb_GroupName = new System.Windows.Forms.ComboBox();
            this.dgv_Main = new System.Windows.Forms.DataGridView();
            this.VarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OffsetOrLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Scale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Offset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PosAlarm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NegAlarm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Modify = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Remark = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_DataType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panelEnhanced1.SuspendLayout();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Offset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Scale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_OffsetOrLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Start)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).BeginInit();
            this.TopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEnhanced1
            // 
            this.panelEnhanced1.BackgroundImage = global::Wang.MTHProject.Properties.Resources.BackGround;
            this.panelEnhanced1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelEnhanced1.Controls.Add(this.panelEx1);
            this.panelEnhanced1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEnhanced1.Location = new System.Drawing.Point(0, 0);
            this.panelEnhanced1.Name = "panelEnhanced1";
            this.panelEnhanced1.Size = new System.Drawing.Size(1458, 788);
            this.panelEnhanced1.TabIndex = 0;
            // 
            // panelEx1
            // 
            this.panelEx1.BackColor = System.Drawing.Color.Transparent;
            this.panelEx1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(79)))), ((int)(((byte)(150)))));
            this.panelEx1.BorderWidth = 2;
            this.panelEx1.BottomGap = 1;
            this.panelEx1.Controls.Add(this.num_Offset);
            this.panelEx1.Controls.Add(this.label9);
            this.panelEx1.Controls.Add(this.num_Scale);
            this.panelEx1.Controls.Add(this.label8);
            this.panelEx1.Controls.Add(this.chk_NegAlarm);
            this.panelEx1.Controls.Add(this.chk_PosAlarm);
            this.panelEx1.Controls.Add(this.num_OffsetOrLength);
            this.panelEx1.Controls.Add(this.num_Start);
            this.panelEx1.Controls.Add(this.txt_VarName);
            this.panelEx1.Controls.Add(this.label7);
            this.panelEx1.Controls.Add(this.cmb_GroupName);
            this.panelEx1.Controls.Add(this.dgv_Main);
            this.panelEx1.Controls.Add(this.btn_Delete);
            this.panelEx1.Controls.Add(this.label1);
            this.panelEx1.Controls.Add(this.btn_Modify);
            this.panelEx1.Controls.Add(this.btn_Add);
            this.panelEx1.Controls.Add(this.label3);
            this.panelEx1.Controls.Add(this.txt_Remark);
            this.panelEx1.Controls.Add(this.label6);
            this.panelEx1.Controls.Add(this.label4);
            this.panelEx1.Controls.Add(this.cmb_DataType);
            this.panelEx1.Controls.Add(this.label5);
            this.panelEx1.Controls.Add(this.TopPanel);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.panelEx1.LeftGap = 1;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.RightGap = 1;
            this.panelEx1.Size = new System.Drawing.Size(1458, 788);
            this.panelEx1.TabIndex = 0;
            this.panelEx1.TopGap = 1;
            // 
            // num_Offset
            // 
            this.num_Offset.DecimalPlaces = 1;
            this.num_Offset.Font = new System.Drawing.Font("微软雅黑", 13.5F);
            this.num_Offset.Location = new System.Drawing.Point(1168, 173);
            this.num_Offset.Name = "num_Offset";
            this.num_Offset.Size = new System.Drawing.Size(120, 31);
            this.num_Offset.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 13.75F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(1075, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 26);
            this.label9.TabIndex = 37;
            this.label9.Text = "偏移量：";
            // 
            // num_Scale
            // 
            this.num_Scale.DecimalPlaces = 1;
            this.num_Scale.Font = new System.Drawing.Font("微软雅黑", 13.5F);
            this.num_Scale.Location = new System.Drawing.Point(865, 173);
            this.num_Scale.Name = "num_Scale";
            this.num_Scale.Size = new System.Drawing.Size(120, 31);
            this.num_Scale.TabIndex = 36;
            this.num_Scale.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 13.75F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(751, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 26);
            this.label8.TabIndex = 35;
            this.label8.Text = "线性系数：";
            // 
            // chk_NegAlarm
            // 
            this.chk_NegAlarm.CheckBtnBackColor = System.Drawing.Color.White;
            this.chk_NegAlarm.CheckBtnBorderColor = System.Drawing.Color.LightGray;
            this.chk_NegAlarm.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_NegAlarm.DefaultCheckButtonWidth = 22;
            this.chk_NegAlarm.ForeColor = System.Drawing.Color.White;
            this.chk_NegAlarm.Location = new System.Drawing.Point(564, 174);
            this.chk_NegAlarm.Name = "chk_NegAlarm";
            this.chk_NegAlarm.Size = new System.Drawing.Size(133, 29);
            this.chk_NegAlarm.TabIndex = 34;
            this.chk_NegAlarm.Text = "下降沿报警";
            this.chk_NegAlarm.UseVisualStyleBackColor = true;
            // 
            // chk_PosAlarm
            // 
            this.chk_PosAlarm.CheckBtnBackColor = System.Drawing.Color.White;
            this.chk_PosAlarm.CheckBtnBorderColor = System.Drawing.Color.LightGray;
            this.chk_PosAlarm.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_PosAlarm.DefaultCheckButtonWidth = 22;
            this.chk_PosAlarm.ForeColor = System.Drawing.Color.White;
            this.chk_PosAlarm.Location = new System.Drawing.Point(399, 174);
            this.chk_PosAlarm.Name = "chk_PosAlarm";
            this.chk_PosAlarm.Size = new System.Drawing.Size(133, 29);
            this.chk_PosAlarm.TabIndex = 33;
            this.chk_PosAlarm.Text = "上升沿报警";
            this.chk_PosAlarm.UseVisualStyleBackColor = true;
            // 
            // num_OffsetOrLength
            // 
            this.num_OffsetOrLength.Font = new System.Drawing.Font("微软雅黑", 13.5F);
            this.num_OffsetOrLength.Location = new System.Drawing.Point(1306, 103);
            this.num_OffsetOrLength.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.num_OffsetOrLength.Name = "num_OffsetOrLength";
            this.num_OffsetOrLength.Size = new System.Drawing.Size(112, 31);
            this.num_OffsetOrLength.TabIndex = 21;
            // 
            // num_Start
            // 
            this.num_Start.Font = new System.Drawing.Font("微软雅黑", 13.5F);
            this.num_Start.Location = new System.Drawing.Point(908, 103);
            this.num_Start.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.num_Start.Name = "num_Start";
            this.num_Start.Size = new System.Drawing.Size(120, 31);
            this.num_Start.TabIndex = 19;
            // 
            // txt_VarName
            // 
            this.txt_VarName.Font = new System.Drawing.Font("微软雅黑", 13.5F);
            this.txt_VarName.Location = new System.Drawing.Point(506, 103);
            this.txt_VarName.Name = "txt_VarName";
            this.txt_VarName.Size = new System.Drawing.Size(191, 31);
            this.txt_VarName.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 13.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(394, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 26);
            this.label7.TabIndex = 31;
            this.label7.Text = "变量名称：";
            // 
            // cmb_GroupName
            // 
            this.cmb_GroupName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_GroupName.Font = new System.Drawing.Font("微软雅黑", 13.5F);
            this.cmb_GroupName.FormattingEnabled = true;
            this.cmb_GroupName.Location = new System.Drawing.Point(169, 102);
            this.cmb_GroupName.Name = "cmb_GroupName";
            this.cmb_GroupName.Size = new System.Drawing.Size(191, 32);
            this.cmb_GroupName.TabIndex = 30;
            // 
            // dgv_Main
            // 
            this.dgv_Main.AllowUserToAddRows = false;
            this.dgv_Main.AllowUserToDeleteRows = false;
            this.dgv_Main.AllowUserToResizeColumns = false;
            this.dgv_Main.AllowUserToResizeRows = false;
            this.dgv_Main.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            this.dgv_Main.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_Main.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Main.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Main.ColumnHeadersHeight = 45;
            this.dgv_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VarName,
            this.Start,
            this.OffsetOrLength,
            this.DataType,
            this.Scale,
            this.Offset,
            this.PosAlarm,
            this.NegAlarm,
            this.GroupName,
            this.Remark});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(40)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(40)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Main.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Main.EnableHeadersVisualStyles = false;
            this.dgv_Main.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(146)))), ((int)(((byte)(235)))));
            this.dgv_Main.Location = new System.Drawing.Point(37, 293);
            this.dgv_Main.Name = "dgv_Main";
            this.dgv_Main.ReadOnly = true;
            this.dgv_Main.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(40)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(40)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Main.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Main.RowHeadersWidth = 50;
            this.dgv_Main.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_Main.RowTemplate.Height = 40;
            this.dgv_Main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Main.Size = new System.Drawing.Size(1381, 465);
            this.dgv_Main.TabIndex = 29;
            this.dgv_Main.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Main_CellClick);
            this.dgv_Main.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_Main_CellFormatting);
            this.dgv_Main.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_Main_EditingControlShowing);
            this.dgv_Main.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_Main_RowPostPaint);
            // 
            // VarName
            // 
            this.VarName.DataPropertyName = "VarName";
            this.VarName.HeaderText = "变量名称";
            this.VarName.Name = "VarName";
            this.VarName.ReadOnly = true;
            this.VarName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.VarName.Width = 160;
            // 
            // Start
            // 
            this.Start.DataPropertyName = "Start";
            this.Start.HeaderText = "起始索引";
            this.Start.Name = "Start";
            this.Start.ReadOnly = true;
            this.Start.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Start.Width = 90;
            // 
            // OffsetOrLength
            // 
            this.OffsetOrLength.DataPropertyName = "OffsetOrLength";
            this.OffsetOrLength.HeaderText = "位偏移或长度";
            this.OffsetOrLength.Name = "OffsetOrLength";
            this.OffsetOrLength.ReadOnly = true;
            this.OffsetOrLength.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OffsetOrLength.Width = 120;
            // 
            // DataType
            // 
            this.DataType.DataPropertyName = "DataType";
            this.DataType.HeaderText = "数据类型";
            this.DataType.Name = "DataType";
            this.DataType.ReadOnly = true;
            this.DataType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DataType.Width = 80;
            // 
            // Scale
            // 
            this.Scale.DataPropertyName = "Scale";
            this.Scale.HeaderText = "线性系数";
            this.Scale.Name = "Scale";
            this.Scale.ReadOnly = true;
            this.Scale.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Scale.Width = 80;
            // 
            // Offset
            // 
            this.Offset.DataPropertyName = "Offset";
            this.Offset.HeaderText = "偏移量";
            this.Offset.Name = "Offset";
            this.Offset.ReadOnly = true;
            this.Offset.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Offset.Width = 80;
            // 
            // PosAlarm
            // 
            this.PosAlarm.DataPropertyName = "PosAlarm";
            this.PosAlarm.HeaderText = "上升沿";
            this.PosAlarm.Name = "PosAlarm";
            this.PosAlarm.ReadOnly = true;
            this.PosAlarm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PosAlarm.Width = 80;
            // 
            // NegAlarm
            // 
            this.NegAlarm.DataPropertyName = "NegAlarm";
            this.NegAlarm.HeaderText = "下降沿";
            this.NegAlarm.Name = "NegAlarm";
            this.NegAlarm.ReadOnly = true;
            this.NegAlarm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NegAlarm.Width = 80;
            // 
            // GroupName
            // 
            this.GroupName.DataPropertyName = "GroupName";
            this.GroupName.HeaderText = "通信组名称";
            this.GroupName.Name = "GroupName";
            this.GroupName.ReadOnly = true;
            this.GroupName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GroupName.Width = 160;
            // 
            // Remark
            // 
            this.Remark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "备注说明";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            this.Remark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delete.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.btn_Delete.ForeColor = System.Drawing.Color.White;
            this.btn_Delete.Location = new System.Drawing.Point(1127, 235);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(108, 38);
            this.btn_Delete.TabIndex = 28;
            this.btn_Delete.Text = "删除变量";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 13.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(41, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 26);
            this.label1.TabIndex = 16;
            this.label1.Text = "通信组名称：";
            // 
            // btn_Modify
            // 
            this.btn_Modify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_Modify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Modify.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.btn_Modify.ForeColor = System.Drawing.Color.White;
            this.btn_Modify.Location = new System.Drawing.Point(1306, 235);
            this.btn_Modify.Name = "btn_Modify";
            this.btn_Modify.Size = new System.Drawing.Size(108, 38);
            this.btn_Modify.TabIndex = 27;
            this.btn_Modify.Text = "修改变量";
            this.btn_Modify.UseVisualStyleBackColor = false;
            this.btn_Modify.Click += new System.EventHandler(this.btn_Modify_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.btn_Add.ForeColor = System.Drawing.Color.White;
            this.btn_Add.Location = new System.Drawing.Point(947, 235);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(108, 38);
            this.btn_Add.TabIndex = 26;
            this.btn_Add.Text = "新增变量";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 13.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(728, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 26);
            this.label3.TabIndex = 18;
            this.label3.Text = "组内变量起始索引：";
            // 
            // txt_Remark
            // 
            this.txt_Remark.Font = new System.Drawing.Font("微软雅黑", 13.5F);
            this.txt_Remark.Location = new System.Drawing.Point(154, 238);
            this.txt_Remark.Name = "txt_Remark";
            this.txt_Remark.Size = new System.Drawing.Size(716, 31);
            this.txt_Remark.TabIndex = 25;
            this.txt_Remark.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 13.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(40, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 26);
            this.label6.TabIndex = 24;
            this.label6.Text = "备注说明：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 13.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(1060, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(249, 26);
            this.label4.TabIndex = 20;
            this.label4.Text = "字节内位偏移/字符串长度：";
            // 
            // cmb_DataType
            // 
            this.cmb_DataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_DataType.Font = new System.Drawing.Font("微软雅黑", 13.5F);
            this.cmb_DataType.FormattingEnabled = true;
            this.cmb_DataType.Location = new System.Drawing.Point(160, 173);
            this.cmb_DataType.Name = "cmb_DataType";
            this.cmb_DataType.Size = new System.Drawing.Size(200, 32);
            this.cmb_DataType.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 13.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(40, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 26);
            this.label5.TabIndex = 22;
            this.label5.Text = "数据类型：";
            // 
            // TopPanel
            // 
            this.TopPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TopPanel.Controls.Add(this.btn_Quit);
            this.TopPanel.Controls.Add(this.label2);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1458, 82);
            this.TopPanel.TabIndex = 0;
            this.TopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.TopPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // btn_Quit
            // 
            this.btn_Quit.BackColor = System.Drawing.Color.Transparent;
            this.btn_Quit.FlatAppearance.BorderSize = 0;
            this.btn_Quit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Quit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Quit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Quit.Font = new System.Drawing.Font("微软雅黑", 20.5F);
            this.btn_Quit.ForeColor = System.Drawing.Color.White;
            this.btn_Quit.Location = new System.Drawing.Point(1375, 5);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(87, 72);
            this.btn_Quit.TabIndex = 7;
            this.btn_Quit.Text = "X";
            this.btn_Quit.UseVisualStyleBackColor = false;
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 20.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(24, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 37);
            this.label2.TabIndex = 5;
            this.label2.Text = "变量配置";
            // 
            // FrmVariableConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1458, 788);
            this.Controls.Add(this.panelEnhanced1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmVariableConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmGroupConfig2";
            this.panelEnhanced1.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Offset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Scale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_OffsetOrLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Start)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).EndInit();
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MTHControlLib.PanelEnhanced panelEnhanced1;
        private MTHControlLib.PanelEx panelEx1;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Quit;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Modify;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Remark;
        private System.Windows.Forms.NumericUpDown num_Start;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_DataType;
        private System.Windows.Forms.NumericUpDown num_OffsetOrLength;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_Main;
        private System.Windows.Forms.ComboBox cmb_GroupName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_VarName;
        private MTHControlLib.CheckBoxEx chk_PosAlarm;
        private MTHControlLib.CheckBoxEx chk_NegAlarm;
        private System.Windows.Forms.NumericUpDown num_Scale;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown num_Offset;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn VarName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Start;
        private System.Windows.Forms.DataGridViewTextBoxColumn OffsetOrLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataType;
        private new System.Windows.Forms.DataGridViewTextBoxColumn Scale;
        private System.Windows.Forms.DataGridViewTextBoxColumn Offset;
        private System.Windows.Forms.DataGridViewTextBoxColumn PosAlarm;
        private System.Windows.Forms.DataGridViewTextBoxColumn NegAlarm;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
    }
}