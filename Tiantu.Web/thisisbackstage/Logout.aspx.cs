using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class webadmin_Logout : System.Web.UI.Page
{
    Tiantu.DB.DAL.Admins dalAdmins = new Tiantu.DB.DAL.Admins();

    protected void Page_Load(object sender, EventArgs e)
    {
        dalAdmins.Logout();
        Response.Redirect("Login.aspx");
    }

}