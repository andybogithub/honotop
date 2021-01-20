using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;
using Tinatu.DB;

public partial class en_report : System.Web.UI.Page
{
    Tiantu.DB.DAL.Reports dalReports = new Tiantu.DB.DAL.Reports();
    protected int PageIndex = 0;
    protected int RecordCount = 0;
    protected int cateid = SL.GetQueryIntValue("ca");


    protected void Page_Load(object sender, EventArgs e)
    {

        #region 左侧菜单
        string strMenu = "";
        var catelist = DBHelper.GetReportCateList();
        foreach (var item in catelist)
        {
            strMenu += string.Format("<li class='{2}'><a href = 'report.aspx?ca={0}'>{1}</a></li>", item.CATEID, item.CATENAME,
                 this.cateid == item.CATEID ? "on" : "");
        }
        this.lblNav.Text = strMenu;
        #endregion


        string strWhere = "1=1";
        string srtOrder = "REPORTID DESC,PUBDATE DESC";
        if (this.cateid > 0)
        {
            strWhere += " AND T.CATEID=" + this.cateid;
        }

        #region 分页
        this.PageIndex = SL.GetQueryIntValue("pageid");
        this.RecordCount = dalReports.GetRecordCount(strWhere);

        int PageSize = 12;
        int startIndex = 0;
        int endIndex = 0;
        SL.GetPager(ref this.PageIndex, this.RecordCount, PageSize, out startIndex, out endIndex);
        #endregion

        var list = dalReports.GetListByPage(strWhere, srtOrder, startIndex, endIndex);
        if (list != null)
        {
            this.RepeaterList.DataSource = list;
            this.RepeaterList.DataBind();
        }

    }



}