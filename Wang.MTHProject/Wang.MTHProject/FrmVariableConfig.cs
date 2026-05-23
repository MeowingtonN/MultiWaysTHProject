using MiniExcelLibs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.DataConvertLib;
using Wang.MTHHelper;
using Wang.MTHModels;

namespace Wang.MTHProject
{
    public partial class FrmVariableConfig : Form
    {
        public FrmVariableConfig(string _devpath, string _groupPath, string _variablePath)
        {
            InitializeComponent();

            devPath = _devpath;
            groupPath = _groupPath;
            variablePath = _variablePath;

            // 设置数据类型下拉框的数据源
            this.cmb_DataType.DataSource = Enum.GetNames(typeof(DataType));

            this.dgv_Main.AutoGenerateColumns = false;
            this.dgv_Main.ReadOnly = false;

            List<Group> TotalGroups = GetAllGroups();

            this.TotalVariables = GetAllVariables();
            //this.CurrentVariables = TotalVariables;
            // 为下拉框条目选中（条目索引赋值）事件绑定处理方法
            this.cmb_GroupName.SelectedIndexChanged += Cmb_GroupName_SelectedIndexChanged;

            if (TotalGroups != null && TotalGroups.Count > 0)
            {
                // 设置通信组名称下拉框数据源
                foreach (Group item in TotalGroups)
                {
                    this.cmb_GroupName.Items.Add(item.GroupName);
                }
                this.cmb_GroupName.SelectedIndex = -1;
                RefreshVariables();
            }
        }

        /// <summary>
        /// 下拉框条目选中（条目索引赋值）事件处理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cmb_GroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshVariables();
        }

        #region 设备配置文件路径、存储通信组和变量的Excel表的路径、变量集合
        // 设备配置文件路径
        private readonly string devPath = Application.StartupPath + "\\Config\\Device.ini";
        // 存储通信组的Excel表的路径
        private readonly string groupPath = Application.StartupPath + "\\Config\\Group.xlsx";
        // 存储变量的Excel表的路径
        private readonly string variablePath = Application.StartupPath + "\\Config\\Variable.xlsx";

        // 存储Excel表中记录的所有变量
        private readonly List<Variable> TotalVariables = null;
        // 用于存储当前变量（经过筛选后的）的集合
        private List<Variable> CurrentVariables = null;
        #endregion

        #region 查询Excel表格，获取所有通信组
        /// <summary>
        /// 查询指定Excel表格，获取所有的通信组
        /// </summary>
        /// <returns></returns>
        private List<Group> GetAllGroups()
        {
            try
            {
                return MiniExcel.Query<Group>(groupPath).ToList();
            }
            catch (Exception)
            {
                // 若指定Excel不存在或内容为空，则先返回内容为空的集合
                return new List<Group>();
            }
        }
        #endregion

        #region 查询指定Excel表格，获取所有的变量
        /// <summary>
        /// 查询指定Excel表格，获取所有的变量
        /// </summary>
        /// <returns></returns>
        private List<Variable> GetAllVariables()
        {
            try
            {
                return MiniExcel.Query<Variable>(variablePath).ToList();
            }
            catch (Exception)
            {
                // 若指定Excel不存在或内容为空，则先返回内容为空的集合
                return new List<Variable>();
            }
        }
        #endregion

        #region 依据所有的变量，根据通信组名称筛选变量
        /// <summary>
        /// 根据通信组名称筛选变量
        /// </summary>
        /// <param name="groupName">通信组名称</param>
        /// <returns></returns>
        private List<Variable> GetVariablesByGroupName(string groupName)
        {
            if(groupName == null || groupName.Length == 0)
            {
                return TotalVariables;
            }
            else
            {
                return TotalVariables.FindAll(c => c.GroupName == groupName).ToList();
            }
        }
        #endregion

        #region 刷新DataGridView的变量数据显示
        /// <summary>
        /// 刷新DataGridView的变量数据显示（为DGV的数据源重新赋值）
        /// </summary>
        private void RefreshVariables()
        {
            List<Variable> list = GetVariablesByGroupName(this.cmb_GroupName.Text.Trim());
            // 仅在list有内容时修改DGV数据展示的绑定数据源，防止发生选中行时索引超出范围的Bug（避免使DGV数据展示的数据源绑定到内容为空的集合）。
            if (list != null && list.Count > 0)
            {
                this.CurrentVariables = list;
                this.dgv_Main.DataSource = null;
                this.dgv_Main.DataSource = list;
            }
            else
            {
                this.CurrentVariables = list;
                this.dgv_Main.DataSource = null;
            }
        }
        #endregion

