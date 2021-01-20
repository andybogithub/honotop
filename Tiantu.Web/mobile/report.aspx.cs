using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;
using Tinatu.DB;

public partial class mobile_report : System.Web.UI.Page
{
    Tiantu.DB.DAL.Reports dalReports = new Tiantu.DB.DAL.Reports();
    

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
        string srtOrder = "REPORTID DESC,PUBDATE DESC";

  
        #region 分页
        int PageSize = 8;
        int RecordTotal = dalReports.GetRecordCount(strWhere);
        int startIndex = 0;
        int endIndex = 0;

        #endregion

        if (SL.GetPager(ref PageIndex, RecordTotal, PageSize, out startIndex, out endIndex))
        {
            var dsList = dalReports.GetListByPage(strWhere, srtOrder, startIndex, endIndex);
            if (dsList != null)
            {
                foreach (var item in dsList)
                {
                    dataString += string.Format(@" <li>
                            <a href='reportde.aspx?id={0}'><img src='{1}'/></a>
                            <div  class='download'>
                                <a href='{2}' download>下载</a>
                            </div>
                            <p>{3}</p>
                        </li>", item.REPORTID, item.IMGURL, item.PDFURL, item.TITLE);
                }
            }

        }
        return dataString;

    }



}