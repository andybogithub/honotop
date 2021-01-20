using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Tiantu.DB.Common;

public partial class _shop_admin_order_List : System.Web.UI.Page
{
    public string searchKey1 = "";
    public string searchKey2 = "";
    public string searchKey3 = "";

    Tiantu.DB.DAL.ShopStore dalShopStore = new Tiantu.DB.DAL.ShopStore();


    protected void Page_Load(object sender, EventArgs e)
    {
        ShowOrderProducts();
    }

    private void ShowOrderProducts()
    {
        int pageSize = 10;
        int pageId = SL.GetQueryInt("page");
        pageId = (pageId < 1 ? 1 : pageId);


        searchKey1 = SL.GetQueryString("p1");
        searchKey2 = SL.GetQueryString("p2");
        searchKey3 = SL.GetQueryString("p3");

        string strWhere = "1=1";
        string strParams = "";
        
        //商品名称
        if (searchKey1.Length > 0)
        {
            strWhere += string.Format(" AND t.prodname like '%{0}%' ", searchKey1);
            strParams += string.Format("&p1={0}", searchKey1);
        }

        //收货人
        if (searchKey2.Length > 0)
        {
            strWhere += string.Format(" AND (o.username like '%{0}%' OR o.usertel like '%{0}%') ", searchKey2);
            strParams += string.Format("&p2={0}", searchKey2);
        }

        //已发货
        if (searchKey3.Length > 0 && "1".Equals(searchKey3))
        {
            strWhere += " and t.shipstatus='已发货' ";
            strParams += "&p3=1";
        }

        int totalRecords = 0;
        DataSet dsList = dalShopStore.GetShopAllOrderProductList(pageId, pageSize, strWhere, "", out totalRecords);
        pageId = pageId > totalRecords ? totalRecords : pageId;
        int pageCount = totalRecords % pageSize == 0 ? totalRecords / pageSize : totalRecords / pageSize + 1;

        if (dsList != null)
        {
            this.RepeaterList.DataSource = dsList.Tables[0];
            this.RepeaterList.DataBind();
        }
        this.lblPager.Text = dalShopStore.GetPageToolBar(pageId, pageSize, totalRecords, strParams);
    }
}