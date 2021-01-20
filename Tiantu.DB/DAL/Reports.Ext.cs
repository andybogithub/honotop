using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Tiantu.DB.DAL
{
    public partial class Reports
    {

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public IEnumerable<Tiantu.DB.Model.ReportsExt> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.REPORTID desc");
            }
            strSql.Append(")AS Row, T.REPORTID,T.TITLE,T.PDFURL,T.PDFURL_EN,T.IMGURL,IMGURL_EN,T.PUBDATE,T.SORTID,C.CATEID,C.CATENAME from Reports T ");
            strSql.Append("LEFT JOIN Categorys C ON T.CATEID=C.CATEID ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                IEnumerable<Tiantu.DB.Model.ReportsExt> list = cn.Query<Tiantu.DB.Model.ReportsExt, Tiantu.DB.Model.Categorys, Tiantu.DB.Model.ReportsExt>(strSql.ToString(),
                      (reports, categorys) =>
                      {
                          reports.Categorys = categorys;
                          return reports;
                      }, null, null, true, "REPORTID,CATEID", null, null);
                cn.Close();
                return list;
            }
        }

    }
}
