using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _shop_web_Earn : System.Web.UI.Page
{
    int clazzId = 2;    //金币规则类
    Tiantu.DB.DAL.ShopStore dalShopStore = new Tiantu.DB.DAL.ShopStore();
    protected void Page_Load(object sender, EventArgs e)
    {
        string Details = dalShopStore.GetAboutDetails(1);
        this.lblDetails.Text = Details;

        DataSet dsHelpList = dalShopStore.GetShopNewsList(10, clazzId);
        if (dsHelpList != null)
        {
            this.RepeaterTitleList.DataSource = dsHelpList.Tables[0];
            this.RepeaterTitleList.DataBind();
        }
    }
}