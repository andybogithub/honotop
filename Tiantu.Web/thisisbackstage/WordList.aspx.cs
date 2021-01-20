using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class thisisbackstage_WordList : System.Web.UI.Page
{
    Tiantu.DB.DAL.Setting dalSetting = new Tiantu.DB.DAL.Setting();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.txtFilterWord.Text = dalSetting.GetValue(Tiantu.DB.DAL.Setting.key_filterword);
     
        }
    }

    //保存
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        dalSetting.SetValue(Tiantu.DB.DAL.Setting.key_filterword, this.txtFilterWord.Text);
     

        Response.Redirect("WordList.aspx");


    }
}