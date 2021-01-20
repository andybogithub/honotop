using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class webadmin_CasesAdd : System.Web.UI.Page
{

    Tiantu.DB.DAL.Cases dalCases = new Tiantu.DB.DAL.Cases();
    protected int caseid = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.caseid = SL.GetQueryIntValue("caseid");
            ShowInfo(this.caseid);
        }
    }


    private void ShowInfo(int caseid)
    {
        Tiantu.DB.Model.Cases model = dalCases.GetModel(caseid);
        if (model != null)
        {
            this.hfCaseid.Value = model.CASEID.ToString();
            this.txtNotes.Text = model.NOTES;
            this.txtNotes_en.Text = model.NOTES_EN;
            this.txtSortid.Text = model.SORTID.ToString();

            this.hfImgurl.Value = model.IMGURL;
            if (SL.IsImageExt(model.IMGURL))
            {
                this.lblImgurl.Text = string.Format("<a href='{0}' target='_blank'>{1}</a>", model.IMGURL, SL.OutImage(model.IMGURL, 260, 200));
            }
        }
        else
        {
            this.txtSortid.Text = "0";
        }
    }


    //保存
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int caseid = Convert.ToInt32(this.hfCaseid.Value);
        string notes = this.txtNotes.Text;
        string notes_en = this.txtNotes_en.Text;
        int sortid = Convert.ToInt32(this.txtSortid.Text);

        string imgurl = this.hfImgurl.Value;
        imgurl = WebControlsHelper.FileUploadImage(this.FileUpload1, "cases", imgurl);

        Tiantu.DB.Model.Cases model = dalCases.GetModel(caseid);
        model = (model == null ? new Tiantu.DB.Model.Cases() : model);
        model.CASEID = caseid;
        model.NOTES = notes;
        model.NOTES_EN = notes_en;
        model.IMGURL = imgurl;
        model.SORTID = sortid;


        if (caseid > 0)
        {
            dalCases.Update(model);
        }
        else
        {
            dalCases.Add(model);
        }
        SL.Show(this.Page, "保存成功!", "CasesList.aspx");
    }
}