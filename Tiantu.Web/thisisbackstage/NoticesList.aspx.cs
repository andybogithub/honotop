using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class webadmin_NoticesList : System.Web.UI.Page
{
    Tiantu.DB.DAL.Notices dalNotices = new Tiantu.DB.DAL.Notices();
    

    protected void Page_Load(object sender, EventArgs e)
    {

   
   
        #region 显示列表
        string strWhere = "1=1";
        string strParams = "";
        

        #region 分页
        int pageIndex = SL.GetQueryIntValue("pageid");
        int recordCount = dalNotices.GetRecordCount(strWhere);
        int startIndex = 0;
        int endIndex = 0;
        string strPager = SL.GetPagerNavigator(pageIndex, recordCount, strParams, 3, "/thisisbackstage/NoticesList.aspx", out startIndex, out endIndex);
        this.lblPagination.Text = strPager;
        #endregion

        var list = dalNotices.GetListByPage(strWhere, "PUBDATE DESC,NOTICEID DESC", startIndex, endIndex);
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
            int relid = Convert.ToInt32(e.CommandArgument);
            Tiantu.DB.Model.Notices model = dalNotices.GetModel(relid);
            dalNotices.Delete(relid);
            Response.Redirect("NoticesList.aspx");
        }
    }



  

}