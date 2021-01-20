using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Tiantu.DB.DAL;
using Tinatu.DB;

public partial class _shop_admin_banner_List : System.Web.UI.Page
{
    Banners dalBanner = new Banners();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
           
        }
        catch  
        {
             
        }

        ShowList();
    }

    private void ShowList()
    {
        DataSet dsBanner = dalBanner.GetList(string.Format("webid={0}", DBHelper.WEBID_SHOP));
        if (dsBanner != null)
        {
            this.RepeaterBannerList.DataSource = dsBanner.Tables[0];
            this.RepeaterBannerList.DataBind();
        }
    }
}