using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wang.MTHModels;

namespace Wang.MTHDAL
{
    public class ActualDataService
    {
        /// <summary>
        /// 向实时数据表中插入数据（数据访问层）
        /// </summary>
        /// <param name="actualData">要插入的数据对象</param>
        /// <returns>受影响的行数，可能抛出异常</returns>
        /// <exception cref="Exception"></exception>
        public int AddActualData(ActualData actualData)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Insert into ActualData(InsertTime, Station1Temp, Station1Humidity, ");
            stringBuilder.Append("Station2Temp, Station2Humidity, Station3Temp, Station3Humidity, ");
            stringBuilder.Append("Station4Temp, Station4Humidity, Station5Temp, Station5Humidity, ");
            stringBuilder.Append("Station6Temp, Station6Humidity) values(@InsertTime, @Station1Temp, @Station1Humidity, ");
            stringBuilder.Append("@Station2Temp, @Station2Humidity, @Station3Temp, @Station3Humidity, ");
            stringBuilder.Append("@Station4Temp, @Station4Humidity, @Station5Temp, @Station5Humidity, ");
            stringBuilder.Append("@Station6Temp, @Station6Humidity)");

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@InsertTime", actualData.InsertTime),
                new SqlParameter("@Station1Temp", actualData.Station1Temp),
                new SqlParameter("@Station1Humidity", actualData.Station1Humidity),
                new SqlParameter("@Station2Temp", actualData.Station2Temp),
                new SqlParameter("@Station2Humidity", actualData.Station2Humidity),
                new SqlParameter("@Station3Temp", actualData.Station3Temp),
                new SqlParameter("@Station3Humidity", actualData.Station3Humidity),
                new SqlParameter("@Station4Temp", actualData.Station4Temp),
                new SqlParameter("@Station4Humidity", actualData.Station4Humidity),
                new SqlParameter("@Station5Temp", actualData.Station5Temp),
                new SqlParameter("@Station5Humidity", actualData.Station5Humidity),
                new SqlParameter("@Station6Temp", actualData.Station6Temp),
                new SqlParameter("@Station6Humidity", actualData.Station6Humidity)
            };
            try
            {
                return SQLHelper.ExecuteNonQuery(stringBuilder.ToString(), sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception("数据访问层发生异常：" + ex.Message);
            }
        }

        /// <summary>
        /// 依据时间条件和要查询的列名进行实时数据表查询（数据访问层）
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="columns"></param>
        /// <returns>查询得到的数据表，为null表示没有查询到合法数据。可能抛出异常</returns>
        /// <exception cref="Exception"></exception>
        public DataTable QueryActualDataByCondition(string start, string end, List<string> columns)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Select InsertTime, ");
            stringBuilder.Append(string.Join(",", columns));
            stringBuilder.Append(" from ActualData where InsertTime between @Start and @End");

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@Start", start),
                new SqlParameter("@End", end)
            };

            try
            {
                DataSet dataSet = SQLHelper.GetDataSet(stringBuilder.ToString(), sqlParameters);
                if (dataSet != null && dataSet.Tables.Count > 0)
                {
                    return dataSet.Tables[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("数据访问层抛出异常：" + ex.Message);
            }
        }
    }
}
