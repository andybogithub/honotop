using System;
using System.Data;
using System.Data.SqlClient;
using Tiantu.DB.Common;
using Tiantu.DB.DBUtility;
using Dapper;
using DapperExtensions;
using System.Text;
using System.Collections.Generic;

namespace Tiantu.DB.DAL
{
    public partial class Admins
    {
        #region 管理员登录
        public bool Login(string AdminName, string AdminPass)
        {
            int AdminId = 0;
            string strSql = "SELECT AdminId FROM Admins WHERE  AdminName=@AdminName AND AdminPass = @AdminPass";
            SqlParameter[] parameters = {
                    new SqlParameter("@AdminName", SqlDbType.NVarChar,16),
                    new SqlParameter("@AdminPass", SqlDbType.NVarChar,32)};
            parameters[0].Value = AdminName;
            parameters[1].Value = SL.EncryptMD5(AdminPass);
            object rs = DbHelperSQL.GetSingle(strSql, parameters);
            AdminId = (null == rs ? 0 : Convert.ToInt32(rs));

            if (AdminId > 0)
            {
                System.Web.HttpCookie userCookie = new System.Web.HttpCookie("tiantuAdmin");
                userCookie["AdminId"] = AdminId.ToString();
                userCookie.Expires = DateTime.Now.AddDays(1);
                userCookie.Path = "/";
                System.Web.HttpContext.Current.Response.Cookies.Add(userCookie);
            }
            return AdminId > 0;
        }


        /// <summary>
        /// 获取登录ID
        /// </summary>
        public int GetAdminIdFromCookie()
        {
            int AdminId = 0;
            if (System.Web.HttpContext.Current.Request.Cookies["tiantuAdmin"] != null)
            {
                string strAdminId = System.Web.HttpContext.Current.Request.Cookies["tiantuAdmin"]["AdminId"];
                int.TryParse(strAdminId, out AdminId);
            }
            return AdminId;
        }



        /// <summary>
        /// 删除登录信息
        /// </summary>
        public void Logout()
        {
            System.Web.HttpCookie aCookie;
            string cookieName;
            int limit = System.Web.HttpContext.Current.Request.Cookies.Count;
            for (int i = 0; i < limit; i++)
            {
                cookieName = System.Web.HttpContext.Current.Request.Cookies[i].Name;
                if ("tiantuAdmin".Equals(cookieName))
                {
                    aCookie = new System.Web.HttpCookie(cookieName);
                    aCookie.Expires = DateTime.Now.AddDays(-1);
                    aCookie.Path = "/";
                    System.Web.HttpContext.Current.Response.Cookies.Add(aCookie);
                }
            }
        }

        /// <summary>
        /// 用户是否登陆
        /// </summary>
        /// <returns></returns>
        public bool IsLogin()
        {
            int AdminId = GetAdminIdFromCookie();
            return AdminId > 0;
        }


        #endregion



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddLoginLog(Tiantu.DB.Model.LoginLog model)
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
        /// 分页获取数据列表
        /// </summary>
        public IEnumerable<Tiantu.DB.Model.LoginLog> GetLogList(string strWhere, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.LogId desc");
            }
            strSql.Append(")AS Row, T.*  from LoginLog T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                IEnumerable<Tiantu.DB.Model.LoginLog> list = cn.Query<Tiantu.DB.Model.LoginLog>(strSql.ToString());
                cn.Close();
                return list;
            }
        }


        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetLogCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM LoginLog ");
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



    }
}
