namespace Wang.MTHProject
{
    partial class FrmRecipe
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            Wang.MTHModels.RecipeParam recipeParam7 = new Wang.MTHModels.RecipeParam();
            Wang.MTHModels.RecipeParam recipeParam8 = new Wang.MTHModels.RecipeParam();
            Wang.MTHModels.RecipeParam recipeParam9 = new Wang.MTHModels.RecipeParam();
            Wang.MTHModels.RecipeParam recipeParam10 = new Wang.MTHModels.RecipeParam();
            Wang.MTHModels.RecipeParam recipeParam11 = new Wang.MTHModels.RecipeParam();
            Wang.MTHModels.RecipeParam recipeParam12 = new Wang.MTHModels.RecipeParam();
            this.panelEnhanced1 = new Wang.MTHControlLib.PanelEnhanced();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_Apply = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Modify = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.txt_RecipeName = new System.Windows.Forms.TextBox();
            this.lbl_CurrentRecipe = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_Main = new System.Windows.Forms.DataGridView();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recipeControl_6 = new Wang.MTHControlLib.RecipeControl();
            this.recipeControl_3 = new Wang.MTHControlLib.RecipeControl();
            this.recipeControl_5 = new Wang.MTHControlLib.RecipeControl();
            this.recipeControl_2 = new Wang.MTHControlLib.RecipeControl();
            this.recipeControl_4 = new Wang.MTHControlLib.RecipeControl();
            this.recipeControl_1 = new Wang.MTHControlLib.RecipeControl();
            this.panelEnhanced1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEnhanced1
            // 
            this.panelEnhanced1.BackgroundImage = global::Wang.MTHProject.Properties.Resources.BackGround;
            this.panelEnhanced1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelEnhanced1.Controls.Add(this.splitContainer1);
            this.panelEnhanced1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEnhanced1.Location = new System.Drawing.Point(0, 0);
            this.panelEnhanced1.Name = "panelEnhanced1";
            this.panelEnhanced1.Size = new System.Drawing.Size(1394, 736);
            this.panelEnhanced1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel1.Controls.Add(this.btn_Apply);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Delete);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Modify);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Add);
            this.splitContainer1.Panel1.Controls.Add(this.txt_RecipeName);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_CurrentRecipe);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.dgv_Main);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel2.Controls.Add(this.recipeControl_6);
            this.splitContainer1.Panel2.Controls.Add(this.recipeControl_3);
            this.splitContainer1.Panel2.Controls.Add(this.recipeControl_5);
            this.splitContainer1.Panel2.Controls.Add(this.recipeControl_2);
            this.splitContainer1.Panel2.Controls.Add(this.recipeControl_4);
            this.splitContainer1.Panel2.Controls.Add(this.recipeControl_1);
            this.splitContainer1.Size = new System.Drawing.Size(1394, 736);
            this.splitContainer1.SplitterDistance = 341;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // btn_Apply
            // 
            this.btn_Apply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_Apply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Apply.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.btn_Apply.ForeColor = System.Drawing.Color.White;
            this.btn_Apply.Location = new System.Drawing.Point(202, 668);
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.Size = new System.Drawing.Size(108, 38);
            this.btn_Apply.TabIndex = 38;
            this.btn_Apply.Text = "应用配方";
            this.btn_Apply.UseVisualStyleBackColor = false;
            this.btn_Apply.Click += new System.EventHandler(this.btn_Apply_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delete.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.btn_Delete.ForeColor = System.Drawing.Color.White;
            this.btn_Delete.Location = new System.Drawing.Point(33, 668);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(108, 38);
            this.btn_Delete.TabIndex = 37;
            this.btn_Delete.Text = "删除配方";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Modify
            // 
            this.btn_Modify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_Modify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Modify.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.btn_Modify.ForeColor = System.Drawing.Color.White;
            this.btn_Modify.Location = new System.Drawing.Point(202, 592);
            this.btn_Modify.Name = "btn_Modify";
            this.btn_Modify.Size = new System.Drawing.Size(108, 38);
            this.btn_Modify.TabIndex = 36;
            this.btn_Modify.Text = "修改配方";
            this.btn_Modify.UseVisualStyleBackColor = false;
            this.btn_Modify.Click += new System.EventHandler(this.btn_Modify_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.btn_Add.ForeColor = System.Drawing.Color.White;
            this.btn_Add.Location = new System.Drawing.Point(33, 592);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(108, 38);
            this.btn_Add.TabIndex = 35;
            this.btn_Add.Text = "添加配方";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // txt_RecipeName
            // 
            this.txt_RecipeName.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.txt_RecipeName.Location = new System.Drawing.Point(126, 522);
            this.txt_RecipeName.Name = "txt_RecipeName";
            this.txt_RecipeName.Size = new System.Drawing.Size(184, 29);
            this.txt_RecipeName.TabIndex = 34;
            this.txt_RecipeName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_CurrentRecipe
            // 
            this.lbl_CurrentRecipe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_CurrentRecipe.ForeColor = System.Drawing.Color.White;
            this.lbl_CurrentRecipe.Location = new System.Drawing.Point(125, 453);
            this.lbl_CurrentRecipe.Name = "lbl_CurrentRecipe";
            this.lbl_CurrentRecipe.Size = new System.Drawing.Size(185, 44);
            this.lbl_CurrentRecipe.TabIndex = 33;
            this.lbl_CurrentRecipe.Text = "THPR";
            this.lbl_CurrentRecipe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(29, 526);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 32;
            this.label2.Text = "配方名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(29, 465);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 31;
            this.label1.Text = "当前配方：";
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Main.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Main.ColumnHeadersHeight = 35;
            this.dgv_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupName,
            this.StartAddress});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(40)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Main.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_Main.EnableHeadersVisualStyles = false;
            this.dgv_Main.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(146)))), ((int)(((byte)(235)))));
            this.dgv_Main.Location = new System.Drawing.Point(29, 12);
            this.dgv_Main.Name = "dgv_Main";
            this.dgv_Main.ReadOnly = true;
            this.dgv_Main.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(40)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(40)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Main.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_Main.RowHeadersVisible = false;
            this.dgv_Main.RowHeadersWidth = 50;
            this.dgv_Main.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_Main.RowTemplate.Height = 40;
            this.dgv_Main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Main.Size = new System.Drawing.Size(281, 407);
            this.dgv_Main.TabIndex = 30;
            this.dgv_Main.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Main_CellClick);
            this.dgv_Main.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_Main_EditingControlShowing);
            // 
            // GroupName
            // 
            this.GroupName.DataPropertyName = "GroupName";
            this.GroupName.HeaderText = "序号";
            this.GroupName.Name = "GroupName";
            this.GroupName.ReadOnly = true;
            this.GroupName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // StartAddress
            // 
            this.StartAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StartAddress.DataPropertyName = "StartAddress";
            this.StartAddress.HeaderText = "配方名称";
            this.StartAddress.Name = "StartAddress";
            this.StartAddress.ReadOnly = true;
            this.StartAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // recipeControl_6
            // 
            this.recipeControl_6.BackColor = System.Drawing.Color.Transparent;
            this.recipeControl_6.DevName = "6#站点";
            this.recipeControl_6.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.recipeControl_6.Location = new System.Drawing.Point(706, 382);
            this.recipeControl_6.Margin = new System.Windows.Forms.Padding(5);
            this.recipeControl_6.Name = "recipeControl_6";
            recipeParam7.HumidityAlarmEnable = false;
            recipeParam7.HumidityHighLimit = 0F;
            recipeParam7.HumidityLowLimit = 0F;
            recipeParam7.TempAlarmEnable = false;
            recipeParam7.TempHighLimit = 0F;
            recipeParam7.TempLowLimit = 0F;
            this.recipeControl_6.RecipeParam = recipeParam7;
            this.recipeControl_6.Size = new System.Drawing.Size(319, 312);
            this.recipeControl_6.TabIndex = 5;
            // 
            // recipeControl_3
            // 
            this.recipeControl_3.BackColor = System.Drawing.Color.Transparent;
            this.recipeControl_3.DevName = "3#站点";
            this.recipeControl_3.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.recipeControl_3.Location = new System.Drawing.Point(706, 12);
            this.recipeControl_3.Margin = new System.Windows.Forms.Padding(5);
            this.recipeControl_3.Name = "recipeControl_3";
            recipeParam8.HumidityAlarmEnable = false;
            recipeParam8.HumidityHighLimit = 0F;
            recipeParam8.HumidityLowLimit = 0F;
            recipeParam8.TempAlarmEnable = false;
            recipeParam8.TempHighLimit = 0F;
            recipeParam8.TempLowLimit = 0F;
            this.recipeControl_3.RecipeParam = recipeParam8;
            this.recipeControl_3.Size = new System.Drawing.Size(319, 312);
            this.recipeControl_3.TabIndex = 4;
            // 
            // recipeControl_5
            // 
            this.recipeControl_5.BackColor = System.Drawing.Color.Transparent;
            this.recipeControl_5.DevName = "5#站点";
            this.recipeControl_5.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.recipeControl_5.Location = new System.Drawing.Point(360, 382);
            this.recipeControl_5.Margin = new System.Windows.Forms.Padding(5);
            this.recipeControl_5.Name = "recipeControl_5";
            recipeParam9.HumidityAlarmEnable = false;
            recipeParam9.HumidityHighLimit = 0F;
            recipeParam9.HumidityLowLimit = 0F;
            recipeParam9.TempAlarmEnable = false;
            recipeParam9.TempHighLimit = 0F;
            recipeParam9.TempLowLimit = 0F;
            this.recipeControl_5.RecipeParam = recipeParam9;
            this.recipeControl_5.Size = new System.Drawing.Size(321, 312);
            this.recipeControl_5.TabIndex = 3;
            // 
            // recipeControl_2
            // 
            this.recipeControl_2.BackColor = System.Drawing.Color.Transparent;
            this.recipeControl_2.DevName = "2#站点";
            this.recipeControl_2.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.recipeControl_2.Location = new System.Drawing.Point(360, 12);
            this.recipeControl_2.Margin = new System.Windows.Forms.Padding(5);
            this.recipeControl_2.Name = "recipeControl_2";
            recipeParam10.HumidityAlarmEnable = false;
            recipeParam10.HumidityHighLimit = 0F;
            recipeParam10.HumidityLowLimit = 0F;
            recipeParam10.TempAlarmEnable = false;
            recipeParam10.TempHighLimit = 0F;
            recipeParam10.TempLowLimit = 0F;
            this.recipeControl_2.RecipeParam = recipeParam10;
            this.recipeControl_2.Size = new System.Drawing.Size(321, 312);
            this.recipeControl_2.TabIndex = 2;
            // 
            // recipeControl_4
            // 
            this.recipeControl_4.BackColor = System.Drawing.Color.Transparent;
            this.recipeControl_4.DevName = "4#站点";
            this.recipeControl_4.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.recipeControl_4.Location = new System.Drawing.Point(28, 382);
            this.recipeControl_4.Margin = new System.Windows.Forms.Padding(5);
            this.recipeControl_4.Name = "recipeControl_4";
            recipeParam11.HumidityAlarmEnable = false;
            recipeParam11.HumidityHighLimit = 0F;
            recipeParam11.HumidityLowLimit = 0F;
            recipeParam11.TempAlarmEnable = false;
            recipeParam11.TempHighLimit = 0F;
            recipeParam11.TempLowLimit = 0F;
            this.recipeControl_4.RecipeParam = recipeParam11;
            this.recipeControl_4.Size = new System.Drawing.Size(322, 312);
            this.recipeControl_4.TabIndex = 1;
            // 
            // recipeControl_1
            // 
            this.recipeControl_1.BackColor = System.Drawing.Color.Transparent;
            this.recipeControl_1.DevName = "1#站点";
            this.recipeControl_1.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.recipeControl_1.Location = new System.Drawing.Point(28, 12);
            this.recipeControl_1.Margin = new System.Windows.Forms.Padding(5);
            this.recipeControl_1.Name = "recipeControl_1";
            recipeParam12.HumidityAlarmEnable = false;
            recipeParam12.HumidityHighLimit = 0F;
            recipeParam12.HumidityLowLimit = 0F;
            recipeParam12.TempAlarmEnable = false;
            recipeParam12.TempHighLimit = 0F;
            recipeParam12.TempLowLimit = 0F;
            this.recipeControl_1.RecipeParam = recipeParam12;
            this.recipeControl_1.Size = new System.Drawing.Size(322, 312);
            this.recipeControl_1.TabIndex = 0;
            // 
            // FrmRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1394, 736);
            this.Controls.Add(this.panelEnhanced1);
            this.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmRecipe";
            this.Text = "配方管理";
            this.panelEnhanced1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MTHControlLib.PanelEnhanced panelEnhanced1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgv_Main;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_CurrentRecipe;
        private System.Windows.Forms.TextBox txt_RecipeName;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Apply;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Modify;
        private MTHControlLib.RecipeControl recipeControl_1;
        private MTHControlLib.RecipeControl recipeControl_4;
        private MTHControlLib.RecipeControl recipeControl_3;
        private MTHControlLib.RecipeControl recipeControl_5;
        private MTHControlLib.RecipeControl recipeControl_2;
        private MTHControlLib.RecipeControl recipeControl_6;
    }
}