using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Tiantu.DB.Common;

public partial class _shop_admin_news_List : System.Web.UI.Page
{
    public string searchKey = "";
    int pageId = 0;
    int pageSize = 10;
    Tiantu.DB.DAL.ShopStore dalShopStore = new Tiantu.DB.DAL.ShopStore();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ShowList();
        }
        catch
        {

        }       
    }


    /// <summary>
    /// 显示列表
    /// </summary>
    private void ShowList()
    {
        pageId = SL.GetQueryInt("pageid");
        pageId = (pageId < 1 ? 1 : pageId);

        string strWhere = string.Format("clazzid={0}", ShopStoreConfig.CLASS_NEWS);
        string strParams = "";

        searchKey = SL.GetQueryString("key");
        if (!string.IsNullOrEmpty(searchKey))
        {
            strWhere += string.Format(" AND newsTitle LIKE '%{0}%'  ", searchKey);
            strParams += string.Format("&key={0}", searchKey);
        }


        int totalRecords = 0;
        DataSet dsList = dalShopStore.GetShopNewsList(pageId, pageSize, strWhere, "", out totalRecords);
        pageId = pageId > totalRecords ? totalRecords : pageId;

        if (dsList != null)
        {
            this.RepeaterList.DataSource = dsList.Tables[0];
            this.RepeaterList.DataBind();
        }

        this.lblPager.Text = dalShopStore.GetPageToolBar(pageId, pageSize, totalRecords, strParams);
    }


    
}