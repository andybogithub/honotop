using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Tiantu.DB.Common;

public partial class _shop_web_Index : System.Web.UI.Page
{
    public int bannerTotal = 0;
    public int tjProductTotal = 0;
    public bool todayIsCheckIn = false;
    Tiantu.DB.DAL.Banners dalBanner = new Tiantu.DB.DAL.Banners();
    Tiantu.DB.DAL.ShopStore dalShopStore = new Tiantu.DB.DAL.ShopStore();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            #region 手机访问跳转到手机版
            //if (true == SL.IsMobilePhoneVisit())
            //{
            //    string UrlReferrerPath = "";    // 来源
            //    string Url = Request.Url.PathAndQuery;
            //    if (Request.UrlReferrer != null)
            //    {
            //        UrlReferrerPath = Request.UrlReferrer.OriginalString;
            //    }
            //    //直接访问跳转到手机版                  
            //    if (string.IsNullOrWhiteSpace(UrlReferrerPath) && Url.ToLower().Equals("/_shop_web/index.aspx"))
            //    {
            //        Response.Redirect(WebDomain.HttpShopMobile);
            //    }
            //}
            #endregion


            //if (Master.user.USERID > 0)
            //{
            //    //今日签到状态
            //    this.todayIsCheckIn = dalShopStore.GetShopUserTodayCheckIn(Master.UserId, 0);
            //}

            ShowBanner();
            ShowNews();
            ShowSeckillProducts();
            ShowTJProducts();
            ShowDubaoProducts();
            ShowHotProducts();

            ShowCases();    
        }
        catch
        {
        }
    }


    private void ShowBanner()
    {
        DataSet dsBanner = dalBanner.GetList(string.Format("WEBID={0}", Tinatu.DB.DBHelper.WEBID_SHOP));
        if (dsBanner != null)
        {
            this.bannerTotal = dsBanner.Tables[0].Rows.Count;

            this.RepeaterBanners.DataSource = dsBanner.Tables[0];
            this.RepeaterBanners.DataBind();
        }
    }


  


    private void ShowCases()
    {
        Tiantu.DB.DAL.Cases dalCases = new Tiantu.DB.DAL.Cases();
        var list = dalCases.GetList(0, "", "SORTID DESC");

        if (list != null)
        {
          
            this.RepeaterCases.DataSource = list;
            this.RepeaterCases.DataBind();
        }
    }


    private void ShowNews()
    {
        //DataSet dsNews = dalShopStore.GetShopNewsList(5, 1);
        //if (dsNews != null)
        //{
        //    this.RepeaterNews.DataSource = dsNews.Tables[0];
        //    this.RepeaterNews.DataBind();
        //}
    }


    /// <summary>
    /// 限时秒杀
    /// </summary>
    private void ShowSeckillProducts()
    {
        string strWhere = "CLAZZID=1 AND IsOnLine=1 AND SeckillTag=1 AND ShowHomeTag=1";
        DataSet dsProducts = dalShopStore.GetShopProductList(2, strWhere, "SeckillEndTime desc");
        if (dsProducts != null)
        {
            this.RepeaterSeckillProducts.DataSource = dsProducts.Tables[0];
            this.RepeaterSeckillProducts.DataBind();
        }
    }

    /// <summary>
    /// 正在夺宝
    /// </summary>
    private void ShowDubaoProducts()
    {
        string strWhere = "";
        int totalRecords = 0;
        DataSet dsProducts = dalShopStore.GetShopDuobaoProductList(1, 2, strWhere, "", out totalRecords);
        if (dsProducts != null)
        {
            this.RepeaterDBList.DataSource = dsProducts.Tables[0];
            this.RepeaterDBList.DataBind();
        }
    }

    /// <summary>
    /// 推荐商品
    /// </summary>
    private void ShowTJProducts()
    {
        //string strWhere = "CLAZZID=1 AND IsOnLine=1 AND tjTag=1 AND ShowHomeTag=1";
        //DataSet dsProducts = dalShopStore.GetShopProductList(8, strWhere, "productId desc");
        //if (dsProducts != null)
        //{
        //    this.RepeaterTJList.DataSource = dsProducts.Tables[0];
        //    this.RepeaterTJList.DataBind();

        //    //推荐产品数量
        //    this.tjProductTotal = dsProducts.Tables[0].Rows.Count;
        //}
    }

    /// <summary>
    /// 热门商品
    /// </summary>
    private void ShowHotProducts()
    {
        string strWhere = "CLAZZID=1 AND IsOnLine=1 AND hotTag=1 AND ShowHomeTag=1";
        DataSet dsProducts = dalShopStore.GetShopProductListWithOrderQty(4, strWhere, "productId desc");
        if (dsProducts != null)
        {
            this.RepeaterHotList.DataSource = dsProducts.Tables[0];
            this.RepeaterHotList.DataBind();
        }
    }
    /// <summary>
    /// 库存进度
    /// </summary>
    /// <param name="qtyStatus"></param>
    /// <returns></returns>
    public int GetProductQtyProgress(object qtyStatus)
    {
        int process = 0;
        switch (qtyStatus.ToString().Trim())
        {
            case "库存充足":
                process = 100;
                break;
            case "库存紧张":
                process = 20;
                break;
        }
        return process;
    }

    protected int GetPercent(int total, int used)
    {
        double du = 0.00;
        if (total > 0)
        {
            du = used / total * 1.00;
        }

        int result = Convert.ToInt32(du * 100);
        return result > 100 ? 100 : result;
    }
}