        #region 添加变量时判断变量名称是否已被使用
        /// <summary>
        /// 判断逻辑：在当前TotalVariables中找是否有变量名称与当前想要添加的变量名称相同
        /// </summary>
        /// <param name="varName"></param>
        /// <returns></returns>
        private bool IsVarNameExists(string varName)
        {
            return TotalVariables.FindAll(c => c.VarName == varName).ToList().Count > 0;
        }
        #endregion

        #region 自定义无边框窗体拖动（Drag）
        private Point mPoint;

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            // 拿到当前点击本窗体的位置
            mPoint = new Point(e.X, e.Y);
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // this.Location表示以屏幕坐标表示的该窗体左上角的点的坐标。
                // e.X - mPoint.X 和 e.Y - mPoint.Y 表示了鼠标左键按下后的位移。
                this.Location = new Point(this.Location.X + (e.X - mPoint.X), this.Location.Y + (e.Y - mPoint.Y));
            }
        }
        #endregion

        #region 编写RowPostPaint事件处理方法，给DataGridView添加行号
        private void dgv_Main_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                // 给DataGridView添加行号
                DataGridViewHelper.DgvRowPostPaint((DataGridView)sender, e);
            }
            catch (Exception ex)
            {
                new FrmMsgBoxWithoutAck(ex.Message, "绘制控件时操作失败").ShowDialog();
            }
        }
        #endregion

        #region 关闭窗口
        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 在单元格内容为空时显示“---”，在上升沿和下降沿报警列依据布尔值显示“启用”或“禁用”
        /// <summary>
        /// 设置单元格内容显示格式时触发执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Main_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // 获取具体单元格中的内容
                object value = this.dgv_Main.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (e.ColumnIndex == 6 || e.ColumnIndex == 7)
                {// 上升沿和下降沿报警列
                    if (value != null)
                    {
                        e.Value = value.ToString() == "True" ? "启用" : "禁用";
                    }
                }
                else
                {
                    if (value == null || value.ToString().Length == 0)
                    {
                        // 当单元格的内容为空时，设置其的内容为“---”。
                        e.Value = "---";
                    }
                }
            }
        }
        #endregion

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

        #region 减少闪烁
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        #endregion

        #region 添加、删除、修改变量
        /// <summary>
        /// 添加变量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            string variableName = this.txt_VarName.Text.Trim();
            if(this.cmb_GroupName.Text.Trim().Length <= 0)
            {
                new FrmMsgBoxWithoutAck("所属通信组名称不能为空！", "添加变量").ShowDialog();
                return;
            }
            if (variableName.Length <= 0)
            {
                new FrmMsgBoxWithoutAck("变量名称不能为空！", "添加变量").ShowDialog();
                return;
            }
            // 变量名称重复的不能添加（视变量名称为主键）
            if (IsVarNameExists(variableName))
            {
                new FrmMsgBoxWithoutAck("变量名称已存在，不能重复！", "添加变量").ShowDialog();
                return;
            }

            Variable variable = new Variable()
            {
                // 属性初始化器
                VarName = variableName,
                Start = Convert.ToUInt16(this.num_Start.Value),
                OffsetOrLength = Convert.ToInt32(this.num_OffsetOrLength.Value),
                DataType = this.cmb_DataType.Text,
                GroupName = this.cmb_GroupName.Text.Trim(),
                PosAlarm = this.chk_PosAlarm.Checked,
                NegAlarm = this.chk_NegAlarm.Checked,
                Scale = Convert.ToSingle(this.num_Scale.Value),
                Offset = Convert.ToSingle(this.num_Offset.Value),
                Remark = this.txt_Remark.Text.Trim()
            };

            TotalVariables.Add(variable);

            try
            {
                MiniExcel.SaveAs(variablePath, TotalVariables, overwriteFile: true);

                // 更新全局Device配置信息
                if(CommonMethods.Device != null)
                {
                    foreach (Group group in CommonMethods.Device.GroupList)
                    {
                        group.VariableList = TotalVariables.FindAll(c => c.GroupName == group.GroupName).ToList();
                    }
                }
                else
                {
                    CommonMethods.Device = CommonMethods.LoadDevice(devPath, groupPath, variablePath);
                    if (CommonMethods.Device != null)
                    {
                        // 调用CommonMethods中的AddLog委托，它已绑定到具体方法
                        CommonMethods.AddLog(0, "添加变量成功。设备信息加载成功。");
                    }
                    else
                    {
                        CommonMethods.AddLog(2, "添加变量，设备信息加载失败。");
                    }
                }

                // 刷新数据显示
                RefreshVariables();
            }
            catch (Exception ex)
            {
                // 在Excel表中添加变量失败，则也在TotalVariables中移除之前添加的变量
                TotalVariables.RemoveAll(c => c.VarName == variable.VarName);
                // this.TotalVariables = GetAllVariables();
                if (TotalVariables.Count == 0)
                {
                    this.dgv_Main.DataSource = null;
                }
                else
                {
                    // 刷新数据显示
                    RefreshVariables();
                }
                CommonMethods.AddLog(2, "在Excel表中添加变量失败，失败原因：" + ex.Message);
                new FrmMsgBoxWithoutAck("在Excel表中添加变量失败，失败原因：" + ex.Message, "添加变量").ShowDialog();
            }
            //finally
            //{
            //    CommonMethods.Device = MainForm.LoadDevice(devPath, groupPath, variablePath);
            //    if (CommonMethods.Device != null)
            //    {
            //        // 调用CommonMethods中的AddLog委托，它已绑定到具体方法
            //        CommonMethods.AddLog(0, "设备信息加载成功");
            //    }
            //    else
            //    {
            //        CommonMethods.AddLog(2, "设备信息加载失败");
            //    }
            //}
        }

        /// <summary>
        /// 依据变量名称删除指定变量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string variableName = this.txt_VarName.Text.Trim();
            if (!IsVarNameExists(variableName))
            {
                new FrmMsgBoxWithoutAck("变量名称不存在！", "删除变量").ShowDialog();
                return;
            }
            Variable variable = TotalVariables.Find(c => c.VarName == variableName);
            // 移除集合中所有变量名为variableName的变量
            TotalVariables.RemoveAll(c => c.VarName == variableName);
            try
            {
                // 重新将TotalVariables的内容保存到Excel表中
                MiniExcel.SaveAs(variablePath, TotalVariables, overwriteFile: true);

                // 更新全局Device配置信息
                if (CommonMethods.Device != null)
                {
                    foreach (Group group in CommonMethods.Device.GroupList)
                    {
                        group.VariableList = TotalVariables.FindAll(c => c.GroupName == group.GroupName).ToList();
                    }
                }
                else
                {
                    CommonMethods.Device = CommonMethods.LoadDevice(devPath, groupPath, variablePath);
                    if (CommonMethods.Device != null)
                    {
                        // 调用CommonMethods中的AddLog委托，它已绑定到具体方法
                        CommonMethods.AddLog(0, "删除变量成功。设备信息加载成功。");
                    }
                    else
                    {
                        CommonMethods.AddLog(2, "删除变量，设备信息加载失败。");
                    }
                }

                if (TotalVariables.Count == 0)
                {
                    // 当集合TotalVariables为空时，设置dgv_Main的数据源为null。
                    this.dgv_Main.DataSource = null;
                }
                else
                {
                    // 刷新数据显示
                    RefreshVariables();
                }
            }
            catch (Exception ex)
            {
                // 在Excel表中删除变量失败，则在TotalVariables中恢复之前移除的变量
                TotalVariables.Add(variable);
                // this.TotalVariables = GetAllVariables();
                // 刷新数据显示
                RefreshVariables();
                CommonMethods.AddLog(2, "在Excel表中删除变量失败，失败原因：" + ex.Message);
                new FrmMsgBoxWithoutAck("在Excel表中删除变量失败，失败原因：" + ex.Message, "删除变量").ShowDialog();
            }
            //finally
            //{
            //    CommonMethods.Device = MainForm.LoadDevice(devPath, groupPath, variablePath);
            //    if (CommonMethods.Device != null)
            //    {
            //        // 调用CommonMethods中的AddLog委托，它已绑定到具体方法
            //        CommonMethods.AddLog(0, "设备信息加载成功");
            //    }
            //    else
            //    {
            //        CommonMethods.AddLog(2, "设备信息加载失败");
            //    }
            //}
        }

        /// <summary>
        /// 修改指定变量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Modify_Click(object sender, EventArgs e)
        {
            string variableName = this.txt_VarName.Text.Trim();
            if (!IsVarNameExists(variableName))
            {
                new FrmMsgBoxWithoutAck("变量名称不存在！", "修改变量").ShowDialog();
                return;
            }
            // 先找到对应变量
            Variable variable = TotalVariables.Find(c => c.VarName == variableName);

            // 先保存该变量的成员旧值
            ushort old_Start = variable.Start;
            int old_OffsetOrLength = variable.OffsetOrLength;
            string old_DataType = variable.DataType;
            string old_GroupName = variable.GroupName;
            bool old_PosAlarm = variable.PosAlarm;
            bool old_NegAlarm = variable.NegAlarm;
            float old_Scale = variable.Scale;
            float old_Offset = variable.Offset;
            string old_Remark = variable.Remark;

            // 修改变量时，不可修改变量名称
            variable.Start = Convert.ToUInt16(this.num_Start.Value);
            variable.OffsetOrLength = Convert.ToInt32(this.num_OffsetOrLength.Value);
            variable.DataType = this.cmb_DataType.Text.Trim();
            variable.GroupName = this.cmb_GroupName.Text.Trim();
            variable.PosAlarm = this.chk_PosAlarm.Checked;
            variable.NegAlarm = this.chk_NegAlarm.Checked;
            variable.Scale = Convert.ToSingle(this.num_Scale.Value);
            variable.Offset = Convert.ToSingle(this.num_Offset.Value);
            variable.Remark = this.txt_Remark.Text.Trim();
            try
            {
                // 重新将TotalVariables的内容保存到Excel表中
                MiniExcel.SaveAs(variablePath, TotalVariables, overwriteFile: true);

                // 更新全局Device配置信息
                if (CommonMethods.Device != null)
                {
                    foreach (Group group in CommonMethods.Device.GroupList)
                    {
                        group.VariableList = TotalVariables.FindAll(c => c.GroupName == group.GroupName).ToList();
                    }
                }
                else
                {
                    CommonMethods.Device = CommonMethods.LoadDevice(devPath, groupPath, variablePath);
                    if (CommonMethods.Device != null)
                    {
                        // 调用CommonMethods中的AddLog委托，它已绑定到具体方法
                        CommonMethods.AddLog(0, "修改变量成功，设备信息加载成功。");
                    }
                    else
                    {
                        CommonMethods.AddLog(2, "修改变量，设备信息加载失败。");
                    }
                }

                // 刷新数据显示
                RefreshVariables();
            }
            catch (Exception ex)
            {
                // 在Excel表中修改变量失败，则在TotalVariables中恢复之前的变量成员旧值
                variable.Start = old_Start;
                variable.OffsetOrLength = old_OffsetOrLength;
                variable.DataType = old_DataType;
                variable.GroupName = old_GroupName;
                variable.PosAlarm = old_PosAlarm;
                variable.NegAlarm = old_NegAlarm;
                variable.Scale = old_Scale;
                variable.Offset = old_Offset;
                variable.Remark = old_Remark;
                // this.TotalVariables = GetAllVariables();
                // 刷新数据显示
                RefreshVariables();
                CommonMethods.AddLog(2, "在Excel表中修改变量失败，失败原因：" + ex.Message);
                new FrmMsgBoxWithoutAck("在Excel表中修改变量失败，失败原因：" + ex.Message, "修改变量").ShowDialog();
            }
            //finally
            //{
            //    CommonMethods.Device = MainForm.LoadDevice(devPath, groupPath, variablePath);
            //    if (CommonMethods.Device != null)
            //    {
            //        // 调用CommonMethods中的AddLog委托，它已绑定到具体方法
            //        CommonMethods.AddLog(0, "设备信息加载成功");
            //    }
            //    else
            //    {
            //        CommonMethods.AddLog(2, "设备信息加载失败");
            //    }
            //}
        }
        #endregion

        #region 点击单元格，更新显示的表单内容
        /// <summary>
        /// 依据指定的变量，更新显示的表单内容
        /// </summary>
        /// <param name="group"></param>
        private void UpdateVariableForm(Variable variable)
        {
            if (variable == null) return;

            this.txt_VarName.Text = variable.VarName;
            this.num_Start.Text = variable.Start.ToString();
            this.num_OffsetOrLength.Text = variable.OffsetOrLength.ToString();
            this.cmb_DataType.Text = variable.DataType;
            this.cmb_GroupName.Text = variable.GroupName;
            this.chk_PosAlarm.Checked = variable.PosAlarm;
            this.chk_NegAlarm.Checked = variable.NegAlarm;
            this.num_Scale.Text = variable.Scale.ToString();
            this.num_Offset.Text = variable.Offset.ToString();
            this.txt_Remark.Text = variable.Remark;
        }

        /// <summary>
        /// 点击单元格时触发执行此方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // 依据选中的行，在当前Variable集合中找到对应的Variable
                Variable variable = CurrentVariables[e.RowIndex];
                // 依据指定的变量，更新显示的表单内容
                UpdateVariableForm(variable);
            }
            else
            {
                UpdateVariableForm(new Variable()
                {
                    VarName = string.Empty,
                    Start = 0,
                    OffsetOrLength = 0,
                    DataType = string.Empty,
                    GroupName = string.Empty,
                    PosAlarm = false,
                    NegAlarm = false,
                    Scale = 1.0f,
                    Offset = 0.0f,
                    Remark = string.Empty
                });
            }
        }
        #endregion
    }
}
