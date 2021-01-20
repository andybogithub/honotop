using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tiantu.DB.DBUtility;
using System.Data.SqlClient;
using Tiantu.DB.Model;
using System.Data;
using Dapper;
using DapperExtensions;


namespace Tiantu.DB.DAL
{


    public class ShopStore
    {


        private static readonly string _connectionString = DbHelperSQL.ConnectionString;


        #region 兑换商品分类
        /// <summary>
        /// 添加或更新商品分类
        /// </summary>
        /// <param name="model"></param>
        public void AddOrUpdateShopCategory(ShopCategory model)
        {
            StringBuilder strSql = new StringBuilder();

            SqlParameter[] parameters = null;
            if (model.CategoryId == 0)
            {
                strSql.Append("insert into Shop_Categorys(");
                strSql.Append("CategoryName,ClazzId)");
                strSql.Append(" values (");
                strSql.Append("@CategoryName,@ClazzId)");
                strSql.Append(";select @@IDENTITY");
                parameters = new SqlParameter[]  {
                    new SqlParameter("@CategoryName", SqlDbType.NVarChar,16),
                    new SqlParameter("@ClazzId", SqlDbType.Int )};
                parameters[0].Value = model.CategoryName;
                parameters[1].Value = model.ClazzId;
            }
            else
            {
                strSql.Append("update Shop_Categorys set ");
                strSql.Append("CategoryName=@CategoryName,");
                strSql.Append("ClazzId=@ClazzId");
                strSql.Append(" where CategoryId=@CategoryId");
                parameters = new SqlParameter[] {
                    new SqlParameter("@CategoryName", SqlDbType.NVarChar,16),
                    new SqlParameter("@ClazzId", SqlDbType.Int ),
                    new SqlParameter("@CategoryId", SqlDbType.Int )};
                parameters[0].Value = model.CategoryName;
                parameters[1].Value = model.ClazzId;
                parameters[2].Value = model.CategoryId;
            }

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一个产品分类
        /// </summary>
        /// <param name="categoryId"></param>
        public void DeleteShopCategory(int categoryId)
        {
            string strSql = string.Format("delete from Shop_Categorys where categoryId={0}", categoryId);
            DbHelperSQL.ExecuteSql(strSql);
        }

        /// <summary>
        /// 获取商品分类列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetShopCategoryList(string strWhere = "")
        {
            string strSql = "select * from Shop_Categorys t";
            if (strWhere.Length > 0)
                strSql += " where " + strWhere;
            return DbHelperSQL.Query(strSql);
        }

        public ShopCategory GetShopCategoryModel(int categoryId)
        {
            string strSql = string.Format("select * from Shop_Categorys t where t.categoryId={0}", categoryId);
            DataSet dsList = DbHelperSQL.Query(strSql);

            ShopCategory model = null;
            if (dsList != null && dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                model = Common.SL.DataRowToModel<ShopCategory>(dsList.Tables[0].Rows[0]);
            return model;
        }
        #endregion


        #region 兑换商品
        /// <summary>
        /// 添加或更新商品分类
        /// </summary>
        /// <param name="model"></param>
        public void AddOrUpdateShopProduct(ShopProduct model)
        {
            StringBuilder strSql = new StringBuilder();

            SqlParameter[] parameters = null;
            if (model.ProductId == 0)
            {
                strSql.Append("insert into Shop_Products(");
                strSql.Append("ProductName,ClazzId,CategoryId,Point,InsurancePrice,Qty,Shipment,ProductDetails,TJTag,PubTime,ImageIcon,QtyStatus,IsOnLine,SeckillTag,SubName,ShowHomeTag,HotTag,DBNeedTotal,DBAllowJoin)");
                strSql.Append(" values (");
                strSql.Append("@ProductName,@ClazzId,@CategoryId,@Point,@InsurancePrice,@Qty,@Shipment,@ProductDetails,@TJTag,@PubTime,@ImageIcon,@QtyStatus,@IsOnLine,@SeckillTag,@SubName,@ShowHomeTag,@HotTag,@DBNeedTotal,@DBAllowJoin)");
                strSql.Append(";select @@IDENTITY");
                parameters = new SqlParameter[] {
                    new SqlParameter("@ProductName", SqlDbType.NVarChar,128),
                    new SqlParameter("@ClazzId", SqlDbType.Int ),
                    new SqlParameter("@CategoryId", SqlDbType.Int ),
                    new SqlParameter("@Point", SqlDbType.Int ),
                    new SqlParameter("@InsurancePrice", SqlDbType.Decimal,6),
                    new SqlParameter("@Qty", SqlDbType.Int ),
                    new SqlParameter("@Shipment", SqlDbType.NVarChar,8),
                    new SqlParameter("@ProductDetails", SqlDbType.NVarChar,-1),
                    new SqlParameter("@TJTag", SqlDbType.Bit,1),
                    new SqlParameter("@PubTime", SqlDbType.DateTime),
                    new SqlParameter("@ImageIcon", SqlDbType.NVarChar,256),
                    new SqlParameter("@QtyStatus", SqlDbType.NVarChar,8),
                    new SqlParameter("@IsOnLine", SqlDbType.Bit,1),
                    new SqlParameter("@SeckillTag", SqlDbType.Bit,1),
                    new SqlParameter("@SubName", SqlDbType.NVarChar,128),
                    new SqlParameter("@ShowHomeTag", SqlDbType.Bit,1),
                    new SqlParameter("@HotTag", SqlDbType.Bit,1),
                    new SqlParameter("@DBNeedTotal", SqlDbType.Int),
                    new SqlParameter("@DBAllowJoin", SqlDbType.Int)
               };
                parameters[0].Value = model.ProductName;
                parameters[1].Value = model.ClazzId;
                parameters[2].Value = model.CategoryId;
                parameters[3].Value = model.Point;
                parameters[4].Value = model.InsurancePrice;
                parameters[5].Value = model.Qty;
                parameters[6].Value = model.Shipment;
                parameters[7].Value = model.ProductDetails;
                parameters[8].Value = model.TJTag;
                parameters[9].Value = model.PubTime;
                parameters[10].Value = model.ImageIcon;
                parameters[11].Value = model.QtyStatus;
                parameters[12].Value = model.IsOnLine;
                parameters[13].Value = model.SeckillTag;
                parameters[14].Value = model.SubName;
                parameters[15].Value = model.ShowHomeTag;
                parameters[16].Value = model.HotTag;
                parameters[17].Value = model.DBNeedTotal;
                parameters[18].Value = model.DBAllowJoin;

                object objRs = DbHelperSQL.GetSingle(strSql.ToString(), parameters);

                int productId = (null == objRs ? 0 : Convert.ToInt32(objRs));
                if (productId > 0 && model.SeckillTag)
                {
                    string updateSql = string.Format("update Shop_Products set SeckillEndTime='{0}',SeckillPoint={1} where productId={2} ", model.SeckillEndTime.ToString("yyyy-MM-dd HH:mm:ss"), model.SeckillPoint, productId);
                    DbHelperSQL.ExecuteSql(updateSql);
                }
            }
            else
            {
                strSql.Append("update Shop_Products set ");
                strSql.Append("ProductName=@ProductName,");
                strSql.Append("CategoryId=@CategoryId,");
                strSql.Append("Point=@Point,");
                strSql.Append("InsurancePrice=@InsurancePrice,");
                strSql.Append("Qty=@Qty,");
                strSql.Append("Shipment=@Shipment,");
                strSql.Append("ProductDetails=@ProductDetails,");
                strSql.Append("TJTag=@TJTag,");
                strSql.Append("PubTime=@PubTime,");
                strSql.Append("ImageIcon=@ImageIcon,");
                strSql.Append("QtyStatus=@QtyStatus,");
                strSql.Append("IsOnLine=@IsOnLine,");
                strSql.Append("SeckillTag=@SeckillTag,");
                strSql.Append("SubName=@SubName,");
                strSql.Append("ShowHomeTag=@ShowHomeTag,");
                strSql.Append("HotTag=@HotTag,");
                strSql.Append("DBNeedTotal=@DBNeedTotal,");
                strSql.Append("DBAllowJoin=@DBAllowJoin");
                strSql.Append(" where ProductId=@ProductId");
                parameters = new SqlParameter[] {
                    new SqlParameter("@ProductName", SqlDbType.NVarChar,128),
                    new SqlParameter("@CategoryId", SqlDbType.Int ),
                    new SqlParameter("@Point", SqlDbType.Int ),
                    new SqlParameter("@InsurancePrice", SqlDbType.Decimal,6 ),
                    new SqlParameter("@Qty", SqlDbType.Int ),
                    new SqlParameter("@Shipment", SqlDbType.NVarChar,8),
                    new SqlParameter("@ProductDetails", SqlDbType.NVarChar,-1),
                    new SqlParameter("@TJTag", SqlDbType.Bit,1),
                    new SqlParameter("@PubTime", SqlDbType.DateTime),
                    new SqlParameter("@ImageIcon", SqlDbType.NVarChar,256),
                    new SqlParameter("@QtyStatus", SqlDbType.NVarChar,8),
                    new SqlParameter("@IsOnLine", SqlDbType.Bit,1),
                    new SqlParameter("@SeckillTag", SqlDbType.Bit,1),
                    new SqlParameter("@SubName", SqlDbType.NVarChar,128),
                    new SqlParameter("@ShowHomeTag", SqlDbType.Bit,1),
                    new SqlParameter("@HotTag", SqlDbType.Bit,1),
                    new SqlParameter("@DBNeedTotal", SqlDbType.Int),
                    new SqlParameter("@DBAllowJoin", SqlDbType.Int),
                    new SqlParameter("@ProductId", SqlDbType.Int )};
                parameters[0].Value = model.ProductName;
                parameters[1].Value = model.CategoryId;
                parameters[2].Value = model.Point;
                parameters[3].Value = model.InsurancePrice;
                parameters[4].Value = model.Qty;
                parameters[5].Value = model.Shipment;
                parameters[6].Value = model.ProductDetails;
                parameters[7].Value = model.TJTag;
                parameters[8].Value = model.PubTime;
                parameters[9].Value = model.ImageIcon;
                parameters[10].Value = model.QtyStatus;
                parameters[11].Value = model.IsOnLine;
                parameters[12].Value = model.SeckillTag;
                parameters[13].Value = model.SubName;
                parameters[14].Value = model.ShowHomeTag;
                parameters[15].Value = model.HotTag;
                parameters[16].Value = model.DBNeedTotal;
                parameters[17].Value = model.DBAllowJoin;
                parameters[18].Value = model.ProductId;

                DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

                if (model.ProductId > 0)
                {
                    if (model.SeckillTag)
                    {
                        string updateSql = string.Format("update Shop_Products set SeckillEndTime='{0}',SeckillPoint={1} where productId={2} ", model.SeckillEndTime.ToString("yyyy-MM-dd HH:mm:ss"), model.SeckillPoint, model.ProductId);
                        DbHelperSQL.ExecuteSql(updateSql);
                    }
                    else
                    {
                        string updateSql = string.Format("update Shop_Products set SeckillEndTime=NULL,SeckillPoint=0 where productId={0} ", model.ProductId);
                        DbHelperSQL.ExecuteSql(updateSql);
                    }
                }
            }


        }

        /// <summary>
        /// 删除一个产品
        /// </summary>
        /// <param name="productId"></param>
        public void DeleteShopProduct(int productId)
        {
            string strSql = string.Format("delete from Shop_Products where productId={0}", productId);
            DbHelperSQL.ExecuteSql(strSql);
        }

        /// <summary>
        /// 更新产品是否下架
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="isOnLine"></param>
        public void OffLineShopProduct(int productId, bool isOnLine = false)
        {
            string strSql = string.Format("update Shop_Products set IsOnLine = {0} where productId={1}", isOnLine ? 1 : 0, productId);
            DbHelperSQL.ExecuteSql(strSql);
        }

        public DataSet GetShopProductList(int top, string strWhere, string orderBy = "")
        {
            string strSql = string.Format("select top {0} productId,productName,subname,ImageIcon, Qty, Point,qtystatus,SeckillPoint,SeckillEndTime from Shop_Products t   ", top);
            if (strWhere.Length > 0)
                strSql += " where " + strWhere;
            if (orderBy.Length > 0)
                strSql += " order by " + orderBy;
            return DbHelperSQL.Query(strSql);
        }

        public DataSet GetShopProductListWithOrderQty(int top, string strWhere, string orderBy = "")
        {
            string strSql = string.Format(@"select top {0} productId,productName,subname,ImageIcon, Qty, Point,qtystatus,SeckillPoint,SeckillEndTime,
(select count(1) from Shop_OrderProducts op where op.productId=t.productId) as orderQty
from Shop_Products t   ", top);
            if (strWhere.Length > 0)
                strSql += " where " + strWhere;
            if (orderBy.Length > 0)
                strSql += " order by " + orderBy;
            return DbHelperSQL.Query(strSql);
        }


        /// <summary>
        /// 获取商品列表
        /// </summary>
        public DataSet GetShopProductList(int pageId, int pageSize, string strWhere, string orderBy, out int total)
        {
            pageId = pageId < 1 ? 1 : pageId;
            int startIndex = (pageId - 1) * pageSize + 1;
            int endIndex = pageId * pageSize;

            string procName = "PS_GetShopProductList";

            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@startIndex",SqlDbType.Int),
                new SqlParameter("@endIndex",SqlDbType.Int),
                new SqlParameter("@strWhere",SqlDbType.NVarChar,1000),
                new SqlParameter("@orderBy",SqlDbType.NVarChar,128),
                new SqlParameter("@total",SqlDbType.Int)
             };
            parameters[0].Value = startIndex;
            parameters[1].Value = endIndex;
            parameters[2].Value = strWhere;
            parameters[3].Value = orderBy;
            parameters[4].Direction = ParameterDirection.Output;

            DataSet dsList = DbHelperSQL.ProcQuery(procName, parameters);

            total = Convert.ToInt32(parameters[4].Value);

            return dsList;
        }


        public DataSet GetShopDuobaoProductList(int pageId, int pageSize, string strWhere, string orderBy, out int total)
        {
            pageId = pageId < 1 ? 1 : pageId;
            int startIndex = (pageId - 1) * pageSize + 1;
            int endIndex = pageId * pageSize;

            string procName = "PS_GetShopDuobaoProductList";

            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@startIndex",SqlDbType.Int),
                new SqlParameter("@endIndex",SqlDbType.Int),
                new SqlParameter("@strWhere",SqlDbType.NVarChar,1000),
                new SqlParameter("@orderBy",SqlDbType.NVarChar,128),
                new SqlParameter("@total",SqlDbType.Int)
             };
            parameters[0].Value = startIndex;
            parameters[1].Value = endIndex;
            parameters[2].Value = strWhere;
            parameters[3].Value = orderBy;
            parameters[4].Direction = ParameterDirection.Output;

            DataSet dsList = DbHelperSQL.ProcQuery(procName, parameters);

            total = Convert.ToInt32(parameters[4].Value);

            return dsList;
        }

        public ShopProduct GetShopProductModel(int productId)
        {
            string strSql = string.Format(@"select t.*,c.CategoryName from Shop_Products t 
                            left join Shop_Categorys c on t.categoryId=c.categoryId where t.productId={0}", productId);
            DataSet dsList = DbHelperSQL.Query(strSql);

            ShopProduct model = null;
            if (dsList != null && dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                model = Common.SL.DataRowToModel<ShopProduct>(dsList.Tables[0].Rows[0]);
            return model;
        }


        #endregion


        #region 订单
        /// <summary>
        /// 提交订单信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="emplId"></param>
        /// <param name="addressId"></param>
        /// <param name="productIdList"></param>
        /// <param name="qtyList"></param>
        /// <returns></returns>
        public int AddShopOrder(int userId, int emplId, int addressId, List<int> shopCartIdList)
        {
            if (shopCartIdList.Count == 0) return 0;
            string tempOrderIds = Common.SL.GetArrayInt(shopCartIdList);

            string procName = "PS_AddShopOrder";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter(@"userId",SqlDbType.Int),
                new SqlParameter(@"emplId",SqlDbType.Int),
                new SqlParameter(@"addressId",SqlDbType.Int),
                new SqlParameter(@"tempOrderIds",SqlDbType.NVarChar,128),
                new SqlParameter(@"orderId",SqlDbType.Int)
            };

            parameters[0].Value = userId;
            parameters[1].Value = emplId;
            parameters[2].Value = addressId;
            parameters[3].Value = tempOrderIds;
            parameters[4].Direction = ParameterDirection.Output;

            DbHelperSQL.ExecuteProcQuery(procName, parameters);

            int orderId = Convert.ToInt32(parameters[4].Value);
            if (orderId > 0)
            {

            }
            return orderId;
        }

        /// <summary>
        /// 夺宝订单
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="emplId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public int AddShopDubaoOrder(int userId, int emplId, int productId)
        {
            string procName = "PS_AddShopDubaoOrder";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter(@"userId",SqlDbType.Int),
                new SqlParameter(@"emplId",SqlDbType.Int),
                new SqlParameter(@"productId",SqlDbType.Int),
                new SqlParameter(@"orderId",SqlDbType.Int)
            };

            parameters[0].Value = userId;
            parameters[1].Value = emplId;
            parameters[2].Value = productId;
            parameters[3].Direction = ParameterDirection.Output;

            DbHelperSQL.ExecuteProcQuery(procName, parameters);

            int orderId = Convert.ToInt32(parameters[3].Value);
            return orderId;
        }

        /// <summary>
        /// 获取订单列表
        /// </summary>
        public DataSet GetShopOrderList(int pageId, int pageSize, string strWhere, string orderBy, out int total)
        {
            pageId = pageId < 1 ? 1 : pageId;
            int startIndex = (pageId - 1) * pageSize + 1;
            int endIndex = pageId * pageSize;

            string procName = "PS_GetShopOrderList";

            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@startIndex",SqlDbType.Int),
                new SqlParameter("@endIndex",SqlDbType.Int),
                new SqlParameter("@strWhere",SqlDbType.NVarChar,1000),
                new SqlParameter("@orderBy",SqlDbType.NVarChar,128),
                new SqlParameter("@total",SqlDbType.Int)
             };
            parameters[0].Value = startIndex;
            parameters[1].Value = endIndex;
            parameters[2].Value = strWhere;
            parameters[3].Value = orderBy;
            parameters[4].Direction = ParameterDirection.Output;

            DataSet dsList = DbHelperSQL.ProcQuery(procName, parameters);

            total = Convert.ToInt32(parameters[4].Value);

            return dsList;
        }


