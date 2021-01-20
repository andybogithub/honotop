using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class webadmin_Instructions : System.Web.UI.Page
{
    Tiantu.DB.DAL.Setting dalSetting = new Tiantu.DB.DAL.Setting();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.txtInstructionsNote.Text = dalSetting.GetValue(Tiantu.DB.DAL.Setting.key_instructions_note);
            this.txtInstructionsNoteEn.Text = dalSetting.GetValue(Tiantu.DB.DAL.Setting.key_instructions_note_en);



            string pdfurl = dalSetting.GetValue(Tiantu.DB.DAL.Setting.key_instructions_pdf);
            this.hfPDFURL.Value = pdfurl;
            this.lblPDF.Text = pdfurl.Length > 0 ? "已上传" : "未上传";

            string pdfurl_en = dalSetting.GetValue(Tiantu.DB.DAL.Setting.key_instructions_pdf_en);
            this.hfPDFURL_EN.Value = pdfurl_en;
            this.lblPDF_EN.Text = pdfurl_en.Length > 0 ? "已上传" : "未上传";

        }
    }

    //保存
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        dalSetting.SetValue(Tiantu.DB.DAL.Setting.key_instructions_note, this.txtInstructionsNote.Text);
        dalSetting.SetValue(Tiantu.DB.DAL.Setting.key_instructions_note_en, this.txtInstructionsNoteEn.Text);

        //
        string pdfurl = this.hfPDFURL.Value;
        pdfurl = WebControlsHelper.FileUpload(this.fuPDF, "pdf", pdfurl, "招股说明书" + System.DateTime.Now.ToString("yyyyMMdd"));
        dalSetting.SetValue(Tiantu.DB.DAL.Setting.key_instructions_pdf, pdfurl);
        //
        string pdfurl_en = this.hfPDFURL_EN.Value;
        pdfurl_en = WebControlsHelper.FileUpload(this.fuPDF_EN, "pdf", pdfurl_en, "prospectus_" + System.DateTime.Now.ToString("yyyyMMdd"));
        dalSetting.SetValue(Tiantu.DB.DAL.Setting.key_instructions_pdf_en, pdfurl_en);

        Response.Redirect("Instructions.aspx");


    }
}