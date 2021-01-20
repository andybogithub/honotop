using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class webadmin_AboutUsAdd : System.Web.UI.Page
{
    Tiantu.DB.DAL.AboutUs dalAboutUs = new Tiantu.DB.DAL.AboutUs();
    protected int abid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.abid = SL.GetQueryIntValue("abid");
            ShowInfo(this.abid);
        }
    }


    private void ShowInfo(int abid)
    {
        Tiantu.DB.Model.AboutUs model = dalAboutUs.GetModel(abid);
        if (model != null)
        {
            this.hfAboutid.Value = model.ABOUTID.ToString();
            this.txtTitle.Text = model.TITLE;
            this.txtContents.Text = model.CONTENTS;
            this.txtTitle_en.Text = model.TITLE_EN;
            this.txtContents_en.Text = model.CONTENTS_EN;
            this.hfSortid.Value = model.SORTID.ToString();
        }
    }



    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int aboutid = Convert.ToInt32(this.hfAboutid.Value);
        string title = this.txtTitle.Text;
        string contents = this.txtContents.Text;
        string title_en = this.txtTitle_en.Text;
        string contents_en = this.txtContents_en.Text;
        int sortid = Convert.ToInt32(this.hfSortid.Value);

        Tiantu.DB.Model.AboutUs model = dalAboutUs.GetModel(aboutid);
        model = (model == null ? new Tiantu.DB.Model.AboutUs() : model);

        model.ABOUTID = aboutid;
        model.TITLE = title;
        model.CONTENTS = contents;
        model.TITLE_EN = string.IsNullOrWhiteSpace(title_en) ? title : title_en;
        model.CONTENTS_EN = string.IsNullOrWhiteSpace(contents_en) ? contents : contents_en; ;
        model.SORTID = sortid;


        if (aboutid > 0)
        {
            dalAboutUs.Update(model);
        }
        else
        {
            dalAboutUs.Add(model);
        }
        //SL.Show(this.Page, "保存成功!", "AboutUsList.aspx");
        Response.Redirect("AboutUsAdd.aspx?abid=" + aboutid);
    }
}