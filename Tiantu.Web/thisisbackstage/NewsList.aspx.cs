using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class webadmin_NewsList : System.Web.UI.Page
{

    Tiantu.DB.DAL.News dalNews = new Tiantu.DB.DAL.News();
    public int cateid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        this.cateid = SL.GetQueryIntValue("cateid");

        string strMenu = "";
        string[] strCatename = { "全部", "新闻资讯", "新闻报道", "杂志报道" };
        int[] intCateid = { 0, 1, 2, 3 };
        for (int i = 0; i < strCatename.Length; i++)
        {
            strMenu += string.Format("<a href = 'NewsList.aspx?cateid={0}' class='btn {2}'>{1}</a>", intCateid[i], strCatename[i],
                this.cateid == intCateid[i] ? "active" : "");
        }
        this.lblMenu.Text = strMenu;


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
        int recordCount = dalNews.GetRecordCount(strWhere);
        int startIndex = 0;
        int endIndex = 0;
        string strPager = SL.GetPagerNavigator(pageIndex, recordCount, strParams, 3, "/webadmin/NewsList.aspx", out startIndex, out endIndex);
        this.lblPagination.Text = strPager;
        #endregion

        var list = dalNews.GetListByPage(strWhere, "NEWSID DESC,PUBDATE DESC", startIndex, endIndex);
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
            Tiantu.DB.Model.News model = dalNews.GetModel(newsid);
            if (model != null)
            {
                //删除图片文件
                SL.TryDeleteImage(model.IMGURL);
            }
            dalNews.Delete(newsid);
            Response.Redirect("NewsList.aspx");
        }
    }


    protected string GetImg(object img)
    {
        string imgCont = "";
        if (img != null && img.ToString().Length > 0)
        {
            imgCont = string.Format("<img src='{0}' style='width:60px;height:60px;'/>", img.ToString());
        }
        else
        {
            imgCont = "无";
        }

        return imgCont;
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