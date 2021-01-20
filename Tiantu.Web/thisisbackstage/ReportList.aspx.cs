using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;
using Tinatu.DB;

public partial class webadmin_ReportList : System.Web.UI.Page
{
    Tiantu.DB.DAL.Reports dalReports = new Tiantu.DB.DAL.Reports();
    public int cateid = 0;


    protected void Page_Load(object sender, EventArgs e)
    {

        this.cateid = SL.GetQueryIntValue("cateid");



        string strMenu = string.Format("<a href = 'ReportList.aspx?cateid=0' class='btn {0}'>全部</a>", this.cateid == 0 ? "active" : "");
        var catelist = DBHelper.GetReportCateList();
        foreach (var item in catelist)
        {
            strMenu += string.Format("<a href = 'ReportList.aspx?cateid={0}' class='btn {2}'>{1}</a>", item.CATEID, item.CATENAME,
                 this.cateid == item.CATEID ? "active" : "");
        }
        this.lblMenu.Text = "";


        #region 显示列表
        string strWhere = "1=1";
        string strParams = "";

        this.cateid = SL.GetQueryIntValue("cateid");
        if (this.cateid > 0)
        {
            strWhere += " AND CATEID=" + this.cateid;
            strParams += "&cateid=" + cateid;
        }

        #region 分页
        int pageIndex = SL.GetQueryIntValue("pageid");
        int recordCount = dalReports.GetRecordCount(strWhere);
        int startIndex = 0;
        int endIndex = 0;
        string strPager = SL.GetPagerNavigator(pageIndex, recordCount, strParams, 3, "/webadmin/ReportList.aspx", out startIndex, out endIndex);
        this.lblPagination.Text = strPager;
        #endregion

        var list = dalReports.GetListByPage(strWhere, "sortId DESC, REPORTID DESC,PUBDATE DESC", startIndex, endIndex);
        if (list != null)
        {
            this.RepeaterStores.DataSource = list;
            this.RepeaterStores.DataBind();
        }
        #endregion


    }

    protected void RepeaterStores_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if ("delete".Equals(e.CommandName))
        {
            int newsid = Convert.ToInt32(e.CommandArgument);
            Tiantu.DB.Model.Reports model = dalReports.GetModel(newsid);
            if (model != null)
            {
                //删除图片文件
                SL.TryDeleteImage(model.IMGURL);
            }
            dalReports.Delete(newsid);
            Response.Redirect("ReportList.aspx");
        }
    }

    

    protected string GetCateName(object cateid)
    {
        string cateName = "";

        if (cateid != null)
        {
            int caid = Convert.ToInt32(cateid);

            if (caid == 1)
            {
                cateName = "新闻资讯";
            }
            else if (caid == 2)
            {
                cateName = "新闻报道";
            }
            else if (caid == 3)
            {
                cateName = "杂志报道";
            }
            else if (caid == 4)
            {
                cateName = "公司公告";
            }
        }
        return cateName;
    }


}