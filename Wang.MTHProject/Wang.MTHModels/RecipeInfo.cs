using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wang.MTHModels
{
    /// <summary>
    /// 配方实体类
    /// </summary>
    public class RecipeInfo
    {
        /// <summary>
        /// 配方名称
        /// </summary>
        public string RecipeName {  get; set; } = string.Empty;

        /// <summary>
        /// 配方内对于所有站点的配置集合
        /// </summary>
        public List<RecipeParam> RecipeParams { get; set; } = new List<RecipeParam>();
    }
}
