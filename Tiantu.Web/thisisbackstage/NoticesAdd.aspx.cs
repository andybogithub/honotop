using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class webadmin_NoticesAdd : System.Web.UI.Page
{

    Tiantu.DB.DAL.Notices dalNotices = new Tiantu.DB.DAL.Notices();
    protected int noticeid = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.noticeid = SL.GetQueryIntValue("noticeid");
            ShowInfo(this.noticeid);
        }
    }


    private void ShowInfo(int newsid)
    {
        Tiantu.DB.Model.Notices model = dalNotices.GetModel(newsid);
        if (model != null)
        {
            this.hfNOTICEID.Value = model.NOTICEID.ToString();
            this.hfSORTID.Value = model.SORTID.ToString();
            this.txtTitle.Text = model.TITLE;
            this.txtSubtitle.Text = model.SUBTITLE;
            this.txtTitle_en.Text = model.TITLE_EN;
            this.txtSubtitle_en.Text = model.SUBTITLE_EN;

            this.txtSortid.Text = model.SORTID.ToString();
            this.txtPubdate.Text = model.PUBDATE.ToString("yyyy-MM-dd");
            this.hfPDFURL.Value = model.PDFURL;
            this.lblPDF.Text = model.PDFURL;
            this.hfPDFURL_EN.Value = model.PDFURL_EN;
            this.lblPDF_EN.Text = model.PDFURL_EN;

        }
        else
        {
            this.txtPubdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.txtSortid.Text = "0";
        }
    }


    //保存
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        bool isFilter = false;
        bool isExistFilter = false;

        //
        Tiantu.DB.DAL.Setting dalSetting = new Tiantu.DB.DAL.Setting();
        string filterWordsContent = dalSetting.GetValue(Tiantu.DB.DAL.Setting.key_filterword);


        //
        int noticeid = Convert.ToInt32(this.hfNOTICEID.Value);

        string title = SL.FilterQueryValue(out isFilter, txtTitle.Text, false, filterWordsContent);
        isExistFilter = isExistFilter || isFilter;

        string subtitle = SL.FilterQueryValue(out isFilter, txtSubtitle.Text, false, filterWordsContent);
        isExistFilter = isExistFilter || isFilter;

        string contents = "";

        string title_en = SL.FilterQueryValue(out isFilter, txtTitle_en.Text, false, filterWordsContent);
        isExistFilter = isExistFilter || isFilter;

        string subtitle_en = SL.FilterQueryValue(out isFilter, txtSubtitle_en.Text, false, filterWordsContent);
        isExistFilter = isExistFilter || isFilter;

        string contents_en = "";

        int sortid = Convert.ToInt32(this.txtSortid.Text);
        DateTime pubdate = Convert.ToDateTime(this.txtPubdate.Text);

        string pdfurl = this.hfPDFURL.Value;
        string pdfurl_en = this.hfPDFURL_EN.Value;


        pdfurl = WebControlsHelper.FileUpload(this.fieluploadPDF, "pdf", pdfurl, "公司公告_" + System.DateTime.Now.ToString("yyyyMMddHHmmssffff"));
        pdfurl_en = WebControlsHelper.FileUpload(this.fieluploadPDF_EN, "pdf", pdfurl_en, "公司公告_e" + System.DateTime.Now.ToString("yyyyMMddHHmmssffff"));

        title_en = string.IsNullOrWhiteSpace(title_en) ? title : title_en;
        subtitle_en = string.IsNullOrWhiteSpace(subtitle_en) ? subtitle : subtitle_en;
        contents_en = string.IsNullOrWhiteSpace(contents_en) ? contents : contents_en;


        Tiantu.DB.Model.Notices model = dalNotices.GetModel(noticeid);
        model = (model == null ? new Tiantu.DB.Model.Notices() : model);

        model.NOTICEID = noticeid;
        model.TITLE = title;
        model.SUBTITLE = subtitle;
        model.CONTENTS = contents;
        model.TITLE_EN = title_en;
        model.SUBTITLE_EN = subtitle_en;
        model.CONTENTS_EN = contents_en;
        model.PDFURL = pdfurl;
        model.PDFURL_EN = pdfurl_en;
        model.SORTID = sortid;
        model.PUBDATE = pubdate;

        if (noticeid > 0)
        {
            dalNotices.Update(model);
        }
        else
        {
            dalNotices.Add(model);
        }

        if (isExistFilter)
        {
            SL.Show(this.Page, "保存成功，内容存在敏感词，已经过滤!", "NoticesList.aspx");
        }
        else
        {

            SL.Show(this.Page, "保存成功!", "NoticesList.aspx");
        }
    }

}