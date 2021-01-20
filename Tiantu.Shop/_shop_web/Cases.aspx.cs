using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _shop_web_Cases : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Tiantu.DB.DAL.Cases dalCases = new Tiantu.DB.DAL.Cases();
        var list = dalCases.GetList(0, "", "SORTID DESC");

        if (list != null)
        {

            this.RepeaterCases.DataSource = list;
            this.RepeaterCases.DataBind();
        }


    }
}