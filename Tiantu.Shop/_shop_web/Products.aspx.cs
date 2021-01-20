using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Tiantu.DB.Common;

public partial class _shop_web_Products : System.Web.UI.Page
{
    public int pageId = 0;
    public int pageSize = 18;
    public int totalRecords = 0;
    public int pageCount = 0;
    Tiantu.DB.DAL.ShopStore dalShopStore = new Tiantu.DB.DAL.ShopStore();

    protected void Page_Load(object sender, EventArgs e)
    {
        ShowCategorys();
        ShowProducts();
    }

    /// <summary>
    /// 商品分类
    /// </summary>
    private void ShowCategorys()
    {
        DataSet dsList = dalShopStore.GetShopCategoryList("ClazzId=1");
        if (dsList != null)
        {
            this.RepeaterCategoryList.DataSource = dsList.Tables[0];
            this.RepeaterCategoryList.DataBind();
        }
    }


    private void ShowProducts()
    {

        pageId = SL.GetQueryInt("page");
        pageId = (pageId < 1 ? 1 : pageId);

        string strWhere = string.Format("t.clazzId={0}", 1);
        string action = SL.GetQueryString("action");
        int categoryId = SL.GetQueryInt("cateid");

        if (!string.IsNullOrEmpty(action))
        {
            if ("tj".Equals(action))
            {
                strWhere += " AND TJTag=1";
            }
            else if ("rm".Equals(action))
            {
                strWhere += " AND HotTag=1";
            }
            else if ("ms".Equals(action))
            {
                strWhere += " AND SeckillTag=1";
            }
        }
        if (categoryId > 0)
        {
            strWhere += string.Format(" AND t.categoryId={0}", categoryId);
        }



        DataSet dsList = dalShopStore.GetShopProductList(pageId, pageSize, strWhere, "", out totalRecords);
        pageId = pageId > totalRecords ? totalRecords : pageId;
        pageCount = totalRecords % pageSize == 0 ? totalRecords / pageSize : totalRecords / pageSize + 1;

        if (dsList != null)
        {
            this.RepeaterProductList.DataSource = dsList.Tables[0];
            this.RepeaterProductList.DataBind();
        }

        // <%=SL.GetPaginationJSCode(ViewBag.RecordCount,ViewBag.CurrentPage,ViewBag.PageSize ,"'&cateid=' + vCateId + '&subcateid=' + vSubCateId") %>

        if (totalRecords > 0)
        {
            this.lblPager.Text = SL.GetPaginationJSCode(totalRecords, pageId, pageSize, "");
        }
        else
        {
            this.lblPager.Text = "暂无商品";
        }
    }
}