using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wang.MTHDAL;
using Wang.MTHModels;

// 业务层
namespace Wang.MTHBLL
{
    public class SysLogManage
    {
        /// <summary>
        /// 日志数据表数据访问层服务
        /// </summary>
        private readonly SysLogService sysLogService = new SysLogService();

        /// <summary>
        /// 向日志数据表插入一条报警记录（业务层）
        /// </summary>
        /// <param name="sysLog">要插入的日志数据实体对象</param>
        /// <returns>插入成功返回true，失败返回false，可能抛出异常</returns>
        /// <exception cref="Exception"></exception>
        public bool AddSysLog(SysLog sysLog)
        {
            try
            {
                return sysLogService.AddSysLog(sysLog) == 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 依据时间条件和报警类型查询日志数据表（业务层）
        /// </summary>
        /// <param name="start">数据表条目查询起始日期</param>
        /// <param name="end">数据表条目查询终止日期</param>
        /// <param name="alarmType">报警类型</param>
        /// <returns>返回查询到的数据表，可能抛出异常</returns>
        /// <exception cref="Exception"></exception>
        public DataTable QuerySysLogByCondition(string start, string end, string alarmType)
        {
            try
            {
                return sysLogService.QuerySysLogByCondition(start, end, alarmType);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
