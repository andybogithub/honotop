using Dapper;
using DapperExtensions;
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tiantu.DB.DBUtility;
using System.Collections.Generic;
using Tiantu.DB.Common;

namespace Tiantu.DB.DAL
{
	/// <summary>
	/// Admins:数据访问类
	/// </summary>
	public partial class Admins
	{	
        private static readonly string _connectionString = DbHelperSQL.ConnectionString;

		public Admins()
        { }
		#region BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string FieldName = "ADMINID";
            string TableName = "Admins";
            string strsql = "SELECT ISNULL(MAX(" + FieldName + "),0)+1 FROM " + TableName;
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                int result = cn.QuerySingle<int>(strsql);
                cn.Close();
                return result;
            }
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ADMINID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Admins");
            strSql.Append(" where ADMINID=@ADMINID ");
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                int result = cn.QuerySingle<int>(strSql.ToString(), new { ADMINID = ADMINID });
                cn.Close();
                return result > 0;
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tiantu.DB.Model.Admins model)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                int id = cn.Insert(model);
                cn.Close();
                return id;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Tiantu.DB.Model.Admins model)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                bool result = cn.Update(model);
                cn.Close();
                return result;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ADMINID)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                Tiantu.DB.Model.Admins model = cn.Get<Tiantu.DB.Model.Admins>(ADMINID);
                bool result = cn.Delete(model);
                cn.Close();
                return result;
            }
        }


        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(int[] ADMINIDlist)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                IEnumerable<int> rows = cn.Query<int>("delete from Admins where ADMINID in @Ids",
                    new { Ids = ADMINIDlist });
                cn.Close();
                return true;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tiantu.DB.Model.Admins GetModel(int ADMINID)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                Tiantu.DB.Model.Admins model = cn.Get<Tiantu.DB.Model.Admins>(ADMINID);
                cn.Close();
                return model;
            }
        }



        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public IEnumerable<Tiantu.DB.Model.Admins> GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ADMINID,ADMINNAME,ADMINPASS,REALNAME,LASTLOGINTIME,LASTLOGINIP ");
            strSql.Append(" FROM Admins ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                IEnumerable<Tiantu.DB.Model.Admins> list = cn.Query<Tiantu.DB.Model.Admins>(strSql.ToString());
                cn.Close();
                return list;
            }

        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Admins ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                int result = cn.QuerySingle<int>(strSql.ToString());
                cn.Close();
                return result;
            }
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public IEnumerable<Tiantu.DB.Model.Admins> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ADMINID desc");
            }
            strSql.Append(")AS Row, T.*  from Admins T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                IEnumerable<Tiantu.DB.Model.Admins> list = cn.Query<Tiantu.DB.Model.Admins>(strSql.ToString());
                cn.Close();
                return list;
            }
        }

        #endregion BasicMethod

        



    }
}
