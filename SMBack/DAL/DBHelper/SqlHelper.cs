using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;


namespace DAL
{
    /// <summary>
    /// 通用数据访问类
    /// </summary>
    class SqlHelper
    {
        private static readonly string ConnString = ConfigurationManager.ConnectionStrings["connString"].ToString();

        #region 执行insert、delete、update数据操作
        /// <summary>
        /// 执行insert、delete、update数据操作
        /// </summary>
        /// <param name="cmdText">sql语句或者存储过程名称</param>
        /// <param name="sqlParameters">参数数组</param>
        /// <param name="isProcedure">是否是存储过程，默认不是</param>
        /// <returns>返回受影响的和行数</returns>
        public static int ExecuteNonQuery(string cmdText,SqlParameter[] sqlParameters=null,bool isProcedure=false)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand(cmdText,conn);
            if (sqlParameters != null)
            {
                cmd.Parameters.AddRange(sqlParameters);
            }
            if (isProcedure)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex.Message);
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region 获取单一结果
        /// <summary>
        /// 执行sql并返回单一结果
        /// </summary>
        /// <param name="cmdText">sql语句或者存储过程名称</param>
        /// <param name="sqlParameters">参数数组</param>
        /// <param name="isProcedure">是否是存储过程，默认不是</param>
        /// <returns>返回单一结果的object对象</returns>
        public static object ExecuteScalar(string cmdText, SqlParameter[] sqlParameters = null, bool isProcedure = false)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            if (sqlParameters != null)
            {
                cmd.Parameters.AddRange(sqlParameters);
            }
            if (isProcedure)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex.Message);
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region 执行结果集查询
        /// <summary>
        /// 执行结果集查询
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="sqlParameters"></param>
        /// <param name="isProcedure"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string cmdText, SqlParameter[] sqlParameters = null, bool isProcedure = false)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            if (sqlParameters != null)
            {
                cmd.Parameters.AddRange(sqlParameters);
            }
            if (isProcedure)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                WriteErrorLog(ex.Message);
                throw ex;
            }
        }
        #endregion

        #region 获取数据库服务器时间
        /// <summary>
        /// 获取数据库服务器时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetDbServerTime()
        {
            return Convert.ToDateTime(ExecuteScalar("select getdate()",null));
        }
        #endregion

        #region 返回数据集查询（包括单张数据表以及多张数据表）
        /// <summary>
        /// 执行返回数据集的查询（针对一张数据表）
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="sqlParameters"></param>
        /// <param name="isProcedure"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string cmdText, SqlParameter[] sqlParameters = null, string tableName = null,bool isProcedure=false)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand(cmdText, conn);

            if (isProcedure)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }

            //创建数据适配器
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //创建数据集对象
            DataSet ds = new DataSet();

            if (sqlParameters != null)
            {
                cmd.Parameters.AddRange(sqlParameters);
            }

            try
            {
                conn.Open();
                if (tableName != null)
                {
                    adapter.Fill(ds, tableName);
                }
                else
                {
                    adapter.Fill(ds);
                }
                return ds;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex.Message);
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 使用DataSet存储查询的结果（针对多张数据表）
        /// </summary>
        /// <param name="sqlAndTableName"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(Dictionary<string,string> sqlAndTableName)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            //创建数据适配器
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //创建数据集对象
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                foreach (string tableName in sqlAndTableName.Keys)
                {
                    cmd.CommandText = sqlAndTableName[tableName];
                    adapter.Fill(ds, tableName);
                }

                return ds;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex.Message);
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region 执行事务：提交多条不带参数的sql语句以及提交多条带参数的sql语句，适合主从表的关系
        /// <summary>
        /// 开启事务：提交多条不带参数的sql语句
        /// </summary>
        /// <param name="sqlList"></param>
        /// <returns></returns>
        public static bool ExecuteTransaction(List<string> sqlList)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            try
            {
                //开启事务
                cmd.Transaction = conn.BeginTransaction();
                foreach (var sql in sqlList)
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();//提交事务
                return true;
            }
            catch (Exception ex)
            {
                if (cmd.Transaction != null)
                {
                    cmd.Transaction.Rollback();//执行失败回滚事务
                }
                WriteErrorLog(ex.Message);
                throw ex;
            }
            finally
            {
                if (cmd.Transaction != null)
                {
                    cmd.Transaction = null;//清空事务
                }
                conn.Close();
            }
        }

        /// <summary>
        /// 启用事务，提交多条带参数的sql语句，适合主从表的关系
        /// </summary>
        /// <param name="mainSql"></param>
        /// <param name="mainParam"></param>
        /// <param name="detailSql"></param>
        /// <param name="detailParam"></param>
        /// <returns></returns>
        public static bool ExecuteTransaction(string mainSql,SqlParameter[] mainParam,string detailSql,List<SqlParameter[]> detailParam)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            try
            {
                //开启事务
                cmd.Transaction = conn.BeginTransaction();
                //执行主表sql
                cmd.CommandText = mainSql;
                cmd.Parameters.AddRange(mainParam);
                cmd.ExecuteNonQuery();
                //执行明细表
                cmd.CommandText = detailSql;
                foreach (SqlParameter[] parameters in detailParam)
                {
                    cmd.Parameters.Clear();//此处必须先清空已经添加的参数数组
                    cmd.Parameters.AddRange(parameters);
                    cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();//提交事务
                return true;
            }
            catch (Exception ex)
            {
                if (cmd.Transaction != null)
                {
                    cmd.Transaction.Rollback();//执行失败回滚事务
                }
                WriteErrorLog(ex.Message);
                throw ex;
            }
            finally
            {
                if (cmd.Transaction != null)
                {
                    cmd.Transaction = null;//清空事务
                }
                conn.Close();
            }
        }
        #endregion

        #region 将错误信息写入日志
        /// <summary>
        /// 日志记录
        /// </summary>
        /// <param name="msg"></param>
        private static void WriteErrorLog(string msg)
        {
            FileStream fs = new FileStream("Error.Log",FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write("【"+GetDbServerTime()+"】:"+msg+"\r\n");
            sw.Close();
        }
        #endregion
    }
}
