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
    /// Honors:数据访问类
    /// </summary>
    public partial class Honors
    {
        private static readonly string _connectionString = DbHelperSQL.ConnectionString;

        public Honors()
        { }
        #region BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string FieldName = "HONORID";
            string TableName = "Honors";
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
        /// 得到最大ID
        /// </summary>
        public int SetMaxSortId(int HONORID)
        {
            string strsql = @"UPDATE Honors SET SORTID=TT.ROWID FROM (SELECT HONORID,ROW_NUMBER() OVER (ORDER BY SORTID) AS ROWID
		            	FROM Honors) AS TT WHERE TT.HONORID=Honors.HONORID ;
                        UPDATE Honors SET SORTID=(SELECT ISNULL(MAX(SORTID),0)+1 FROM Honors) WHERE dbo.Honors.HONORID=@HONORID";
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                int result = cn.Execute(strsql, new { HONORID = HONORID });
                cn.Close();
                return result;
            }
        }

        /// <summary>
        /// 得到最小ID
        /// </summary>
        public int SetMinSortId(int HONORID)
        {
            string strsql = @"UPDATE Honors SET SORTID=TT.ROWID FROM (SELECT HONORID,ROW_NUMBER() OVER (ORDER BY SORTID) AS ROWID
		            	FROM Honors ) AS TT WHERE TT.HONORID=Honors.HONORID ;
                        UPDATE Honors SET SORTID=(SELECT ISNULL(MIN(SORTID),0)-1 FROM Honors) WHERE dbo.Honors.HONORID=@HONORID";
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                int result = cn.Execute(strsql, new { HONORID = HONORID });
                cn.Close();
                return result;
            }
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int HONORID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Honors");
            strSql.Append(" where HONORID=@HONORID ");
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                int result = cn.QuerySingle<int>(strSql.ToString(), new { HONORID = HONORID });
                cn.Close();
                return result > 0;
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tiantu.DB.Model.Honors model)
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
        public bool Update(Tiantu.DB.Model.Honors model)
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
        public bool Delete(int HONORID)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                Tiantu.DB.Model.Honors model = cn.Get<Tiantu.DB.Model.Honors>(HONORID);
                bool result = cn.Delete(model);
                cn.Close();
                return result;
            }
        }


        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(int[] HONORIDlist)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                IEnumerable<int> rows = cn.Query<int>("delete from Honors where HONORID in @Ids",
                    new { Ids = HONORIDlist });
                cn.Close();
                return true;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tiantu.DB.Model.Honors GetModel(int HONORID)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                Tiantu.DB.Model.Honors model = cn.Get<Tiantu.DB.Model.Honors>(HONORID);
                cn.Close();
                return model;
            }
        }



        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public IEnumerable<Tiantu.DB.Model.Honors> GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" HONORID,IMGURL,SMIMGURL,SORTID ");
            strSql.Append(" FROM Honors ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                IEnumerable<Tiantu.DB.Model.Honors> list = cn.Query<Tiantu.DB.Model.Honors>(strSql.ToString());
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
            strSql.Append("select count(1) FROM Honors ");
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
        public IEnumerable<Tiantu.DB.Model.Honors> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.HONORID desc");
            }
            strSql.Append(")AS Row, T.*  from Honors T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                IEnumerable<Tiantu.DB.Model.Honors> list = cn.Query<Tiantu.DB.Model.Honors>(strSql.ToString());
                cn.Close();
                return list;
            }
        }

        #endregion BasicMethod


    }
}
