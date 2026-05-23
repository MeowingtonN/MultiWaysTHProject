using SeeSharpTools.JY.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wang.MTHControlLib;

namespace Wang.MTHProject
{
    public partial class FrmMonitor : Form
    {
        public FrmMonitor()
        {
            InitializeComponent();

            // 依据ListView的总宽度和第一列宽度，动态修改ListView第二列的宽度
            list_Info.Columns[1].Width = list_Info.Width - list_Info.Columns[0].Width - 25;

            SetChart();

            this.updateTimer.Interval = 1000;
            this.updateTimer.Tick += UpdateTimer_Tick;
            this.updateTimer.Start();

            this.FormClosing += (sender, e) =>
            {
                this.updateTimer.Stop();
            };
        }

        /// <summary>
        /// 定时器滴答事件处理方法。定时根据设备的变量键值对的缓存数据更新控件（仪表盘、曲线图）的显示。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (CommonMethods.Device != null && CommonMethods.Device.IsConnected)
            {
                foreach (THMControl item in this.MainPanel.Controls.OfType<THMControl>())
                {
                    // 更新控件显示
                    UpdateTHMControl(item);
                }

                // 设置曲线图显示的数据源
                List<double> ydata = new List<double>();
                for(int i = 0; i < 6; i++)
                {
                    ydata.Add(Convert.ToDouble(CommonMethods.Device[$"模块{i+1}温度"]));
                    ydata.Add(Convert.ToDouble(CommonMethods.Device[$"模块{i+1}湿度"]));
                }
                // 让曲线图依据数据源绘制曲线
                this.chart_ActualTrend.PlotSingle(ydata.ToArray());
            }
        }

        /// <summary>
        /// 更新控件显示
        /// </summary>
        /// <param name="thmControl"></param>
        private void UpdateTHMControl(THMControl thmControl)
        {
            // 更新温度控件显示
            if (CommonMethods.Device != null && CommonMethods.Device[thmControl.TempVarName] != null)
            {
                thmControl.Temp = CommonMethods.Device[thmControl.TempVarName].ToString();
            }

            // 更新湿度控件显示
            if (CommonMethods.Device != null && CommonMethods.Device[thmControl.HumidityVarName] != null)
            {
                thmControl.Humidity = CommonMethods.Device[thmControl.HumidityVarName].ToString();
            }

            // 更新模块异常状态控件显示
            if (CommonMethods.Device != null && CommonMethods.Device[thmControl.StateVarName] != null)
            {
                thmControl.ModuleError = CommonMethods.Device[thmControl.StateVarName].ToString() == "True";
            }
        }

        /// <summary>
        /// 设置曲线图
        /// </summary>
        private void SetChart()
        {
            // 设置曲线图x轴的数据类型
            this.chart_ActualTrend.XDataType = StripChartX.XAxisDataType.TimeStamp;
            // 设置时间戳的格式
            this.chart_ActualTrend.TimeStampFormat = "HH:mm:ss";
            // 设置图例可见
            this.chart_ActualTrend.LegendVisible = true;
            // 设置显示数据点
            this.chart_ActualTrend.DisplayPoints = 4000;
            // 设置Y轴范围
            this.chart_ActualTrend.AxisY.Minimum = 0.0f;
            this.chart_ActualTrend.AxisY.Maximum = 100.0f;
            this.chart_ActualTrend.AxisY.AutoScale = false;
            // 清除曲线
            this.chart_ActualTrend.Series.Clear();
            // 设置曲线数量
            this.chart_ActualTrend.SeriesCount = 12;
            // 设置曲线
            for(int i = 0; i < 12; i++)
            {
                // 设置曲线名称
                this.chart_ActualTrend.Series[i].Name = i % 2 == 0 ? $"{i / 2 + 1}#站点温度" : $"{i / 2 + 1}#站点湿度";
                // 设置曲线不可见
                this.chart_ActualTrend.Series[i].Visible = false;
                // 设置曲线的粗细
                this.chart_ActualTrend.Series[i].Width = StripChartXSeries.LineWidth.Middle;
                // 设置曲线的Y轴
                this.chart_ActualTrend.Series[i].YPlotAxis = StripChartXAxis.PlotAxis.Primary;
            }

            this.chk_Temp1.Checked = true;
            this.chk_Humidity1.Checked = true;
        }

        /// <summary>
        /// 定时器
        /// </summary>
        private Timer updateTimer = new Timer();

        private string CurrentTime
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        /// <summary>
        /// 最终实现添加系统日志的方法，可能跨线程访问。
        /// </summary>
        /// <param name="level">日志等级，用于选择图标</param>
        /// <param name="log">日志内容</param>
        public void AddLog(int level, string log)
        {
            if (level > 2)
            {
                level = 2;
            }
            else if (level < 0)
            {
                level = 0;
            }

            // 若调用方位于创建控件所在线程以外的线程中，则InvokeRequired为true。
            if (this.list_Info.InvokeRequired)
            {
                // 投递给UI线程以执行给定委托
                this.list_Info.Invoke(new Action<int, string>(AddLog), level, log);
            }
            else
            {
                // CurrentTime为第一列内容，level为绑定的ImageList的索引。
                ListViewItem listViewItem = new ListViewItem("    " + CurrentTime, level);
                // 添加第二列
                listViewItem.SubItems.Add(log);

                // 将Item添加到ListView的Item集合中
                list_Info.Items.Add(listViewItem);

                // 让最新的日志显示在最下面并可见
                this.list_Info.Items[this.list_Info.Items.Count - 1].EnsureVisible();
            }
        }

        /// <summary>
        /// 多选框选择对应的曲线显示或隐藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chk_Common_CheckedChanged(object sender, EventArgs e)
        {
            if(sender is CheckBoxEx checkBox)
            {
                if(checkBox.Tag != null && checkBox.Tag.ToString().Length > 0)
                {
                    // checkBox的Tag的值对应了相应曲线的索引
                    int index = Convert.ToInt32(checkBox.Tag.ToString());
                    // 设置对应曲线的显示或隐藏
                    this.chart_ActualTrend.Series[index].Visible = checkBox.Checked;
                }
            }
        }
    }
}
