using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tinatu.DB;

public partial class en_money : System.Web.UI.Page
{

    Tiantu.DB.DAL.Photos dalPhotos = new Tiantu.DB.DAL.Photos();
    protected Tiantu.DB.Model.AboutUs pageModel = DBHelper.GetAboutUs(11);


    protected void Page_Load(object sender, EventArgs e)
    {
        var list = dalPhotos.GetList(0, "", "SORTID DESC");
        var list1 = list.Where(p => p.CATEID ==4).ToList();
        if (list1 != null)
        {
            this.RepeaterList1.DataSource = list1;
            this.RepeaterList1.DataBind();
        }

        var list2 = list.Where(p => p.CATEID == 5).ToList();
        if (list2 != null)
        {
            this.RepeaterList2.DataSource = list2;
            this.RepeaterList2.DataBind();
        }

        var list3 = list.Where(p => p.CATEID ==6).ToList();
        if (list3 != null)
        {
            this.RepeaterList3.DataSource = list3;
            this.RepeaterList3.DataBind();
        }
    }
}