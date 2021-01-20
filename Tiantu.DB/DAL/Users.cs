using Dapper;
using DapperExtensions;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using Tiantu.DB.Common;
using Tiantu.DB.DBUtility;

namespace Tiantu.DB.DAL
{
    /// <summary>
    /// 会员
    /// </summary>
    public partial class Users
    {
        public Users()
        { }

        #region  基本方法


        private static readonly string _connectionString = DbHelperSQL.ConnectionString;


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// 
        public bool Exists(int USERID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Users");
            strSql.Append(" where USERID=@USERID");
            SqlParameter[] parameters = {
                    new SqlParameter("@USERID", SqlDbType.Int)
            };
            parameters[0].Value = USERID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 验证密码是否正确
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public bool CheckPassword(int UserId, string Password)
        {
            string UserPassword = SL.EncryptMD5(Password);
            string strSql = string.Format("select count(1) from Users where   USERID={0} AND USERPASS='{1}' ", UserId, UserPassword);
            return DbHelperSQL.Exists(strSql);
        }



        // 会员登录       
        public int GetUseridWithTel(string UserTel, string Password)
        {
            string strSql = "SELECT USERID FROM Users WHERE USERTEL=@USERTEL AND USERPASS = @USERPASS";
            SqlParameter[] parameters = {
                    new SqlParameter("@USERTEL", SqlDbType.NVarChar,11),
                    new SqlParameter("@USERPASS", SqlDbType.NVarChar,32)};
            parameters[0].Value = UserTel;
            parameters[1].Value = SL.EncryptMD5(Password);

            object objRs = DbHelperSQL.GetSingle(strSql, parameters);
            return null == objRs ? 0 : Convert.ToInt32(objRs);
        }



        /// <summary>
        /// 根据会员ID获取会员姓名
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetUserNameById(int userId)
        {
            string strSql = string.Format("select username from Users u where u.UserID={0}", userId);
            object objRs = DbHelperSQL.GetSingle(strSql);
            return null == objRs ? "" : objRs.ToString().Trim();
        }

        /// <summary>
        /// 根据会员ID来获取会员头像地址
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetUserImageUrlById(int userId)
        {
            string strSql = string.Format("select imgurl from Users u where u.UserID={0}", userId);
            object objRs = DbHelperSQL.GetSingle(strSql);
            return null == objRs ? "" : objRs.ToString().Trim();
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Users model)
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
        public bool Update(Model.Users model)
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
        public bool Delete(int USERID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Users ");
            strSql.Append(" where USERID=@USERID");
            SqlParameter[] parameters = {
                    new SqlParameter("@USERID", SqlDbType.Int)
            };
            parameters[0].Value = USERID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string USERIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Users ");
            strSql.Append(" where USERID in (" + USERIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取会员ID通过手机号码
        /// </summary>
        /// <param name="UserTel"></param>
        /// <returns></returns>
        public int GetUserIdByUserTel(string UserTel)
        {
            string strSql = string.Format("SELECT userid FROM Users t WHERE usertel='{0}' ", UserTel);
            object objRs = DbHelperSQL.GetSingle(strSql);
            return null == objRs ? 0 : Convert.ToInt32(objRs);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tiantu.DB.Model.Users GetModel(int USERID)
        {            
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                Tiantu.DB.Model.Users model = cn.Get<Tiantu.DB.Model.Users>(USERID);
                cn.Close();
                return model;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Users T ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM Users ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Users T ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.USERID desc");
            }
            strSql.Append(")AS Row, T.*  from Users T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }



        #endregion  BasicMethod


        private string GetValueFromCookie(string keyName)
        {
            string value = "";
            if (System.Web.HttpContext.Current.Request.Cookies["TiantuUser"] != null)
            {
                value = System.Web.HttpContext.Current.Request.Cookies["TiantuUser"][keyName];
            }
            return value;
        }


        /// <summary>
        /// 获取个人或商户ID （如果是员工登录，则返回商户ID）
        /// </summary>
        public int GetUserIdFromCookie()
        {
            string value = GetValueFromCookie("userid");
            int userid = 0;
            int.TryParse(value, out userid);
            return userid;
        }

        /// <summary>
        /// 获取会员登录账号
        /// </summary>
        public string GetUserNameFromCookie()
        {
            string base64Value = GetValueFromCookie("username");
            string username = "";
            if (!string.IsNullOrEmpty(base64Value))
            {
                username = SL.Base64Decrypt(base64Value);
            }
            return username;
        }



        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="resolution">分辨率</param>
        /// <returns></returns>
        public bool Login(string UserTel, string UserPass, int ExpiredHours)
        {
            int UserId = 0;
            bool isLogin = false;

            string strSql = "SELECT userid, username FROM Users WHERE  USERTEL=@USERTEL AND USERPASS = @USERPASS";

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                UserId = cn.QueryFirstOrDefault<int>(strSql, new { USERTEL = UserTel , USERPASS = SL.EncryptMD5(UserPass) });
                cn.Close();              
            }

            isLogin = (UserId > 0);


            //设置Cookie
            System.Web.HttpCookie userloginCookie = new System.Web.HttpCookie("TiantuUser");
            userloginCookie["userid"] = UserId.ToString();
            userloginCookie.Expires = DateTime.Now.AddHours(7200);//记住登录过的用户ID
            userloginCookie.Path = "/";
            System.Web.HttpContext.Current.Response.Cookies.Add(userloginCookie);


            return isLogin;
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
                if ("TiantuUser".Equals(cookieName))
                {

                    aCookie = new System.Web.HttpCookie(cookieName);
                    aCookie.Expires = DateTime.Now.AddDays(-1);
                    aCookie.Path = "/";

                    System.Web.HttpContext.Current.Response.Cookies.Add(aCookie);
                }
            }
        }


    }


}

