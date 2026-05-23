using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wang.MTHModels
{
    /// <summary>
    /// 用户实体类，和数据表对应
    /// </summary>
    public class SysAdmin
    {
        public int LoginId {  get; set; }

        public string LoginName { get; set; }

        public string LoginPwd {  get; set; }

        // 下面是关于用户的5个不同的权限

        public bool ParamSet {  get; set; }

        public bool Recipe {  get; set; }

        public bool HistoryLog {  get; set; }

        public bool HistoryTrend {  get; set; }

        public bool UserManage {  get; set; }
    }
}
