using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Tiantu.DB.Common;
using Tiantu.DB.Model;

public partial class _shop_web_QA : System.Web.UI.Page
{
    public string nsTitle = "", nsBody = "";
  
    Tiantu.DB.DAL.ShopStore dalShopStore = new Tiantu.DB.DAL.ShopStore();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect("/help.html");

        int newsId = SL.GetQueryInt("newsid", true);
        if (newsId > 0)
        {
            ShopNews model = dalShopStore.GetShopNewsModel(newsId);
            if(model!=null)
            {
                nsTitle = model.NewsTitle;
                nsBody = model.NewsBody;
            }
        }
        else
        {
            DataSet dsList = dalShopStore.GetShopNewsList(1, ShopStoreConfig.CLASS_QA);
            if (dsList != null && dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
            {
                DataRow row = dsList.Tables[0].Rows[0];
                nsTitle = row["newsTitle"].ToString();
                nsBody = row["newsBody"].ToString();
            }
        }
         
    }
}