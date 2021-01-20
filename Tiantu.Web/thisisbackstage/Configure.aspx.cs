using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class webadmin_Configure : System.Web.UI.Page
{
    Tiantu.DB.DAL.Setting dalSetting = new Tiantu.DB.DAL.Setting();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.txtCopyright.Text = dalSetting.GetValue(Tiantu.DB.DAL.Setting.key_copyright);
            this.txtCopyright_en.Text = dalSetting.GetValue(Tiantu.DB.DAL.Setting.key_copyright_en);

            string logourl = dalSetting.GetValue(Tiantu.DB.DAL.Setting.key_logo);
            this.hfLogo.Value = logourl;
            this.lblLogo.Text = string.Format("<img src='{0}' style='width:200px;'/>", logourl); ;
        }
    }

    //保存
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        dalSetting.SetValue(Tiantu.DB.DAL.Setting.key_copyright, this.txtCopyright.Text);
        dalSetting.SetValue(Tiantu.DB.DAL.Setting.key_copyright_en, this.txtCopyright_en.Text);

        string logourl = this.hfLogo.Value;
        logourl = WebControlsHelper.FileUpload(this.fieluploadLogo, "image", logourl);
        dalSetting.SetValue(Tiantu.DB.DAL.Setting.key_logo, logourl);

        Response.Redirect("Configure.aspx");


    }
}