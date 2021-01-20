using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Tiantu.DB.Common;

public partial class _shop_admin_user_UserPointList : System.Web.UI.Page
{

    public string searchKey = "";
    public int pageId = 0;
    public int pageSize = 10;


    Tiantu.DB.DAL.ShopStore dalShopStore = new Tiantu.DB.DAL.ShopStore();

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect("/");

        try
        {
            ShowList();
        }
        catch
        {

        }
       
    }


    private void ShowList()
    {
        pageId = SL.GetQueryInt("pageid");
        pageId = (pageId < 1 ? 1 : pageId);

        string strWhere = "";
        string strParams = "";

        searchKey = SL.GetQueryString("key");
        if (!string.IsNullOrEmpty(searchKey))
        {
            strWhere += string.Format("(T.usertel LIKE '%{0}%' OR T.username LIKE '%{0}%')  ", searchKey);
            strParams += string.Format("&key={0}", searchKey);
        }

        int totalRecords = 0;
        DataSet dsList = dalShopStore.GetShopUserPointList(pageId, pageSize, strWhere, "", out totalRecords);
        pageId = pageId > totalRecords ? totalRecords : pageId;

        if (dsList != null)
        {
            this.RepeaterList.DataSource = dsList.Tables[0];
            this.RepeaterList.DataBind();
        }


        this.lblPager.Text = dalShopStore.GetPageToolBar(pageId, pageSize, totalRecords,strParams);
    }
}