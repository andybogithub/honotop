using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Tiantu.DB.Common;

public partial class _shop_web_News : System.Web.UI.Page
{
    public int pageId = 0;
    public int pageSize = 8;
    public int totalRecords = 0;
    public int pageCount = 0;
    Tiantu.DB.DAL.ShopStore dalShopStore = new Tiantu.DB.DAL.ShopStore();

    protected void Page_Load(object sender, EventArgs e)
    {
        ShowHelp();
        ShowNews();
    }

    private void ShowHelp()
    {
        DataSet dsHelpList = dalShopStore.GetShopNewsList(10, ShopStoreConfig.CLASS_NEWS);
        if (dsHelpList != null)
        {
            this.RepeaterTitleList.DataSource = dsHelpList.Tables[0];
            this.RepeaterTitleList.DataBind();
        }
    }

    private void ShowNews()
    {

        pageId = SL.GetQueryInt("page");
        pageId = (pageId < 1 ? 1 : pageId);

        string strWhere = string.Format("t.clazzId={0}", ShopStoreConfig.CLASS_NEWS);
        DataSet dsList = dalShopStore.GetShopNewsList(pageId, pageSize, strWhere, "", out totalRecords);
        pageId = pageId > totalRecords ? totalRecords : pageId;
        pageCount = totalRecords % pageSize == 0 ? totalRecords / pageSize : totalRecords / pageSize + 1;

        if (dsList != null)
        {
            this.RepeaterNewsList.DataSource = dsList.Tables[0];
            this.RepeaterNewsList.DataBind();
        }
 
        if (totalRecords > 0)
        {
            this.lblPager.Text = SL.GetPaginationJSCode(totalRecords, pageId, pageSize, "");
        }
        else
        {
            this.lblPager.Text = "暂无记录";
        }
    }
}