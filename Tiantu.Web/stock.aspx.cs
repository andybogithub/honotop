using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;
using Tinatu.DB;

public partial class stock : System.Web.UI.Page
{

    protected Tiantu.DB.Model.AboutUs pageModel = null;
    protected int aboutid = SL.GetQueryIntValue("aboutid");

    protected void Page_Load(object sender, EventArgs e)
    {
       
        aboutid = (aboutid == 0) ? 7 : aboutid;
        this.pageModel = DBHelper.GetAboutUs(aboutid);

      
        #region 二级菜单
        string strMenu = "";
        string[] sName = { "新闻", "公告", "研报", "资料" };
        int[] iAboutid = { 7, 8, 9, 10 };
        for (int i = 0; i < sName.Length; i++)
        {
            strMenu += string.Format("<li class='{2}'><a href='stock.aspx?aboutid={0}'>{1}</a></li>", iAboutid[i], sName[i],
                this.aboutid == iAboutid[i] ? "on" : "");
        }
        this.lblSubmenu.Text = strMenu;
        #endregion
    }
}