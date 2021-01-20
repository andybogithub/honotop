using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using System.Collections.Generic;
using Tiantu.DB.DBUtility;

namespace Tiantu.DB.DAL
{
	/// <summary>
	/// 数据访问类:Banners
	/// </summary>
	public partial class Banners
	{
		public Banners()
		{}
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("BNID", "Banners");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int BNID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Banners");
            strSql.Append(" where BNID=@BNID");
            SqlParameter[] parameters = {
					new SqlParameter("@BNID", SqlDbType.Int,4)
			};
            parameters[0].Value = BNID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Banners model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Banners(");
            strSql.Append("TITLE,LINKURL,MOBILE_LINKURL,IMGURL,SORTID,TYPE,WEBID)");
            strSql.Append(" values (");
            strSql.Append("@TITLE,@LINKURL,@MOBILE_LINKURL,@IMGURL,@SORTID,@TYPE,@WEBID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@TITLE", SqlDbType.NVarChar,64),
					new SqlParameter("@LINKURL", SqlDbType.NVarChar,200),
                    new SqlParameter("@MOBILE_LINKURL", SqlDbType.NVarChar,200),
					new SqlParameter("@IMGURL", SqlDbType.NVarChar,200),
					new SqlParameter("@SORTID", SqlDbType.Int,4),
					new SqlParameter("@TYPE", SqlDbType.NVarChar,50),
                    new SqlParameter("@WEBID", SqlDbType.Int,4)};
            parameters[0].Value = model.TITLE;
            parameters[1].Value = model.LINKURL;
            parameters[2].Value = model.MOBILE_LINKURL;
            parameters[3].Value = model.IMGURL;
            parameters[4].Value = model.SORTID;
            parameters[5].Value = model.TYPE;
            parameters[6].Value = model.WEBID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Banners model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Banners set ");
            strSql.Append("LINKURL=@LINKURL,");
            strSql.Append("MOBILE_LINKURL=@MOBILE_LINKURL,");
            strSql.Append("IMGURL=@IMGURL,");
            strSql.Append("SORTID=@SORTID,");      
            strSql.Append("TYPE=@TYPE,");
            strSql.Append("WEBID=@WEBID");
            strSql.Append(" where BNID=@BNID");
            SqlParameter[] parameters = {
					new SqlParameter("@LINKURL", SqlDbType.NVarChar,200),
                    new SqlParameter("@MOBILE_LINKURL", SqlDbType.NVarChar,200),
					new SqlParameter("@IMGURL", SqlDbType.NVarChar,200),
					new SqlParameter("@SORTID", SqlDbType.Int,4),                       
                    new SqlParameter("@TYPE", SqlDbType.NVarChar,50),
                    new SqlParameter("@WEBID", SqlDbType.Int,4),
                    new SqlParameter("@BNID", SqlDbType.Int,4)};
            parameters[0].Value = model.LINKURL;
            parameters[1].Value = model.MOBILE_LINKURL;
            parameters[2].Value = model.IMGURL;
            parameters[3].Value = model.SORTID;
            parameters[4].Value = model.TYPE;
            parameters[5].Value = model.WEBID;
            parameters[6].Value = model.BNID;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int BNID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Banners ");
            strSql.Append(" where BNID=@BNID");
            SqlParameter[] parameters = {
					new SqlParameter("@BNID", SqlDbType.Int,4)
			};
            parameters[0].Value = BNID;

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
        public bool DeleteList(string BNIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Banners ");
            strSql.Append(" where BNID in (" + BNIDlist + ")  ");
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
        /// 得到一个对象实体
        /// </summary>
        public Model.Banners GetModel(int BNID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 BNID,TITLE,LINKURL,MOBILE_LINKURL,IMGURL,SORTID,TYPE from Banners ");
            strSql.Append(" where BNID=@BNID");
            SqlParameter[] parameters = {
					new SqlParameter("@BNID", SqlDbType.Int,4)
			};
            parameters[0].Value = BNID;

            Model.Banners model = new Model.Banners();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Banners DataRowToModel(DataRow row)
        {
            Model.Banners model = new Model.Banners();
            if (row != null)
            {
                if (row["BNID"] != null && row["BNID"].ToString() != "")
                {
                    model.BNID = int.Parse(row["BNID"].ToString());
                }
                if (row["TITLE"] != null)
                {
                    model.TITLE = row["TITLE"].ToString();
                }
                if (row["LINKURL"] != null)
                {
                    model.LINKURL = row["LINKURL"].ToString();
                }
                if (row["MOBILE_LINKURL"] != null)
                {
                    model.MOBILE_LINKURL = row["MOBILE_LINKURL"].ToString();
                }
                if (row["IMGURL"] != null)
                {
                    model.IMGURL = row["IMGURL"].ToString();
                }
                if (row["SORTID"] != null && row["SORTID"].ToString() != "")
                {
                    model.SORTID = int.Parse(row["SORTID"].ToString());
                }
                if (row["TYPE"] != null)
                {
                    model.TYPE = row["TYPE"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BNID,TITLE,LINKURL,MOBILE_LINKURL,IMGURL,SORTID,TYPE ");
            strSql.Append(" FROM Banners ");
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
            strSql.Append(" BNID,TITLE,LINKURL,MOBILE_LINKURL,IMGURL,SORTID,TYPE ");
            strSql.Append(" FROM Banners ");
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
            strSql.Append("select count(1) FROM Banners ");
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
                strSql.Append("order by T.BNID desc");
            }
            strSql.Append(")AS Row, T.*  from Banners T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }


        #endregion  BasicMethod





        /// <summary>
        /// 更新标题
        /// </summary>
        public bool UpdateTitle(Model.Banners model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Banners set ");
            strSql.Append("TITLE=@TITLE");
            strSql.Append(" where BNID=@BNID");
            SqlParameter[] parameters = {
                    new SqlParameter("@TITLE", SqlDbType.NVarChar,64),
                    new SqlParameter("@BNID", SqlDbType.Int,4)};
            parameters[0].Value = model.TITLE;
            parameters[1].Value = model.BNID;

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




        #region  ExtensionMethod

        #region 获取Banners资料
        /// <summary>
        /// 数据库表转为列表
        /// </summary>
        /// <param name="dsList"></param>
        /// <returns></returns>
        private IList<Model.Banners> DataSetToModel(DataSet dsList)
        {
            IList<Model.Banners> result = new List<Model.Banners>();
            if (dsList.Tables.Count > 0)
            {
                DataTable dt = dsList.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    result.Add(DataRowToModel(row));
                }
            }
            return result;
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public IList<Model.Banners> GetModelListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            DataSet dsList = GetListByPage(strWhere, orderby, startIndex, endIndex);
            IList<Model.Banners> result = DataSetToModel(dsList);
            return result;
        }
        public IList<Model.Banners> GetModelList(string strWhere)
        {
            DataSet dsList = GetList(strWhere);
            IList<Model.Banners> result = DataSetToModel(dsList);
            return result;
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public IList<Model.Banners> GetModelList(int Top, string strWhere, string filedOrder)
        {
            DataSet dsList = GetList(Top, strWhere, filedOrder);
            IList<Model.Banners> result = DataSetToModel(dsList);
            return result;
        }
        #endregion


		#endregion  ExtensionMethod
	}
}

