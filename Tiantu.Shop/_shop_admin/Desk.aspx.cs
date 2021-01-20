using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;



public partial class _shop_admin_Desk : System.Web.UI.Page
{
    Tiantu.DB.DAL.ShopStore dalShopStore = new Tiantu.DB.DAL.ShopStore();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ShowOrderProducts();
        }
        catch  
        { 
        }
    }


    private void ShowOrderProducts()
    {
        string strWhere = "";
        int totalRecords = 0;
        DataSet dsList = dalShopStore.GetShopOrderProductList(1, 15, strWhere, "", out totalRecords);
        if (dsList != null)
        {
            this.RepeaterOrderProductList.DataSource = dsList.Tables[0];
            this.RepeaterOrderProductList.DataBind();
        }
    }
}