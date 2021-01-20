using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;
using Tinatu.DB;

public partial class webadmin_ReportAdd : System.Web.UI.Page
{

    Tiantu.DB.DAL.Reports dalReports = new Tiantu.DB.DAL.Reports();
    protected int reportid = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.reportid = SL.GetQueryIntValue("reportid");
            var catelist = DBHelper.GetReportCateList();
            foreach (var item in catelist)
            {
                ddlCateid.Items.Add(new ListItem(item.CATENAME, item.CATEID.ToString()));
            }
             
            ShowInfo(this.reportid);
        }
    }


    private void ShowInfo(int reportid)
    {
        Tiantu.DB.Model.Reports model = dalReports.GetModel(reportid);
        if (model != null)
        {
            this.hfReportid.Value = model.REPORTID.ToString();
            this.txtTitle.Text = model.TITLE;
            SL.SetControlValue(ddlCateid, model.CATEID);
            this.txtSortid.Text = model.SORTID.ToString();
            this.txtPubdate.Text = model.PUBDATE.ToString("yyyy-MM-dd");
            this.hfPDFURL.Value = model.PDFURL;
            this.lblPDF.Text = model.PDFURL;
            this.hfPDFURL_EN.Value = model.PDFURL_EN;
            this.lblPDF_EN.Text = model.PDFURL_EN;

            this.hfImgurl.Value = model.IMGURL;
            if (SL.IsImageExt(model.IMGURL))
            {
                this.lblImgurl.Text = string.Format("<a href='{0}' target='_blank'>{1}</a>", model.IMGURL, SL.OutImage(model.IMGURL, 130, 175));
            }
        }
        else
        {
            this.txtPubdate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            var total = dalReports.GetRecordCount("");
            this.txtSortid.Text = String.Format("{0}", total + 1);
        }
    }


    //保存
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int reportid = Convert.ToInt32(this.hfReportid.Value);
        string title = this.txtTitle.Text;
        int cateid = Convert.ToInt32(this.ddlCateid.SelectedValue);
        int sortid = Convert.ToInt32(this.txtSortid.Text);
        string pdfurl = this.hfPDFURL.Value;
        string pdfurl_en = this.hfPDFURL_EN.Value;
        string imgurl = this.hfImgurl.Value;
        DateTime pubdate = Convert.ToDateTime(this.txtPubdate.Text);
        imgurl = WebControlsHelper.FileUploadImage(this.FileUpload1, "report", imgurl);

        pdfurl = WebControlsHelper.FileUpload(this.fieluploadPDF, "pdf", pdfurl, "定期报告_" + System.DateTime.Now.ToString("yyyyMMddHHmmssffff"));
        pdfurl_en = WebControlsHelper.FileUpload(this.fieluploadPDF_EN, "pdf", pdfurl_en, "定期报告_e" + System.DateTime.Now.ToString("yyyyMMddHHmmssffff"));

        Tiantu.DB.Model.Reports model = dalReports.GetModel(reportid);
        model = (model == null ? new Tiantu.DB.Model.Reports() : model);
        model.REPORTID = reportid;
        model.CATEID = cateid;
        model.TITLE = title;
        model.PDFURL = pdfurl;
        model.PDFURL_EN = pdfurl_en;
        model.IMGURL = imgurl;
        model.IMGURL_EN = "";
        model.PUBDATE = pubdate;
        model.SORTID = sortid;

        if (reportid > 0)
        {
            dalReports.Update(model);
        }
        else
        {
            dalReports.Add(model);
        }

        SL.Show(this.Page, "保存成功!", "ReportList.aspx");
    }
}