        public DataSet GetShopAllOrderProductList(int pageId, int pageSize, string strWhere, string orderBy, out int total)
        {
            pageId = pageId < 1 ? 1 : pageId;
            int startIndex = (pageId - 1) * pageSize + 1;
            int endIndex = pageId * pageSize;

            string procName = "PS_GetShopAllOrderProductList";

            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@startIndex",SqlDbType.Int),
                new SqlParameter("@endIndex",SqlDbType.Int),
                new SqlParameter("@strWhere",SqlDbType.NVarChar,1000),
                new SqlParameter("@orderBy",SqlDbType.NVarChar,128),
                new SqlParameter("@total",SqlDbType.Int)
             };
            parameters[0].Value = startIndex;
            parameters[1].Value = endIndex;
            parameters[2].Value = strWhere;
            parameters[3].Value = orderBy;
            parameters[4].Direction = ParameterDirection.Output;

            DataSet dsList = DbHelperSQL.ProcQuery(procName, parameters);

            total = Convert.ToInt32(parameters[4].Value);

            return dsList;
        }

        public DataSet GetShopOrderProductList(int pageId, int pageSize, string strWhere, string orderBy, out int total)
        {
            pageId = pageId < 1 ? 1 : pageId;
            int startIndex = (pageId - 1) * pageSize + 1;
            int endIndex = pageId * pageSize;

            string procName = "PS_GetShopOrderProductList";

            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@startIndex",SqlDbType.Int),
                new SqlParameter("@endIndex",SqlDbType.Int),
                new SqlParameter("@strWhere",SqlDbType.NVarChar,1000),
                new SqlParameter("@orderBy",SqlDbType.NVarChar,128),
                new SqlParameter("@total",SqlDbType.Int)
             };
            parameters[0].Value = startIndex;
            parameters[1].Value = endIndex;
            parameters[2].Value = strWhere;
            parameters[3].Value = orderBy;
            parameters[4].Direction = ParameterDirection.Output;

