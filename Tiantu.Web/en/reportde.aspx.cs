using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;
using Tinatu.DB;

public partial class en_reportde : System.Web.UI.Page
{
    Tiantu.DB.DAL.Reports dalReports = new Tiantu.DB.DAL.Reports();

    protected int reportid = SL.GetQueryIntValue("reportid");
    protected Tiantu.DB.Model.Reports pageModel = null;

    protected void Page_Load(object sender, EventArgs e)
    {

        this.pageModel = dalReports.GetModel(reportid);
        this.pageModel = (this.pageModel == null) ? new Tiantu.DB.Model.Reports() : this.pageModel;
        int cateid = this.pageModel.CATEID;



        #region 左侧菜单
        string strMenu = "";
        var catelist = DBHelper.GetReportCateList();
        foreach (var item in catelist)
        {
            strMenu += string.Format("<li class='{2}'><a href = 'report.aspx?ca={0}'>{1}</a></li>", item.CATEID, item.CATENAME,
                 cateid == item.CATEID ? "on" : "");
        }
        this.lblNav.Text = strMenu;
        #endregion

    }



}