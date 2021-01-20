using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class honor : System.Web.UI.Page
{
    Tiantu.DB.DAL.Honors dalHonors = new Tiantu.DB.DAL.Honors();

    protected void Page_Load(object sender, EventArgs e)
    {
        var photoList = dalHonors.GetList(0, "", "SORTID DESC");
        string strList = "<ul>";
        int count = 0;

        foreach (var item in photoList)
        {
            count++;
            if (count % 12 == 1 && count != 1)
            {
                strList += "</ul><ul>";
            }
            strList += string.Format(@"<li>
                                         <a class='image-zoom' href='{0}' rel='prettyPhoto[gallery]'>
                                            <img src = '{1}' width='200' height='150' />
                                         </a>
                                      </li>", item.IMGURL, item.SMIMGURL);
        }

        strList += "</ul>";
        this.lblPhotoList.Text = strList;

    }
}