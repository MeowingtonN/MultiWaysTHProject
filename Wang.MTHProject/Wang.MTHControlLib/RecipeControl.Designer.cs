namespace Wang.MTHControlLib
{
    partial class RecipeControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecipeControl));
            this.chk_HumidityAlarmEnable = new Wang.MTHControlLib.CheckBoxEx();
            this.chk_TempAlarmEnable = new Wang.MTHControlLib.CheckBoxEx();
            this.textSetNum_HLo = new Wang.MTHControlLib.TextSetNum();
            this.textSetNum_HHi = new Wang.MTHControlLib.TextSetNum();
            this.textSetNum_TLo = new Wang.MTHControlLib.TextSetNum();
            this.textSetNum_THi = new Wang.MTHControlLib.TextSetNum();
            this.title = new Wang.MTHControlLib.Title();
            this.SuspendLayout();
            // 
            // chk_HumidityAlarmEnable
            // 
            this.chk_HumidityAlarmEnable.CheckBtnBackColor = System.Drawing.Color.White;
            this.chk_HumidityAlarmEnable.CheckBtnBorderColor = System.Drawing.Color.LightGray;
            this.chk_HumidityAlarmEnable.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_HumidityAlarmEnable.DefaultCheckButtonWidth = 20;
            this.chk_HumidityAlarmEnable.ForeColor = System.Drawing.Color.White;
            this.chk_HumidityAlarmEnable.Location = new System.Drawing.Point(180, 255);
            this.chk_HumidityAlarmEnable.Name = "chk_HumidityAlarmEnable";
            this.chk_HumidityAlarmEnable.Size = new System.Drawing.Size(134, 38);
            this.chk_HumidityAlarmEnable.TabIndex = 6;
            this.chk_HumidityAlarmEnable.Text = "湿度报警启用";
            this.chk_HumidityAlarmEnable.UseVisualStyleBackColor = true;
            // 
            // chk_TempAlarmEnable
            // 
            this.chk_TempAlarmEnable.CheckBtnBackColor = System.Drawing.Color.White;
            this.chk_TempAlarmEnable.CheckBtnBorderColor = System.Drawing.Color.LightGray;
            this.chk_TempAlarmEnable.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_TempAlarmEnable.DefaultCheckButtonWidth = 20;
            this.chk_TempAlarmEnable.ForeColor = System.Drawing.Color.White;
            this.chk_TempAlarmEnable.Location = new System.Drawing.Point(19, 255);
            this.chk_TempAlarmEnable.Name = "chk_TempAlarmEnable";
            this.chk_TempAlarmEnable.Size = new System.Drawing.Size(134, 38);
            this.chk_TempAlarmEnable.TabIndex = 5;
            this.chk_TempAlarmEnable.Text = "温度报警启用";
            this.chk_TempAlarmEnable.UseVisualStyleBackColor = true;
            // 
            // textSetNum_HLo
            // 
            this.textSetNum_HLo.BackColor = System.Drawing.Color.Transparent;
            this.textSetNum_HLo.CurrentValue = 0F;
            this.textSetNum_HLo.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.textSetNum_HLo.Location = new System.Drawing.Point(-1, 196);
            this.textSetNum_HLo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textSetNum_HLo.Name = "textSetNum_HLo";
            this.textSetNum_HLo.Size = new System.Drawing.Size(320, 40);
            this.textSetNum_HLo.TabIndex = 4;
            this.textSetNum_HLo.TitleName = "1#站点湿度低限";
            this.textSetNum_HLo.Unit = "％";
            // 
            // textSetNum_HHi
            // 
            this.textSetNum_HHi.BackColor = System.Drawing.Color.Transparent;
            this.textSetNum_HHi.CurrentValue = 0F;
            this.textSetNum_HHi.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.textSetNum_HHi.Location = new System.Drawing.Point(-1, 146);
            this.textSetNum_HHi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textSetNum_HHi.Name = "textSetNum_HHi";
            this.textSetNum_HHi.Size = new System.Drawing.Size(320, 40);
            this.textSetNum_HHi.TabIndex = 3;
            this.textSetNum_HHi.TitleName = "1#站点湿度高限";
            this.textSetNum_HHi.Unit = "％";
            // 
            // textSetNum_TLo
            // 
            this.textSetNum_TLo.BackColor = System.Drawing.Color.Transparent;
            this.textSetNum_TLo.CurrentValue = 0F;
            this.textSetNum_TLo.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.textSetNum_TLo.Location = new System.Drawing.Point(-1, 96);
            this.textSetNum_TLo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textSetNum_TLo.Name = "textSetNum_TLo";
            this.textSetNum_TLo.Size = new System.Drawing.Size(320, 40);
            this.textSetNum_TLo.TabIndex = 2;
            this.textSetNum_TLo.TitleName = "1#站点温度低限";
            this.textSetNum_TLo.Unit = "℃";
            // 
            // textSetNum_THi
            // 
            this.textSetNum_THi.BackColor = System.Drawing.Color.Transparent;
            this.textSetNum_THi.CurrentValue = 0F;
            this.textSetNum_THi.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.textSetNum_THi.Location = new System.Drawing.Point(-1, 46);
            this.textSetNum_THi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textSetNum_THi.Name = "textSetNum_THi";
            this.textSetNum_THi.Size = new System.Drawing.Size(320, 40);
            this.textSetNum_THi.TabIndex = 1;
            this.textSetNum_THi.TitleName = "1#站点温度高限";
            this.textSetNum_THi.Unit = "℃";
            // 
            // title
            // 
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("title.BackgroundImage")));
            this.title.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.title.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title.Location = new System.Drawing.Point(4, 5);
            this.title.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(109, 31);
            this.title.TabIndex = 0;
            this.title.TitleName = "1#站点";
            // 
            // RecipeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(39)))), ((int)(((byte)(104)))));
            this.Controls.Add(this.chk_HumidityAlarmEnable);
            this.Controls.Add(this.chk_TempAlarmEnable);
            this.Controls.Add(this.textSetNum_HLo);
            this.Controls.Add(this.textSetNum_HHi);
            this.Controls.Add(this.textSetNum_TLo);
            this.Controls.Add(this.textSetNum_THi);
            this.Controls.Add(this.title);
            this.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "RecipeControl";
            this.Size = new System.Drawing.Size(330, 312);
            this.ResumeLayout(false);

        }

        #endregion

        private Title title;
        private TextSetNum textSetNum_THi;
        private TextSetNum textSetNum_TLo;
        private TextSetNum textSetNum_HHi;
        private TextSetNum textSetNum_HLo;
        private CheckBoxEx chk_TempAlarmEnable;
        private CheckBoxEx chk_HumidityAlarmEnable;
    }
}
