using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mobile_transport : System.Web.UI.Page
{
    Tiantu.DB.DAL.Photos dalPhotos = new Tiantu.DB.DAL.Photos();

    protected void Page_Load(object sender, EventArgs e)
    {
        var list = dalPhotos.GetList(0, "", "SORTID DESC");
        var list1 = list.Where(p => p.CATEID == 7).ToList();
        if (list1.Count > 0)
        {
            this.lblPic1.Text = string.Format("<img src='{0}' width='140' height='90'/>", list1.First().IMGURL);
        }

        var list2 = list.Where(p => p.CATEID == 8).ToList();
        if (list2.Count > 0)
        {
            this.lblPic2.Text = string.Format("<img src='{0}' width='140' height='90'/>", list2.First().IMGURL);
        }

        var list3 = list.Where(p => p.CATEID == 9).ToList();
        if (list3.Count > 0)
        {
            this.lblPic3.Text = string.Format("<img src='{0}' width='140' height='90'/>", list3.First().IMGURL);
        }

    }
}