using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class webadmin_Webadmin : System.Web.UI.MasterPage
{
    Tiantu.DB.DAL.Admins dalAdmins = new Tiantu.DB.DAL.Admins();
    protected string adminname = "";
    protected int adminid = 0;

    protected void Page_Load(object sender, EventArgs e)
    {


        this.adminid = dalAdmins.GetAdminIdFromCookie();
        Tiantu.DB.Model.Admins model = dalAdmins.GetModel(this.adminid);
        if (model != null)
        {
            this.adminname = model.ADMINNAME;
        }
        else
        {
            Response.Redirect("Login.aspx");
        }




    }
}
