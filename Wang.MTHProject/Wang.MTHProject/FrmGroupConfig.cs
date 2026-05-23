using MiniExcelLibs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wang.MTHHelper;
using Wang.MTHModels;

namespace Wang.MTHProject
{
    public partial class FrmGroupConfig : Form
    {
        public FrmGroupConfig(string _devpath, string _groupPath, string _variablePath)
        {
            InitializeComponent();

            devPath = _devpath;
            groupPath = _groupPath;
            variablePath = _variablePath;

            // 设置ComboBox的数据源
            this.cmb_StoreArea.DataSource = new string[]
            {
                "输入线圈", "输出线圈", "输入寄存器", "输出寄存器"
            };

            this.dgv_Main.AutoGenerateColumns = false;
            this.dgv_Main.ReadOnly = false;

            TotalGroups = GetAllGroups();
            RefreshGroups();
        }

        #region 相关文件路径及通信组集合
        // 设备配置文件路径
        private readonly string devPath = Application.StartupPath + "\\Config\\Device.ini";
        // 存储通信组的Excel表的路径
        private readonly string groupPath = Application.StartupPath + "\\Config\\Group.xlsx";
        // 存储变量的Excel表的路径
        private readonly string variablePath = Application.StartupPath + "\\Config\\Variable.xlsx";

        // 存储所有Excel表中记录的通信组
        private readonly List<Group> TotalGroups = null;
        #endregion

        #region 获取所有的通信组
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

        #region 刷新DataGridView的通信组数据显示
        /// <summary>
        /// 刷新DataGridView的通信组数据显示（为DGV的数据源重新赋值）
        /// </summary>
        private void RefreshGroups()
        {
            // 仅在TotalGroups有内容时修改DGV的绑定数据源，防止发生选中行时索引超出范围的Bug（避免使DGV的数据源绑定到内容为空的集合）。
            if (TotalGroups != null && TotalGroups.Count > 0)
            {
                this.dgv_Main.DataSource = null;
                this.dgv_Main.DataSource = TotalGroups;
            }
        }
        #endregion

        #region 添加通信组时判断组名是否已被使用
        /// <summary>
        /// 判断逻辑：在当前TotalGroups中找是否有通信组名称与当前想要添加的通信组名称相同
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        private bool IsGroupNameExists(string groupName)
        {
            return TotalGroups.FindAll(c => c.GroupName == groupName).ToList().Count > 0;
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

        #region 在DataGridView中绘制行号
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

        #region 关闭窗体
        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 在单元格内容为空时显示“---”
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

                if (value == null || value.ToString().Length == 0)
                {
                    // 当单元格的内容为空时，设置其的内容为“---”。
                    e.Value = "---";
                }
            }
        }
        #endregion

        #region 用于设置单元格内容可选择复制但不可修改
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

        #region 添加、删除、修改通信组
        /// <summary>
        /// 添加通信组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            string groupName = this.txt_GroupName.Text.Trim();
            if (groupName.Length <= 0)
            {
                new FrmMsgBoxWithoutAck("通信组名称不能为空！", "添加通信组").ShowDialog();
                return;
            }
            // 通信组名称重复的不能添加（视通信组名称为主键）
            if (IsGroupNameExists(groupName))
            {
                new FrmMsgBoxWithoutAck("通信组名称已存在，不能重复！", "添加通信组").ShowDialog();
                return;
            }

            Group group = new Group() 
            {
                // 属性初始化器
                GroupName = groupName,
                StartAddress = Convert.ToUInt16(this.num_StartAddress.Value),
                Length = Convert.ToUInt16(this.num_Length.Value),
                StoreArea = this.cmb_StoreArea.Text,
                Remark = this.txt_Remark.Text.Trim()
            };

            TotalGroups.Add(group);

