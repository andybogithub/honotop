using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tinatu.DB;

public partial class mobile_saas : System.Web.UI.Page
{

    protected Tiantu.DB.Model.AboutUs pageModel = DBHelper.GetAboutUs(1);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}