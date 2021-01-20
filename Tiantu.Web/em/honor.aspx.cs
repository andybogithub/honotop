using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class em_honor : System.Web.UI.Page
{
    Tiantu.DB.DAL.Honors dalHonors = new Tiantu.DB.DAL.Honors();

    protected void Page_Load(object sender, EventArgs e)
    {
        var photoList = dalHonors.GetList(0, "", "SORTID DESC");
        string strList = "";

        foreach (var item in photoList)
        {
            //<li><a href="#"><img src="style/images/honor_1.jpg"  ><p>2016食品物流会员单位</p></a></li>
            strList += string.Format(@"<li><img src = '{0}' /><p></p></li>", item.SMIMGURL);


        }
        this.lblPhotoList.Text = strList;

    }
}