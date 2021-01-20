using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class em_news : System.Web.UI.Page
{
    Tiantu.DB.DAL.News dalNews = new Tiantu.DB.DAL.News();
    protected int cateid = SL.GetQueryIntValue("ca");




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
        string srtOrder = "NEWSID DESC";

        if (this.cateid > 0)
        {
            strWhere += " AND CATEID=" + this.cateid;
            srtOrder = "SORTID DESC,NEWSID DESC";
        }

        #region 分页
        int PageSize = 8;
        int RecordTotal = dalNews.GetRecordCount(strWhere);
        int startIndex = 0;
        int endIndex = 0;

        #endregion

        if (SL.GetPager(ref PageIndex, RecordTotal, PageSize, out startIndex, out endIndex))
        {
            var dsList = dalNews.GetListByPage(strWhere, srtOrder, startIndex, endIndex);
            if (dsList != null)
            {
                foreach (var item in dsList)
                {
                    dataString += string.Format(@"<div class='c_list cl'>
                    <a href = 'newsde.aspx?no={0}' >
                        <div class='l pic' {4}>
                            <img src = '{1}' width='125' height='100' />
                        </div>
                        <div class='clist_cont'>
                            <h5>{2}</h5>
                            <div class='time'>{3}</div>
                            <div class='words'>{5}</div>
                        </div>
                    </a>
                </div>", item.NEWSID, item.IMGURL, item.TITLE_EN, item.PUBDATE.ToString("yyyy/MM/dd"), item.IMGURL.Length > 3 ? "": "style='display:none;'",
                       item.SUBTITLE);
                }
            }

        }
        return dataString;

    }
}