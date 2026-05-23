using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wang.MTHDAL;
using Wang.MTHModels;

// 业务层
namespace Wang.MTHBLL
{
    public class SysAdminManage
    {
        /// <summary>
        /// 数据访问层对象
        /// </summary>
        private readonly SysAdminService sysAdminService = new SysAdminService();

        /// <summary>
        /// 用户登录（业务层）
        /// </summary>
        /// <param name="sysAdmin"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public SysAdmin AdminLogin(SysAdmin sysAdmin)
        {
            try
            {
                // 若有业务，比如对于输入进行逻辑判断，可以在这边进行。
                if(sysAdmin.LoginName == null || sysAdmin.LoginName.Length <= 0)
                {
                    throw new Exception("输入异常：用户名不能为空，请输入用户名。");
                }
                if (sysAdmin.LoginPwd == null || sysAdmin.LoginPwd.Length <= 0)
                {
                    throw new Exception("输入异常：密码不能为空，请输入密码。");
                }

                return sysAdminService.AdminLogin(sysAdmin);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 添加用户（业务层）
        /// </summary>
        /// <param name="sysAdmin"></param>
        /// <returns>返回是否添加成功，可能抛出异常</returns>
        /// <exception cref="Exception"></exception>
        public bool AddSysAdmin(SysAdmin sysAdmin)
        {
            try
            {
                return sysAdminService.AddSysAdmin(sysAdmin) == 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 批量删除用户（业务层）
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns>返回是否删除成功，可能抛出异常</returns>
        /// <exception cref="Exception"></exception>
        public bool DeleteSysAdmin(int[] loginIds)
        {
            if (loginIds == null || loginIds.Length <= 0)
                throw new Exception("LoginId入参数组不合法！");

            try
            {
                return sysAdminService.DeleteSysAdmin(loginIds) >= 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 修改用户信息（业务层）
        /// </summary>
        /// <param name="sysAdmin"></param>
        /// <returns>返回是否修改成功，可能抛出异常</returns>
        /// <exception cref="Exception"></exception>
        public bool ModifySysAdmin(SysAdmin sysAdmin)
        {
            try
            {
                return sysAdminService.ModifySysAdmin(sysAdmin) == 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 查询所有用户（业务层）
        /// </summary>
        /// <returns>查询到的所有用户集合，可能抛出异常</returns>
        /// <exception cref="Exception"></exception>
        public List<SysAdmin> QueryAllSysAdmins()
        {
            try
            {
                return sysAdminService.QueryAllSysAdmins();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
