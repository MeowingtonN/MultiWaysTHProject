namespace Wang.MTHProject
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_LoginName = new System.Windows.Forms.TextBox();
            this.txt_Pwd = new System.Windows.Forms.TextBox();
            this.btn_Login = new System.Windows.Forms.Button();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12.5F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "多温湿度采集监控系统";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(113, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(237, 1);
            this.label2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(113, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(237, 1);
            this.label3.TabIndex = 2;
            // 
            // txt_LoginName
            // 
            this.txt_LoginName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(85)))));
            this.txt_LoginName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_LoginName.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.txt_LoginName.ForeColor = System.Drawing.Color.White;
            this.txt_LoginName.Location = new System.Drawing.Point(117, 138);
            this.txt_LoginName.Name = "txt_LoginName";
            this.txt_LoginName.Size = new System.Drawing.Size(233, 22);
            this.txt_LoginName.TabIndex = 3;
            this.txt_LoginName.Text = "Admin";
            this.txt_LoginName.DoubleClick += new System.EventHandler(this.txt_LoginName_DoubleClick);
            this.txt_LoginName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_LoginName_KeyDown);
            // 
            // txt_Pwd
            // 
            this.txt_Pwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(85)))));
            this.txt_Pwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Pwd.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.txt_Pwd.ForeColor = System.Drawing.Color.White;
            this.txt_Pwd.Location = new System.Drawing.Point(117, 179);
            this.txt_Pwd.Name = "txt_Pwd";
            this.txt_Pwd.PasswordChar = '*';
            this.txt_Pwd.Size = new System.Drawing.Size(233, 22);
            this.txt_Pwd.TabIndex = 4;
            this.txt_Pwd.Text = "123";
            this.txt_Pwd.DoubleClick += new System.EventHandler(this.txt_Pwd_DoubleClick);
            this.txt_Pwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Pwd_KeyDown);
            // 
            // btn_Login
            // 
            this.btn_Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Login.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.btn_Login.ForeColor = System.Drawing.Color.White;
            this.btn_Login.Location = new System.Drawing.Point(88, 223);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(257, 34);
            this.btn_Login.TabIndex = 6;
            this.btn_Login.Text = "登   录";
            this.btn_Login.UseVisualStyleBackColor = false;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
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
            this.btn_Quit.Location = new System.Drawing.Point(393, -2);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(38, 38);
            this.btn_Quit.TabIndex = 8;
            this.btn_Quit.Text = "X";
            this.btn_Quit.UseVisualStyleBackColor = false;
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Wang.MTHProject.Properties.Resources.Login;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(430, 330);
            this.Controls.Add(this.btn_Quit);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.txt_Pwd);
            this.Controls.Add(this.txt_LoginName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLogin";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_LoginName;
        private System.Windows.Forms.TextBox txt_Pwd;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Button btn_Quit;
    }
}