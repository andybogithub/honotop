using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class en_company : System.Web.UI.Page
{
    Tiantu.DB.DAL.Notices dalNotices = new Tiantu.DB.DAL.Notices();
    protected int PageIndex = 0;
    protected int RecordCount = 0;



    protected void Page_Load(object sender, EventArgs e)
    {
        
        string strWhere = "1=1";
        string srtOrder = "NOTICEID DESC";
      

        #region 分页
        this.PageIndex = SL.GetQueryIntValue("pageid");
        this.RecordCount = dalNotices.GetRecordCount(strWhere);

        int PageSize = 10;
        int startIndex = 0;
        int endIndex = 0;
        SL.GetPager(ref this.PageIndex, this.RecordCount, PageSize, out startIndex, out endIndex);
        #endregion

        var list = dalNotices.GetListByPage(strWhere, srtOrder, startIndex, endIndex);
        if (list != null)
        {
            this.RepeaterList.DataSource = list;
            this.RepeaterList.DataBind();
        }

    }

}