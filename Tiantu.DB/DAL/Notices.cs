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
	/// Notices:数据访问类
	/// </summary>
	public partial class Notices
	{	
        private static readonly string _connectionString = DbHelperSQL.ConnectionString;

		public Notices()
        { }
		#region BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string FieldName = "NOTICEID";
            string TableName = "Notices";
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
        public bool Exists(int NOTICEID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Notices");
            strSql.Append(" where NOTICEID=@NOTICEID ");
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                int result = cn.QuerySingle<int>(strSql.ToString(), new { NOTICEID = NOTICEID });
                cn.Close();
                return result > 0;
            }
        }

        public bool Exists(string title)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Notices");
            strSql.Append(" where title=@title ");
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                int result = cn.QuerySingle<int>(strSql.ToString(), new { title = title });
                cn.Close();
                return result > 0;
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tiantu.DB.Model.Notices model)
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
        public bool Update(Tiantu.DB.Model.Notices model)
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
        public bool Delete(int NOTICEID)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                Tiantu.DB.Model.Notices model = cn.Get<Tiantu.DB.Model.Notices>(NOTICEID);
                bool result = cn.Delete(model);
                cn.Close();
                return result;
            }
        }


        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(int[] NOTICEIDlist)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                IEnumerable<int> rows = cn.Query<int>("delete from Notices where NOTICEID in @Ids",
                    new { Ids = NOTICEIDlist });
                cn.Close();
                return true;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tiantu.DB.Model.Notices GetModel(int NOTICEID)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                Tiantu.DB.Model.Notices model = cn.Get<Tiantu.DB.Model.Notices>(NOTICEID);
                cn.Close();
                return model;
            }
        }



        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public IEnumerable<Tiantu.DB.Model.Notices> GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" NOTICEID,TITLE,SUBTITLE,CONTENTS,TITLE_EN,SUBTITLE_EN,CONTENTS_EN,PDFURL,PDFURL_EN,SORTID,PUBDATE ");
            strSql.Append(" FROM Notices ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                IEnumerable<Tiantu.DB.Model.Notices> list = cn.Query<Tiantu.DB.Model.Notices>(strSql.ToString());
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
            strSql.Append("select count(1) FROM Notices ");
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
        public IEnumerable<Tiantu.DB.Model.Notices> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.NOTICEID desc");
            }
            strSql.Append(")AS Row, T.*  from Notices T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                IEnumerable<Tiantu.DB.Model.Notices> list = cn.Query<Tiantu.DB.Model.Notices>(strSql.ToString());
                cn.Close();
                return list;
            }
        }

		#endregion BasicMethod

	
	}
}
