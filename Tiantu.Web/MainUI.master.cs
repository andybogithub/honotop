using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MainUI : System.Web.UI.MasterPage
{


    protected static Tiantu.DB.DAL.Setting dalSetting = new Tiantu.DB.DAL.Setting();
    protected string logourl = dalSetting.GetValue(Tiantu.DB.DAL.Setting.key_logo);
    protected string copyright = dalSetting.GetValue(Tiantu.DB.DAL.Setting.key_copyright);
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Tiantu.DB.Common.SL.IsWXBrowser() || Tiantu.DB.Common.SL.IsMobile())
        {
            Response.Redirect("http://www.honotop.com/mobile/index.aspx");
        }
    }
}
