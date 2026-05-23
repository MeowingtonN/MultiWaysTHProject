namespace Wang.MTHControlLib
{
    partial class THMControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_Title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Temp = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Humidity = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dialPlate = new Wang.MTHControlLib.DialPlate();
            this.SuspendLayout();
            // 
            // lbl_Title
            // 
            this.lbl_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(184)))), ((int)(((byte)(196)))));
            this.lbl_Title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Title.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.lbl_Title.ForeColor = System.Drawing.Color.White;
            this.lbl_Title.Location = new System.Drawing.Point(-1, 0);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(81, 35);
            this.lbl_Title.TabIndex = 1;
            this.lbl_Title.Text = "1#站点";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "温度：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Temp
            // 
            this.lbl_Temp.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Temp.Font = new System.Drawing.Font("微软雅黑", 13.75F, System.Drawing.FontStyle.Bold);
            this.lbl_Temp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(184)))), ((int)(((byte)(196)))));
            this.lbl_Temp.Location = new System.Drawing.Point(61, 168);
            this.lbl_Temp.Name = "lbl_Temp";
            this.lbl_Temp.Size = new System.Drawing.Size(70, 41);
            this.lbl_Temp.TabIndex = 3;
            this.lbl_Temp.Text = "0.0";
            this.lbl_Temp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 13.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(184)))), ((int)(((byte)(196)))));
            this.label3.Location = new System.Drawing.Point(125, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "℃";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 13.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(184)))), ((int)(((byte)(196)))));
            this.label2.Location = new System.Drawing.Point(294, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 26);
            this.label2.TabIndex = 7;
            this.label2.Text = "％";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Humidity
            // 
            this.lbl_Humidity.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Humidity.Font = new System.Drawing.Font("微软雅黑", 13.75F, System.Drawing.FontStyle.Bold);
            this.lbl_Humidity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(184)))), ((int)(((byte)(196)))));
            this.lbl_Humidity.Location = new System.Drawing.Point(229, 168);
            this.lbl_Humidity.Name = "lbl_Humidity";
            this.lbl_Humidity.Size = new System.Drawing.Size(70, 41);
            this.lbl_Humidity.TabIndex = 6;
            this.lbl_Humidity.Text = "0.0";
            this.lbl_Humidity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12.5F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(184, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 23);
            this.label5.TabIndex = 5;
            this.label5.Text = "湿度：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dialPlate
            // 
            this.dialPlate.AlarmAngle = 120F;
            this.dialPlate.AlarmColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(184)))), ((int)(((byte)(196)))));
            this.dialPlate.BackColor = System.Drawing.Color.Transparent;
            this.dialPlate.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dialPlate.ForeColor = System.Drawing.Color.White;
            this.dialPlate.Humidity = 0F;
            this.dialPlate.HumidityColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(184)))), ((int)(((byte)(196)))));
            this.dialPlate.HumidityScale = 0.35F;
            this.dialPlate.InnerThickness = 16;
            this.dialPlate.Location = new System.Drawing.Point(30, 6);
            this.dialPlate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dialPlate.Name = "dialPlate";
            this.dialPlate.OuterRingColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.dialPlate.OuterThickness = 8;
            this.dialPlate.RangeMax = 90F;
            this.dialPlate.RangeMin = 0F;
            this.dialPlate.Size = new System.Drawing.Size(283, 163);
            this.dialPlate.TabIndex = 0;
            this.dialPlate.TempColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(184)))), ((int)(((byte)(196)))));
            this.dialPlate.Temperature = 0F;
            this.dialPlate.TempScale = 0.65F;
            this.dialPlate.TextScale = 0.85F;
            // 
            // THMControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.Controls.Add(this.lbl_Humidity);
            this.Controls.Add(this.lbl_Temp);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dialPlate);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "THMControl";
            this.Size = new System.Drawing.Size(338, 215);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DialPlate dialPlate;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Temp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_Humidity;
        private System.Windows.Forms.Label label5;
    }
}
