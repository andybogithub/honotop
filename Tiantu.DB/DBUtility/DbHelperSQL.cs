using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Tiantu.DB.DBUtility
{
    public class DbHelperSQL
    {

        /// <summary>
        /// SQL Server 数据库链接
        /// </summary>
        public static string ConnectionString
        {
            get { return connString; }

        }
        private static string connString = System.Configuration.ConfigurationManager.AppSettings["SQLConnectionString"];


        public DbHelperSQL()
        {

        }

        #region 查询语句操作
        public static DataSet Query(string strQuery, SqlParameter[] sparams, out int rowsCount)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(strQuery))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        bool blsparams = (sparams != null && sparams.Length > 0);
                        if (blsparams)
                        {
                            cmd.Parameters.AddRange(sparams);
                        }
                        cmd.Connection = conn;
                        conn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);

                        if (blsparams)
                        {
                            rowsCount = Convert.ToInt32(cmd.Parameters["@rowsCount"].Value);
                        }
                        else
                        {
                            rowsCount = ds.Tables[0].Rows.Count;
                        }
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;

        }

        public static DataSet Query(string strQuery, params SqlParameter[] sparams)
        {
            DataSet ds = Query(CommandType.Text, strQuery, sparams);
            return ds;
        }

        public static DataSet ProcQuery(string procQuery, params SqlParameter[] sparams)
        {
            DataSet ds = Query(CommandType.StoredProcedure, procQuery, sparams);
            return ds;
        }

        private static DataSet Query(CommandType cmdType, string strQuery, params SqlParameter[] sparams)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(strQuery))
                    {
                        cmd.CommandType = cmdType;
                        cmd.Connection = conn;
                        bool blsparams = (sparams != null && sparams.Length > 0);
                        if (blsparams)
                        {
                            cmd.Parameters.AddRange(sparams);
                        }
                        conn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        #endregion


        #region 执行语句操作
        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        public static int ExecuteSqlTran(List<String> SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    int count = 0;
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n];
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            count += cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                    return count;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw ex;
                    //return 0;
                }
            }
        }


        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        public static void ExecuteSqlTranWithIndentity(Hashtable SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        int indentity = 0;
                        //循环
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                            foreach (SqlParameter q in cmdParms)
                            {
                                if (q.Direction == ParameterDirection.InputOutput)
                                {
                                    q.Value = indentity;
                                }
                            }
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            foreach (SqlParameter q in cmdParms)
                            {
                                if (q.Direction == ParameterDirection.Output)
                                {
                                    indentity = Convert.ToInt32(q.Value);
                                }
                            }
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }


        public static int ExecuteSql(string strQuery, params SqlParameter[] sparams)
        {
            return Execute(CommandType.Text, strQuery, sparams);
        }


        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        public static int ExecuteSqlTran(System.Collections.Generic.List<CommandInfo> cmdList)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        int count = 0;
                        //循环
                        foreach (CommandInfo myDE in cmdList)
                        {
                            string cmdText = myDE.CommandText;
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Parameters;
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);

                            if (myDE.EffentNextType == EffentNextType.WhenHaveContine || myDE.EffentNextType == EffentNextType.WhenNoHaveContine)
                            {
                                if (myDE.CommandText.ToLower().IndexOf("count(") == -1)
                                {
                                    trans.Rollback();
                                    return 0;
                                }

                                object obj = cmd.ExecuteScalar();
                                bool isHave = false;
                                if (obj == null && obj == DBNull.Value)
                                {
                                    isHave = false;
                                }
                                isHave = Convert.ToInt32(obj) > 0;

                                if (myDE.EffentNextType == EffentNextType.WhenHaveContine && !isHave)
                                {
                                    trans.Rollback();
                                    return 0;
                                }
                                if (myDE.EffentNextType == EffentNextType.WhenNoHaveContine && isHave)
                                {
                                    trans.Rollback();
                                    return 0;
                                }
                                continue;
                            }
                            int val = cmd.ExecuteNonQuery();
                            count += val;
                            if (myDE.EffentNextType == EffentNextType.ExcuteEffectRows && val == 0)
                            {
                                trans.Rollback();
                                return 0;
                            }
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                        return count;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }


        public static void ExecuteProcQuery(string procQuery, params SqlParameter[] sparams)
        {
            Execute(CommandType.StoredProcedure, procQuery, sparams);
        }

        private static int Execute(CommandType cmdType, string strQuery, params SqlParameter[] sparams)
        {
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(strQuery))
                    {
                        cmd.CommandType = cmdType;
                        bool blsparams = (null != sparams && sparams.Length > 0);
                        if (blsparams)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddRange(sparams);
                        }
                        cmd.Connection = conn;
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion


        #region 取一行记录的一列值
        public static int GetMaxID(string FieldName, string TableName)
        {
            string strsql = "SELECT ISNULL(MAX(" + FieldName + "),0)+1 FROM " + TableName;
            object obj = GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }

        public static bool Exists(string strSql)
        {
            object obj = GetSingle(strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool Exists(string strSql, params SqlParameter[] cmdParms)
        {
            object obj = GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static object GetSingle(string strQuery, params SqlParameter[] sparams)
        {
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(strQuery))
                    {
                        cmd.CommandType = CommandType.Text;
                        bool blsparams = (null != sparams && sparams.Length > 0);
                        if (blsparams)
                        {
                            cmd.Parameters.AddRange(sparams);
                        }
                        cmd.Connection = conn;
                        conn.Open();
                        object obj = cmd.ExecuteScalar();
                        if (blsparams)
                        {
                            cmd.Parameters.Clear();
                        }

                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion
    }

}