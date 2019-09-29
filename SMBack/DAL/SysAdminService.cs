using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace DAL
{
    public class SysAdminService
    {
        #region 管理员登录
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="admins"></param>
        /// <returns></returns>
        public SysAdmins AdminLogin(SysAdmins admins)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@LoginId",admins.LoginId),
                new SqlParameter("@LoginPwd",admins.LoginPwd)
            };

            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader("usp_AdminLogin", sqlParameters, true);
                if (reader.Read())
                {
                    admins.AdminName = reader["AdminName"].ToString();
                    admins.AdminStatus = Convert.ToInt32(reader["AdminStatus"]);
                    admins.RoleId = Convert.ToInt32(reader["RoleId"]);
                }
                else
                {
                    admins = null;
                }
                reader.Close();
                return admins;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 登录、退出日志记录
        /// <summary>
        /// 登录日志记录
        /// </summary>
        /// <param name="logInfo"></param>
        /// <returns></returns>
        public int WriteToLoginLog(LoginLogs logInfo)
        {
            string sql = "insert into LoginLogs(LoginId,SPName,ServerName) values(@LoginId,@SPName,@ServerName);select @@identity";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@LoginId",logInfo.LoginId),
                new SqlParameter("@SPName",logInfo.SPName),
                new SqlParameter("@ServerName",logInfo.ServerName),
            };

            try
            {
                return Convert.ToInt32(SqlHelper.ExecuteScalar(sql, sqlParameters));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 退出登录日志记录
        /// </summary>
        /// <param name="logId"></param>
        /// <returns></returns>
        public int WriteToExitLog(int logId)
        {
            string sql = "update LoginLogs set ExitTime=@ExitTime where LogId=@LogId";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@ExitTime",SqlHelper.GetDbServerTime()),
                new SqlParameter("@LogId",logId),
            };

            try
            {
                return (int)SqlHelper.ExecuteNonQuery(sql, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
