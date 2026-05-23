namespace Wang.MTHProject
{
    partial class FrmGroupConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGroupConfig));
            this.panelEnhanced1 = new Wang.MTHControlLib.PanelEnhanced();
            this.panelEx1 = new Wang.MTHControlLib.PanelEx();
            this.num_Length = new System.Windows.Forms.NumericUpDown();
            this.dgv_Main = new System.Windows.Forms.DataGridView();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Modify = new System.Windows.Forms.Button();
            this.txt_GroupName = new System.Windows.Forms.TextBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Remark = new System.Windows.Forms.TextBox();
            this.num_StartAddress = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_StoreArea = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panelEnhanced1.SuspendLayout();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Length)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_StartAddress)).BeginInit();
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
            this.panelEnhanced1.Size = new System.Drawing.Size(1406, 788);
            this.panelEnhanced1.TabIndex = 0;
            // 
            // panelEx1
            // 
            this.panelEx1.BackColor = System.Drawing.Color.Transparent;
            this.panelEx1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(79)))), ((int)(((byte)(150)))));
            this.panelEx1.BorderWidth = 2;
            this.panelEx1.BottomGap = 1;
            this.panelEx1.Controls.Add(this.num_Length);
            this.panelEx1.Controls.Add(this.dgv_Main);
            this.panelEx1.Controls.Add(this.btn_Delete);
            this.panelEx1.Controls.Add(this.label1);
            this.panelEx1.Controls.Add(this.btn_Modify);
            this.panelEx1.Controls.Add(this.txt_GroupName);
            this.panelEx1.Controls.Add(this.btn_Add);
            this.panelEx1.Controls.Add(this.label3);
            this.panelEx1.Controls.Add(this.txt_Remark);
            this.panelEx1.Controls.Add(this.num_StartAddress);
            this.panelEx1.Controls.Add(this.label6);
            this.panelEx1.Controls.Add(this.label4);
            this.panelEx1.Controls.Add(this.cmb_StoreArea);
            this.panelEx1.Controls.Add(this.label5);
            this.panelEx1.Controls.Add(this.TopPanel);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.panelEx1.LeftGap = 1;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.RightGap = 1;
            this.panelEx1.Size = new System.Drawing.Size(1406, 788);
            this.panelEx1.TabIndex = 0;
            this.panelEx1.TopGap = 1;
            // 
            // num_Length
            // 
            this.num_Length.Font = new System.Drawing.Font("微软雅黑", 13.5F);
            this.num_Length.Location = new System.Drawing.Point(870, 102);
            this.num_Length.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.num_Length.Name = "num_Length";
            this.num_Length.Size = new System.Drawing.Size(120, 31);
            this.num_Length.TabIndex = 21;
            this.num_Length.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
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
            this.GroupName,
            this.StartAddress,
            this.Length,
            this.StoreArea,
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
            this.dgv_Main.Location = new System.Drawing.Point(44, 221);
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
            this.dgv_Main.Size = new System.Drawing.Size(1319, 537);
            this.dgv_Main.TabIndex = 29;
            this.dgv_Main.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Main_CellClick);
            this.dgv_Main.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_Main_CellFormatting);
            this.dgv_Main.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_Main_EditingControlShowing);
            this.dgv_Main.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_Main_RowPostPaint);
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
            // StartAddress
            // 
            this.StartAddress.DataPropertyName = "StartAddress";
            this.StartAddress.HeaderText = "硬件起始地址";
            this.StartAddress.Name = "StartAddress";
            this.StartAddress.ReadOnly = true;
            this.StartAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StartAddress.Width = 140;
            // 
            // Length
            // 
            this.Length.DataPropertyName = "Length";
            this.Length.HeaderText = "长度";
            this.Length.Name = "Length";
            this.Length.ReadOnly = true;
            this.Length.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // StoreArea
            // 
            this.StoreArea.DataPropertyName = "StoreArea";
            this.StoreArea.HeaderText = "存储区名称";
            this.StoreArea.Name = "StoreArea";
            this.StoreArea.ReadOnly = true;
            this.StoreArea.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StoreArea.Width = 160;
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
            this.btn_Delete.Location = new System.Drawing.Point(1056, 163);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(108, 38);
            this.btn_Delete.TabIndex = 28;
            this.btn_Delete.Text = "删除通信组";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 13.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(39, 104);
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
            this.btn_Modify.Location = new System.Drawing.Point(1255, 162);
            this.btn_Modify.Name = "btn_Modify";
            this.btn_Modify.Size = new System.Drawing.Size(108, 38);
            this.btn_Modify.TabIndex = 27;
            this.btn_Modify.Text = "修改通信组";
            this.btn_Modify.UseVisualStyleBackColor = false;
            this.btn_Modify.Click += new System.EventHandler(this.btn_Modify_Click);
            // 
            // txt_GroupName
            // 
            this.txt_GroupName.Font = new System.Drawing.Font("微软雅黑", 13.5F);
            this.txt_GroupName.Location = new System.Drawing.Point(169, 102);
            this.txt_GroupName.Name = "txt_GroupName";
            this.txt_GroupName.Size = new System.Drawing.Size(177, 31);
            this.txt_GroupName.TabIndex = 17;
            this.txt_GroupName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.btn_Add.ForeColor = System.Drawing.Color.White;
            this.btn_Add.Location = new System.Drawing.Point(853, 163);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(108, 38);
            this.btn_Add.TabIndex = 26;
            this.btn_Add.Text = "新增通信组";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 13.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(387, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 26);
            this.label3.TabIndex = 18;
            this.label3.Text = "硬件起始地址：";
            // 
            // txt_Remark
            // 
            this.txt_Remark.Font = new System.Drawing.Font("微软雅黑", 13.5F);
            this.txt_Remark.Location = new System.Drawing.Point(161, 166);
            this.txt_Remark.Name = "txt_Remark";
            this.txt_Remark.Size = new System.Drawing.Size(623, 31);
            this.txt_Remark.TabIndex = 25;
            this.txt_Remark.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // num_StartAddress
            // 
            this.num_StartAddress.Font = new System.Drawing.Font("微软雅黑", 13.5F);
            this.num_StartAddress.Location = new System.Drawing.Point(539, 102);
            this.num_StartAddress.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.num_StartAddress.Name = "num_StartAddress";
            this.num_StartAddress.Size = new System.Drawing.Size(120, 31);
            this.num_StartAddress.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 13.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(39, 168);
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
            this.label4.Location = new System.Drawing.Point(698, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 26);
            this.label4.TabIndex = 20;
            this.label4.Text = "线圈/寄存器个数：";
            // 
            // cmb_StoreArea
            // 
            this.cmb_StoreArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_StoreArea.Font = new System.Drawing.Font("微软雅黑", 13.5F);
            this.cmb_StoreArea.FormattingEnabled = true;
            this.cmb_StoreArea.Location = new System.Drawing.Point(1172, 101);
            this.cmb_StoreArea.Name = "cmb_StoreArea";
            this.cmb_StoreArea.Size = new System.Drawing.Size(191, 32);
            this.cmb_StoreArea.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 13.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1051, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 26);
            this.label5.TabIndex = 22;
            this.label5.Text = "存储区名称：";
            // 
            // TopPanel
            // 
            this.TopPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TopPanel.Controls.Add(this.btn_Quit);
            this.TopPanel.Controls.Add(this.label2);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1406, 82);
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
            this.btn_Quit.Location = new System.Drawing.Point(1321, 5);
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
            this.label2.Size = new System.Drawing.Size(157, 37);
            this.label2.TabIndex = 5;
            this.label2.Text = "通信组配置";
            // 
            // FrmGroupConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1406, 788);
            this.Controls.Add(this.panelEnhanced1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmGroupConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmGroupConfig2";
            this.panelEnhanced1.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Length)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_StartAddress)).EndInit();
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
        private System.Windows.Forms.TextBox txt_GroupName;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Remark;
        private System.Windows.Forms.NumericUpDown num_StartAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_StoreArea;
        private System.Windows.Forms.NumericUpDown num_Length;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_Main;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
    }
}