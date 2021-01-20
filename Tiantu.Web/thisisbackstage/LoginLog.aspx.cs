using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class thisisbackstage_LoginLog : System.Web.UI.Page
{

    Tiantu.DB.DAL.Admins dalAdmins = new Tiantu.DB.DAL.Admins();
    

    protected void Page_Load(object sender, EventArgs e)
    {
        

        #region 显示列表
        string strWhere = "1=1";
        string strParams = "";



        #region 分页
        int pageIndex = SL.GetQueryIntValue("pageid");
        int recordCount = dalAdmins.GetRecordCount(strWhere);
        int startIndex = 0;
        int endIndex = 0;
        string strPager = SL.GetPagerNavigator(pageIndex, recordCount, strParams, 3, "/thisisbackstage/LoginLog.aspx", out startIndex, out endIndex);
        this.lblPagination.Text = strPager;
        #endregion

        var list = dalAdmins.GetLogList(strWhere, "LogId DESC", startIndex, endIndex);
        if (list != null)
        {
            this.RepeaterStores.DataSource = list;
            this.RepeaterStores.DataBind();
        }
        #endregion


    }







}