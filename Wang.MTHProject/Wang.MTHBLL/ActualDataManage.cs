using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wang.MTHDAL;
using Wang.MTHModels;

namespace Wang.MTHBLL
{
    public class ActualDataManage
    {
        /// <summary>
        /// 实时数据表数据访问层服务
        /// </summary>
        private readonly ActualDataService actualDataService = new ActualDataService();

        /// <summary>
        /// 向实时数据表中插入数据（业务层）
        /// </summary>
        /// <param name="actualData"></param>
        /// <returns>插入成功返回true，失败返回false，可能抛出异常</returns>
        /// <exception cref="Exception"></exception>
        public bool AddActualData(ActualData actualData)
        {
            try
            {
                return actualDataService.AddActualData(actualData) == 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 依据时间条件和要查询的列名进行实时数据表查询（业务层）
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="columns"></param>
        /// <returns>查询得到的数据表，为null表示没有查询到合法数据。可能抛出异常。</returns>
        /// <exception cref="Exception"></exception>
        public DataTable QueryActualDataByCondition(string start, string end, List<string> columns)
        {
            try
            {
                return actualDataService.QueryActualDataByCondition(start, end, columns);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
