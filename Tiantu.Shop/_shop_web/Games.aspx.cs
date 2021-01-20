using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Tiantu.DB.Common;

public partial class _shop_web_Games : System.Web.UI.Page
{
    public int pageId = 0;
    public int pageSize = 8;
    public int totalRecords = 0;
    public int pageCount = 0;
    Tiantu.DB.DAL.ShopStore dalShopStore = new Tiantu.DB.DAL.ShopStore();
    protected void Page_Load(object sender, EventArgs e)
    {
        ShowGames();
    }

    private void ShowGames()
    {
        pageId = SL.GetQueryInt("page");
        pageId = (pageId < 1 ? 1 : pageId);

        DataSet dsList = dalShopStore.GetShopGameList();
        totalRecords = dsList.Tables[0].Rows.Count;
        pageId = pageId > totalRecords ? totalRecords : pageId;
        pageCount = totalRecords % pageSize == 0 ? totalRecords / pageSize : totalRecords / pageSize + 1;

        if (dsList != null)
        {
            this.RepeaterGameList.DataSource = dsList.Tables[0];
            this.RepeaterGameList.DataBind();
        }

        if (totalRecords > 0)
        {
            //this.lblPager.Text = SL.GetPaginationJSCode(totalRecords, pageId, pageSize, "");
        } 
    }


  
}