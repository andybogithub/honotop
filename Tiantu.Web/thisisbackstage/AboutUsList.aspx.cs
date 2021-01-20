using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class webadmin_AboutUsList : System.Web.UI.Page
{

    Tiantu.DB.DAL.AboutUs dalAboutUs = new Tiantu.DB.DAL.AboutUs();
    public int cateId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

        #region Banners

        this.cateId = SL.GetQueryIntValue("cateid");
        string strWhere = "1=1";

        if (this.cateId > 0)
        {
            strWhere += string.Format(" and cateid = '{0}'  ", this.cateId);
        }

        var list = dalAboutUs.GetList(0, strWhere, "ABOUTID");
        if (list != null)
        {
            this.RepeaterBook.DataSource = list;
            this.RepeaterBook.DataBind();
        }
        #endregion

    }


    protected void RepeaterBook_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if ("delete".Equals(e.CommandName))
        {
            int abid = Convert.ToInt32(e.CommandArgument);
            dalAboutUs.Delete(abid);
            Response.Redirect("AboutUsList.aspx?cateid=" + this.cateId);
        }
    }


}