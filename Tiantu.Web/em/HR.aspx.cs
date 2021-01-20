using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tinatu.DB;

public partial class em_HR : System.Web.UI.Page
{


    protected Tiantu.DB.Model.AboutUs pageModel = DBHelper.GetAboutUs(2);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}