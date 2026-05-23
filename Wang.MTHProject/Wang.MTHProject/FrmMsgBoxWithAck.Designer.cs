namespace Wang.MTHProject
{
    partial class FrmMsgBoxWithAck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMsgBoxWithAck));
            this.lbl_Title = new System.Windows.Forms.Label();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.lbl_Content = new System.Windows.Forms.Label();
            this.btn_Ack = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Title.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold);
            this.lbl_Title.ForeColor = System.Drawing.Color.White;
            this.lbl_Title.Location = new System.Drawing.Point(10, 3);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(96, 28);
            this.lbl_Title.TabIndex = 5;
            this.lbl_Title.Text = "退出系统";
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
            this.btn_Quit.Location = new System.Drawing.Point(354, -5);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(34, 42);
            this.btn_Quit.TabIndex = 7;
            this.btn_Quit.Text = "X";
            this.btn_Quit.UseVisualStyleBackColor = false;
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // lbl_Content
            // 
            this.lbl_Content.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Content.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lbl_Content.ForeColor = System.Drawing.Color.White;
            this.lbl_Content.Location = new System.Drawing.Point(10, 58);
            this.lbl_Content.Name = "lbl_Content";
            this.lbl_Content.Size = new System.Drawing.Size(367, 158);
            this.lbl_Content.TabIndex = 8;
            this.lbl_Content.Text = "是否确认要退出系统？";
            this.lbl_Content.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Ack
            // 
            this.btn_Ack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_Ack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Ack.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.btn_Ack.ForeColor = System.Drawing.Color.White;
            this.btn_Ack.Location = new System.Drawing.Point(28, 230);
            this.btn_Ack.Name = "btn_Ack";
            this.btn_Ack.Size = new System.Drawing.Size(108, 38);
            this.btn_Ack.TabIndex = 14;
            this.btn_Ack.Text = "确定";
            this.btn_Ack.UseVisualStyleBackColor = false;
            this.btn_Ack.Click += new System.EventHandler(this.btn_Ack_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.btn_Cancel.ForeColor = System.Drawing.Color.White;
            this.btn_Cancel.Location = new System.Drawing.Point(243, 230);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(108, 38);
            this.btn_Cancel.TabIndex = 15;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // FrmMsgBoxWithAck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Wang.MTHProject.Properties.Resources.TitleBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(389, 293);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Ack);
            this.Controls.Add(this.lbl_Content);
            this.Controls.Add(this.btn_Quit);
            this.Controls.Add(this.lbl_Title);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmMsgBoxWithAck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMsgBoxWithAck";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Button btn_Quit;
        private System.Windows.Forms.Label lbl_Content;
        private System.Windows.Forms.Button btn_Ack;
        private System.Windows.Forms.Button btn_Cancel;
    }
}