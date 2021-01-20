using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tinatu.DB;

public partial class en_Index : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {


        var list = DBHelper.GetTopNews();
        if (list != null)
        {
            this.RepeaterListNews.DataSource = list;
            this.RepeaterListNews.DataBind();
        }


    }
}