using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;




public partial class _shop_web__account_MyAddress : System.Web.UI.Page
{
    Tiantu.DB.DAL.Users dalUser = new Tiantu.DB.DAL.Users();
    Tiantu.DB.DAL.ShopStore dalShopStore = new Tiantu.DB.DAL.ShopStore();

    protected void Page_Load(object sender, EventArgs e)
    {
        int userId = dalUser.GetUserIdFromCookie();
        if (userId == 0)
        {
            Response.Redirect("/");
        }

        int emplId = 0;

        //地址列表
        ShowAddress(userId, emplId);
    }


    private void ShowAddress(int userId, int emplId)
    {
        DataSet dsList = dalShopStore.GetShopAddressList(userId, emplId);
        if(dsList!=null)
        {
            this.RepeaterAddressList.DataSource = dsList.Tables[0];
            this.RepeaterAddressList.DataBind();

            this.lblAddressTotal.Text = dsList.Tables[0].Rows.Count.ToString();
        }
    }

}