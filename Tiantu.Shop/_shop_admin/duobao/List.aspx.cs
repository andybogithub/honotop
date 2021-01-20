using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Tiantu.DB.Common;

public partial class _shop_admin_duobao_List : System.Web.UI.Page
{
    public string p1 = "", p2 = "", p3 = "", p4 = "", p5 = "", p6 = "" ;

    int pageId = 0;
    int pageSize = 10;
    Tiantu.DB.DAL.ShopStore dalShopStore = new Tiantu.DB.DAL.ShopStore();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
          
        }
        catch  
        {

        }
        ShowList();

    }

    private void ShowList()
    {
        pageId = SL.GetQueryInt("pageid");
        pageId = (pageId < 1 ? 1 : pageId);



        int clazzId = 2;
        string strWhere = string.Format("t.clazzId={0}", clazzId);
        string strParams = "";

        p1 = SL.GetQueryString("p1");
        p2 = SL.GetQueryString("p2");
        p3 = SL.GetQueryString("p3");
        p4 = SL.GetQueryString("p4");
        p5 = SL.GetQueryString("p5");
        p6 = SL.GetQueryString("p6"); 

        if (!string.IsNullOrEmpty(p1))
        {
            strWhere += string.Format(" AND productname LIKE '%{0}%'  ", p1);
            strParams += string.Format("&p1={0}", p1);
        }

        if (!string.IsNullOrEmpty(p2))
        {
            strWhere += string.Format(" AND QtyStatus='{0}'  ", p2);
            strParams += string.Format("&p2={0}", p2);
        }

        if (!string.IsNullOrEmpty(p3) && Convert.ToInt32(p3) == 1)
        {
            strWhere += string.Format(" AND ShowHomeTag={0}  ", 1);
            strParams += string.Format("&p3={0}", p3);
        }

        if (!string.IsNullOrEmpty(p4) && Convert.ToInt32(p4) == 1)
        {
            strWhere += string.Format(" AND seckillTag={0}  ", 1);
            strParams += string.Format("&p4={0}", p3);
        }


        if (!string.IsNullOrEmpty(p5) && Convert.ToInt32(p5) == 1)
        {
            strWhere += string.Format(" AND tjTag={0}  ", 1);
            strParams += string.Format("&p5={0}", p5);
        }

        if (!string.IsNullOrEmpty(p6) && Convert.ToInt32(p6)==1)
        {
            strWhere += string.Format(" AND hotTag={0}  ", 1);
            strParams += string.Format("&p6={0}", p6);
        }
         
        int totalRecords = 0;
        DataSet dsList = dalShopStore.GetShopProductList(pageId,pageSize,strWhere,"",out totalRecords);
        pageId = pageId > totalRecords ? totalRecords : pageId;

        if (dsList != null)
        {
            this.RepeaterList.DataSource = dsList.Tables[0];
            this.RepeaterList.DataBind();
        }

        this.lblTotalProducts.Text = totalRecords.ToString();
        this.lblPager.Text = dalShopStore.GetPageToolBar(pageId, pageSize, totalRecords, strParams);
    }


    #region Method
    public string GetQtyStatus(object qtyStatus)
    {
        if (null == qtyStatus) return "";

        string strClass = "";

        switch (qtyStatus.ToString())
        {
       
            case "库存充足":
                strClass = "btn btn-border-green btn-xs";
                break;
            case "库存紧张":
                strClass = "btn btn-border-theme btn-xs";
                break;
            case "无货":
                strClass = "btn btn-border-white btn-xs";
                break;
        }

         return string.Format("<span class='{0}'>{1}</span>", "",qtyStatus);
        
    }
    #endregion
}