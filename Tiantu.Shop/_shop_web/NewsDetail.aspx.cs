using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Tiantu.DB.Common;
using Tiantu.DB.Model;

public partial class _shop_web_NewsDetail : System.Web.UI.Page
{
    public ShopNews model;
    Tiantu.DB.DAL.ShopStore dalShopStore = new Tiantu.DB.DAL.ShopStore();

    protected void Page_Load(object sender, EventArgs e)
    {
        int newsId = SL.GetQueryInt("newsid", true);
        if (newsId>0)
        {
           

            model = dalShopStore.GetShopNewsModel(newsId);
            if (model == null)
            {
                Response.Redirect("/news.html");
            }

            ShowHelp();
        }
    }

    private void ShowHelp()
    {
        DataSet dsHelpList = dalShopStore.GetShopNewsList(10,  ShopStoreConfig.CLASS_NEWS);
        if (dsHelpList != null)
        {
            this.RepeaterTitleList.DataSource = dsHelpList.Tables[0];
            this.RepeaterTitleList.DataBind();
        }
    }
}