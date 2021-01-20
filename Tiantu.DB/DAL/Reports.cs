using Dapper;
using DapperExtensions;
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tiantu.DB.DBUtility;
using System.Collections.Generic;

namespace Tiantu.DB.DAL
{
    /// <summary>
    /// Reports:数据访问类
    /// </summary>
    public partial class Reports
    {
        private static readonly string _connectionString = DbHelperSQL.ConnectionString;

        public Reports()
        { }
        #region BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string FieldName = "REPORTID";
            string TableName = "Reports";
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
        public bool Exists(int REPORTID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Reports");
            strSql.Append(" where REPORTID=@REPORTID ");
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                int result = cn.QuerySingle<int>(strSql.ToString(), new { REPORTID = REPORTID });
                cn.Close();
                return result > 0;
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tiantu.DB.Model.Reports model)
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
        public bool Update(Tiantu.DB.Model.Reports model)
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
        public bool Delete(int REPORTID)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                Tiantu.DB.Model.Reports model = cn.Get<Tiantu.DB.Model.Reports>(REPORTID);
                bool result = cn.Delete(model);
                cn.Close();
                return result;
            }
        }


        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(int[] REPORTIDlist)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                IEnumerable<int> rows = cn.Query<int>("delete from Reports where REPORTID in @Ids",
                    new { Ids = REPORTIDlist });
                cn.Close();
                return true;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tiantu.DB.Model.Reports GetModel(int REPORTID)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                Tiantu.DB.Model.Reports model = cn.Get<Tiantu.DB.Model.Reports>(REPORTID);
                cn.Close();
                return model;
            }
        }



        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public IEnumerable<Tiantu.DB.Model.Reports> GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" REPORTID,CATEID,TITLE,PDFURL,PDFURL_EN,IMGURL,IMGURL_EN,PUBDATE,SORTID ");
            strSql.Append(" FROM Reports ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                IEnumerable<Tiantu.DB.Model.Reports> list = cn.Query<Tiantu.DB.Model.Reports>(strSql.ToString());
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
            strSql.Append("select count(1) FROM Reports T ");
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


 
        #endregion BasicMethod


    }
}
