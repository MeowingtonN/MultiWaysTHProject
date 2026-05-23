using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wang.MTHModels
{
    /// <summary>
    /// 配方内对于一个站点的配置实体类，和配方配置表单对应
    /// </summary>
    public class RecipeParam
    {
        public float TempHighLimit { get; set; }

        public float TempLowLimit { get; set; }

        public float HumidityHighLimit { get; set; }

        public float HumidityLowLimit { get; set; }

        public bool TempAlarmEnable { get; set; }

        public bool HumidityAlarmEnable { get; set; }
    }
}
