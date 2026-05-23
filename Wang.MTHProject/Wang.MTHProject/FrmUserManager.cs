using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wang.MTHBLL;
using Wang.MTHHelper;
using Wang.MTHModels;

namespace Wang.MTHProject
{
    public partial class FrmUserManager : Form
    {
        public FrmUserManager()
        {
            InitializeComponent();

            // 这个事件在DGV数据绑定完成后触发
            dgv_UserManage.DataBindingComplete += Dgv_UserManage_DataBindingComplete;

            this.dgv_UserManage.AutoGenerateColumns = false;
            this.dgv_UserManage.ReadOnly = false;

            UpdateData();
        }

        /// <summary>
        /// 这个事件触发方法在DGV数据绑定完成后触发执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_UserManage_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv_UserManage.ClearSelection();
        }

        /// <summary>
        /// 用户表管理业务
        /// </summary>
        private readonly SysAdminManage sysAdminManage = new SysAdminManage();

        /// <summary>
        /// 存储查询到的所有用户信息
        /// </summary>
        private List<SysAdmin> sysAdminList = new List<SysAdmin>();

        /// <summary>
        /// 查询用户数据表，更新sysAdminList和DGV显示。
        /// </summary>
        private void UpdateData()
        {
            try
            {
                sysAdminList = sysAdminManage.QueryAllSysAdmins();
                if (sysAdminList.Count > 0)
                {
                    this.dgv_UserManage.DataSource = null;
                    this.dgv_UserManage.DataSource = sysAdminList;
                }
                else
                {
                    this.dgv_UserManage.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                CommonMethods.AddLog(2, "查询用户数据表失败！原因：" + ex.Message);
                new FrmMsgBoxWithoutAck("查询用户数据表失败！原因：" + ex.Message, "查询用户").ShowDialog();
            }
        }

        /// <summary>
        /// 聚焦用户名称文本框时取消DGV的所有选中。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_LoginName_Enter(object sender, EventArgs e)
        {
            dgv_UserManage.ClearSelection();
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            if(this.txt_LoginName.Text.Trim().Length <= 0)
            {
                new FrmMsgBoxWithoutAck("用户名不能为空！", "添加用户").ShowDialog();
                return;
            }
            if(this.txt_LoginPwd.Text.Length <= 0)
            {
                new FrmMsgBoxWithoutAck("用户密码不能为空！", "添加用户").ShowDialog();
                return;
            }
            if(this.txt_LoginPwd2.Text.Length <= 0)
            {
                new FrmMsgBoxWithoutAck("确认密码不能为空！", "添加用户").ShowDialog();
                return;
            }

            if(this.txt_LoginPwd.Text != this.txt_LoginPwd2.Text)
            {
                new FrmMsgBoxWithoutAck("确认密码与设置的密码不一致！请重新输入。", "添加用户").ShowDialog();
                return;
            }

            if(sysAdminList.Where(c => c.LoginName == this.txt_LoginName.Text.Trim()).ToList().Count > 0)
            {
                new FrmMsgBoxWithoutAck("用户名不可与已有用户重复！", "添加用户").ShowDialog();
                return;
            }

            // 添加用户
            SysAdmin sysAdmin = new SysAdmin()
            {
                LoginName = this.txt_LoginName.Text.Trim(),
                LoginPwd = this.txt_LoginPwd.Text,
                ParamSet = this.chk_ParamSet.Checked,
                Recipe = this.chk_Recipe.Checked,
                HistoryLog = this.chk_HistoryLog.Checked,
                HistoryTrend = this.chk_HistoryTrend.Checked,
                UserManage = this.chk_UserManage.Checked
            };
            try
            {
                if (sysAdminManage.AddSysAdmin(sysAdmin))
                {
                    UpdateData();
                }
                else
                {
                    CommonMethods.AddLog(2, "添加用户失败！");
                    new FrmMsgBoxWithoutAck("添加用户失败！", "添加用户").ShowDialog();
                }
            }
            catch (Exception ex)
            {
                CommonMethods.AddLog(2, "添加用户失败！原因：" + ex.Message);
                new FrmMsgBoxWithoutAck("添加用户失败！原因：" + ex.Message, "添加用户").ShowDialog();
            }
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Modify_Click(object sender, EventArgs e)
        {
            if (this.txt_LoginName.Text.Trim().Length <= 0)
            {
                new FrmMsgBoxWithoutAck("用户名不能为空！", "修改用户").ShowDialog();
                return;
            }
            if (this.txt_LoginPwd.Text.Length <= 0)
            {
                new FrmMsgBoxWithoutAck("用户密码不能为空！", "修改用户").ShowDialog();
                return;
            }
            if (this.txt_LoginPwd2.Text.Length <= 0)
            {
                new FrmMsgBoxWithoutAck("确认密码不能为空！", "修改用户").ShowDialog();
                return;
            }

            if (this.txt_LoginPwd.Text != this.txt_LoginPwd2.Text)
            {
                new FrmMsgBoxWithoutAck("确认密码与设置的密码不一致！请重新输入。", "修改用户").ShowDialog();
                return;
            }

            int _loginId;

            // 判断是否修改用户名称
            if (this.dgv_UserManage.SelectedRows != null && this.dgv_UserManage.SelectedRows.Count > 0 &&
                sysAdminList[this.dgv_UserManage.SelectedRows[0].Index].LoginName != this.txt_LoginName.Text.Trim())
            {
                // 如果是修改用户名称，则检查修改后的用户名是否与已有的其它用户名重复
                if (sysAdminList.Where(c => c.LoginName == this.txt_LoginName.Text.Trim()).ToList().Count > 0)
                {
                    new FrmMsgBoxWithoutAck("修改的用户名不可与已有用户重复！", "修改用户").ShowDialog();
                    return;
                }

                _loginId = sysAdminList[this.dgv_UserManage.SelectedRows[0].Index].LoginId;
            }
            else
            {
                List<SysAdmin> temp = sysAdminList.Where(c => c.LoginName == this.txt_LoginName.Text.Trim()).ToList();
                // 直接编辑用户名称文本框时应取消DGV的所有选中。然后需要判断输入的用户名称能否在数据表中找到，若找不到则用户名称非法。
                if (temp.Count <= 0)
                {
                    new FrmMsgBoxWithoutAck("用户名称无法在数据表中找到，不可修改！", "修改用户").ShowDialog();
                    return;
                }

                _loginId = temp[0].LoginId;
            }

            SysAdmin sysAdmin = new SysAdmin()
            {
                LoginId = _loginId,
                LoginName = this.txt_LoginName.Text.Trim(),
                LoginPwd = this.txt_LoginPwd.Text,
                ParamSet = this.chk_ParamSet.Checked,
                Recipe = this.chk_Recipe.Checked,
                HistoryLog = this.chk_HistoryLog.Checked,
                HistoryTrend = this.chk_HistoryTrend.Checked,
                UserManage = this.chk_UserManage.Checked
            };
            try
            {
                if (sysAdminManage.ModifySysAdmin(sysAdmin))
                {
                    UpdateData();
                }
                else
                {
                    CommonMethods.AddLog(2, "修改用户失败！");
                    new FrmMsgBoxWithoutAck("修改用户失败！", "修改用户").ShowDialog();
                }
            }
            catch (Exception ex)
            {
                CommonMethods.AddLog(2, "修改用户失败！原因：" + ex.Message);
                new FrmMsgBoxWithoutAck("修改用户失败！原因：" + ex.Message, "修改用户").ShowDialog();
            }
        }

        /// <summary>
        /// 删除用户（可批量选中删除）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            List<int> _loginIds = new List<int>();

            // 判断DGV是否有选中行
            if (this.dgv_UserManage.SelectedRows != null && this.dgv_UserManage.SelectedRows.Count > 0)
            {
                // 依据DGV的选中行删除对应用户
                for(int i = 0; i < this.dgv_UserManage.SelectedRows.Count; i++)
                {
                    _loginIds.Add(sysAdminList[this.dgv_UserManage.SelectedRows[i].Index].LoginId);
                }
            }
            else
            {
                // 若DGV没有选中行，则依据用户名称文本框中的用户名称删除对应用户
                List<SysAdmin> temp = sysAdminList.Where(c => c.LoginName == this.txt_LoginName.Text.Trim()).ToList();
                // 直接编辑用户名称文本框时应取消DGV的所有选中。然后需要判断输入的用户名称能否在数据表中找到，若找不到则用户名称非法。
                if (temp.Count <= 0)
                {
                    new FrmMsgBoxWithoutAck("用户名称无法在数据表中找到，不可删除！", "删除用户").ShowDialog();
                    return;
                }

                _loginIds.Add(temp[0].LoginId);
            }

            try
            {
                if (new FrmMsgBoxWithAck("确定要删除指定用户吗？", "删除用户").ShowDialog() == DialogResult.OK)
                {
                    if (sysAdminManage.DeleteSysAdmin(_loginIds.ToArray()))
                    {
                        UpdateData();
                    }
                    else
                    {
                        CommonMethods.AddLog(2, "删除用户失败！");
                        new FrmMsgBoxWithoutAck("删除用户失败！", "删除用户").ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                CommonMethods.AddLog(2, "删除用户失败！原因：" + ex.Message);
                new FrmMsgBoxWithoutAck("删除用户失败！原因：" + ex.Message, "删除用户").ShowDialog();
            }
        }

        /// <summary>
        /// 清空文本框信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            this.txt_LoginName.Clear();
            this.txt_LoginPwd.Clear();
            this.txt_LoginPwd2.Clear();
        }

        private void SetChecked(bool value)
        {
            this.chk_ParamSet.Checked = value;
            this.chk_Recipe.Checked = value;
            this.chk_HistoryLog.Checked = value;
            this.chk_HistoryTrend.Checked = value;
            this.chk_UserManage.Checked = value;
        }

        /// <summary>
        /// 全选/全不选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SelectAll_Click(object sender, EventArgs e)
        {
            SetChecked(!this.chk_ParamSet.Checked);
        }

        /// <summary>
        /// 添加行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_UserManage_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewHelper.DgvRowPostPaint(sender as DataGridView, e);
        }

        /// <summary>
        /// 点击单元格事件处理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_UserManage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                UpdateUserInfoForm(sysAdminList[e.RowIndex]);
            }
            else
            {
                UpdateUserInfoForm(new SysAdmin()
                {
                    LoginName = string.Empty,
                    LoginPwd = string.Empty,
                    ParamSet = false,
                    Recipe = false,
                    HistoryLog = false,
                    HistoryTrend = false,
                    UserManage = false
                });
            }
        }

        /// <summary>
        /// 依据对应的用户对象更新表单显示
        /// </summary>
        /// <param name="sysAdmin"></param>
        private void UpdateUserInfoForm(SysAdmin sysAdmin)
        {
            if (sysAdmin != null)
            {
                this.txt_LoginName.Text = sysAdmin.LoginName;
                this.txt_LoginPwd.Text = sysAdmin.LoginPwd;
                this.txt_LoginPwd2.Text = sysAdmin.LoginPwd;
                this.chk_ParamSet.Checked = sysAdmin.ParamSet;
                this.chk_Recipe.Checked = sysAdmin.Recipe;
                this.chk_HistoryLog.Checked = sysAdmin.HistoryLog;
                this.chk_HistoryTrend.Checked = sysAdmin.HistoryTrend;
                this.chk_UserManage.Checked = sysAdmin.UserManage;
            }
        }

        /// <summary>
        /// 对单元格显示内容进行格式化显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_UserManage_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex >= 2)
            {
                object value = this.dgv_UserManage.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (value != null)
                {
                    if(value.ToString().ToLower() == "true")
                    {
                        e.Value = "启用";
                    }
                    else if(value.ToString().ToLower() == "false")
                    {
                        e.Value = "禁用";
                    }
                }
            } 
        }

        #region 实现单元格内容可选择复制但不可编辑
        /// <summary>
        /// 编辑单元格的控件时触发执行此方法，用于设置单元格内容可选择复制但不可修改。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_UserManage_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
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
                this.dgv_UserManage.CurrentCell != null &&
                this.dgv_UserManage.EditingControl is TextBox textBox &&
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
