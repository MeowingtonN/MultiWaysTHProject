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
    public class SysAdminService
    {
        /// <summary>
        /// 用户登录（数据访问层）
        /// </summary>
        /// <param name="sysAdmin">填入了用户名和密码的SysAdmin对象</param>
        /// <returns>登录成功（查询用户表有结果）则返回非空的SysAdmin对象，否则返回null。可能抛出异常。</returns>
        /// <exception cref="Exception"></exception>
        public SysAdmin AdminLogin(SysAdmin sysAdmin)
        {
            string sql = "Select LoginId, ParamSet, Recipe, HistoryLog, HistoryTrend, UserManage ";
            sql += "from SysAdmin where LoginName=@LoginName and LoginPwd=@LoginPwd";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@LoginName", sysAdmin.LoginName),
                new SqlParameter("@LoginPwd", sysAdmin.LoginPwd)
            };
            try
            {
                DataSet dataSet = SQLHelper.GetDataSet(sql, parameters);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count == 1)
                {
                    sysAdmin.LoginId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["LoginId"]);
                    sysAdmin.ParamSet = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["ParamSet"]);
                    sysAdmin.Recipe = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["Recipe"]);
                    sysAdmin.HistoryLog = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["HistoryLog"]);
                    sysAdmin.HistoryTrend = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["HistoryTrend"]);
                    sysAdmin.UserManage = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["UserManage"]);
                    return sysAdmin;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("数据访问层发生异常：" + ex.Message);
            }
        }

        /// <summary>
        /// 添加用户（数据访问层）
        /// </summary>
        /// <param name="sysAdmin"></param>
        /// <returns>返回受影响的行数，可能抛出异常</returns>
        /// <exception cref="Exception"></exception>
        public int AddSysAdmin(SysAdmin sysAdmin)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Insert into SysAdmin(LoginName, LoginPwd, ParamSet, Recipe, HistoryLog, HistoryTrend, UserManage)");
            stringBuilder.Append(" values(@LoginName, @LoginPwd, @ParamSet, @Recipe, @HistoryLog, @HistoryTrend, @UserManage)");

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@LoginName", sysAdmin.LoginName),
                new SqlParameter("@LoginPwd", sysAdmin.LoginPwd),
                new SqlParameter("@ParamSet", sysAdmin.ParamSet),
                new SqlParameter("@Recipe", sysAdmin.Recipe),
                new SqlParameter("@HistoryLog", sysAdmin.HistoryLog),
                new SqlParameter("@HistoryTrend", sysAdmin.HistoryTrend),
                new SqlParameter("@UserManage", sysAdmin.UserManage)
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
        /// 批量删除用户（数据访问层）
        /// </summary>
        /// <param name="loginIds"></param>
        /// <returns>返回受影响的行数，可能抛出异常</returns>
        /// <exception cref="Exception"></exception>
        public int DeleteSysAdmin(int[] loginIds)
        {
            if (loginIds == null || loginIds.Length == 0)
                throw new Exception("数据访问层发生异常：LoginId入参数组不合法！");

            // 构建参数化 IN 子句：DELETE FROM SysAdmin WHERE LoginId IN (@LoginId0, @LoginId1, ...)
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DELETE FROM SysAdmin WHERE LoginId IN (");
            SqlParameter[] parameters = new SqlParameter[loginIds.Length];

            for (int i = 0; i < loginIds.Length; i++)
            {
                string paramName = $"@LoginId{i}";
                stringBuilder.Append((i == 0 ? "" : ",") + paramName);
                parameters[i] = new SqlParameter(paramName, loginIds[i]);
            }
            stringBuilder.Append(")");

            try
            {
                return SQLHelper.ExecuteNonQuery(stringBuilder.ToString(), parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("数据访问层发生异常：" + ex.Message);
            }
        }

        /// <summary>
        /// 修改用户信息（数据访问层）
        /// </summary>
        /// <param name="sysAdmin"></param>
        /// <returns>返回受影响的行数，可能抛出异常</returns>
        /// <exception cref="Exception"></exception>
        public int ModifySysAdmin(SysAdmin sysAdmin)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Update SysAdmin set LoginName=@LoginName, LoginPwd=@LoginPwd, ");
            stringBuilder.Append("ParamSet=@ParamSet, Recipe=@Recipe, HistoryLog=@HistoryLog, ");
            stringBuilder.Append("HistoryTrend=@HistoryTrend, UserManage=@UserManage where LoginId=@LoginId");

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@LoginName", sysAdmin.LoginName),
                new SqlParameter("@LoginPwd", sysAdmin.LoginPwd),
                new SqlParameter("@ParamSet", sysAdmin.ParamSet),
                new SqlParameter("@Recipe", sysAdmin.Recipe),
                new SqlParameter("@HistoryLog", sysAdmin.HistoryLog),
                new SqlParameter("@HistoryTrend", sysAdmin.HistoryTrend),
                new SqlParameter("@UserManage", sysAdmin.UserManage),
                new SqlParameter("@LoginId", sysAdmin.LoginId)
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
        /// 查询所有用户（数据访问层）
        /// </summary>
        /// <returns>查询到的所有用户集合，可能抛出异常</returns>
        /// <exception cref="Exception"></exception>
        public List<SysAdmin> QueryAllSysAdmins()
        {
            string sql = "Select LoginId, LoginName, LoginPwd, ParamSet, Recipe, HistoryLog, HistoryTrend, UserManage from SysAdmin";
            
            List<SysAdmin> sysAdminList = new List<SysAdmin>();

            SqlDataReader sqlDataReader = null;
            try
            {
                sqlDataReader = SQLHelper.ExecuteReader(sql);

                while (sqlDataReader.Read())
                {
                    sysAdminList.Add(new SysAdmin()
                    {
                        LoginId = Convert.ToInt32(sqlDataReader["LoginId"]),
                        LoginName = Convert.ToString(sqlDataReader["LoginName"]),
                        LoginPwd = Convert.ToString(sqlDataReader["LoginPwd"]),
                        ParamSet = Convert.ToBoolean(sqlDataReader["ParamSet"]),
                        Recipe = Convert.ToBoolean(sqlDataReader["Recipe"]),
                        HistoryLog = Convert.ToBoolean(sqlDataReader["HistoryLog"]),
                        HistoryTrend = Convert.ToBoolean(sqlDataReader["HistoryTrend"]),
                        UserManage = Convert.ToBoolean(sqlDataReader["UserManage"])
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("数据访问层发生异常：" + ex.Message);
            }

            sqlDataReader?.Close();

            return sysAdminList;
        }
    }
}