            DataSet dsList = DbHelperSQL.ProcQuery(procName, parameters);

            total = Convert.ToInt32(parameters[4].Value);

            return dsList;
        }

        public DataSet GetShopDubaoProductList(int pageId, int pageSize, string strWhere, string orderBy, out int total)
        {
            pageId = pageId < 1 ? 1 : pageId;
            int startIndex = (pageId - 1) * pageSize + 1;
            int endIndex = pageId * pageSize;

            string procName = "PS_GetShopDubaoProductList";

            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@startIndex",SqlDbType.Int),
                new SqlParameter("@endIndex",SqlDbType.Int),
                new SqlParameter("@strWhere",SqlDbType.NVarChar,1000),
                new SqlParameter("@orderBy",SqlDbType.NVarChar,128),
                new SqlParameter("@total",SqlDbType.Int)
             };
            parameters[0].Value = startIndex;
            parameters[1].Value = endIndex;
            parameters[2].Value = strWhere;
            parameters[3].Value = orderBy;
            parameters[4].Direction = ParameterDirection.Output;

            DataSet dsList = DbHelperSQL.ProcQuery(procName, parameters);

            total = Convert.ToInt32(parameters[4].Value);

            return dsList;
        }

        public DataRow GetShopOrderProductRow(int opId)
        {
            string strSql = string.Format(@"select t.*,o.UserId,o.EmplId,o.OrderTime,o.username,o.city,o.addrs,o.zipcode,o.usertel from Shop_OrderProducts t 
inner join Shop_Orders o on t.orderId = o.orderId where t.opid={0}", opId);
            DataSet dsList = DbHelperSQL.Query(strSql);

            if (dsList != null && dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                return dsList.Tables[0].Rows[0];
            return null;
        }

        /// <summary>
        /// 删除一个订单
        /// </summary>
        /// <param name="orderId"></param>
        public void DeleteShopOrder(int orderId)
        {
            string strSql = string.Format("delete from Shop_Orders where orderId={0}", orderId);
            DbHelperSQL.ExecuteSql(strSql);
        }

        public void DeleteShopOrderProduct(int opId)
        {
            DataRow row = GetShopOrderProductRow(opId);
            if (row == null) return;
            int orderId = Convert.ToInt32(row["orderid"]);

            string strSql = string.Format("delete from Shop_OrderProducts where opId={0}", opId);
            DbHelperSQL.ExecuteSql(strSql);

            DeleteShopOrder(orderId);
        }


        public void UpdateShopOrderProductShipmentStatus(int opId, string shipCompany, string shipNo)
        {
            string strSql = string.Format(@"update Shop_OrderProducts 
            set ShipStatus='已发货',shipcompany='{0}',shipno='{1}' 
            where opId={2}", shipCompany, shipNo, opId);
            DbHelperSQL.ExecuteSql(strSql);
        }
        #endregion


        #region 收货地址

        public bool ExistShopAddress(ShopUserAddress model)
        {
            string strSql = string.Format("select count(1) from Shop_UserAddress t where userid={0} and emplid={1} and username='{2}' and usertel='{3}' and city='{4}' and Addrs='{5}' and ZipCode='{6}' ",
                model.UserId, model.EmplId, model.UserName, model.UserTel, model.City, model.Addrs, model.ZipCode);
            return DbHelperSQL.Exists(strSql);
        }

        /// <summary>
        /// 添加或更新收货地址
        /// </summary>
        /// <param name="model"></param>
        public void AddOrUpdateShopAddress(ShopUserAddress model)
        {
            //更新默认地址
            if (model.IsDefaultAddress)
            {
                string updateSql = string.Format("update Shop_UserAddress set IsDefaultAddress=0 where userid={0} AND emplid={1}", model.UserId, model.EmplId);
                DbHelperSQL.ExecuteSql(updateSql);
            }

            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;

            if (model.AddressId == 0)
            {
                strSql.Append("insert into Shop_UserAddress(");
                strSql.Append("UserId,EmplId,City,Addrs,ZipCode,UserName,UserTel,IsDefaultAddress)");
                strSql.Append(" values (");
                strSql.Append("@UserId,@EmplId,@City,@Addrs,@ZipCode,@UserName,@UserTel,@IsDefaultAddress)");
                strSql.Append(";select @@IDENTITY");

                parameters = new SqlParameter[] {
                    new SqlParameter("@UserId", SqlDbType.Int ),
                    new SqlParameter("@EmplId", SqlDbType.Int ),
                    new SqlParameter("@City", SqlDbType.NVarChar,64),
                    new SqlParameter("@Addrs", SqlDbType.NVarChar,128),
                    new SqlParameter("@ZipCode", SqlDbType.NVarChar,8),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,16),
                    new SqlParameter("@UserTel", SqlDbType.NVarChar,16),
                    new SqlParameter("@IsDefaultAddress", SqlDbType.Bit,1)};
                parameters[0].Value = model.UserId;
                parameters[1].Value = model.EmplId;
                parameters[2].Value = model.City;
                parameters[3].Value = model.Addrs;
                parameters[4].Value = model.ZipCode;
                parameters[5].Value = model.UserName;
                parameters[6].Value = model.UserTel;
                parameters[7].Value = model.IsDefaultAddress;
            }
            else
            {
                strSql.Append("update Shop_UserAddress set ");
                strSql.Append("UserId=@UserId,");
                strSql.Append("EmplId=@EmplId,");
                strSql.Append("City=@City,");
                strSql.Append("Addrs=@Addrs,");
                strSql.Append("ZipCode=@ZipCode,");
                strSql.Append("UserName=@UserName,");
                strSql.Append("UserTel=@UserTel,");
                strSql.Append("IsDefaultAddress=@IsDefaultAddress");
                strSql.Append(" where AddressId=@AddressId");

                parameters = new SqlParameter[] {
                    new SqlParameter("@UserId", SqlDbType.Int ),
                    new SqlParameter("@EmplId", SqlDbType.Int ),
                    new SqlParameter("@City", SqlDbType.NVarChar,16),
                    new SqlParameter("@Addrs", SqlDbType.NVarChar,128),
                    new SqlParameter("@ZipCode", SqlDbType.NVarChar,8),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,16),
                    new SqlParameter("@UserTel", SqlDbType.NVarChar,16),
                    new SqlParameter("@IsDefaultAddress", SqlDbType.Bit,1),
                    new SqlParameter("@AddressId", SqlDbType.Int )};
                parameters[0].Value = model.UserId;
                parameters[1].Value = model.EmplId;
                parameters[2].Value = model.City;
                parameters[3].Value = model.Addrs;
                parameters[4].Value = model.ZipCode;
                parameters[5].Value = model.UserName;
                parameters[6].Value = model.UserTel;
                parameters[7].Value = model.IsDefaultAddress;
                parameters[8].Value = model.AddressId;
            }

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一个收货地址
        /// </summary>
        /// <param name="addressId"></param>
        public void DeleteShopAddress(int addressId)
        {
            string strSql = string.Format("delete from  Shop_UserAddress where addressId={0}", addressId);
            DbHelperSQL.ExecuteSql(strSql);
        }


        /// <summary>
        /// 获取收货地址列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="emplId"></param>
        /// <returns></returns>
        public DataSet GetShopAddressList(int userId, int emplId = 0)
        {
            string strSql = string.Format("select * from Shop_UserAddress t where userId={0}", userId);
            if (emplId > 0)
                strSql += string.Format(" and emplId={0}", emplId);
            return DbHelperSQL.Query(strSql);
        }

        public ShopUserAddress GetShopAddressModel(int addressId)
        {
            string strSql = string.Format("select * from Shop_UserAddress t where addressId={0}", addressId);
            DataSet dsList = DbHelperSQL.Query(strSql);
            if (dsList != null && dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
            {
                return Common.SL.DataRowToModel<ShopUserAddress>(dsList.Tables[0].Rows[0]);
            }
            return null;
        }
        #endregion


        #region 会员积分
        public DataSet GetShopUserPointList(int pageId, int pageSize, string strWhere, string orderBy, out int total)
        {
            pageId = pageId < 1 ? 1 : pageId;
            int startIndex = (pageId - 1) * pageSize + 1;
            int endIndex = pageId * pageSize;

            string procName = "PS_GetShopUserPointList";

            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@startIndex",SqlDbType.Int),
                new SqlParameter("@endIndex",SqlDbType.Int),
                new SqlParameter("@strWhere",SqlDbType.NVarChar,1000),
                new SqlParameter("@orderBy",SqlDbType.NVarChar,128),
                new SqlParameter("@total",SqlDbType.Int)
             };
            parameters[0].Value = startIndex;
            parameters[1].Value = endIndex;
            parameters[2].Value = strWhere;
            parameters[3].Value = orderBy;
            parameters[4].Direction = ParameterDirection.Output;

            DataSet dsList = DbHelperSQL.ProcQuery(procName, parameters);

            total = Convert.ToInt32(parameters[4].Value);

            return dsList;
        }

        /*
        public DataSet GetShopEmployeePointList(int pageId, int pageSize, string strWhere, string orderBy, out int total)
        {
            pageId = pageId < 1 ? 1 : pageId;
            int startIndex = (pageId - 1) * pageSize + 1;
            int endIndex = pageId * pageSize;

            string procName = "PS_GetShopEmployeePointList";

            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@startIndex",SqlDbType.Int),
                new SqlParameter("@endIndex",SqlDbType.Int),
                new SqlParameter("@strWhere",SqlDbType.NVarChar,1000),
                new SqlParameter("@orderBy",SqlDbType.NVarChar,128),
                new SqlParameter("@total",SqlDbType.Int)
             };
            parameters[0].Value = startIndex;
            parameters[1].Value = endIndex;
            parameters[2].Value = strWhere;
            parameters[3].Value = orderBy;
            parameters[4].Direction = ParameterDirection.Output;

            DataSet dsList = DbHelperSQL.ProcQuery(procName, parameters);

            total = Convert.ToInt32(parameters[4].Value);

            return dsList;
        }
        */


        /// <summary>
        /// 获取会员积分
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int GetShopUserPoint(int userId)
        {
            string strSql = "";
            strSql = string.Format("select POINTS from Users t where userId={0} ", userId);

            object objRs = DbHelperSQL.GetSingle(strSql);

            return null == objRs ? 0 : Convert.ToInt32(objRs);
        }


        public bool GetShopUserTodayCheckIn(int userId, int emplId = 0)
        {
            string strSql = string.Format("SELECT count(1) FROM dbo.UserPoints t WHERE USERID = {0} AND EMPLID = {1} AND MODELNO = 101 AND YEAR(PUBDATE) = YEAR(GETDATE()) AND MONTH(PUBDATE) = MONTH(GETDATE()) AND DAY(PUBDATE) = DAY(GETDATE())", userId, emplId);
            return DbHelperSQL.Exists(strSql);
        }

        /// <summary>
        /// 获取签到列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="emplId"></param>
        /// <returns></returns>
        public DataSet GetCheckInList(int userId, int emplId = 0)
        {
            string strSql = string.Format("select Top 62 PUBDATE from UserPoints t where modelno = 101 and userId={0}", userId);
            if (emplId > 0)
                strSql += string.Format(" and emplId={0}", emplId);
            strSql += " ORDER BY PUBDATE DESC ";
            return DbHelperSQL.Query(strSql);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddUserPoint(Tiantu.DB.Model.UserPoints model)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                int id = cn.Insert(model);
                cn.Close();
                return id;
            }
        }

        #endregion


        #region 分页按钮

        public string GetPageToolBar(int PageIndex, int PageSize, int RecordCount, string queryParams)
        {
            int PageCount = RecordCount % PageSize == 0 ? RecordCount / PageSize : RecordCount / PageSize + 1;

            int startIndex = (PageIndex - 1) * PageSize + 1;
            int endIndex = PageIndex * PageSize;
            startIndex = startIndex < 0 ? 0 : startIndex;
            endIndex = endIndex > RecordCount ? RecordCount : endIndex;

            if (RecordCount == 0)
                return @" <div class='col-md-4 col-xs-12'><div class='dataTables_info'>记录为空</div></div>";


            string template = @" <div class='col-md-4 col-xs-12'>
                                                <div class='dataTables_info'  role='status' aria-live='polite'>显示 {0} - {1} / {2} 条记录</div>
                                            </div>
                                            <div class='col-md-8 col-xs-12'>
                                                <div class='dataTables_paginate paging_simple_numbers' id='basic-datatables_paginate'>
                                                    <ul class='pagination'>
                                                        {3}
                                                    </ul>
                                                </div>
                                            </div>";


            StringBuilder sbLi = new StringBuilder();

            //固定：上一页
            sbLi.AppendFormat("<li class='paginate_button previous {0}'><a href='?pageid={1}{2}' >Previous</a></li>", PageIndex == 1 ? "disabled" : "", PageIndex - 1, queryParams);

            //固定：第一页
            sbLi.AppendFormat(" <li class='paginate_button {0}'><a href='?pageid={1}{2}'>{1}</a></li>", PageIndex == 1 ? "active" : "", 1, queryParams);

            if (PageCount < 6)
            {
                for (int i = 2; i <= PageCount; i++)
                {
                    sbLi.AppendFormat(" <li class='paginate_button {0}'><a href='?pageid={1}{2}'>{1}</a></li>", PageIndex == i ? "active" : "", i, queryParams);
                    if (i == PageCount) break;
                }
            }
            else
            {
                if (PageIndex < 5)
                {
                    //1,2,3 ,5...205
                    for (int i = 2; i <= 5; i++)
                    {
                        sbLi.AppendFormat(" <li class='paginate_button {0}'><a href='?pageid={1}{2}'>{1}</a></li>", PageIndex == i ? "active" : "", i, queryParams);
                    }
                    sbLi.Append("<li class='paginate_button disabled'><a>…</a></li>");
                    sbLi.AppendFormat(" <li class='paginate_button {0}'><a href='?pageid={1}{2}'>{1}</a></li>", PageIndex == PageCount ? "active" : "", PageCount, queryParams);
                }
                else if (PageIndex + 4 > PageCount)
                {
                    //1...201,202,203,204,205
                    sbLi.Append("<li class='paginate_button disabled'><a>…</a></li>");
                    for (int i = PageCount - 4; i <= PageCount; i++)
                    {
                        sbLi.AppendFormat(" <li class='paginate_button {0}'><a href='?pageid={1}{2}'>{1}</a></li>", PageIndex == i ? "active" : "", i, queryParams);
                    }
                }
                else
                {
                    //1...100,101,102...205
                    sbLi.Append("<li class='paginate_button disabled'><a>…</a></li>");

                    for (int i = PageIndex - 1; i <= PageIndex + 1; i++)
                    {
                        sbLi.AppendFormat(" <li class='paginate_button {0}'><a href='?pageid={1}{2}'>{1}</a></li>", PageIndex == i ? "active" : "", i, queryParams);
                    }

                    sbLi.Append("<li class='paginate_button disabled'><a>…</a></li>");
                    sbLi.AppendFormat(" <li class='paginate_button {0}'><a href='?pageid={1}{2}'>{1}</a></li>", PageIndex == PageCount ? "active" : "", PageCount, queryParams);
                }
            }


            //固定：下一页
            sbLi.AppendFormat("<li class='paginate_button next {0}'><a href='?pageid={1}{2}'>Next</a></li>", PageIndex == PageCount ? "disabled" : "", PageIndex + 1, queryParams);


            return string.Format(template, startIndex, endIndex, RecordCount, sbLi.ToString());
        }

        #endregion

        #region 文章
        /// <summary>
        /// 添加或更新文章内容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddOrUpdateShopNews(ShopNews model)
        {
            if (model.NewsId == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Shop_News(");
                strSql.Append("NewsTitle,NewsBody,ClazzId,PubTime)");
                strSql.Append(" values (");
                strSql.Append("@NewsTitle,@NewsBody,@ClazzId,@PubTime)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
                    new SqlParameter("@NewsTitle", SqlDbType.NVarChar,128),
                    new SqlParameter("@NewsBody", SqlDbType.NVarChar,-1),
                    new SqlParameter("@ClazzId", SqlDbType.Int),
                    new SqlParameter("@PubTime", SqlDbType.DateTime)};
                parameters[0].Value = model.NewsTitle;
                parameters[1].Value = model.NewsBody;
                parameters[2].Value = model.ClazzId;
                parameters[3].Value = DateTime.Now;

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
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update Shop_News set ");
                strSql.Append("NewsTitle=@NewsTitle,");
                strSql.Append("NewsBody=@NewsBody,");
                strSql.Append("ClazzId=@ClazzId,");
                strSql.Append("PubTime=@PubTime");
                strSql.Append(" where NewsId=@NewsId");
                SqlParameter[] parameters = {
                    new SqlParameter("@NewsTitle", SqlDbType.NVarChar,128),
                    new SqlParameter("@NewsBody", SqlDbType.NVarChar,-1),
                    new SqlParameter("@ClazzId", SqlDbType.Int),
                    new SqlParameter("@PubTime", SqlDbType.DateTime),
                    new SqlParameter("@NewsId", SqlDbType.Int)};
                parameters[0].Value = model.NewsTitle;
                parameters[1].Value = model.NewsBody;
                parameters[2].Value = model.ClazzId;
                parameters[3].Value = DateTime.Now;
                parameters[4].Value = model.NewsId;

                int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                if (rows > 0)
                {
                    return model.NewsId;
                }
                else
                {
                    return 0;
                }
            }
        }

        public DataSet GetShopNewsList(int top, int clazzId)
        {
            string strSql = string.Format("select top {0} newsId,newsTitle,newsBody,pubTime,clazzId  FROM Shop_News  T where clazzId={1} order by NewsId desc", top, clazzId);
            return DbHelperSQL.Query(strSql);
        }



        public DataSet GetShopNewsList(int pageId, int pageSize, string strWhere, string orderBy, out int total)
        {
            pageId = pageId < 1 ? 1 : pageId;
            int startIndex = (pageId - 1) * pageSize + 1;
            int endIndex = pageId * pageSize;

            string procName = "PS_GetShopNewsList";

            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@startIndex",SqlDbType.Int),
                new SqlParameter("@endIndex",SqlDbType.Int),
                new SqlParameter("@strWhere",SqlDbType.NVarChar,1000),
                new SqlParameter("@orderBy",SqlDbType.NVarChar,128),
                new SqlParameter("@total",SqlDbType.Int)
             };
            parameters[0].Value = startIndex;
            parameters[1].Value = endIndex;
            parameters[2].Value = strWhere;
            parameters[3].Value = orderBy;
            parameters[4].Direction = ParameterDirection.Output;

            DataSet dsList = DbHelperSQL.ProcQuery(procName, parameters);

            total = Convert.ToInt32(parameters[4].Value);

            return dsList;
        }


        public ShopNews GetShopNewsModel(int newsId)
        {
            string strSql = string.Format(@"select  * from Shop_News t where newsId={0} ", newsId);
            DataSet dsList = DbHelperSQL.Query(strSql);

            ShopNews model = null;
            if (dsList != null && dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                model = Common.SL.DataRowToModel<ShopNews>(dsList.Tables[0].Rows[0]);
            return model;
        }

        public void DeleteShopNews(int newsId)
        {
            string strSql = string.Format("delete from Shop_News where newsId={0}", newsId);
            DbHelperSQL.ExecuteSql(strSql);
        }
        #endregion


        #region 购物车
        /// <summary>
        /// 添加到购物车
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="emplId"></param>
        /// <param name="productId"></param>
        /// <param name="qty"></param>
        /// <param name="addressId"></param>
        public void AddToShopCart(ShopCart cart)
        {
            string strSql = string.Format("select count(1) from Shop_Carts  where userId={0} and emplId={1} and productId={2} ", cart.UserId, cart.EmplId, cart.ProductId);
            if (!DbHelperSQL.Exists(strSql))
            {
                //清空购物车（保证每次只能购买一种商品）
                strSql = string.Format("delete from Shop_Carts where userid={0} and emplid={1}", cart.UserId, cart.EmplId);
                DbHelperSQL.ExecuteSql(strSql);

                //添加要兑换的商品
                strSql = string.Format("insert into Shop_Carts(userid,emplid,productid,orderQty,orderPoint,IsInsurance) values({0},{1},{2},{3},{4},{5});", cart.UserId, cart.EmplId, cart.ProductId, cart.OrderQty, cart.OrderPoint, cart.IsInsurance ? 1 : 0);
                DbHelperSQL.ExecuteSql(strSql);
            }
            else
            {
                strSql = string.Format("update Shop_Carts set orderQty={0},orderPoint={1},IsInsurance={2},OrderDateTime=GETDATE() where userid={3} and emplid={4} and productId={5}", cart.OrderQty, cart.OrderPoint, cart.IsInsurance ? 1 : 0, cart.UserId, cart.EmplId, cart.ProductId);
                DbHelperSQL.ExecuteSql(strSql);
            }
        }

        /// <summary>
        /// 更新购买保险状态
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="emplId"></param>
        /// <param name="tempOrderId"></param>
        /// <param name="IsInsurance"></param>
        public void UpdateShopCartInsuranceStatus(int userId, int emplId, int tempOrderId, bool IsInsurance)
        {
            string strSql = string.Format("update Shop_Carts set IsInsurance={0} where userid={1} AND emplid={2} AND temporderId={3}", IsInsurance ? 1 : 0, userId, emplId, tempOrderId);
            DbHelperSQL.ExecuteSql(strSql);
        }

        public DataSet GetShopCartList(int userId, int emplId)
        {
            string strSql = string.Format(@"SELECT t.*,p.ProductName,p.ImageIcon,p.Shipment,p.InsurancePrice FROM Shop_Carts t
INNER JOIN  Shop_Products p ON p.ProductId = t.ProductId where t.userid={0} and t.emplid={1}", userId, emplId);
            return DbHelperSQL.Query(strSql);
        }

        public void DeleteShopCart(int tempOrderId, int userId, int emplId)
        {
            string strSql = string.Format("delete from Shop_Carts where TempOrderId={0} AND userId={1} AND emplId={2}", tempOrderId, userId, emplId);
            DbHelperSQL.ExecuteSql(strSql);
        }
        #endregion


        #region 夺宝
        /// <summary>
        /// 添加或更新商品分类
        /// </summary>
        /// <param name="model"></param>
        public void AddOrUpdateDuobaoProduct(ShopProduct model)
        {
            StringBuilder strSql = new StringBuilder();

            SqlParameter[] parameters = null;
            if (model.ProductId == 0)
            {
                strSql.Append("insert into Shop_Products(");
                strSql.Append("ProductName,ClazzId,CategoryId,SeckillPoint,InsurancePrice,Shipment,ProductDetails,PubTime,ImageIcon,DBNeedTotal,DBAllowJoin)");
                strSql.Append(" values (");
                strSql.Append("@ProductName,@ClazzId,@CategoryId,@SeckillPoint,@InsurancePrice,@Shipment,@ProductDetails,GETDATE(),@ImageIcon,@DBNeedTotal,@DBAllowJoin)");
                strSql.Append(";select @@IDENTITY");
                parameters = new SqlParameter[] {
                    new SqlParameter("@ProductName", SqlDbType.NVarChar,128),
                    new SqlParameter("@ClazzId", SqlDbType.Int ),
                    new SqlParameter("@CategoryId", SqlDbType.Int ),
                    new SqlParameter("@SeckillPoint", SqlDbType.Int ),
                    new SqlParameter("@InsurancePrice", SqlDbType.Decimal,6),
                    new SqlParameter("@Shipment", SqlDbType.NVarChar,8),
                    new SqlParameter("@ProductDetails", SqlDbType.NVarChar,-1),
                    new SqlParameter("@ImageIcon", SqlDbType.NVarChar,256),
                    new SqlParameter("@DBNeedTotal", SqlDbType.Int),
                    new SqlParameter("@DBAllowJoin", SqlDbType.Int)
               };
                parameters[0].Value = model.ProductName;
                parameters[1].Value = model.ClazzId;
                parameters[2].Value = model.CategoryId;
                parameters[3].Value = model.SeckillPoint;
                parameters[4].Value = model.InsurancePrice;
                parameters[5].Value = model.Shipment;
                parameters[6].Value = model.ProductDetails;
                parameters[7].Value = model.ImageIcon;
                parameters[8].Value = model.DBNeedTotal;
                parameters[9].Value = model.DBAllowJoin;
                DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            }
            else
            {
                strSql.Append("update Shop_Products set ");
                strSql.Append("ProductName=@ProductName,");
                strSql.Append("CategoryId=@CategoryId,");
                strSql.Append("SeckillPoint=@SeckillPoint,");
                strSql.Append("InsurancePrice=@InsurancePrice,");
                strSql.Append("Shipment=@Shipment,");
                strSql.Append("ProductDetails=@ProductDetails,");
                strSql.Append("ImageIcon=@ImageIcon,");
                strSql.Append("DBNeedTotal=@DBNeedTotal,");
                strSql.Append("DBAllowJoin=@DBAllowJoin");
                strSql.Append(" where ProductId=@ProductId");
                parameters = new SqlParameter[] {
                    new SqlParameter("@ProductName", SqlDbType.NVarChar,128),
                    new SqlParameter("@CategoryId", SqlDbType.Int ),
                    new SqlParameter("@SeckillPoint", SqlDbType.Int ),
                    new SqlParameter("@InsurancePrice", SqlDbType.Decimal,6 ),
                    new SqlParameter("@Shipment", SqlDbType.NVarChar,8),
                    new SqlParameter("@ProductDetails", SqlDbType.NVarChar,-1),
                    new SqlParameter("@ImageIcon", SqlDbType.NVarChar,256),
                    new SqlParameter("@DBNeedTotal", SqlDbType.Int),
                    new SqlParameter("@DBAllowJoin", SqlDbType.Int),
                    new SqlParameter("@ProductId", SqlDbType.Int )};
                parameters[0].Value = model.ProductName;
                parameters[1].Value = model.CategoryId;
                parameters[2].Value = model.SeckillPoint;
                parameters[3].Value = model.InsurancePrice;
                parameters[4].Value = model.Shipment;
                parameters[5].Value = model.ProductDetails;
                parameters[6].Value = model.ImageIcon;
                parameters[7].Value = model.DBNeedTotal;
                parameters[8].Value = model.DBAllowJoin;
                parameters[9].Value = model.ProductId;

                DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
        }


        /// <summary>
        /// 获取目前已参加的总人数
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public int GetNowJoinedTotal(int ProductId)
        {
            string strSql = string.Format("select count(1) from Shop_DuobaoUserNOs where productId={0}", ProductId);
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql));
        }


        public int JoinedDuobao(int userId, int emplId, int productId, int joinTimes, int points, string ip, string city, out int leftTimes)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@userId",SqlDbType.Int),
                new SqlParameter("@emplId",SqlDbType.Int),
                new SqlParameter("@productId",SqlDbType.Int),
                new SqlParameter("@joinTimes",SqlDbType.Int),
                new SqlParameter("@ip",SqlDbType.NVarChar,15),
                new SqlParameter("@city",SqlDbType.NVarChar,15),
                new SqlParameter("@joinId",SqlDbType.Int),
                new SqlParameter("@leftTimes",SqlDbType.Int)
            };
            parameters[0].Value = userId;
            parameters[1].Value = emplId;
            parameters[2].Value = productId;
            parameters[3].Value = joinTimes;
            parameters[4].Value = ip;
            parameters[5].Value = city;
            parameters[6].Direction = ParameterDirection.Output;
            parameters[7].Direction = ParameterDirection.Output;

            DbHelperSQL.ExecuteProcQuery("PS_AddShopDuobao", parameters);
            int joinedId = Convert.ToInt32(parameters[6].Value);
            leftTimes = Convert.ToInt32(parameters[7].Value);
            if (joinedId > 0)
            {

                AddUserPoint(new Tiantu.DB.Model.UserPoints()
                {
                    POINTID = 0,
                    MODELNO = 103,
                    USERID = userId,
                    EMPLID = 0,
                    POINTS = 0 - points,
                    OPERTYPE = 2,
                    OPERID = 0,
                    PUBDATE = DateTime.Now
                });
            }

            return joinedId;
        }

        /// <summary>
        /// 是否参与本次夺宝
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="UserId"></param>
        /// <param name="EmplId"></param>
        /// <returns></returns>
        public bool GetDuobaoJoinedStatus(int ProductId, int UserId, int EmplId)
        {
            string strSql = string.Format("select COUNT(1) from Shop_DuobaoUsers  WHERE productId={0} AND userId={1} AND emplId={2} ",
                ProductId,
                UserId,
                EmplId);
            object objRs = DbHelperSQL.GetSingle(strSql);
            int total = objRs != null ? Convert.ToInt32(objRs) : 0;
            return total > 0;
        }

        /// <summary>
        /// 获取已参与夺宝分配的号
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="UserId"></param>
        /// <param name="EmplId"></param>
        /// <returns></returns>
        public List<string> GetDuobaoJoinedNumbers(int ProductId, int UserId, int EmplId)
        {
            string strSql = string.Format(@"select rndId from Shop_DuobaoUserNos t
                                                                        INNER JOIN dbo.Shop_DuobaoUsers u 
                                                                        ON u.ProductId = t.ProductId and t.JoinId = u.JoinId
                                                                        where u.productId={0} AND u.userId={1} AND u.emplId={2} ", ProductId, UserId, EmplId);
            DataSet dsList = DbHelperSQL.Query(strSql);

            List<string> rndIdList = new List<string>();
            if (dsList != null)
            {
                foreach (DataRow row in dsList.Tables[0].Rows)
                {
                    rndIdList.Add(row[0].ToString());
                }
            }
            return rndIdList;
        }


        /// <summary>
        ///  计算中奖号码
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public int CalculateDuobaoWinNo(int ProductId)
        {
            // 总需参与人次

            /*
            string strSql = string.Format("select DBNeedTotal from Shop_Products where productId={0}", ProductId);
            object objRs = DbHelperSQL.GetSingle(strSql);
            int total = Convert.ToInt32(objRs);
            if (total == 0) return 0;
            */

            // 时间取值之和
            int joinTotal = 0;
            long timeSum = 0;
            string strSql = string.Format("select * from Shop_DuobaoUserNos where productId={0}", ProductId);
            DataSet dsList = DbHelperSQL.Query(strSql);
            if (dsList != null)
            {
                foreach (DataRow row in dsList.Tables[0].Rows)
                {
                    DateTime RndTime = Convert.ToDateTime(row["RndTime"]);
                    timeSum += Convert.ToInt32(RndTime.ToString("HHmmssfff"));
                    joinTotal++;
                }
            }

            int sum = (int)(timeSum % joinTotal + 10000001) /* 固定数值 */;



            return sum;
        }



        /// <summary>
        /// 所有参与计算时间求和
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public long GetDuobaoAllTimeSum(int ProductId)
        {
            long timeSum = 0;
            string strSql = string.Format("select RndTime from Shop_DuobaoUserNos where productId={0}", ProductId);
            DataSet dsList = DbHelperSQL.Query(strSql);
            if (dsList != null)
            {
                foreach (DataRow row in dsList.Tables[0].Rows)
                {
                    DateTime RndTime = Convert.ToDateTime(row["RndTime"]);
                    timeSum += Convert.ToInt32(RndTime.ToString("HHmmssfff"));
                }
            }
            return timeSum;
        }

        /// <summary>
        /// 开奖
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public bool DuobaoOpenWinner(int ProductId)
        {
            bool flag = false;
            int WinNo = CalculateDuobaoWinNo(ProductId);
            if (WinNo > 0)
            {
                flag = UpdateDuobaoWinNo(ProductId, WinNo);
            }
            return flag;
        }

        /// <summary>
        /// 获取参与夺宝的所有记录
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public DataSet GetDuobaoJoinedUserList(int ProductId)
        {
            string strSql = string.Format(@"SELECT du.UserId,du.EmplId,u.USERTEL,du.UserCity,du.IP,du.JoinDate,du.JoinTimes
 FROM Shop_DuobaoUsers du
INNER JOIN Users u ON u.USERID = du.UserId
WHERE du.ProductId = {0} 
ORDER BY du.JoinId DESC", ProductId);
            DataSet dsList = DbHelperSQL.Query(strSql);
            return dsList;
        }

        /// <summary>
        /// 获取参与夺宝的所有记录
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public DataSet GetDuobaoUserNoList(int ProductId)
        {
            string strSql = string.Format(@"SELECT * FROM Shop_DuobaoUserNos t
WHERE t.ProductId = {0} 
ORDER BY t.rndid DESC", ProductId);
            DataSet dsList = DbHelperSQL.Query(strSql);
            return dsList;
        }





        public DataRow GetDuobaoWinInfo(int ProductId)
        {
            string strSql = string.Format(@"SELECT du.UserId,du.EmplId,u.USERTEL,
dt.RndId, dt.WinTime , dt.RndTime,
sp.DBAllowJoin
 FROM Shop_DuobaoUserNos dt
INNER JOIN Shop_DuobaoUsers du ON du.ProductId = dt.ProductId and dt.JoinId = du.JoinId
INNER JOIN Shop_Products sp ON sp.ProductId = dt.ProductId
INNER JOIN Users u ON u.USERID = du.UserId
WHERE dt.ProductId = {0} AND dt.IsWin=1 ", ProductId);
            DataSet dsList = DbHelperSQL.Query(strSql);

            DataRow dataRow = null;
            if (dsList != null && dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
            {
                dataRow = dsList.Tables[0].Rows[0];
            }
            return dataRow;
        }

        /// <summary>
        /// 更新中奖号
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="WinNo"></param>
        /// <returns></returns>
        public bool UpdateDuobaoWinNo(int ProductId, int WinNo)
        {
            string strSql = string.Format("update Shop_DuobaoUserNos set ISWIN=1,WinTime=GETDATE() WHERE  productId={0} AND rndId={1}", ProductId, WinNo);
            int rows = DbHelperSQL.ExecuteSql(strSql);
            if (rows > 0)
            {
                //更新商品已开奖
                strSql = string.Format("UPDATE Shop_Products set DubaoStatus=-1,DubaoWinNo={1},DubaoWinDate=GETDATE() where productId={0}", ProductId, WinNo);
                DbHelperSQL.ExecuteSql(strSql);


            }
            return rows > 0;
        }


        /// <summary>
        /// 更新夺宝收货地址
        /// </summary>
        /// <param name="OrderId"></param>
        /// <param name="AddressId"></param>
        public void UpdateDuobaoOrderAddress(int OrderId, int AddressId)
        {
            Model.ShopUserAddress model = GetShopAddressModel(AddressId);
            if (model != null)
            {
                string strSql = string.Format("update Shop_Orders set City='{0}', Addrs='{1}', ZipCode='{2}',UserName='{3}',UserTel='{4}' where orderId={5} ",
                    model.City,
                    model.Addrs,
                    model.ZipCode,
                    model.UserName,
                    model.UserTel,
                    OrderId);
                DbHelperSQL.ExecuteSql(strSql);
            }
        }


        #endregion


        #region 关于
        public string GetAboutDetails(int AboutId)
        {
            string strSql = string.Format("select Details from Shop_Abouts where aboutId={0}", AboutId);
            object objRs = DbHelperSQL.GetSingle(strSql);
            return objRs != null ? objRs.ToString() : "";
        }

        public ShopAbouts GetAboutModel(int AboutId)
        {
            string strSql = string.Format("select * from Shop_Abouts where aboutId={0}", AboutId);
            DataSet dsList = DbHelperSQL.Query(strSql);
            if (dsList == null || dsList.Tables.Count == 0 || dsList.Tables[0].Rows.Count == 0) return null;
            return Common.SL.DataRowToModel<ShopAbouts>(dsList.Tables[0].Rows[0]);
        }

        public void AddOrUpdateAbout(int AboutId, string Details)
        {
            SqlParameter[] parameters = null;
            string strSql = string.Format("select count(1) from Shop_Abouts where aboutId={0}", AboutId);
            if (!DbHelperSQL.Exists(strSql))
            {
                strSql = "insert into Shop_Abouts(AboutId,Details) Values(@AboutId,@Details);";
                parameters = new SqlParameter[]{
                    new SqlParameter("@AboutId",SqlDbType.Int),
                    new SqlParameter("@Details",SqlDbType.NVarChar,-1)
                };
                parameters[0].Value = AboutId;
                parameters[1].Value = Details;

                DbHelperSQL.ExecuteSql(strSql, parameters);
            }
            else
            {
                strSql = "update Shop_Abouts set Details=@Details WHERE AboutId=@AboutId";
                parameters = new SqlParameter[]{
                    new SqlParameter("@Details",SqlDbType.NVarChar,-1),
                    new SqlParameter("@AboutId",SqlDbType.Int)
                };
                parameters[0].Value = Details;
                parameters[1].Value = AboutId;

                DbHelperSQL.ExecuteSql(strSql, parameters);
            }
        }
        #endregion


        #region 游戏
        public void AddOrUpdateGames(int GameId, string GameName, string ImageUrl, string LinkUrl)
        {
            string strSql = "";
            SqlParameter[] parameters = null;
            if (GameId > 0)
            {
                strSql = "update Shop_Games set gamename=@GameName,ImageUrl=@ImageUrl,linkurl=@LinkUrl where gameId=@GameId ";
                parameters = new SqlParameter[]
                {
                    new SqlParameter("@GameName",SqlDbType.NVarChar,32),
                    new SqlParameter("@ImageUrl",SqlDbType.NVarChar,251),
                    new SqlParameter("@LinkUrl",SqlDbType.NVarChar,512),
                    new SqlParameter("@GameId",SqlDbType.Int),
                };
                parameters[0].Value = GameName;
                parameters[1].Value = ImageUrl;
                parameters[2].Value = LinkUrl;
                parameters[3].Value = GameId;
                DbHelperSQL.ExecuteSql(strSql, parameters);
            }
            else
            {
                strSql = "insert into Shop_Games(gamename,imageurl,linkurl) VALUES(@GameName,@ImageUrl,@LinkUrl);";
                parameters = new SqlParameter[]
                {
                    new SqlParameter("@GameName",SqlDbType.NVarChar,32),
                    new SqlParameter("@ImageUrl",SqlDbType.NVarChar,251),
                    new SqlParameter("@LinkUrl",SqlDbType.NVarChar,512)
                };
                parameters[0].Value = GameName;
                parameters[1].Value = ImageUrl;
                parameters[2].Value = LinkUrl;
                DbHelperSQL.ExecuteSql(strSql, parameters);
            }

        }

        public DataSet GetShopGameList(string strWhere = "")
        {
            string strSql = "select * from Shop_Games t";
            if (strWhere.Length > 0)
                strSql += " where " + strWhere;
            strSql += " Order by gameId desc";
            return DbHelperSQL.Query(strSql);
        }


        public ShopGames GetShopGameModel(int GameId)
        {
            string strSql = string.Format("select * from Shop_Games where gameid={0}", GameId);
            DataSet dsList = DbHelperSQL.Query(strSql);
            if (dsList != null)
            {
                DataRow row = dsList.Tables[0].Rows[0];
                return Common.SL.DataRowToModel<Model.ShopGames>(row);
            }
            return null;
        }

        public void DeleteShopGame(int GameId)
        {
            string strSql = string.Format("delete from Shop_Games where GameId={0}", GameId);
            DbHelperSQL.ExecuteSql(strSql);
        }
        #endregion




        #region 手机版


        #endregion




    }
}
