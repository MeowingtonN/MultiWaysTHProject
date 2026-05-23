using Wang.MTHHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.DataConvertLib;
using Wang.MTHModels;

namespace Wang.MTHProject
{
    public partial class FrmRecipe : Form
    {
        public FrmRecipe(string devPath)
        {
            InitializeComponent();
            this.dgv_Main.ReadOnly = false;
            // 显示当前应用的配方
            this.lbl_CurrentRecipe.Text = CommonMethods.Device.CurrentRecipeName;
            this.txt_RecipeName.Text = CommonMethods.Device.CurrentRecipeName;
            this.devPath = devPath;
            RefreshRecipesDGV();
        }

        /// <summary>
        /// 设备配置文件的路径
        /// </summary>
        private readonly string devPath = string.Empty;

        /// <summary>
        /// INI配方配置文件基路径
        /// </summary>
        private readonly string baseRecipePath = Application.StartupPath + "\\Recipe";

        /// <summary>
        /// 存储所有配方的集合
        /// </summary>
        private List<RecipeInfo> allRecipeInfos = null;

        #region 配方添加、修改、删除
        /// <summary>
        /// 添加配方按钮点击事件处理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            if(this.txt_RecipeName.Text.Trim().Length <= 0)
            {
                new FrmMsgBoxWithoutAck("配方名称不可为空，配方添加失败！", "添加配方").ShowDialog();
                return;
            }

            //if (allRecipeInfos.FindAll(c => c.RecipeName == this.txt_RecipeName.Text.Trim()).ToList().Count > 0)
            //{
            //    new FrmMsgBoxWithoutAck("配方名称与已有配方冲突，配方添加失败！", "添加配方").ShowDialog();
            //    return;
            //}

            RecipeInfo info = allRecipeInfos.Where(c => c.RecipeName == this.txt_RecipeName.Text.Trim()).FirstOrDefault();
            if (info != null)
            {
                new FrmMsgBoxWithoutAck("配方名称与已有配方冲突，配方添加失败！", "添加配方").ShowDialog();
                return;
            }

            // 从控件输入构造配方对象并返回该对象
            RecipeInfo recipeInfo = GetRecipeInfoFromForm();

            // 尝试将配方写入配置文件
            bool result = AddRecipe(recipeInfo);
            if (result)
            {
                RefreshRecipesDGV();
                CommonMethods.AddLog(0, "配方添加成功。");
                new FrmMsgBoxWithoutAck("配方添加成功！", "添加配方").ShowDialog();
            }
            else
            {
                CommonMethods.AddLog(2, "配方添加失败。");
                new FrmMsgBoxWithoutAck("配方添加失败！", "添加配方").ShowDialog();
            }
        }

        /// <summary>
        /// 修改配方按钮点击事件处理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Modify_Click(object sender, EventArgs e)
        {
            if (this.txt_RecipeName.Text.Trim().Length <= 0)
            {
                new FrmMsgBoxWithoutAck("配方名称不可为空，配方修改失败！", "修改配方").ShowDialog();
                return;
            }

            RecipeInfo info = allRecipeInfos.Where(c => c.RecipeName == this.txt_RecipeName.Text.Trim()).FirstOrDefault();
            if (info == null)
            {
                new FrmMsgBoxWithoutAck("当前配方不存在，配方修改失败！", "修改配方").ShowDialog();
                return;
            }

            // 从控件输入构造配方对象并返回该对象
            RecipeInfo recipeInfo = GetRecipeInfoFromForm();

            // 尝试将配方写入配置文件（修改配方，即写入覆盖）
            bool result = AddRecipe(recipeInfo);
            if (result)
            {
                CommonMethods.AddLog(0, "配方修改成功。");
                new FrmMsgBoxWithoutAck("配方修改成功！", "修改配方").ShowDialog();
            }
            else
            {
                CommonMethods.AddLog(2, "配方修改失败。");
                new FrmMsgBoxWithoutAck("配方修改失败！", "修改配方").ShowDialog();
            }
        }

