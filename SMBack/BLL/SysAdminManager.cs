using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using DAL;
using Models;

namespace BLL
{
    /// <summary>
    /// 管理员业务类
    /// </summary>
    public class SysAdminManager
    {
        private SysAdminService adminService = new SysAdminService();
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="admins"></param>
        /// <returns></returns>
        public SysAdmins AdminLogin(SysAdmins admins)
        {
            admins = adminService.AdminLogin(admins);
         
            if (admins != null && admins.AdminStatus == 1)
            {
                //登录成功日志记录
                LoginLogs logInfo = new LoginLogs
                {
                    LoginId = admins.LoginId,
                    SPName = admins.AdminName,
                    ServerName  = Dns.GetHostName()
                };
                var logId = adminService.WriteToLoginLog(logInfo);
                admins.LogId = logId;//为退出做准备
            }

            return admins;
        }

        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="admins"></param>
        /// <returns></returns>
        public int AdminLogout(int logId)
        {
            return adminService.WriteToExitLog(logId);
        }

    }
}
