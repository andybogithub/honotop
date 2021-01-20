using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;
using Tinatu.DB;

public partial class em_money : System.Web.UI.Page
{
    Tiantu.DB.DAL.Photos dalPhotos = new Tiantu.DB.DAL.Photos();   
    protected int caseid = SL.GetQueryIntValue("ca");
    protected Tiantu.DB.Model.AboutUs pageModel = DBHelper.GetAboutUs(11);

    protected void Page_Load(object sender, EventArgs e)
    {
        caseid = caseid == 0 ? 4 : caseid;
        var list = dalPhotos.GetList(0, "", "SORTID DESC");
        var list1 = list.Where(p => p.CATEID == caseid).ToList();
        if (list1 != null)
        {
            this.RepeaterList.DataSource = list1;
            this.RepeaterList.DataBind();
        }
    }

}