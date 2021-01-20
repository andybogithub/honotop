using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class en_newsde : System.Web.UI.Page
{
    Tiantu.DB.DAL.News dalNews = new Tiantu.DB.DAL.News();

    protected int newsid = SL.GetQueryIntValue("no");
    protected Tiantu.DB.Model.News pageModel = null;

    protected void Page_Load(object sender, EventArgs e)
    {

        this.pageModel = dalNews.GetModel(newsid);
        this.pageModel = (this.pageModel == null) ? new Tiantu.DB.Model.News() : this.pageModel;
        int cateid = this.pageModel.CATEID;


        #region 左侧菜单
        string strMenu = "";
        string[] strCatename = { "Latest news", "Media center", "News reports", "Magazine" };
        int[] intCateid = { 0, 1, 2, 3 };
        for (int i = 0; i < strCatename.Length; i++)
        {
            strMenu += string.Format("<li class='{2}'><a href='news.aspx?ca={0}'><i></i>{1}</a></li>", intCateid[i], strCatename[i],
                cateid == intCateid[i] ? "on" : "");
        }
        this.lblNav.Text = strMenu;
        #endregion
    }




}