            try
            {
                MiniExcel.SaveAs(groupPath, TotalGroups, overwriteFile: true);

                // 更新全局Device配置信息
                if (CommonMethods.Device != null)
                {
                    CommonMethods.Device.GroupList = TotalGroups;
                }
                else
                {
                    CommonMethods.Device = CommonMethods.LoadDevice(devPath, groupPath, variablePath);
                    if (CommonMethods.Device != null)
                    {
                        // 调用CommonMethods中的AddLog委托，它已绑定到具体方法
                        CommonMethods.AddLog(0, "添加通信组成功，设备信息加载成功。");
                    }
                    else
                    {
                        CommonMethods.AddLog(2, "添加通信组，设备信息加载失败。");
                    }
                }

                // 刷新数据显示
                RefreshGroups();
            }
            catch (Exception ex)
            {
                // 在Excel表中添加通信组失败，则也在TotalGroups中移除之前添加的通信组
                TotalGroups.RemoveAll(c => c.GroupName == group.GroupName);
                // TotalGroups = GetAllGroups();
                if (TotalGroups.Count == 0)
                {
                    this.dgv_Main.DataSource = null;
                }
                else
                {
                    // 刷新数据显示
                    RefreshGroups();
                }
                CommonMethods.AddLog(2, "在Excel表中添加通信组失败，失败原因：" + ex.Message);
                new FrmMsgBoxWithoutAck("在Excel表中添加通信组失败，失败原因：" + ex.Message, "添加通信组").ShowDialog();
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
        /// 依据通信组名称删除指定通信组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string groupName = this.txt_GroupName.Text.Trim();
            if(!IsGroupNameExists(groupName))
            {
                new FrmMsgBoxWithoutAck("通信组名称不存在！", "删除通信组").ShowDialog();
                return;
            }
            Group group = TotalGroups.Find(c => c.GroupName == groupName);
            // 移除集合中所有组名为groupName的通信组
            TotalGroups.RemoveAll(c => c.GroupName == groupName);
            try
            {
                // 重新将TotalGroups的内容保存到Excel表中
                MiniExcel.SaveAs(groupPath, TotalGroups, overwriteFile: true);

                // 更新全局Device配置信息
                if (CommonMethods.Device != null)
                {
                    CommonMethods.Device.GroupList = TotalGroups;
                }
                else
                {
                    CommonMethods.Device = CommonMethods.LoadDevice(devPath, groupPath, variablePath);
                    if (CommonMethods.Device != null)
                    {
                        // 调用CommonMethods中的AddLog委托，它已绑定到具体方法
                        CommonMethods.AddLog(0, "删除通信组成功，设备信息加载成功。");
                    }
                    else
                    {
                        CommonMethods.AddLog(2, "删除通信组，设备信息加载失败。");
                    }
                }

                if (TotalGroups.Count == 0)
                {
                    // 当集合TotalGroups为空时，设置dgv_Main的数据源为null。
                    this.dgv_Main.DataSource = null;
                }
                else
                {
                    // 刷新数据显示
                    RefreshGroups();
                }
            }
            catch (Exception ex)
            {
                // 在Excel表中删除通信组失败，则在TotalGroups中恢复之前移除的通信组
                TotalGroups.Add(group);
                // TotalGroups = GetAllGroups();
                // 刷新数据显示
                RefreshGroups();
                CommonMethods.AddLog(2, "在Excel表中删除通信组失败，失败原因：" + ex.Message);
                new FrmMsgBoxWithoutAck("在Excel表中删除通信组失败，失败原因：" + ex.Message, "删除通信组").ShowDialog();
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
        /// 修改指定通信组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Modify_Click(object sender, EventArgs e)
        {
            string groupName = this.txt_GroupName.Text.Trim();
            if(!IsGroupNameExists(groupName))
            {
                new FrmMsgBoxWithoutAck("通信组名称不存在！", "修改通信组").ShowDialog();
                return;
            }
            // 先找到对应通信组
            Group group = TotalGroups.Find(c => c.GroupName == groupName);

            // 先保存该通信组的成员旧值
            ushort old_StartAddress = group.StartAddress;
            ushort old_Length = group.Length;
            string old_StoreArea = group.StoreArea;
            string old_Remark = group.Remark;

            // 修改通信组时，不可修改通信组名称
            group.StartAddress = Convert.ToUInt16(this.num_StartAddress.Value);
            group.Length = Convert.ToUInt16(this.num_Length.Value);
            group.StoreArea = this.cmb_StoreArea.Text.Trim();
            group.Remark = this.txt_Remark.Text.Trim();
            try
            {
                // 重新将TotalGroups的内容保存到Excel表中
                MiniExcel.SaveAs(groupPath, TotalGroups, overwriteFile: true);

                // 更新全局Device配置信息
                if (CommonMethods.Device != null)
                {
                    CommonMethods.Device.GroupList = TotalGroups;
                }
                else
                {
                    CommonMethods.Device = CommonMethods.LoadDevice(devPath, groupPath, variablePath);
                    if (CommonMethods.Device != null)
                    {
                        // 调用CommonMethods中的AddLog委托，它已绑定到具体方法
                        CommonMethods.AddLog(0, "修改通信组成功，设备信息加载成功。");
                    }
                    else
                    {
                        CommonMethods.AddLog(2, "修改通信组，设备信息加载失败。");
                    }
                }

                // 刷新数据显示
                RefreshGroups();
            }
            catch (Exception ex)
            {
                // 在Excel表中修改通信组失败，则在TotalGroups中恢复之前的通信组成员旧值
                group.StartAddress = old_StartAddress;
                group.Length = old_Length;
                group.StoreArea = old_StoreArea;
                group.Remark = old_Remark;
                // TotalGroups = GetAllGroups();
                // 刷新数据显示
                RefreshGroups();
                CommonMethods.AddLog(2, "在Excel表中修改通信组失败，失败原因：" + ex.Message);
                new FrmMsgBoxWithoutAck("在Excel表中修改通信组失败，失败原因：" + ex.Message, "修改通信组").ShowDialog();
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

        #region 依据选中的单元格，更新显示的表单内容
        /// <summary>
        /// 依据指定的通信组，更新显示的表单内容
        /// </summary>
        /// <param name="group"></param>
        private void UpdateGroupForm(Group group)
        {
            if (group == null) return;

            this.txt_GroupName.Text = group.GroupName;
            this.num_StartAddress.Text = group.StartAddress.ToString();
            this.num_Length.Text = group.Length.ToString();
            this.cmb_StoreArea.Text = group.StoreArea.ToString();
            this.txt_Remark.Text = group.Remark;
        }

        /// <summary>
        /// 点击单元格时触发执行此方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                // 依据选中的行，找到对应的Group
                Group group = TotalGroups[e.RowIndex];
                // 依据指定的通信组，更新显示的表单内容
                UpdateGroupForm(group);
            }
            else
            {
                UpdateGroupForm(new Group()
                {
                    GroupName = string.Empty,
                    StartAddress = 0,
                    Length = 100,
                    StoreArea = string.Empty,
                    Remark = string.Empty
                });
            }
        }
        #endregion
    }
}
