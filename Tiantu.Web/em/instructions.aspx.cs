using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class em_instructions : System.Web.UI.Page
{
    protected static Tiantu.DB.DAL.Setting dalSetting = new Tiantu.DB.DAL.Setting();
    protected string instructions_pdf = dalSetting.GetValue(Tiantu.DB.DAL.Setting.key_instructions_pdf_en);


    protected void Page_Load(object sender, EventArgs e)
    {

    }
}