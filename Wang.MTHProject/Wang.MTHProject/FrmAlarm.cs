using MiniExcelLibs;
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
using Wang.MTHHelper;

namespace Wang.MTHProject
{
    public partial class FrmAlarm : Form
    {
        public FrmAlarm()
        {
            InitializeComponent();

            this.dgv_Main.AutoGenerateColumns = false;
            this.dgv_Main.ReadOnly = false;

            this.cmb_AlarmType.Items.AddRange(new string[]
            {
                "全部", "触发", "消除"
            });
            this.cmb_AlarmType.SelectedIndex = 0;

            this.dtp_Start.Value = DateTime.Now.AddHours(-2.0f);
            this.dtp_End.Value = DateTime.Now;
        }

        /// <summary>
        /// 日志数据表业务管理
        /// </summary>
        private readonly SysLogManage sysLogManage = new SysLogManage();

        /// <summary>
        /// 依据起始时间、结束时间和报警类型查询报警日志信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Query_Click(object sender, EventArgs e)
        {
            string start = this.dtp_Start.Text;
            string end = this.dtp_End.Text;
            string alarmType = this.cmb_AlarmType.Text == "全部" ? "" : this.cmb_AlarmType.Text;

            Task<OperateResult<DataTable>> task1 = Task.Run(() =>
            {
                return QueryProcess(start, end, alarmType);
            });

            Task task2 = task1.ContinueWith(task =>
            {
                this.Invoke(new Action(() =>
                {
                    if (task.Result.IsSuccess)
                    {
                        this.dgv_Main.DataSource = null;
                        this.dgv_Main.DataSource = task.Result.Content;
                    }
                    else
                    {
                        this.dgv_Main.DataSource = null;
                        CommonMethods.AddLog(2, "查询失败，失败原因：" + task.Result.Message);
                        new FrmMsgBoxWithoutAck("查询失败，失败原因：" + task.Result.Message, "报警日志查询").ShowDialog();
                    }
                }));
            });
        }

        /// <summary>
        /// 执行查询任务。以OperateResult的方式统一正确情况以及错误（异常）情况的返回值。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="alarmType"></param>
        /// <returns></returns>
        private OperateResult<DataTable> QueryProcess(string start, string end, string alarmType)
        {
            // 判断时间
            DateTime startTime = Convert.ToDateTime(start);
            DateTime endTime = Convert.ToDateTime(end);
            if(startTime > endTime)
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
                DataTable dataTable = sysLogManage.QuerySysLogByCondition(start, end, alarmType);
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
        /// 添加行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Main_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewHelper.DgvRowPostPaint(sender as DataGridView, e);
        }

        /// <summary>
        /// 将日志信息导出Excel表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Export_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "xlsx文件(*.xlsx)|*.xlsx|所有文件|*.*";
            saveFileDialog.Title = "导出历史报警日志";
            saveFileDialog.FileName = "历史报警" + DateTime.Now.ToString("yyyyMMddHHmmss");
            saveFileDialog.DefaultExt = "xlsx";
            saveFileDialog.AddExtension = true;

            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                MiniExcel.SaveAs(saveFileDialog.FileName, this.dgv_Main.DataSource);
                if(new FrmMsgBoxWithAck("导出报警成功，是否立即打开？", "打开导出的报警日志文件").ShowDialog() == DialogResult.OK)
                {
                    Process.Start(saveFileDialog.FileName);
                }
            }
        }

        #region 实现单元格内容可选择复制但不可编辑
        /// <summary>
        /// 编辑单元格的控件时触发执行此方法，用于设置单元格内容可选择复制但不可修改。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Main_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // 当单元格进入编辑时，获取其宿主编辑控件，并判断该控件是否是TextBox类型
            if (e.Control is TextBox textBox)
            {
                // 将编辑控件（TextBox）设为只读，从而允许选择复制，但禁止修改文本
                textBox.ReadOnly = true;
            }
        }

        /// <summary>
        /// 重写 DataGridView 的 ProcessCmdKey 方法，当检测到 Ctrl+C 时，如果当前单元格的编辑控件是 TextBox 且有选中文字，
        /// 就执行用户自定义的复制逻辑。
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // 检查条件：
            // 1. 按下了 Ctrl+C
            // 2. 当前正在编辑的单元格存在
            // 3. 编辑器控件是 TextBox
            // 4. TextBox 中有选中文本
            if (keyData == (Keys.Control | Keys.C) &&
                this.dgv_Main.CurrentCell != null &&
                this.dgv_Main.EditingControl is TextBox textBox &&
                textBox.SelectionLength > 0)
            {
                // 让 TextBox 执行复制
                textBox.Copy();
                // 返回 true 表示该按键已处理，DataGridView 不会再执行默认的整行复制
                return true;
            }

            // 否则按默认处理
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
    }
}
