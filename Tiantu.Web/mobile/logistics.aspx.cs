using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mobile_logistics : System.Web.UI.Page
{
    Tiantu.DB.DAL.Photos dalPhotos = new Tiantu.DB.DAL.Photos();

    protected void Page_Load(object sender, EventArgs e)
    {
        var list1 = dalPhotos.GetList(1, "CATEID=1", "SORTID DESC");
        if (list1 != null)
        {
            this.RepeaterList1.DataSource = list1;
            this.RepeaterList1.DataBind();
        }

        var list2 = dalPhotos.GetList(1, "CATEID=2", "SORTID DESC");
        if (list2 != null)
        {
            this.RepeaterList2.DataSource = list2;
            this.RepeaterList2.DataBind();
        }

        var list3 = dalPhotos.GetList(1, "CATEID=3", "SORTID DESC");
        if (list3 != null)
        {
            this.RepeaterList3.DataSource = list3;
            this.RepeaterList3.DataBind();
        }
    }


}