using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class _shop_web_ProductDetail : System.Web.UI.Page
{
    public bool IsLogin = false;
    public Tiantu.DB.Model.ShopProduct productmodel;

    Tiantu.DB.DAL.Users dalUsers = new Tiantu.DB.DAL.Users();
    Tiantu.DB.DAL.ShopStore dalShopStore = new Tiantu.DB.DAL.ShopStore();

    protected void Page_Load(object sender, EventArgs e)
    {
        int productId = SL.GetQueryInt("productno", true);

        if (productId > 0)
        {
            ShowInfo(productId);
        }
        else
        {
            Response.Redirect("/products.html");
        }
    }

    private void ShowInfo(int productId)
    {
        productmodel = dalShopStore.GetShopProductModel(productId);
        if (null == productmodel || productmodel.ProductId == 0)
        {
            Response.Redirect("/products.html");
        }
        else if (productmodel.ClazzId == 2)
        {
            Response.Redirect("/indianas.html");
        }

        int userId = dalUsers.GetUserIdFromCookie();
        this.IsLogin = userId > 0;
    }
}