        /// <summary>
        /// 删除配方按钮点击事件处理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (this.txt_RecipeName.Text.Trim().Length <= 0)
            {
                new FrmMsgBoxWithoutAck("配方名称不可为空，配方删除失败！", "删除配方").ShowDialog();
                return;
            }

            RecipeInfo info = allRecipeInfos.Where(c => c.RecipeName == this.txt_RecipeName.Text.Trim()).FirstOrDefault();
            if (info == null)
            {
                new FrmMsgBoxWithoutAck("当前配方不存在，配方删除失败！", "删除配方").ShowDialog();
                return;
            }

            DialogResult dialogResult = new FrmMsgBoxWithAck("是否确定要删除该配方？", "删除配方").ShowDialog();
            if(dialogResult == DialogResult.OK)
            {
                bool result = DeleteRecipe(this.txt_RecipeName.Text.Trim());
                if (result)
                {
                    RefreshRecipesDGV();
                    CommonMethods.AddLog(0, "配方删除成功。");
                    new FrmMsgBoxWithoutAck("配方删除成功！", "删除配方").ShowDialog();
                }
                else
                {
                    CommonMethods.AddLog(2, "配方删除失败。");
                    new FrmMsgBoxWithoutAck("配方删除失败！", "删除配方").ShowDialog();
                }
            }
        }
        #endregion

        #region 应用配方
        private void btn_Apply_Click(object sender, EventArgs e)
        {
            if (this.txt_RecipeName.Text.Trim().Length <= 0)
            {
                new FrmMsgBoxWithoutAck("配方名称不可为空，配方应用失败！", "应用配方").ShowDialog();
                return;
            }

            RecipeInfo info = allRecipeInfos.Where(c => c.RecipeName == this.txt_RecipeName.Text.Trim()).FirstOrDefault();
            if (info == null)
            {
                new FrmMsgBoxWithoutAck("当前配方不存在，配方应用失败！", "应用配方").ShowDialog();
                return;
            }

            if(CommonMethods.Device == null)
            {
                new FrmMsgBoxWithoutAck("请检查当前设备相关配置是否完备！", "应用配方").ShowDialog();
                return;
            }
            if (!CommonMethods.Device.IsConnected)
            {
                new FrmMsgBoxWithoutAck("请检查当前设备是否连接正常！", "应用配方").ShowDialog();
                return;
            }

            // 检查一个配方是不是包含了6个站点
            if(info.RecipeParams.Count == 6)
            {
                // 最终要写入寄存器的结果（Modbus报文中先传输的数据放在低地址的寄存器中，在values集合中的索引需在前。写入地址需查看设备文档。）
                List<short> values = new List<short>();

                // ①.向values集合添加每个站点的温湿度高低限
                for(int i = 0; i < 6; i++)
                {
                    values.Add(Convert.ToInt16(info.RecipeParams[i].TempHighLimit * 10));
                    values.Add(Convert.ToInt16(info.RecipeParams[i].TempLowLimit * 10));
                    values.Add(Convert.ToInt16(info.RecipeParams[i].HumidityHighLimit * 10));
                    values.Add(Convert.ToInt16(info.RecipeParams[i].HumidityLowLimit * 10));
                }

                // ②.中间有24个寄存器地址的padding，没有实际用途，为了不中断批量一次性写入，填充0
                for(int i = 0; i < 24; i++)
                {
                    values.Add(0);
                }

                // ③.继续向values集合添加每个站点是否启用温湿度报警数据
                for(int i = 0; i < 6; i++)
                {
                    values.Add((short)(info.RecipeParams[i].TempAlarmEnable ? 1 : 0));
                    values.Add((short)(info.RecipeParams[i].HumidityAlarmEnable ? 1 : 0));
                }

                //MessageBox.Show(string.Join(" ", values));

                // 写入寄存器
                try
                {
                    short errno = 0;
                    bool result = CommonMethods.Modbus.PerSetMultiRegisters(36,
                                                   ByteArrayLib.GetByteArrayFromShortArray(values.ToArray(), CommonMethods.dataFormat),
                                                   ref errno);
                    if (result)
                    {
                        // 配方写入寄存器成功，则将当前配方写入设备配置文件
                        IniConfigHelper.WriteIniData("配方参数", "当前配方", info.RecipeName, devPath);
                        CommonMethods.Device.CurrentRecipeName = info.RecipeName;
                        this.lbl_CurrentRecipe.Text = info.RecipeName;
                        CommonMethods.AddLog(0, "配方数据应用（写入）成功！");
                        new FrmMsgBoxWithoutAck("配方数据应用（写入）成功！", "应用配方").ShowDialog();
                    }
                    else
                    {
                        CommonMethods.AddLog(2, "配方数据应用（写入）失败，错误码：" + errno);
                        new FrmMsgBoxWithoutAck("配方数据应用（写入）失败，错误码：" + errno, "应用配方").ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    CommonMethods.AddLog(2, "配方数据应用（写入）失败，原因：" + ex.Message);
                    new FrmMsgBoxWithoutAck("配方数据应用（写入）失败，原因：" + ex.Message, "应用配方").ShowDialog();
                }
            }
            else
            {
                new FrmMsgBoxWithoutAck("配方数据不完整，请检查！", "应用配方").ShowDialog();
            }
            
        }
        #endregion

        #region 从所有有关的配置文件中获取所有配方
        /// <summary>
        /// 从所有有关的配置文件中获取所有配方
        /// </summary>
        /// <returns>所有配方</returns>
        private List<RecipeInfo> GetAllRecipes()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(baseRecipePath);

            List<FileInfo> fileInfos = directoryInfo.GetFiles("*.ini").ToList();

            List<RecipeInfo> recipeInfos = new List<RecipeInfo>();

            foreach (FileInfo fileInfo in fileInfos)
            {
                recipeInfos.Add(GetRecipeFromIni(fileInfo.FullName));
            }

            return recipeInfos;
        }
        #endregion

        #region 更新“所有配方集合”成员字段以及配方的DGV显示和表单显示
        /// <summary>
        /// 更新“所有配方集合”成员字段以及配方的DGV显示和表单显示
        /// </summary>
        private void RefreshRecipesDGV()
        {
            // 先从所有的配置文件中获取所有的配方并赋给成员字段
            allRecipeInfos = GetAllRecipes();

            if(allRecipeInfos.Count > 0)
            {
                // 先清除DGV的所有行
                this.dgv_Main.Rows.Clear();
                for(int i = 0; i < allRecipeInfos.Count; i++)
                {
                    // 添加一行
                    this.dgv_Main.Rows.Add();
                    // 为该行的每一列设置显示值
                    this.dgv_Main.Rows[i].Cells[0].Value = (i + 1).ToString();
                    this.dgv_Main.Rows[i].Cells[1].Value = allRecipeInfos[i].RecipeName;

                    // 依据配方名选中DGV行
                    if(this.txt_RecipeName.Text == allRecipeInfos[i].RecipeName)
                    {
                        this.dgv_Main.Rows[i].Selected = true;
                    }
                    else
                    {
                        this.dgv_Main.Rows[i].Selected = false;
                    }
                }
                if(this.dgv_Main.SelectedRows.Count > 0)
                {
                    // 依据选中的DGV行更新表单显示
                    SetRecipeInfoToForm(this.allRecipeInfos[this.dgv_Main.SelectedRows[0].Index]);
                }
            }
        }
        #endregion

        #region 从文件读取配方并解析JSON获得配方对象
        /// <summary>
        /// 从文件读取配方并解析JSON获得配方对象（RecipeInfo的每个RecipeParam成员也都能依据JSON解析出来）
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private RecipeInfo GetRecipeFromIni(string path)
        {
            return JSONHelper.JSONToEntity<RecipeInfo>(IniConfigHelper.ReadIniData("配方", "配方数据", "", path));
        }
        #endregion

        #region 从控件输入构造配方对象并获取该对象
        /// <summary>
        /// 从控件输入构造配方对象并返回该对象
        /// </summary>
        /// <returns></returns>
        private RecipeInfo GetRecipeInfoFromForm()
        {
            RecipeInfo recipeInfo = new RecipeInfo();

            recipeInfo.RecipeName = this.txt_RecipeName.Text.Trim();

            recipeInfo.RecipeParams = new List<RecipeParam>()
            {
                this.recipeControl_1.RecipeParam,
                this.recipeControl_2.RecipeParam,
                this.recipeControl_3.RecipeParam,
                this.recipeControl_4.RecipeParam,
                this.recipeControl_5.RecipeParam,
                this.recipeControl_6.RecipeParam
            };

            return recipeInfo;
        }
        #endregion

        #region 添加配方（写入ini文件）
        /// <summary>
        /// 添加配方（写入ini文件）
        /// </summary>
        /// <param name="recipeInfo"></param>
        /// <returns></returns>
        private bool AddRecipe(RecipeInfo recipeInfo)
        {
            string path = baseRecipePath + "\\" + recipeInfo.RecipeName + ".ini";

            // 将配方对象按照JSON格式写入ini文件。
            //（RecipeInfo的RecipeParam成员是集合，也会将集合成员信息变成JSON形式记录到ini文件中。）
            return IniConfigHelper.WriteIniData("配方", "配方数据", JSONHelper.EntityToJSON(recipeInfo), path);
        }
        #endregion

        #region 删除配方（删除ini文件）
        /// <summary>
        /// 删除配方（删除ini文件）
        /// </summary>
        /// <param name="recipeName"></param>
        /// <returns></returns>
        private bool DeleteRecipe(string recipeName)
        {
            try
            {
                File.Delete(baseRecipePath + "\\" + recipeName + ".ini");
                return true;
            }
            catch (Exception ex)
            {
                CommonMethods.AddLog(2, "删除配方对应的配置文件时发生异常，原因：" + ex.Message);
                return false;
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

        #region 选择DGV行时在表单中对应显示配方内容
        /// <summary>
        /// 依据配方内容更新表单显示
        /// </summary>
        /// <param name="recipeInfo"></param>
        private void SetRecipeInfoToForm(RecipeInfo recipeInfo)
        {
            this.txt_RecipeName.Text = recipeInfo.RecipeName;
            if(recipeInfo.RecipeParams.Count == 6)
            {
                this.recipeControl_1.RecipeParam = recipeInfo.RecipeParams[0];
                this.recipeControl_2.RecipeParam = recipeInfo.RecipeParams[1];
                this.recipeControl_3.RecipeParam = recipeInfo.RecipeParams[2];
                this.recipeControl_4.RecipeParam = recipeInfo.RecipeParams[3];
                this.recipeControl_5.RecipeParam = recipeInfo.RecipeParams[4];
                this.recipeControl_6.RecipeParam = recipeInfo.RecipeParams[5];
            }
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
                // 依据行号从全局配方集合中找到对应的配方
                RecipeInfo recipeInfo = allRecipeInfos[e.RowIndex];
                // 依据所得配方内容更新表单显示
                SetRecipeInfoToForm(recipeInfo);
            }
            else
            {
                RecipeInfo recipeInfo = new RecipeInfo();
                for(int i = 0; i < 6; i++)
                {
                    recipeInfo.RecipeParams.Add(new RecipeParam());
                }
                SetRecipeInfoToForm(recipeInfo);
            }
        }
        #endregion
    }
}
