using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Collections;
using System.Data;
using Newtonsoft.Json.Linq;
using Tiantu.DB.Common;
using Tiantu.DB.Model;

public partial class _shop_web_AjaxService : System.Web.UI.Page
{
    Tiantu.DB.DAL.Users dalUsers = new Tiantu.DB.DAL.Users();
    Tiantu.DB.DAL.ShopStore dalShopStore = new Tiantu.DB.DAL.ShopStore();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.UrlReferrer == null) return;

        string action = SL.GetQueryString("action");
        if (string.IsNullOrEmpty(action)) return;

        switch (action.ToLower())
        {
            case "logout":
                Logout();
                break;
            case "login":
                Login();
                break;
            case "trylogin":
                TryLogin();
                break;
            case "checkin":
                CheckIn();
                break;
            case "getcheckinstatus":
                GetTodayCheckInStatus();
                break;
            case "addtocart":
                AddToCart();
                break;
            case "editaddress":
                EditAddress();
                break;
            case "getaddressinfo":
                GetAddressInfo();
                break;
            case "deleteaddress":
                DeleteAddress();
                break;
            case "removefromcart":
                RemoveFromCart();
                break;
            case "buyinsurance":
                BuyInsurance();    //购买保险
                break;
            case "exchangenow":    //立即购买
                Exchangenow();
                break;
            case "joined":  //参与夺宝
                JoinedDuobao();
                break;
            case "getduobaorecords":
                GetDuobaoRecords();
                break;
            case "chooseaddress":
                ChooseAddress();
                break;
        }
    }

    #region 选择收货地址
    private void ChooseAddress()
    {
        int orderId = SL.GetFormInt("orderid");
        int addressId = SL.GetFormInt("addressid");
        if (addressId>0)
        {
            dalShopStore.UpdateDuobaoOrderAddress(orderId, addressId);
            Response.Write(0);
        }
    }

    #endregion
    #region 获取夺宝所有记录
    public void GetDuobaoRecords()
    {
        ArrayList items = new ArrayList();
        int productId = SL.GetFormInt("p", true);
        
        if (productId > 0)
        {
            DataSet dsList = dalShopStore.GetDuobaoJoinedUserList(productId);
            if (dsList!=null)
            {
                Hashtable ht = null;
                foreach (DataRow row in dsList.Tables[0].Rows)
                {
                    ht = new Hashtable();
                    ht.Add("time", Convert.ToDateTime(row["JoinDate"]).ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    ht.Add("user", Convert.ToInt32(row["emplid"]) > 0 ? row["EMPLTEL"].ToString() : row["USERTEL"].ToString());
                    ht.Add("ip", row["ip"]);
                    ht.Add("city", row["usercity"]);
                    ht.Add("total", row["JoinTimes"]);

                    items.Add(ht);
                }
            }

            
        }
        Hashtable result = new Hashtable();
        result.Add("list", items);

        Response.Write(JsonUtil.Encode(result));
    }
    #endregion

    #region 参与夺宝
    private void JoinedDuobao()
    {
        Hashtable result = new Hashtable();

        int userId = dalUsers.GetUserIdFromCookie();
        int emplId = 0;

        #region 登录判断
        if (userId == 0)
        {
            result.Add("code", 1);
            result.Add("message", "请登录后操作");
            Response.Write(JsonUtil.Encode(result));
            Response.End();
        }
        #endregion

        int productId = SL.GetFormInt("p1", true);
        int wantJoinNumber = SL.GetFormInt("p2");
        #region 参数有效性判断
        if (productId == 0 || wantJoinNumber <= 0)
        {
            result.Add("code", 1);
            result.Add("message", "参数无效");
            Response.Write(JsonUtil.Encode(result));
            Response.End();
        }
        #endregion


        ShopProduct product = dalShopStore.GetShopProductModel(productId);
        // 目前商品已报名的总人数
        int joinedTotal = dalShopStore.GetNowJoinedTotal(productId);
        #region 活动人数已达到上限
        if (product.DBNeedTotal <= joinedTotal)
        {
            result.Add("code", 1);
            result.Add("message", "活动报名参与人数已达上限");
            Response.Write(JsonUtil.Encode(result));
            Response.End();
        }
        #endregion

        
        int maxCanJoined = product.DBNeedTotal - joinedTotal;
        #region 用户本次申请参与人次已超过剩下总人次数
        if (wantJoinNumber > maxCanJoined)
        {
            result.Add("code", 1);
            result.Add("message", string.Format("本活动剩下报名最多为 {0} 人次", maxCanJoined));
            Response.Write(JsonUtil.Encode(result));
            Response.End();
        }
        #endregion


        #region 用户针对本产品的参与次数已达上限
        List<string> numberList = dalShopStore.GetDuobaoJoinedNumbers(productId, userId, emplId);
        if (numberList.Count + wantJoinNumber > product.DBAllowJoin)
        {
            result.Add("code", 1);
            result.Add("message", string.Format("您最多还能参与{0}次", product.DBAllowJoin - numberList.Count));
            Response.Write(JsonUtil.Encode(result));
            Response.End();
        }
        #endregion

        int userPoint = dalShopStore.GetShopUserPoint(userId);
        int needPoint = product.SeckillPoint * wantJoinNumber;
        #region 用户金币不够
        if (needPoint >= userPoint)
        {
            result.Add("code", 1);
            result.Add("message", string.Format("您的金币不够，本次需要{0}金币", needPoint));
            Response.Write(JsonUtil.Encode(result));
            Response.End();
        }
        #endregion


        // 可以申请
        string userIp = Request.UserHostAddress;
        string userCity = "";
        int leftTimes = 0;
        int joinedId = dalShopStore.JoinedDuobao(userId, emplId, productId, wantJoinNumber, needPoint,  userIp, userCity, out leftTimes);
        if (joinedId == 0)
        {
            result.Add("code", 1);
            result.Add("message", "由于当前报名人次较多，请稍后再试");
            Response.Write(JsonUtil.Encode(result));
            Response.End();
        }


        //申请成功后，看是否已达到开奖条件
        if (leftTimes == 0)
        {
            result.Add("code", 3);
            result.Add("message", "报名成功，2分钟后准备开奖");
        }
        else
        {
            result.Add("code", 2);
            result.Add("message", "报名成功");
        }


    
        Response.Write(JsonUtil.Encode(result));
    }




    #endregion

    #region 会员登录/注册/退出
    /// <summary>
    /// 登录
    /// </summary>
    private void Login()
    {
        string loginUrl = "http://www.honotop.com/account/login?returnurl=http://shop.honotop.com";
        Response.Redirect(loginUrl);
    }

    private void TryLogin()
    {
        Hashtable result = new Hashtable();
        string login_username =  Request.Form["login_username"];
        string login_password =   Request.Form["login_password"];
        if (login_username.Length > 0 && login_password.Length > 0)
        {
            bool success =   dalUsers.Login(login_username, login_password, 5);
            if (success)
            {
                result.Add("errcode", 0);
                result.Add("errmsg", "登录成功");
            }
            else
            {
                result.Add("errcode", 1);
                result.Add("errmsg", "账号或密码不正确");
            }
        }
        else
        {
            result.Add("errcode", 1);
            result.Add("errmsg", "账号或密码不能为空");
        }
        Response.Write(JsonUtil.Encode(result));
    }
 

    /// <summary>
    /// 退出
    /// </summary>
    private void Logout()
    {
       
        dalUsers.Logout();
        Response.Redirect("/");
    }
    #endregion


    #region 会员签到
    private void GetTodayCheckInStatus()
    {
        int userId = dalUsers.GetUserIdFromCookie();
        int emplId = 0;
        if (userId > 0)
        {
            bool todayIsCheckIn = dalShopStore.GetShopUserTodayCheckIn(userId, emplId);
            Response.Write(todayIsCheckIn ? 1 : 0);
        }
        else
        {
            Response.Write(0);
        }
    }


    private void CheckIn()
    {
        Hashtable result = new Hashtable();

        int userId = dalUsers.GetUserIdFromCookie();

        if (userId > 0 && dalUsers.Exists(userId))
        {
            int emplId = 0;
            bool todayIsCheckIn = dalShopStore.GetShopUserTodayCheckIn(userId, emplId);
            if (!todayIsCheckIn)
            {
                //DBHelper.AddUserPoint(101, userId, emplId, 0);

                result.Add("errcode", 0);
                result.Add("errmsg", "");
            }
            else
            {
                result.Add("errcode", 1);
                result.Add("errmsg", "今日已签到");
            }
        }
        else
        {
            result.Add("errcode", 1);
            result.Add("errmsg", "您还没有登录");
        }

        string jsonString = JsonUtil.Encode(result);
        Response.Write(jsonString);
    }
    #endregion

    #region 购物车
    private void AddToCart()
    {
        Hashtable result = new Hashtable();
        int productId = SL.GetQueryInt("productno", true);
        int qty = SL.GetQueryInt("qty");
        int points = 0;

        if (productId <= 0)
        {
            result.Add("errcode", 1);
            result.Add("errmsg", "商品编号不正确");
        }
        else if (qty <= 0)
        {
            result.Add("errcode", 1);
            result.Add("errmsg", "商品购买数量不正确");
        }
        else
        {
            int userId = dalUsers.GetUserIdFromCookie();
            if (userId == 0)
            {
                result.Add("errcode", 2);
                result.Add("errmsg", "会员还没有登录");
            }
            else
            {
                string errInfo = "";
                int emplId = 0;
                ShopProduct product = dalShopStore.GetShopProductModel(productId);

                if (product == null || product.ProductId == 0)
                {
                    errInfo = "商品已删除";
                }
                else if (!product.IsOnLine)
                {
                    errInfo = "商品已下架";
                }
                else if (product.Qty == 0 || product.Qty < qty)
                {
                    errInfo = "商品库存不够";
                }
                else
                {

                    int userPoints = dalShopStore.GetShopUserPoint(userId);

                    //秒杀产品
                    if (product.SeckillTag)
                    {
                        if (product.SeckillEndTime.Subtract(DateTime.Now).TotalSeconds < 0)
                        {
                            errInfo = "商品秒杀活动已结束";
                        }
                        else if (product.SeckillPoint > userPoints)
                        {
                            errInfo = "用户您的金币不足以秒杀此产品，请及时充值。";
                        }
                        else
                        {
                            //秒杀商品金币
                            points = product.SeckillPoint;
                        }
                    }
                    else if (product.Point > userPoints)
                    {
                        errInfo = "用户您的金币不足";
                    }
                    else
                    {
                        //商品金币
                        points = product.Point;
                    }
                }


                if (!string.IsNullOrEmpty(errInfo))
                {
                    result.Add("errcode", 2);
                    result.Add("errmsg", errInfo);
                }
                else
                {
                    //将购买商品添加到购物车中
                    ShopCart model = new ShopCart();
                    model.UserId = userId;
                    model.EmplId = emplId;
                    model.ProductId = productId;
                    model.OrderPoint = points;
                    model.OrderQty = qty;
                    model.IsInsurance = false;
                    dalShopStore.AddToShopCart(model);

                    result.Add("errcode", 0);
                    result.Add("errmsg", "已添加到购物车中");
                }
            }
        }

        string jsonString = JsonUtil.Encode(result);
        Response.Write(jsonString);
    }


    /// <summary>
    /// 从购物车中删除商品
    /// </summary>
    private void RemoveFromCart()
    {
        Hashtable result = new Hashtable();
        int tempOrderId = SL.GetFormInt("tempid", true);

        if (tempOrderId <= 0)
        {
            result.Add("errcode", 1);
            result.Add("errmsg", "商品编号不正确");
        }
        else
        {
            int userId = dalUsers.GetUserIdFromCookie();
            if (userId == 0)
            {
                result.Add("errcode", 2);
                result.Add("errmsg", "会员还没有登录");
            }
            else
            {
                int emplId = 0;
                dalShopStore.DeleteShopCart(tempOrderId, userId, emplId);

                result.Add("errcode", 0);
                result.Add("errmsg", "已删除");
            }
        }

        string jsonString = JsonUtil.Encode(result);
        Response.Write(jsonString);
    }
    #endregion


    #region 收货地址
    private void GetAddressInfo()
    {
        int addressid = SL.GetQueryInt("addressid", true);
        if (addressid > 0)
        {
            ShopUserAddress model = dalShopStore.GetShopAddressModel(addressid);
            if (model != null)
            {
                string jsonString = JsonUtil.Encode(model);
                Response.Write(jsonString);
            }
        }


    }

    private void DeleteAddress()
    {
        Hashtable result = new Hashtable();
        int userId = dalUsers.GetUserIdFromCookie();
        if (userId == 0)
        {
            result.Add("errcode", 2);
            result.Add("errmsg", "会员还没有登录");
        }
        else
        {
            int addressid = SL.GetFormInt("addressid", true);
            dalShopStore.DeleteShopAddress(addressid);

            result.Add("errcode", 0);
            result.Add("errmsg", "已删除");
        }


        string jsonString = JsonUtil.Encode(result);
        Response.Write(jsonString);
    }

    private void EditAddress()
    {
        Hashtable result = new Hashtable();

        int userId = dalUsers.GetUserIdFromCookie();
        if (userId == 0)
        {
            result.Add("errcode", 2);
            result.Add("errmsg", "会员还没有登录");
        }
        else
        {
            try
            {
                int emplId = 0;

                int addressid = SL.GetFormInt("addressid");
                string usercity = SL.GetFormString("usercity");
                string address = SL.GetFormString("address");
                string zipcode = SL.GetFormString("zipcode");
                string username = SL.GetFormString("username");
                string usertel = SL.GetFormString("usertel");
                int isdefault = SL.GetFormInt("isdefault");

                int totalAdderss = 0;
                DataSet dsList = dalShopStore.GetShopAddressList(userId, emplId);
                if (dsList != null && dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    totalAdderss = dsList.Tables[0].Rows.Count;
                }

                string errInfo = "";
                if (totalAdderss > 10)
                {
                    errInfo = "您的收货地址已达到10个";
                }
                else if (string.IsNullOrEmpty(usercity))
                {
                    errInfo = "所在地区为空";
                }
                else if (string.IsNullOrEmpty(address))
                {
                    errInfo = "街道地址为空";
                }
                else if (string.IsNullOrEmpty(zipcode))
                {
                    errInfo = "邮政编码为空";
                }
                else if (string.IsNullOrEmpty(username))
                {
                    errInfo = "收货人姓名为空";
                }
                else if (string.IsNullOrEmpty(usertel))
                {
                    errInfo = "手机/电话为空";
                }

                if (!string.IsNullOrEmpty(errInfo))
                {
                    result.Add("errcode", 2);
                    result.Add("errmsg", "参数提交不完整");
                }
                else
                {
                    ShopUserAddress model = new ShopUserAddress();
                    model.AddressId = addressid;
                    model.UserId = userId;
                    model.EmplId = emplId;
                    model.UserName = username;
                    model.UserTel = usertel;
                    model.City = usercity;
                    model.ZipCode = zipcode;
                    model.Addrs = address;
                    model.IsDefaultAddress = isdefault == 1;

                    if (addressid == 0)
                    {
                        if (!dalShopStore.ExistShopAddress(model))
                        {
                            dalShopStore.AddOrUpdateShopAddress(model);
                        }
                    }
                    else
                    {
                        dalShopStore.AddOrUpdateShopAddress(model);
                    }

                    result.Add("errcode", 0);
                    result.Add("errmsg", "地址保存成功");
                }


            }
            catch (Exception ex)
            {
                result.Add("errcode", 1);
                result.Add("errmsg", ex.Message);
            }
        }

        string jsonString = JsonUtil.Encode(result);
        Response.Write(jsonString);
    }
    #endregion


    #region 购买保险
    private void BuyInsurance()
    {
        Hashtable result = new Hashtable();
        int userId = dalUsers.GetUserIdFromCookie();
        if (userId == 0)
        {
            result.Add("errcode", 2);
            result.Add("errmsg", "会员还没有登录");
        }
        else
        {
            int tempOrderId = SL.GetFormInt("tempid", true);
            int IsInsurance = SL.GetFormInt("status");
            int emplId = 0;

            dalShopStore.UpdateShopCartInsuranceStatus(userId, emplId, tempOrderId, IsInsurance == 1);

            result.Add("errcode", 0);
            result.Add("errmsg", "已确认");
        }
        string jsonString = JsonUtil.Encode(result);
        Response.Write(jsonString);
    }

    #endregion

    #region 立即购买
    private void Exchangenow()
    {
        Hashtable result = new Hashtable();

        int addressId = SL.GetFormInt("order_addressid", true); //收货地址

        int userId = dalUsers.GetUserIdFromCookie();
        if (userId == 0)
        {
            result.Add("errcode", 2);
            result.Add("errmsg", "会员还没有登录");
        }
        else if (addressId <= 0)
        {
            result.Add("errcode", 2);
            result.Add("errmsg", "您还没有选择收货地址");
        }
        else
        {
            string errInfo = "";
            int emplId = 0;

            List<int> shopCartIdList = new List<int>();

            DataSet dsList = dalShopStore.GetShopCartList(userId, emplId);
            if (dsList == null || dsList.Tables.Count == 0 || dsList.Tables[0].Rows.Count == 0)
            {
                errInfo = "您还没有选择要购买的商品";
            }
            else
            {
                int userPoints = dalShopStore.GetShopUserPoint(userId); //会员所有金币

                int totalQty = 0;
                int totalPoints = 0;
                foreach (DataRow row in dsList.Tables[0].Rows)
                {
                    int tempOrderId = Convert.ToInt32(row["tempOrderId"]);
                    int qty = Convert.ToInt32(row["orderQty"]);
                    int point = Convert.ToInt32(row["orderPoint"]);
                    shopCartIdList.Add(tempOrderId);

                    totalQty += qty;
                    totalPoints += qty * point;

                }

                if (totalQty == 0)
                {
                    errInfo = "您还没有选择要购买的商品";
                }
                else if (totalQty > 0 && userPoints < totalPoints)
                {
                    errInfo = "您的金币不足";
                }
            }


            if (!string.IsNullOrEmpty(errInfo))
            {
                result.Add("errcode", 2);
                result.Add("errmsg", errInfo);
            }
            else
            {
                //将购买商品添加到购物车中
                int orderId = dalShopStore.AddShopOrder(userId, emplId, addressId, shopCartIdList);

                result.Add("errcode", 0);
                result.Add("errmsg", "已添加到购物车中");
                result.Add("orderid", orderId);
            }

            string jsonString = JsonUtil.Encode(result);
            Response.Write(jsonString);
        }
    }
    #endregion
}