using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class investors : System.Web.UI.Page
{
    Tiantu.DB.DAL.Reports dalReports = new Tiantu.DB.DAL.Reports();
    Tiantu.DB.DAL.Notices dalNotices = new Tiantu.DB.DAL.Notices();
    Tiantu.DB.DAL.Links dalLinks = new Tiantu.DB.DAL.Links();
    protected static Tiantu.DB.DAL.Setting dalSetting=new Tiantu.DB.DAL.Setting();
    protected string instructions_note = dalSetting.GetValue(Tiantu.DB.DAL.Setting.key_instructions_note);

    protected void Page_Load(object sender, EventArgs e)
    {


        #region 定期报告
        string strWhere = "1=1";
        string srtOrder = "REPORTID DESC,PUBDATE DESC";

        var list = dalReports.GetList(2, strWhere, srtOrder);
        if (list != null)
        {
            this.RepeaterListReport.DataSource = list;
            this.RepeaterListReport.DataBind();
        }
        #endregion

        #region 公司公告
        var list2 = dalNotices.GetList(5, "", "NOTICEID DESC");
        if (list2 != null)
        {
            this.RepeaterListNotice.DataSource = list2;
            this.RepeaterListNotice.DataBind();
        }

        #endregion

        #region 公司公告
        var list3 = dalLinks.GetList(3, "LINKID IN (1,2,3)", "LINKID DESC");
        if (list3 != null)
        {
            this.RepeaterListLink.DataSource = list3;
            this.RepeaterListLink.DataBind();
        }

        #endregion


    }
}