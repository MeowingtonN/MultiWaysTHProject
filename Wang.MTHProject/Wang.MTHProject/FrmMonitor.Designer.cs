namespace Wang.MTHProject
{
    partial class FrmMonitor
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
            this.components = new System.ComponentModel.Container();
            SeeSharpTools.JY.GUI.StripChartXSeries stripChartXSeries2 = new SeeSharpTools.JY.GUI.StripChartXSeries();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMonitor));
            this.chart_ActualTrend = new SeeSharpTools.JY.GUI.StripChartX();
            this.list_Info = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.checkBox_6_2 = new Wang.MTHControlLib.CheckBoxEx();
            this.checkBox_6_1 = new Wang.MTHControlLib.CheckBoxEx();
            this.checkBox_5_2 = new Wang.MTHControlLib.CheckBoxEx();
            this.checkBox_5_1 = new Wang.MTHControlLib.CheckBoxEx();
            this.checkBox_4_2 = new Wang.MTHControlLib.CheckBoxEx();
            this.checkBox_4_1 = new Wang.MTHControlLib.CheckBoxEx();
            this.checkBox_3_2 = new Wang.MTHControlLib.CheckBoxEx();
            this.checkBox_3_1 = new Wang.MTHControlLib.CheckBoxEx();
            this.checkBox_2_2 = new Wang.MTHControlLib.CheckBoxEx();
            this.checkBox_2_1 = new Wang.MTHControlLib.CheckBoxEx();
            this.chk_Humidity1 = new Wang.MTHControlLib.CheckBoxEx();
            this.chk_Temp1 = new Wang.MTHControlLib.CheckBoxEx();
            this.title2 = new Wang.MTHControlLib.Title();
            this.title1 = new Wang.MTHControlLib.Title();
            this.thmControl_6 = new Wang.MTHControlLib.THMControl();
            this.thmControl_4 = new Wang.MTHControlLib.THMControl();
            this.thmControl_2 = new Wang.MTHControlLib.THMControl();
            this.thmControl_5 = new Wang.MTHControlLib.THMControl();
            this.thmControl_3 = new Wang.MTHControlLib.THMControl();
            this.thmControl_1 = new Wang.MTHControlLib.THMControl();
            this.MainPanel = new Wang.MTHControlLib.PanelEnhanced();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart_ActualTrend
            // 
            this.chart_ActualTrend.AxisX.AutoScale = false;
            this.chart_ActualTrend.AxisX.AutoZoomReset = false;
            this.chart_ActualTrend.AxisX.Color = System.Drawing.Color.White;
            this.chart_ActualTrend.AxisX.InitWithScaleView = false;
            this.chart_ActualTrend.AxisX.IsLogarithmic = false;
            this.chart_ActualTrend.AxisX.LabelAngle = 0;
            this.chart_ActualTrend.AxisX.LabelEnabled = true;
            this.chart_ActualTrend.AxisX.LabelFormat = null;
            this.chart_ActualTrend.AxisX.MajorGridColor = System.Drawing.Color.White;
            this.chart_ActualTrend.AxisX.MajorGridCount = 4;
            this.chart_ActualTrend.AxisX.MajorGridEnabled = true;
            this.chart_ActualTrend.AxisX.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.chart_ActualTrend.AxisX.Maximum = 1000D;
            this.chart_ActualTrend.AxisX.Minimum = 0D;
            this.chart_ActualTrend.AxisX.MinorGridColor = System.Drawing.Color.Black;
            this.chart_ActualTrend.AxisX.MinorGridEnabled = false;
            this.chart_ActualTrend.AxisX.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.chart_ActualTrend.AxisX.TickWidth = 1F;
            this.chart_ActualTrend.AxisX.Title = "";
            this.chart_ActualTrend.AxisX.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.chart_ActualTrend.AxisX.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.chart_ActualTrend.AxisX.ViewMaximum = 1000D;
            this.chart_ActualTrend.AxisX.ViewMinimum = 0D;
            this.chart_ActualTrend.AxisX2.AutoScale = false;
            this.chart_ActualTrend.AxisX2.AutoZoomReset = false;
            this.chart_ActualTrend.AxisX2.Color = System.Drawing.Color.Black;
            this.chart_ActualTrend.AxisX2.InitWithScaleView = false;
            this.chart_ActualTrend.AxisX2.IsLogarithmic = false;
            this.chart_ActualTrend.AxisX2.LabelAngle = 0;
            this.chart_ActualTrend.AxisX2.LabelEnabled = true;
            this.chart_ActualTrend.AxisX2.LabelFormat = null;
            this.chart_ActualTrend.AxisX2.MajorGridColor = System.Drawing.Color.Black;
            this.chart_ActualTrend.AxisX2.MajorGridCount = 6;
            this.chart_ActualTrend.AxisX2.MajorGridEnabled = true;
            this.chart_ActualTrend.AxisX2.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.chart_ActualTrend.AxisX2.Maximum = 1000D;
            this.chart_ActualTrend.AxisX2.Minimum = 0D;
            this.chart_ActualTrend.AxisX2.MinorGridColor = System.Drawing.Color.Black;
            this.chart_ActualTrend.AxisX2.MinorGridEnabled = false;
            this.chart_ActualTrend.AxisX2.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.chart_ActualTrend.AxisX2.TickWidth = 1F;
            this.chart_ActualTrend.AxisX2.Title = "";
            this.chart_ActualTrend.AxisX2.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.chart_ActualTrend.AxisX2.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.chart_ActualTrend.AxisX2.ViewMaximum = 1000D;
            this.chart_ActualTrend.AxisX2.ViewMinimum = 0D;
            this.chart_ActualTrend.AxisY.AutoScale = true;
            this.chart_ActualTrend.AxisY.AutoZoomReset = false;
            this.chart_ActualTrend.AxisY.Color = System.Drawing.Color.White;
            this.chart_ActualTrend.AxisY.InitWithScaleView = false;
            this.chart_ActualTrend.AxisY.IsLogarithmic = false;
            this.chart_ActualTrend.AxisY.LabelAngle = 0;
            this.chart_ActualTrend.AxisY.LabelEnabled = true;
            this.chart_ActualTrend.AxisY.LabelFormat = null;
            this.chart_ActualTrend.AxisY.MajorGridColor = System.Drawing.Color.White;
            this.chart_ActualTrend.AxisY.MajorGridCount = 6;
            this.chart_ActualTrend.AxisY.MajorGridEnabled = true;
            this.chart_ActualTrend.AxisY.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.chart_ActualTrend.AxisY.Maximum = 3.5D;
            this.chart_ActualTrend.AxisY.Minimum = 0.5D;
            this.chart_ActualTrend.AxisY.MinorGridColor = System.Drawing.Color.Black;
            this.chart_ActualTrend.AxisY.MinorGridEnabled = false;
            this.chart_ActualTrend.AxisY.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.chart_ActualTrend.AxisY.TickWidth = 1F;
            this.chart_ActualTrend.AxisY.Title = "";
            this.chart_ActualTrend.AxisY.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.chart_ActualTrend.AxisY.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.chart_ActualTrend.AxisY.ViewMaximum = 3.5D;
            this.chart_ActualTrend.AxisY.ViewMinimum = 0.5D;
            this.chart_ActualTrend.AxisY2.AutoScale = true;
            this.chart_ActualTrend.AxisY2.AutoZoomReset = false;
            this.chart_ActualTrend.AxisY2.Color = System.Drawing.Color.Black;
            this.chart_ActualTrend.AxisY2.InitWithScaleView = false;
            this.chart_ActualTrend.AxisY2.IsLogarithmic = false;
            this.chart_ActualTrend.AxisY2.LabelAngle = 0;
            this.chart_ActualTrend.AxisY2.LabelEnabled = true;
            this.chart_ActualTrend.AxisY2.LabelFormat = null;
            this.chart_ActualTrend.AxisY2.MajorGridColor = System.Drawing.Color.Black;
            this.chart_ActualTrend.AxisY2.MajorGridCount = 6;
            this.chart_ActualTrend.AxisY2.MajorGridEnabled = true;
            this.chart_ActualTrend.AxisY2.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.chart_ActualTrend.AxisY2.Maximum = 3.5D;
            this.chart_ActualTrend.AxisY2.Minimum = 0.5D;
            this.chart_ActualTrend.AxisY2.MinorGridColor = System.Drawing.Color.Black;
            this.chart_ActualTrend.AxisY2.MinorGridEnabled = false;
            this.chart_ActualTrend.AxisY2.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.chart_ActualTrend.AxisY2.TickWidth = 1F;
            this.chart_ActualTrend.AxisY2.Title = "";
            this.chart_ActualTrend.AxisY2.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.chart_ActualTrend.AxisY2.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.chart_ActualTrend.AxisY2.ViewMaximum = 3.5D;
            this.chart_ActualTrend.AxisY2.ViewMinimum = 0.5D;
            this.chart_ActualTrend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.chart_ActualTrend.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.chart_ActualTrend.ChartAreaBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.chart_ActualTrend.Direction = SeeSharpTools.JY.GUI.StripChartX.ScrollDirection.LeftToRight;
            this.chart_ActualTrend.DisplayPoints = 4000;
            this.chart_ActualTrend.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.chart_ActualTrend.ForeColor = System.Drawing.Color.White;
            this.chart_ActualTrend.GradientStyle = SeeSharpTools.JY.GUI.StripChartX.ChartGradientStyle.None;
            this.chart_ActualTrend.LegendBackColor = System.Drawing.Color.Transparent;
            this.chart_ActualTrend.LegendFont = new System.Drawing.Font("微软雅黑", 11F);
            this.chart_ActualTrend.LegendForeColor = System.Drawing.Color.White;
            this.chart_ActualTrend.LegendVisible = true;
            stripChartXSeries2.Color = System.Drawing.Color.Red;
            stripChartXSeries2.Marker = SeeSharpTools.JY.GUI.StripChartXSeries.MarkerType.None;
            stripChartXSeries2.Name = "1#站点温度";
            stripChartXSeries2.Type = SeeSharpTools.JY.GUI.StripChartXSeries.LineType.FastLine;
            stripChartXSeries2.Visible = true;
            stripChartXSeries2.Width = SeeSharpTools.JY.GUI.StripChartXSeries.LineWidth.Thin;
            stripChartXSeries2.XPlotAxis = SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Primary;
            stripChartXSeries2.YPlotAxis = SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Primary;
            this.chart_ActualTrend.LineSeries.Add(stripChartXSeries2);
            this.chart_ActualTrend.Location = new System.Drawing.Point(720, 33);
            this.chart_ActualTrend.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chart_ActualTrend.Miscellaneous.CheckInfinity = false;
            this.chart_ActualTrend.Miscellaneous.CheckNaN = false;
            this.chart_ActualTrend.Miscellaneous.CheckNegtiveOrZero = false;
            this.chart_ActualTrend.Miscellaneous.DirectionChartCount = 3;
            this.chart_ActualTrend.Miscellaneous.Fitting = SeeSharpTools.JY.GUI.StripChartX.FitType.Range;
            this.chart_ActualTrend.Miscellaneous.MaxSeriesCount = 32;
            this.chart_ActualTrend.Miscellaneous.MaxSeriesPointCount = 4000;
            this.chart_ActualTrend.Miscellaneous.SplitLayoutColumnInterval = 0F;
            this.chart_ActualTrend.Miscellaneous.SplitLayoutDirection = SeeSharpTools.JY.GUI.StripChartXUtility.LayoutDirection.LeftToRight;
            this.chart_ActualTrend.Miscellaneous.SplitLayoutRowInterval = 0F;
            this.chart_ActualTrend.Miscellaneous.SplitViewAutoLayout = true;
            this.chart_ActualTrend.Name = "chart_ActualTrend";
            this.chart_ActualTrend.NextTimeStamp = new System.DateTime(((long)(0)));
            this.chart_ActualTrend.ScrollType = SeeSharpTools.JY.GUI.StripChartX.StripScrollType.Cumulation;
            this.chart_ActualTrend.SeriesCount = 1;
            this.chart_ActualTrend.Size = new System.Drawing.Size(651, 393);
            this.chart_ActualTrend.SplitView = false;
            this.chart_ActualTrend.StartIndex = 0;
            this.chart_ActualTrend.TabIndex = 9;
            this.chart_ActualTrend.TimeInterval = System.TimeSpan.Parse("00:00:00");
            this.chart_ActualTrend.TimeStampFormat = null;
            this.chart_ActualTrend.XCursor.AutoInterval = true;
            this.chart_ActualTrend.XCursor.Color = System.Drawing.Color.DeepSkyBlue;
            this.chart_ActualTrend.XCursor.Interval = 0.001D;
            this.chart_ActualTrend.XCursor.Mode = SeeSharpTools.JY.GUI.StripChartXCursor.CursorMode.Zoom;
            this.chart_ActualTrend.XCursor.SelectionColor = System.Drawing.Color.LightGray;
            this.chart_ActualTrend.XCursor.Value = double.NaN;
            this.chart_ActualTrend.XDataType = SeeSharpTools.JY.GUI.StripChartX.XAxisDataType.Index;
            this.chart_ActualTrend.YCursor.AutoInterval = true;
            this.chart_ActualTrend.YCursor.Color = System.Drawing.Color.DeepSkyBlue;
            this.chart_ActualTrend.YCursor.Interval = 0.001D;
            this.chart_ActualTrend.YCursor.Mode = SeeSharpTools.JY.GUI.StripChartXCursor.CursorMode.Disabled;
            this.chart_ActualTrend.YCursor.SelectionColor = System.Drawing.Color.LightGray;
            this.chart_ActualTrend.YCursor.Value = double.NaN;
            // 
            // list_Info
            // 
            this.list_Info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.list_Info.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.list_Info.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.list_Info.ForeColor = System.Drawing.Color.White;
            this.list_Info.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.list_Info.HideSelection = false;
            this.list_Info.Location = new System.Drawing.Point(720, 571);
            this.list_Info.Name = "list_Info";
            this.list_Info.ShowItemToolTips = true;
            this.list_Info.Size = new System.Drawing.Size(651, 144);
            this.list_Info.SmallImageList = this.imageList;
            this.list_Info.TabIndex = 21;
            this.list_Info.UseCompatibleStateImageBehavior = false;
            this.list_Info.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "日志时间";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "日志内容";
            this.columnHeader2.Width = 200;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "info.png");
            this.imageList.Images.SetKeyName(1, "warning.png");
            this.imageList.Images.SetKeyName(2, "error.png");
            // 
            // checkBox_6_2
            // 
            this.checkBox_6_2.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_6_2.CheckBtnBackColor = System.Drawing.Color.White;
            this.checkBox_6_2.CheckBtnBorderColor = System.Drawing.Color.LightGray;
            this.checkBox_6_2.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBox_6_2.DefaultCheckButtonWidth = 20;
            this.checkBox_6_2.ForeColor = System.Drawing.Color.White;
            this.checkBox_6_2.Location = new System.Drawing.Point(1254, 503);
            this.checkBox_6_2.Name = "checkBox_6_2";
            this.checkBox_6_2.Size = new System.Drawing.Size(117, 31);
            this.checkBox_6_2.TabIndex = 20;
            this.checkBox_6_2.Tag = "11";
            this.checkBox_6_2.Text = "6#站点湿度";
            this.checkBox_6_2.UseVisualStyleBackColor = false;
            this.checkBox_6_2.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // checkBox_6_1
            // 
            this.checkBox_6_1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_6_1.CheckBtnBackColor = System.Drawing.Color.White;
            this.checkBox_6_1.CheckBtnBorderColor = System.Drawing.Color.LightGray;
            this.checkBox_6_1.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBox_6_1.DefaultCheckButtonWidth = 20;
            this.checkBox_6_1.ForeColor = System.Drawing.Color.White;
            this.checkBox_6_1.Location = new System.Drawing.Point(1082, 503);
            this.checkBox_6_1.Name = "checkBox_6_1";
            this.checkBox_6_1.Size = new System.Drawing.Size(117, 31);
            this.checkBox_6_1.TabIndex = 19;
            this.checkBox_6_1.Tag = "10";
            this.checkBox_6_1.Text = "6#站点温度";
            this.checkBox_6_1.UseVisualStyleBackColor = false;
            this.checkBox_6_1.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // checkBox_5_2
            // 
            this.checkBox_5_2.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_5_2.CheckBtnBackColor = System.Drawing.Color.White;
            this.checkBox_5_2.CheckBtnBorderColor = System.Drawing.Color.LightGray;
            this.checkBox_5_2.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBox_5_2.DefaultCheckButtonWidth = 20;
            this.checkBox_5_2.ForeColor = System.Drawing.Color.White;
            this.checkBox_5_2.Location = new System.Drawing.Point(902, 503);
            this.checkBox_5_2.Name = "checkBox_5_2";
            this.checkBox_5_2.Size = new System.Drawing.Size(117, 31);
            this.checkBox_5_2.TabIndex = 18;
            this.checkBox_5_2.Tag = "9";
            this.checkBox_5_2.Text = "5#站点湿度";
            this.checkBox_5_2.UseVisualStyleBackColor = false;
            this.checkBox_5_2.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // checkBox_5_1
            // 
            this.checkBox_5_1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_5_1.CheckBtnBackColor = System.Drawing.Color.White;
            this.checkBox_5_1.CheckBtnBorderColor = System.Drawing.Color.LightGray;
            this.checkBox_5_1.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBox_5_1.DefaultCheckButtonWidth = 20;
            this.checkBox_5_1.ForeColor = System.Drawing.Color.White;
            this.checkBox_5_1.Location = new System.Drawing.Point(720, 503);
            this.checkBox_5_1.Name = "checkBox_5_1";
            this.checkBox_5_1.Size = new System.Drawing.Size(117, 31);
            this.checkBox_5_1.TabIndex = 17;
            this.checkBox_5_1.Tag = "8";
            this.checkBox_5_1.Text = "5#站点温度";
            this.checkBox_5_1.UseVisualStyleBackColor = false;
            this.checkBox_5_1.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // checkBox_4_2
            // 
            this.checkBox_4_2.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_4_2.CheckBtnBackColor = System.Drawing.Color.White;
            this.checkBox_4_2.CheckBtnBorderColor = System.Drawing.Color.LightGray;
            this.checkBox_4_2.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBox_4_2.DefaultCheckButtonWidth = 20;
            this.checkBox_4_2.ForeColor = System.Drawing.Color.White;
            this.checkBox_4_2.Location = new System.Drawing.Point(1254, 466);
            this.checkBox_4_2.Name = "checkBox_4_2";
            this.checkBox_4_2.Size = new System.Drawing.Size(117, 31);
            this.checkBox_4_2.TabIndex = 16;
            this.checkBox_4_2.Tag = "7";
            this.checkBox_4_2.Text = "4#站点湿度";
            this.checkBox_4_2.UseVisualStyleBackColor = false;
            this.checkBox_4_2.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // checkBox_4_1
            // 
            this.checkBox_4_1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_4_1.CheckBtnBackColor = System.Drawing.Color.White;
            this.checkBox_4_1.CheckBtnBorderColor = System.Drawing.Color.LightGray;
            this.checkBox_4_1.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBox_4_1.DefaultCheckButtonWidth = 20;
            this.checkBox_4_1.ForeColor = System.Drawing.Color.White;
            this.checkBox_4_1.Location = new System.Drawing.Point(1082, 466);
            this.checkBox_4_1.Name = "checkBox_4_1";
            this.checkBox_4_1.Size = new System.Drawing.Size(117, 31);
            this.checkBox_4_1.TabIndex = 15;
            this.checkBox_4_1.Tag = "6";
            this.checkBox_4_1.Text = "4#站点温度";
            this.checkBox_4_1.UseVisualStyleBackColor = false;
            this.checkBox_4_1.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // checkBox_3_2
            // 
            this.checkBox_3_2.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_3_2.CheckBtnBackColor = System.Drawing.Color.White;
            this.checkBox_3_2.CheckBtnBorderColor = System.Drawing.Color.LightGray;
            this.checkBox_3_2.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBox_3_2.DefaultCheckButtonWidth = 20;
            this.checkBox_3_2.ForeColor = System.Drawing.Color.White;
            this.checkBox_3_2.Location = new System.Drawing.Point(902, 466);
            this.checkBox_3_2.Name = "checkBox_3_2";
            this.checkBox_3_2.Size = new System.Drawing.Size(117, 31);
            this.checkBox_3_2.TabIndex = 14;
            this.checkBox_3_2.Tag = "5";
            this.checkBox_3_2.Text = "3#站点湿度";
            this.checkBox_3_2.UseVisualStyleBackColor = false;
            this.checkBox_3_2.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // checkBox_3_1
            // 
            this.checkBox_3_1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_3_1.CheckBtnBackColor = System.Drawing.Color.White;
            this.checkBox_3_1.CheckBtnBorderColor = System.Drawing.Color.LightGray;
            this.checkBox_3_1.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBox_3_1.DefaultCheckButtonWidth = 20;
            this.checkBox_3_1.ForeColor = System.Drawing.Color.White;
            this.checkBox_3_1.Location = new System.Drawing.Point(720, 466);
            this.checkBox_3_1.Name = "checkBox_3_1";
            this.checkBox_3_1.Size = new System.Drawing.Size(117, 31);
            this.checkBox_3_1.TabIndex = 13;
            this.checkBox_3_1.Tag = "4";
            this.checkBox_3_1.Text = "3#站点温度";
            this.checkBox_3_1.UseVisualStyleBackColor = false;
            this.checkBox_3_1.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // checkBox_2_2
            // 
            this.checkBox_2_2.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_2_2.CheckBtnBackColor = System.Drawing.Color.White;
            this.checkBox_2_2.CheckBtnBorderColor = System.Drawing.Color.LightGray;
            this.checkBox_2_2.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBox_2_2.DefaultCheckButtonWidth = 20;
            this.checkBox_2_2.ForeColor = System.Drawing.Color.White;
            this.checkBox_2_2.Location = new System.Drawing.Point(1254, 429);
            this.checkBox_2_2.Name = "checkBox_2_2";
            this.checkBox_2_2.Size = new System.Drawing.Size(117, 31);
            this.checkBox_2_2.TabIndex = 12;
            this.checkBox_2_2.Tag = "3";
            this.checkBox_2_2.Text = "2#站点湿度";
            this.checkBox_2_2.UseVisualStyleBackColor = false;
            this.checkBox_2_2.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // checkBox_2_1
            // 
            this.checkBox_2_1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_2_1.CheckBtnBackColor = System.Drawing.Color.White;
            this.checkBox_2_1.CheckBtnBorderColor = System.Drawing.Color.LightGray;
            this.checkBox_2_1.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBox_2_1.DefaultCheckButtonWidth = 20;
            this.checkBox_2_1.ForeColor = System.Drawing.Color.White;
            this.checkBox_2_1.Location = new System.Drawing.Point(1082, 429);
            this.checkBox_2_1.Name = "checkBox_2_1";
            this.checkBox_2_1.Size = new System.Drawing.Size(117, 31);
            this.checkBox_2_1.TabIndex = 11;
            this.checkBox_2_1.Tag = "2";
            this.checkBox_2_1.Text = "2#站点温度";
            this.checkBox_2_1.UseVisualStyleBackColor = false;
            this.checkBox_2_1.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // chk_Humidity1
            // 
            this.chk_Humidity1.BackColor = System.Drawing.Color.Transparent;
            this.chk_Humidity1.CheckBtnBackColor = System.Drawing.Color.White;
            this.chk_Humidity1.CheckBtnBorderColor = System.Drawing.Color.LightGray;
            this.chk_Humidity1.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_Humidity1.DefaultCheckButtonWidth = 20;
            this.chk_Humidity1.ForeColor = System.Drawing.Color.White;
            this.chk_Humidity1.Location = new System.Drawing.Point(902, 429);
            this.chk_Humidity1.Name = "chk_Humidity1";
            this.chk_Humidity1.Size = new System.Drawing.Size(117, 31);
            this.chk_Humidity1.TabIndex = 10;
            this.chk_Humidity1.Tag = "1";
            this.chk_Humidity1.Text = "1#站点湿度";
            this.chk_Humidity1.UseVisualStyleBackColor = false;
            this.chk_Humidity1.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // chk_Temp1
            // 
            this.chk_Temp1.BackColor = System.Drawing.Color.Transparent;
            this.chk_Temp1.CheckBtnBackColor = System.Drawing.Color.White;
            this.chk_Temp1.CheckBtnBorderColor = System.Drawing.Color.LightGray;
            this.chk_Temp1.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_Temp1.DefaultCheckButtonWidth = 20;
            this.chk_Temp1.ForeColor = System.Drawing.Color.White;
            this.chk_Temp1.Location = new System.Drawing.Point(720, 429);
            this.chk_Temp1.Name = "chk_Temp1";
            this.chk_Temp1.Size = new System.Drawing.Size(117, 31);
            this.chk_Temp1.TabIndex = 8;
            this.chk_Temp1.Tag = "0";
            this.chk_Temp1.Text = "1#站点温度";
            this.chk_Temp1.UseVisualStyleBackColor = false;
            this.chk_Temp1.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // title2
            // 
            this.title2.BackColor = System.Drawing.Color.Transparent;
            this.title2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("title2.BackgroundImage")));
            this.title2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.title2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title2.Location = new System.Drawing.Point(700, 535);
            this.title2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title2.Name = "title2";
            this.title2.Size = new System.Drawing.Size(109, 31);
            this.title2.TabIndex = 7;
            this.title2.TitleName = "系统日志";
            // 
            // title1
            // 
            this.title1.BackColor = System.Drawing.Color.Transparent;
            this.title1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("title1.BackgroundImage")));
            this.title1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.title1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title1.Location = new System.Drawing.Point(700, 0);
            this.title1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(109, 31);
            this.title1.TabIndex = 6;
            this.title1.TitleName = "实时趋势";
            // 
            // thmControl_6
            // 
            this.thmControl_6.BackColor = System.Drawing.Color.Transparent;
            this.thmControl_6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.thmControl_6.Humidity = "0.0";
            this.thmControl_6.HumidityVarName = "模块6湿度";
            this.thmControl_6.Location = new System.Drawing.Point(345, 517);
            this.thmControl_6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.thmControl_6.ModuleError = false;
            this.thmControl_6.Name = "thmControl_6";
            this.thmControl_6.Size = new System.Drawing.Size(338, 215);
            this.thmControl_6.StateVarName = "模块6异常";
            this.thmControl_6.TabIndex = 5;
            this.thmControl_6.Temp = "0.0";
            this.thmControl_6.TempVarName = "模块6温度";
            this.thmControl_6.Title = "6#站点";
            // 
            // thmControl_4
            // 
            this.thmControl_4.BackColor = System.Drawing.Color.Transparent;
            this.thmControl_4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.thmControl_4.Humidity = "0.0";
            this.thmControl_4.HumidityVarName = "模块4湿度";
            this.thmControl_4.Location = new System.Drawing.Point(345, 258);
            this.thmControl_4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.thmControl_4.ModuleError = false;
            this.thmControl_4.Name = "thmControl_4";
            this.thmControl_4.Size = new System.Drawing.Size(338, 215);
            this.thmControl_4.StateVarName = "模块4异常";
            this.thmControl_4.TabIndex = 4;
            this.thmControl_4.Temp = "0.0";
            this.thmControl_4.TempVarName = "模块4温度";
            this.thmControl_4.Title = "4#站点";
            // 
            // thmControl_2
            // 
            this.thmControl_2.BackColor = System.Drawing.Color.Transparent;
            this.thmControl_2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.thmControl_2.Humidity = "0.0";
            this.thmControl_2.HumidityVarName = "模块2湿度";
            this.thmControl_2.Location = new System.Drawing.Point(345, 0);
            this.thmControl_2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.thmControl_2.ModuleError = false;
            this.thmControl_2.Name = "thmControl_2";
            this.thmControl_2.Size = new System.Drawing.Size(338, 215);
            this.thmControl_2.StateVarName = "模块2异常";
            this.thmControl_2.TabIndex = 3;
            this.thmControl_2.Temp = "0.0";
            this.thmControl_2.TempVarName = "模块2温度";
            this.thmControl_2.Title = "2#站点";
            // 
            // thmControl_5
            // 
            this.thmControl_5.BackColor = System.Drawing.Color.Transparent;
            this.thmControl_5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.thmControl_5.Humidity = "0.0";
            this.thmControl_5.HumidityVarName = "模块5湿度";
            this.thmControl_5.Location = new System.Drawing.Point(2, 517);
            this.thmControl_5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.thmControl_5.ModuleError = false;
            this.thmControl_5.Name = "thmControl_5";
            this.thmControl_5.Size = new System.Drawing.Size(338, 215);
            this.thmControl_5.StateVarName = "模块5异常";
            this.thmControl_5.TabIndex = 2;
            this.thmControl_5.Temp = "0.0";
            this.thmControl_5.TempVarName = "模块5温度";
            this.thmControl_5.Title = "5#站点";
            // 
            // thmControl_3
            // 
            this.thmControl_3.BackColor = System.Drawing.Color.Transparent;
            this.thmControl_3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.thmControl_3.Humidity = "0.0";
            this.thmControl_3.HumidityVarName = "模块3湿度";
            this.thmControl_3.Location = new System.Drawing.Point(2, 258);
            this.thmControl_3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.thmControl_3.ModuleError = false;
            this.thmControl_3.Name = "thmControl_3";
            this.thmControl_3.Size = new System.Drawing.Size(338, 215);
            this.thmControl_3.StateVarName = "模块3异常";
            this.thmControl_3.TabIndex = 1;
            this.thmControl_3.Temp = "0.0";
            this.thmControl_3.TempVarName = "模块3温度";
            this.thmControl_3.Title = "3#站点";
            // 
            // thmControl_1
            // 
            this.thmControl_1.BackColor = System.Drawing.Color.Transparent;
            this.thmControl_1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.thmControl_1.Humidity = "0.0";
            this.thmControl_1.HumidityVarName = "模块1湿度";
            this.thmControl_1.Location = new System.Drawing.Point(2, 0);
            this.thmControl_1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.thmControl_1.ModuleError = false;
            this.thmControl_1.Name = "thmControl_1";
            this.thmControl_1.Size = new System.Drawing.Size(338, 215);
            this.thmControl_1.StateVarName = "模块1异常";
            this.thmControl_1.TabIndex = 0;
            this.thmControl_1.Temp = "0.0";
            this.thmControl_1.TempVarName = "模块1温度";
            this.thmControl_1.Title = "1#站点";
            // 
            // MainPanel
            // 
            this.MainPanel.BackgroundImage = global::Wang.MTHProject.Properties.Resources.BackGround;
            this.MainPanel.Controls.Add(this.list_Info);
            this.MainPanel.Controls.Add(this.chart_ActualTrend);
            this.MainPanel.Controls.Add(this.checkBox_6_2);
            this.MainPanel.Controls.Add(this.thmControl_1);
            this.MainPanel.Controls.Add(this.checkBox_6_1);
            this.MainPanel.Controls.Add(this.thmControl_3);
            this.MainPanel.Controls.Add(this.checkBox_5_2);
            this.MainPanel.Controls.Add(this.thmControl_5);
            this.MainPanel.Controls.Add(this.checkBox_5_1);
            this.MainPanel.Controls.Add(this.thmControl_2);
            this.MainPanel.Controls.Add(this.checkBox_4_2);
            this.MainPanel.Controls.Add(this.thmControl_4);
            this.MainPanel.Controls.Add(this.checkBox_4_1);
            this.MainPanel.Controls.Add(this.thmControl_6);
            this.MainPanel.Controls.Add(this.checkBox_3_2);
            this.MainPanel.Controls.Add(this.title1);
            this.MainPanel.Controls.Add(this.checkBox_3_1);
            this.MainPanel.Controls.Add(this.title2);
            this.MainPanel.Controls.Add(this.checkBox_2_2);
            this.MainPanel.Controls.Add(this.chk_Temp1);
            this.MainPanel.Controls.Add(this.checkBox_2_1);
            this.MainPanel.Controls.Add(this.chk_Humidity1);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1394, 736);
            this.MainPanel.TabIndex = 22;
            // 
            // FrmMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1394, 736);
            this.Controls.Add(this.MainPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmMonitor";
            this.Text = "集中监控";
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MTHControlLib.THMControl thmControl_1;
        private MTHControlLib.THMControl thmControl_3;
        private MTHControlLib.THMControl thmControl_5;
        private MTHControlLib.THMControl thmControl_6;
        private MTHControlLib.THMControl thmControl_4;
        private MTHControlLib.THMControl thmControl_2;
        private MTHControlLib.Title title1;
        private MTHControlLib.Title title2;
        private MTHControlLib.CheckBoxEx chk_Temp1;
        private SeeSharpTools.JY.GUI.StripChartX chart_ActualTrend;
        private MTHControlLib.CheckBoxEx chk_Humidity1;
        private MTHControlLib.CheckBoxEx checkBox_2_1;
        private MTHControlLib.CheckBoxEx checkBox_2_2;
        private MTHControlLib.CheckBoxEx checkBox_4_2;
        private MTHControlLib.CheckBoxEx checkBox_4_1;
        private MTHControlLib.CheckBoxEx checkBox_3_2;
        private MTHControlLib.CheckBoxEx checkBox_3_1;
        private MTHControlLib.CheckBoxEx checkBox_6_2;
        private MTHControlLib.CheckBoxEx checkBox_6_1;
        private MTHControlLib.CheckBoxEx checkBox_5_2;
        private MTHControlLib.CheckBoxEx checkBox_5_1;
        private System.Windows.Forms.ListView list_Info;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private MTHControlLib.PanelEnhanced MainPanel;
    }
}