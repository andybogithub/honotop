using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class mobile_company : System.Web.UI.Page
{
    Tiantu.DB.DAL.Notices dalNotices = new Tiantu.DB.DAL.Notices();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        var dddd = dalNotices.GetModel(1);
        WebControlsHelper.SimpleJsonResultxxx(dddd);

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
        string srtOrder = "NOTICEID DESC";

        #region 分页
        int PageSize = 8;
        int RecordTotal = dalNotices.GetRecordCount(strWhere);
        int startIndex = 0;
        int endIndex = 0;

        #endregion

        if (SL.GetPager(ref PageIndex, RecordTotal, PageSize, out startIndex, out endIndex))
        {
            var dsList = dalNotices.GetListByPage(strWhere, srtOrder, startIndex, endIndex);
            if (dsList != null)
            {
                foreach (var item in dsList)
                {
                    dataString += string.Format(@"<div class='c_list cl'>
                    <a href = 'companyde.aspx?id={0}' >
                        <div class='clist_cont'>
                            <h5>{2}</h5>
                            <div class='time'>{3}</div>
                            <div class='dowmload'><a href='{4}' download><input type = 'button' value='下载'></a></div>	
                        </div>
                    </a>
                </div>", item.NOTICEID, "", item.TITLE, item.PUBDATE.ToString("yyyy-MM-dd"),item.PDFURL);
                }
            }
        }
        return dataString;

    }




}