using SeeSharpTools.JY.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.DataConvertLib;
using Wang.MTHBLL;
using Wang.MTHControlLib;

namespace Wang.MTHProject
{
    public partial class FrmHistory : Form
    {
        public FrmHistory()
        {
            InitializeComponent();

            // 有序地向集合中添加CheckBoxEx控件。
            CheckBoxExes.Add(this.chk_Temp1);
            CheckBoxExes.Add(this.chk_Humidity1);
            CheckBoxExes.Add(this.chk_Temp2);
            CheckBoxExes.Add(this.chk_Humidity2);
            CheckBoxExes.Add(this.chk_Temp3);
            CheckBoxExes.Add(this.chk_Humidity3);
            CheckBoxExes.Add(this.chk_Temp4);
            CheckBoxExes.Add(this.chk_Humidity4);
            CheckBoxExes.Add(this.chk_Temp5);
            CheckBoxExes.Add(this.chk_Humidity5);
            CheckBoxExes.Add(this.chk_Temp6);
            CheckBoxExes.Add(this.chk_Humidity6);

            this.dtp_Start.Value = DateTime.Now.AddHours(-2.0f);
            this.dtp_End.Value = DateTime.Now;

            InitChart();
        }
        
        /// <summary>
        /// 保存本次要查询的站点数据集合
        /// </summary>
        private Dictionary<string, string> ParamList = new Dictionary<string, string>();

        /// <summary>
        /// 实时数据管理业务
        /// </summary>
        private readonly ActualDataManage actualDataManage = new ActualDataManage();

        /// <summary>
        /// 有序CheckBoxEx控件集合，有序地向其中添加CheckBoxEx控件。
        /// </summary>
        private readonly List<CheckBoxEx> CheckBoxExes = new List<CheckBoxEx>();

        /// <summary>
        /// 初始化Chart控件显示
        /// </summary>
        private void InitChart()
        {
            // 设置X轴类型为字符串
            this.chart_HistoryTrend.XDataType = StripChartX.XAxisDataType.String;
            // 设置图例
            this.chart_HistoryTrend.LegendVisible = true;

            this.chart_HistoryTrend.DisplayPoints = 100000;

            // Y1轴范围
            this.chart_HistoryTrend.AxisY.Minimum = 0.0f;
            this.chart_HistoryTrend.AxisY.Maximum = 100.0f;
            this.chart_HistoryTrend.AxisY.AutoScale = false;
        }

        /// <summary>
        /// 时间查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Query_Click(object sender, EventArgs e)
        {
            // 获取要查询的站点数据
            ParamList = GetParamList();

            string start = this.dtp_Start.Text;
            string end = this.dtp_End.Text;

            if(ParamList.Count == 0)
            {
                new FrmMsgBoxWithoutAck("请勾选需要查询的参数！", "查询历史数据").ShowDialog();
                return;
            }

            Task<OperateResult<DataTable>> task1 = Task.Run(() =>
            {
                return QueryProcess(start, end);
            });

            Task task2 = task1.ContinueWith(task =>
            {
                this.Invoke(new Action(() =>
                {
                    if (task.Result.IsSuccess)
                    {
                        UpdateChart(task.Result.Content);
                    }
                    else
                    {
                        CommonMethods.AddLog(2, "查询出错，原因：" + task.Result.Message);
                        new FrmMsgBoxWithoutAck("查询出错，原因：" + task.Result.Message, "查询历史数据");
                    }
                }));
            });
        }

        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_QuickQuery_Click(object sender, EventArgs e)
        {
            this.dtp_Start.Value = DateTime.Now.AddHours(-5.0f);
            this.dtp_End.Value = DateTime.Now;

            this.btn_Query_Click(null, null);
        }

        /// <summary>
        /// 导出图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SaveImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "图片文件(*.jpg)|*.jpg|所有文件|*.*";
            saveFileDialog.FileName = "历史趋势图片" + DateTime.Now.ToString("yyyyMMddHHmmss");
            saveFileDialog.Title = "历史趋势图片保存";
            saveFileDialog.DefaultExt = "jpg";
            saveFileDialog.AddExtension = true;

            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.chart_HistoryTrend.SaveAsImage(saveFileDialog.FileName);

