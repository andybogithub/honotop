using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Tiantu.DB.Common;

public partial class _shop_web_Indiana : System.Web.UI.Page
{
    public int pageId = 0;
    public int pageSize = 18;
    public int totalRecords = 0;
    public int pageCount = 0;
    Tiantu.DB.DAL.ShopStore dalShopStore = new Tiantu.DB.DAL.ShopStore();
    protected void Page_Load(object sender, EventArgs e)
    {
        ShowProducts();
    }

    private void ShowProducts()
    {

        pageId = SL.GetQueryInt("page");
        pageId = (pageId < 1 ? 1 : pageId);

        string strWhere = string.Format("t.clazzId={0}", 2);

        DataSet dsList = dalShopStore.GetShopDuobaoProductList(pageId, pageSize, strWhere, "", out totalRecords);
        pageId = pageId > totalRecords ? totalRecords : pageId;
        pageCount = totalRecords % pageSize == 0 ? totalRecords / pageSize : totalRecords / pageSize + 1;

        if (dsList != null)
        {
            this.RepeaterProductList.DataSource = dsList.Tables[0];
            this.RepeaterProductList.DataBind();
        }

        if (totalRecords > 0)
        {
            this.lblPager.Text = SL.GetPaginationJSCode(totalRecords, pageId, pageSize, "");
        }
        else
        {
            this.lblPager.Text = "暂无商品";
        }
    }


  


    #region Method
    public string GetStatus(int productId,int DubaoStatus, object SeckillEndTime)
    {
        string status = "";
        if (DubaoStatus == 0)   //报名中
        {
            status = string.Format(@"<p class='joinBtn'><a href='/idaDe/{0}.html'>参与夺宝</a></p>", SL.DESEncrypt(productId.ToString()).ToLower());
        }
        else if (DubaoStatus == 1) //完成报名，开奖中，倒计时
        {
            status = string.Format(@"<div class='countDownDiv'>
									<strong>开奖倒计时：</strong>
                                        <div class='lastTime conttimeFun' endtime='{0}'>
										<b>0</b>
										<b>0</b>
										<span>:</span>
										<b>0</b>
										<b>0</b>
										<span>:</span>
										<b>0</b>
										<b>0</b>
									</div>
								</div>", Convert.ToDateTime(SeckillEndTime).ToString("MM/dd/yyyy HH:mm:ss"));
        }
        else if (DubaoStatus == -1)//已开奖
        {
            status = string.Format(@"<div class='statusEnd'><div class='endLink'><a href='/idaDe/{0}.html'>查看详情</a></div>", SL.DESEncrypt(productId.ToString()).ToLower());
        }
        return status;
    }

    protected int GetPercent(int total, int used)
    {
        double du = 0.00;
        if (total > 0)
        {
            du = used / (total * 1.00);
        }

        int result = Convert.ToInt32(du * 100);
        return result > 100 ? 100 : result;
    }


    public string GetDubaoStatus(int DubaoStatus)
    {
        string status = "";
        if (DubaoStatus == 1)
        {
            status = "<div class='readyTag'>正在揭晓</div>";
        }
        else if (DubaoStatus == -1)
        {
            status = "<div class='endbg'><img src='/style/images/end.png'/></div>";
        }
        return status;
    }

    public string GetDubaoLiCss(int DubaoStatus)
    {
        string css = "";
        if (DubaoStatus == 1)
        {
            css = "ing";
        }
        else if (DubaoStatus == -1)
        {
            css = "end";
        }
        return css;
    }
    #endregion

}