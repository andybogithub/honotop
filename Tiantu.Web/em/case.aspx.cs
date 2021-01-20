using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class em_case : System.Web.UI.Page
{
    Tiantu.DB.DAL.Cases dalCases = new Tiantu.DB.DAL.Cases();

    protected void Page_Load(object sender, EventArgs e)
    {


        string method = SL.GetQueryStringValue("method");
        int pageid = SL.GetQueryIntValue("pageid");

        #region 分页获取数据
        if ("ajax".Equals(SL.GetQueryStringValue("method")))
        {
            int pageId = SL.GetQueryIntValue("pageid");
            string data = GetDataByPage(pageId);
            Response.Write(data);
            Response.End();
        }
        #endregion

    }


    //
    private string GetDataByPage(int PageIndex)
    {
        string dataString = "";
        string strWhere = "1=1";
        string srtOrder = "CASEID DESC";

        #region 分页
        int PageSize = 8;
        int RecordTotal = dalCases.GetRecordCount(strWhere);
        int startIndex = 0;
        int endIndex = 0;

        #endregion

        if (SL.GetPager(ref PageIndex, RecordTotal, PageSize, out startIndex, out endIndex))
        {
            var dsList = dalCases.GetListByPage(strWhere, srtOrder, startIndex, endIndex);
            if (dsList != null)
            {
                foreach (var item in dsList)
                {
                    dataString += string.Format(@"<li><a href='#'><img src='{0}'></a></li>",item.IMGURL);
                }
            }
        }
        return dataString;

    }
}