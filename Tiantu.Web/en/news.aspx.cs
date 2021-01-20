using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class en_news : System.Web.UI.Page
{
    Tiantu.DB.DAL.News dalNews = new Tiantu.DB.DAL.News();
    protected int PageIndex = 0;
    protected int RecordCount = 0;
    protected int cateid = SL.GetQueryIntValue("ca");


    protected void Page_Load(object sender, EventArgs e)
    {

        #region 左侧菜单
        string strMenu = "";
        string[] strCatename = { "Latest news", "Media center", "News reports", "Magazine" };
        int[] intCateid = { 0, 1, 2, 3 };
        for (int i = 0; i < strCatename.Length; i++)
        {
            strMenu += string.Format("<li class='{2}'><a href='news.aspx?ca={0}'><i></i>{1}</a></li>", intCateid[i], strCatename[i],
                this.cateid == intCateid[i] ? "on" : "");
        }
        this.lblNav.Text = strMenu;
        #endregion


        string strWhere = "1=1";
        string srtOrder = "NEWSID DESC";
        if (this.cateid > 0)
        {
            strWhere += " AND CATEID=" + this.cateid;
            srtOrder = "SORTID DESC,NEWSID DESC";
        }

        #region 分页
        this.PageIndex = SL.GetQueryIntValue("pageid");
        this.RecordCount = dalNews.GetRecordCount(strWhere);

        int PageSize = 10;
        int startIndex = 0;
        int endIndex = 0;
        SL.GetPager(ref this.PageIndex, this.RecordCount, PageSize, out startIndex, out endIndex);
        #endregion

        var list = dalNews.GetListByPage(strWhere, srtOrder, startIndex, endIndex);
        if (list != null)
        {
            this.RepeaterList.DataSource = list;
            this.RepeaterList.DataBind();
        }

    }





}