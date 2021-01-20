using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Tiantu.DB.Common;

public partial class _shop_web__account_MyPoints : System.Web.UI.Page
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

      try
        {
            int emplId = 0;

            //金币列表
            ShowPoints(userId, emplId);
        }
        catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    private void ShowPoints(int userId, int emplId)
    {
        int pageSize = 100;
        int pageId = SL.GetQueryInt("page");
        pageId = (pageId < 1 ? 1 : pageId);

        string strWhere = string.Format("t.userId={0} AND t.emplId={1}", userId, emplId);
        int totalRecords = 0;
        DataSet dsList = dalShopStore.GetShopUserPointList(pageId, pageSize, strWhere, "", out totalRecords);
        pageId = pageId > totalRecords ? totalRecords : pageId;
        int pageCount = totalRecords % pageSize == 0 ? totalRecords / pageSize : totalRecords / pageSize + 1;

        if (dsList != null)
        {
            this.RepeaterPointList.DataSource = dsList.Tables[0];
            this.RepeaterPointList.DataBind();
        }

        if (totalRecords > 0)
        {
            this.lblPager.Text = SL.GetPaginationJSCode(totalRecords, pageId, pageSize, "");
        }
    }

    public string getContrn(int no)
    {

        if (no == 1)
        {
            return "充值";
        }
        else if (no == 102)
        {
            return "购买商品";
        }
        else if (no == 103)
        {
            return "限时抢购";
        }
        else 
        {
            return no.ToString();
        }

    }
}