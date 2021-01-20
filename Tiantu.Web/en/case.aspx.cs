using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class en_Case : System.Web.UI.Page
{
    Tiantu.DB.DAL.Cases dalCases = new Tiantu.DB.DAL.Cases();

    protected void Page_Load(object sender, EventArgs e)
    {
        var list = dalCases.GetList(0, "", "SORTID DESC");
        this.RepeaterList.DataSource = list;
        this.RepeaterList.DataBind();
    }




}