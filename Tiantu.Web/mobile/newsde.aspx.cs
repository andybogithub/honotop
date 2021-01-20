using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class mobile_newsde : System.Web.UI.Page
{
    Tiantu.DB.DAL.News dalNews = new Tiantu.DB.DAL.News();

    protected int newsid = SL.GetQueryIntValue("no");
    protected Tiantu.DB.Model.News pageModel = null;

    protected void Page_Load(object sender, EventArgs e)
    {

        this.pageModel = dalNews.GetModel(newsid);
        this.pageModel = (this.pageModel == null) ? new Tiantu.DB.Model.News() : this.pageModel;

    }
}