using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wang.MTHModels
{
    /// <summary>
    /// 实时温湿度数据实体类
    /// </summary>
    public class ActualData
    {
        /// <summary>
        /// 数据插入时间
        /// </summary>
        public string InsertTime {  get; set; }

        public string Station1Temp {  get; set; }

        public string Station1Humidity {  get; set; }

        public string Station2Temp { get; set; }

        public string Station2Humidity { get; set; }

        public string Station3Temp { get; set; }

        public string Station3Humidity { get; set; }

        public string Station4Temp { get; set; }

        public string Station4Humidity { get; set; }

        public string Station5Temp { get; set; }

        public string Station5Humidity { get; set; }

        public string Station6Temp { get; set; }

        public string Station6Humidity { get; set; }
    }
}