                if(new FrmMsgBoxWithAck("导出历史趋势图片成功，是否立即打开？", "打开导出图片").ShowDialog() == DialogResult.OK)
                {
                    Process.Start(saveFileDialog.FileName);
                }
            }
        }

        /// <summary>
        /// 导出CSV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ExportCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV文件(*.csv)|*.csv|所有文件|*.*";
            saveFileDialog.FileName = "历史趋势CSV" + DateTime.Now.ToString("yyyyMMddHHmmss");
            saveFileDialog.Title = "历史趋势CSV保存";
            saveFileDialog.DefaultExt = "csv";
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.chart_HistoryTrend.SaveAsCsv(saveFileDialog.FileName);

                if (new FrmMsgBoxWithAck("导出历史趋势CSV成功，是否立即打开？", "打开导出CSV").ShowDialog() == DialogResult.OK)
                {
                    Process.Start(saveFileDialog.FileName);
                }
            }
        }

        /// <summary>
        /// 获取勾选的多选框（要查询的站点数据）
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> GetParamList()
        {
            Dictionary<string, string> paramList = new Dictionary<string, string>();

            foreach (CheckBoxEx item in CheckBoxExes)
            {
                if(item.Tag != null && item.Tag.ToString().Length > 0)
                {
                    if (item.Checked)
                    {
                        // 键为Tag，值为Text
                        paramList.Add(item.Tag.ToString(), item.Text);
                    }
                }
            }
            return paramList;
        }

        /// <summary>
        /// 依据时间条件和勾选的要查询的站点数据进行查询
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private OperateResult<DataTable> QueryProcess(string start, string end)
        {
            // 判断时间
            DateTime startTime = Convert.ToDateTime(start);
            DateTime endTime = Convert.ToDateTime(end);
            if (startTime > endTime)
            {
                return OperateResult.CreateFailResult<DataTable>("开始时间不能大于结束时间。");
            }

            //TimeSpan timeSpan = endTime - startTime;
            //if(timeSpan.TotalHours > 24.0f)
            //{
            //    return OperateResult.CreateFailResult<DataTable>("查询范围不能超过24小时。");
            //}

            try
            {
                DataTable dataTable = actualDataManage.QueryActualDataByCondition(start, end, ParamList.Keys.ToList());
                if (dataTable == null)
                {
                    return OperateResult.CreateFailResult<DataTable>("未查询到有效数据。");
                }
                else
                {
                    return OperateResult.CreateSuccessResult(dataTable);
                }
            }
            catch (Exception ex)
            {
                return OperateResult.CreateFailResult<DataTable>(ex.Message);
            }
        }

        /// <summary>
        /// 更新Chart控件显示
        /// </summary>
        /// <param name="dataTable"></param>
        private void UpdateChart(DataTable dataTable)
        {
            // 设置Chart
            this.chart_HistoryTrend.Clear();
            this.chart_HistoryTrend.SeriesCount = ParamList.Count;
            for(int i = 0; i < ParamList.Count; i++)
            {
                this.chart_HistoryTrend.Series[i].Name = ParamList.Values.ToList()[i];
                this.chart_HistoryTrend.Series[i].Width = StripChartXSeries.LineWidth.Middle;
            }

            // 数据表中有多少条记录（多少个时间点）
            int rowCount = dataTable.Rows.Count;

            // 依据查询的站点数据数（ParamList.Count）和时间点（数据表中有多少条记录）创建二维数组YData。
            double[,] YData = new double[ParamList.Count, rowCount];
            // 依据时间点（数据表中有多少条记录）创建数组XData。
            string[] XData = new string[rowCount];

            // 解析DataTable，填充YData和XData
            for (int i = 0; i < rowCount; i++)
            {
                for(int j = 0; j < ParamList.Count; j++)
                {
                    if(dataTable.Rows[i][j + 1] is DBNull)
                    {
                        // YData：（站点数据，时间点）
                        YData[j, i] = 0.0f;
                    }
                    else
                    {
                        YData[j, i] = Convert.ToDouble(dataTable.Rows[i][j + 1]);
                    }
                }
                // XData：（时间点）（x轴为时间轴）
                XData[i] = Convert.ToDateTime(dataTable.Rows[i][0]).ToString("HH:mm:ss");
            }
            // 绘制Chart
            this.chart_HistoryTrend.Plot(YData, XData);
        }
    }
}
