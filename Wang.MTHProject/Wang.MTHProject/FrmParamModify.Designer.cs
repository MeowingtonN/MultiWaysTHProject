namespace Wang.MTHProject
{
    partial class FrmParamModify
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
            this.panelEnhanced = new Wang.MTHControlLib.PanelEnhanced();
            this.panelEx = new Wang.MTHControlLib.PanelEx();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Ack = new System.Windows.Forms.Button();
            this.txt_SetValue = new System.Windows.Forms.TextBox();
            this.lbl_CurrentValue = new System.Windows.Forms.Label();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.panelEnhanced.SuspendLayout();
            this.panelEx.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEnhanced
            // 
            this.panelEnhanced.BackgroundImage = global::Wang.MTHProject.Properties.Resources.TitleBG;
            this.panelEnhanced.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelEnhanced.Controls.Add(this.panelEx);
            this.panelEnhanced.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEnhanced.Location = new System.Drawing.Point(0, 0);
            this.panelEnhanced.Name = "panelEnhanced";
            this.panelEnhanced.Size = new System.Drawing.Size(611, 407);
            this.panelEnhanced.TabIndex = 0;
            // 
            // panelEx
            // 
            this.panelEx.BackColor = System.Drawing.Color.Transparent;
            this.panelEx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelEx.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(79)))), ((int)(((byte)(150)))));
            this.panelEx.BorderWidth = 2;
            this.panelEx.BottomGap = 1;
            this.panelEx.Controls.Add(this.btn_Cancel);
            this.panelEx.Controls.Add(this.btn_Ack);
            this.panelEx.Controls.Add(this.txt_SetValue);
            this.panelEx.Controls.Add(this.lbl_CurrentValue);
            this.panelEx.Controls.Add(this.lbl_Title);
            this.panelEx.Controls.Add(this.label4);
            this.panelEx.Controls.Add(this.label3);
            this.panelEx.Controls.Add(this.label1);
            this.panelEx.Controls.Add(this.label2);
            this.panelEx.Controls.Add(this.btn_Quit);
            this.panelEx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx.LeftGap = 1;
            this.panelEx.Location = new System.Drawing.Point(0, 0);
            this.panelEx.Name = "panelEx";
            this.panelEx.RightGap = 1;
            this.panelEx.Size = new System.Drawing.Size(611, 407);
            this.panelEx.TabIndex = 0;
            this.panelEx.TopGap = 1;
            this.panelEx.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.panelEx.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.btn_Cancel.ForeColor = System.Drawing.Color.White;
            this.btn_Cancel.Location = new System.Drawing.Point(385, 334);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(163, 38);
            this.btn_Cancel.TabIndex = 17;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Ack
            // 
            this.btn_Ack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_Ack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Ack.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.btn_Ack.ForeColor = System.Drawing.Color.White;
            this.btn_Ack.Location = new System.Drawing.Point(54, 334);
            this.btn_Ack.Name = "btn_Ack";
            this.btn_Ack.Size = new System.Drawing.Size(163, 38);
            this.btn_Ack.TabIndex = 16;
            this.btn_Ack.Text = "确定";
            this.btn_Ack.UseVisualStyleBackColor = false;
            this.btn_Ack.Click += new System.EventHandler(this.btn_Ack_Click);
            // 
            // txt_SetValue
            // 
            this.txt_SetValue.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.txt_SetValue.Location = new System.Drawing.Point(185, 258);
            this.txt_SetValue.Name = "txt_SetValue";
            this.txt_SetValue.Size = new System.Drawing.Size(338, 35);
            this.txt_SetValue.TabIndex = 14;
            this.txt_SetValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_SetValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_SetValue_KeyDown);
            // 
            // lbl_CurrentValue
            // 
            this.lbl_CurrentValue.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_CurrentValue.ForeColor = System.Drawing.Color.White;
            this.lbl_CurrentValue.Location = new System.Drawing.Point(217, 156);
            this.lbl_CurrentValue.Name = "lbl_CurrentValue";
            this.lbl_CurrentValue.Size = new System.Drawing.Size(270, 52);
            this.lbl_CurrentValue.TabIndex = 13;
            this.lbl_CurrentValue.Text = "0.0";
            this.lbl_CurrentValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Title
            // 
            this.lbl_Title.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Title.ForeColor = System.Drawing.Color.White;
            this.lbl_Title.Location = new System.Drawing.Point(217, 69);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(270, 52);
            this.lbl_Title.TabIndex = 12;
            this.lbl_Title.Text = "1#站点温度高限";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(62, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 28);
            this.label4.TabIndex = 11;
            this.label4.Text = "当前值：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(62, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 28);
            this.label3.TabIndex = 10;
            this.label3.Text = "修改值：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(62, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 28);
            this.label1.TabIndex = 9;
            this.label1.Text = "参数名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 16.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 31);
            this.label2.TabIndex = 6;
            this.label2.Text = "限值参数修改";
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
            this.btn_Quit.Location = new System.Drawing.Point(549, 3);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(60, 47);
            this.btn_Quit.TabIndex = 8;
            this.btn_Quit.Text = "X";
            this.btn_Quit.UseVisualStyleBackColor = false;
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // FrmParamModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 407);
            this.Controls.Add(this.panelEnhanced);
            this.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmParamModify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "参数修改";
            this.panelEnhanced.ResumeLayout(false);
            this.panelEx.ResumeLayout(false);
            this.panelEx.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MTHControlLib.PanelEnhanced panelEnhanced;
        private MTHControlLib.PanelEx panelEx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Quit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Label lbl_CurrentValue;
        private System.Windows.Forms.TextBox txt_SetValue;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Ack;
    }
}