using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wang.MTHModels;

// 数据访问层
namespace Wang.MTHDAL
{
    public class SysLogService
    {
        /// <summary>
        /// 向日志数据表插入一条报警记录（数据访问层）
        /// </summary>
        /// <param name="sysLog">要插入的日志数据实体对象</param>
        /// <returns>返回受影响的行数，可能抛出异常</returns>
        /// <exception cref="Exception"></exception>
        public int AddSysLog(SysLog sysLog)
        {
            string sql = "Insert into SysLog(InsertTime, Note, AlarmType, Operator, VarName) ";
            sql += "values(@InsertTime, @Note, @AlarmType, @Operator, @VarName)";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@InsertTime", sysLog.InsertTime),
                new SqlParameter("@Note", sysLog.Note),
                new SqlParameter("@AlarmType", sysLog.AlarmType),
                new SqlParameter("@Operator", sysLog.Operator),
                new SqlParameter("@VarName", sysLog.VarName)
            };
            try
            {
                return SQLHelper.ExecuteNonQuery(sql, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception("数据访问层抛出异常：" + ex.Message);
            }
        }

        /// <summary>
        /// 依据时间条件和报警类型查询日志数据表（数据访问层）
        /// </summary>
        /// <param name="start">数据表条目查询起始日期</param>
        /// <param name="end">数据表条目查询终止日期</param>
        /// <param name="alarmType">报警类型</param>
        /// <returns>返回查询到的数据表，可能抛出异常</returns>
        /// <exception cref="Exception"></exception>
        public DataTable QuerySysLogByCondition(string start, string end, string alarmType)
        {
            string sql = "Select InsertTime, Note, AlarmType, Operator, VarName from SysLog where InsertTime between @Start and @End";

            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@Start", start),
                new SqlParameter("@End", end)
            };

            if(alarmType != null && alarmType.Length > 0 && alarmType != "全部")
            {
                sql += " and AlarmType=@AlarmType";
                sqlParameters.Add(new SqlParameter("@AlarmType", alarmType));
            }

            try
            {
                DataSet dataSet = SQLHelper.GetDataSet(sql, sqlParameters.ToArray());
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
