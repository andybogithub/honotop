using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Tiantu.DB.Common;

public partial class _shop_web__account_Index : System.Web.UI.Page
{
 
    Tiantu.DB.DAL.Users dalUser = new Tiantu.DB.DAL.Users();
    
    Tiantu.DB.DAL.ShopStore dalShopStore = new Tiantu.DB.DAL.ShopStore();


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            int userId = dalUser.GetUserIdFromCookie();
            int emplId = 0;

            //订单产品列表
            ShowOrderProducts(userId, emplId);
        }
        catch
        {
             
        }
    }

    private void ShowOrderProducts(int userId,int emplId)
    {
        int pageSize = 10;
        int pageId = SL.GetQueryInt("page");
        pageId = (pageId < 1 ? 1 : pageId);

        string strWhere = string.Format("o.userId={0} AND o.emplId={1}", userId, emplId);
        int totalRecords = 0;
        DataSet dsList = dalShopStore.GetShopOrderProductList(pageId, pageSize, strWhere, "", out totalRecords);
        pageId = pageId > totalRecords ? totalRecords : pageId;
        int pageCount = totalRecords % pageSize == 0 ? totalRecords / pageSize : totalRecords / pageSize + 1;

        if (dsList != null)
        {
            this.RepeaterProductList.DataSource = dsList.Tables[0];
            this.RepeaterProductList.DataBind();
        }

        if (totalRecords > 0)
        {
            this.lblPager.Text = SL.GetPaginationJSCode(totalRecords, pageId, pageSize, "");
        } 
    }
}