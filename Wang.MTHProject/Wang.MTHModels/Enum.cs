using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wang.MTHModels
{
    /// <summary>
    /// 所有窗体的枚举，小于临界窗体的为固定窗体（不关闭）
    /// </summary>
    public enum FormNames
    {
        集中监控,
        临界窗体,
        参数设置,
        配方管理,
        报警追溯,
        历史趋势,
        用户管理
    }
}
