using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class webadmin_AdminList : System.Web.UI.Page
{
    Tiantu.DB.DAL.Admins dalAdmins = new Tiantu.DB.DAL.Admins();

    protected void Page_Load(object sender, EventArgs e)
    {
        ShowList();
    }

    private void ShowList()
    {
       var dsList = dalAdmins.GetList(0, "", "ADMINID DESC");
        if (dsList != null)
        {
            this.RepeaterBook.DataSource = dsList;
            this.RepeaterBook.DataBind();
        }
    }

}