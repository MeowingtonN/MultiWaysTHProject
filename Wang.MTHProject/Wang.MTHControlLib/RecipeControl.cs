using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wang.MTHModels;

namespace Wang.MTHControlLib
{
    public partial class RecipeControl : UserControl
    {
        public RecipeControl()
        {
            InitializeComponent();
        }

        private string devName = "1#站点";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示当前设备站点")]
        public string DevName
        {
            get { return devName; }
            set 
            { 
                devName = value; 
                this.title.TitleName = devName;
                this.textSetNum_THi.TitleName = devName + "温度高限";
                this.textSetNum_TLo.TitleName = devName + "温度低限";
                this.textSetNum_HHi.TitleName = devName + "湿度高限";
                this.textSetNum_HLo.TitleName = devName + "湿度低限";
            }
        }

        private RecipeParam recipeParam = new RecipeParam();
        /// <summary>
        /// 设置或显示表单（配方参数）内容
        /// </summary>
        [Browsable(false)]
        public RecipeParam RecipeParam
        {
            get
            {
                recipeParam = GetRecipeParam();
                return recipeParam;
            }
            set
            {
                recipeParam = value;
                SetRecipeParam(recipeParam);
            }
        }

        /// <summary>
        /// 获取表单输入所构造的RecipeParam实体
        /// </summary>
        /// <returns></returns>
        private RecipeParam GetRecipeParam()
        {
            return new RecipeParam()
            {
                TempHighLimit = this.textSetNum_THi.CurrentValue,
                TempLowLimit = this.textSetNum_TLo.CurrentValue,
                HumidityHighLimit = this.textSetNum_HHi.CurrentValue,
                HumidityLowLimit = this.textSetNum_HLo.CurrentValue,
                TempAlarmEnable = this.chk_TempAlarmEnable.Checked,
                HumidityAlarmEnable = this.chk_HumidityAlarmEnable.Checked
            };
        }

        /// <summary>
        /// 通过RecipeParam实体填充对应表单显示
        /// </summary>
        /// <param name="recipeParam"></param>
        private void SetRecipeParam(RecipeParam recipeParam)
        {
            this.textSetNum_THi.CurrentValue = recipeParam.TempHighLimit;
            this.textSetNum_TLo.CurrentValue = recipeParam.TempLowLimit;
            this.textSetNum_HHi.CurrentValue = recipeParam.HumidityHighLimit;
            this.textSetNum_HLo.CurrentValue = recipeParam.HumidityLowLimit;
            this.chk_TempAlarmEnable.Checked = recipeParam.TempAlarmEnable;
            this.chk_HumidityAlarmEnable.Checked = recipeParam.HumidityAlarmEnable;
        }
    }
}
