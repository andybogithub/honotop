using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class em_companyde : System.Web.UI.Page
{
    Tiantu.DB.DAL.Notices dalNotices = new Tiantu.DB.DAL.Notices();

    protected int noticeid = SL.GetQueryIntValue("id");
    protected Tiantu.DB.Model.Notices pageModel = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.pageModel = dalNotices.GetModel(noticeid);
        this.pageModel = (this.pageModel == null) ? new Tiantu.DB.Model.Notices() : this.pageModel;
    }

}