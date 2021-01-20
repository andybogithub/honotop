using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _shop_admin_Share : System.Web.UI.MasterPage
{
    Tiantu.DB.DAL.Admins dalAdmins = new Tiantu.DB.DAL.Admins();

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);


        #region 登录验证
        if (!dalAdmins.IsLogin())
        {
            Response.Redirect("~/_shop_admin/login.aspx");
        }
        #endregion
    }

    protected void Page_Load(object sender, EventArgs e)
    {
         
    }
}
