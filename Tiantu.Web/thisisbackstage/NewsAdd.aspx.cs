using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;
using Tinatu.DB;

public partial class webadmin_NewsAdd : System.Web.UI.Page
{
    Tiantu.DB.DAL.News dalNews = new Tiantu.DB.DAL.News();
    protected int newsid = SL.GetQueryIntValue("newsid");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.newsid = SL.GetQueryIntValue("newsid");
            ShowInfo(this.newsid);
        }
    }

    protected void ddlCateid_SelectedIndexChanged(object sender, EventArgs e)
    {
        int cateid = Convert.ToInt32(ddlCateid.SelectedValue);

    }
    private void ShowInfo(int newsid)
    {
        Tiantu.DB.Model.News model = dalNews.GetModel(newsid);
        if (model != null)
        {
            this.hfNEWSID.Value = model.NEWSID.ToString();
            this.hfSORTID.Value = model.SORTID.ToString();
            this.txtTitle.Text = model.TITLE;
            this.txtSubtitle.Text = model.SUBTITLE;
            this.txtContents.Text = model.CONTENTS;
            this.txtTitle_en.Text = model.TITLE_EN;
            this.txtSubtitle_en.Text = model.SUBTITLE_EN;
            this.txtContents_en.Text = model.CONTENTS_EN;

            this.txtSortid.Text = model.SORTID.ToString();
            this.txtPubdate.Text = model.PUBDATE.ToString("yyyy-MM-dd");
            this.cbIsTop.Checked = model.ISTOP;
            SL.SetControlValue(ddlCateid, model.CATEID);

            this.hfImgurl.Value = model.IMGURL;
            if (SL.IsImageExt(model.IMGURL))
            {
                this.lblImgurl.Text = string.Format("<a href='{0}' target='_blank'>{1}</a>", model.IMGURL, SL.OutImage(model.IMGURL, 110, 140));
            }
        }
        else
        {
            int cateid = SL.GetQueryIntValue("cateid");
            SL.SetControlValue(ddlCateid, cateid);
            this.txtPubdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.txtSortid.Text = "0";
        }
    }


    //保存
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int newsid = Convert.ToInt32(this.hfNEWSID.Value);

        string pdfurl = "";
        string pdfurl_en = "";
        string imgurl = this.hfImgurl.Value;
        int cateid = Convert.ToInt32(this.ddlCateid.SelectedValue);
        int sortid = Convert.ToInt32(this.txtSortid.Text);
        bool istop = this.cbIsTop.Checked;
        DateTime pubdate = Convert.ToDateTime(this.txtPubdate.Text);
        imgurl = WebControlsHelper.FileUploadImage(this.FileUpload1, "news", imgurl);


        //
        Tiantu.DB.DAL.Setting dalSetting = new Tiantu.DB.DAL.Setting();
        string filterWordsContent = dalSetting.GetValue(Tiantu.DB.DAL.Setting.key_filterword);

        //
        bool isFilter = false;
        string title = SL.FilterQueryValue(out isFilter, txtTitle.Text, false, filterWordsContent);

        string subtitle = SL.FilterQueryValue(out isFilter, txtSubtitle.Text, false, filterWordsContent);
        string contents = SL.FilterQueryValue(out isFilter, txtContents.Text, false, filterWordsContent);
        string title_en = SL.FilterQueryValue(out isFilter, txtTitle_en.Text, false, filterWordsContent);
        string subtitle_en = SL.FilterQueryValue(out isFilter, txtSubtitle_en.Text, false, filterWordsContent);
        string contents_en = SL.FilterQueryValue(out isFilter, txtContents_en.Text, false, filterWordsContent);

        contents = this.txtContents.Text;
        contents_en = this.txtContents_en.Text;


        title_en = string.IsNullOrWhiteSpace(title_en) ? title : title_en;
        subtitle_en = string.IsNullOrWhiteSpace(subtitle_en) ? subtitle : subtitle_en;
        contents_en = string.IsNullOrWhiteSpace(contents_en) ? contents : contents_en;


        Tiantu.DB.Model.News model = dalNews.GetModel(newsid);
        model = (model == null ? new Tiantu.DB.Model.News() : model);


        model.NEWSID = newsid;
        model.CLZID = 3;
        model.CATEID = cateid;
        model.IMGURL = imgurl;
        model.TITLE = title;
        model.SUBTITLE = subtitle;
        model.CONTENTS = contents;
        model.TITLE_EN = title_en;
        model.SUBTITLE_EN = subtitle_en;
        model.CONTENTS_EN = contents_en;
        model.PDFURL = pdfurl;
        model.PDFURL_EN = pdfurl_en;
        model.ISTOP = istop;
        model.SORTID = sortid;
        model.PUBDATE = pubdate;


        if (newsid > 0)
        {
            dalNews.Update(model);
        }
        else
        {
            dalNews.Add(model);
        }
        SL.Show(this.Page, "保存成功!", "NewsList.aspx?cateid=" + cateid);
    }


}