using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class em_reportde : System.Web.UI.Page
{
    Tiantu.DB.DAL.Reports dalReports = new Tiantu.DB.DAL.Reports();

    protected int reportid = SL.GetQueryIntValue("id");
    protected Tiantu.DB.Model.Reports pageModel = null;

    protected void Page_Load(object sender, EventArgs e)
    {

        this.pageModel = dalReports.GetModel(reportid);
        this.pageModel = (this.pageModel == null) ? new Tiantu.DB.Model.Reports() : this.pageModel;
        int cateid = this.pageModel.CATEID;


    }
}