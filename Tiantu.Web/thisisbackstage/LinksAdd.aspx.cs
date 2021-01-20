using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class webadmin_LinksAdd : System.Web.UI.Page
{
    Tiantu.DB.DAL.Links dalLinks = new Tiantu.DB.DAL.Links();
    protected int linkid = SL.GetQueryIntValue("linkid");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.linkid = SL.GetQueryIntValue("linkid");
            ShowInfo(this.linkid);
        }
    }

    private void ShowInfo(int linkid)
    {
        Tiantu.DB.Model.Links model = dalLinks.GetModel(linkid);
        if (model != null)
        {
            this.hfLINKID.Value = model.LINKID.ToString();
            this.txtTitle.Text = model.TITLE;
            this.txtTitle_en.Text = model.TITLE_EN;
            this.txtLinkURL.Text = model.LINKURL;
            this.txtVideoURL.Text = model.VIDEOURL;

            //this.hfImgurl.Value = model.IMGURL;
            this.txtImgurl.Text = model.IMGURL;
            if (SL.IsImageExt(model.IMGURL))
            {
                this.lblImgurl.Text = string.Format("<a href='{0}' target='_blank'>{1}</a>", model.IMGURL, SL.OutImage(model.IMGURL, 190, 100));
            }
        }
    }


    //保存
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int linkid = Convert.ToInt32(this.hfLINKID.Value);
        string title = this.txtTitle.Text;
        string title_en = this.txtTitle_en.Text;
        string linkurl = this.txtLinkURL.Text;
        string videourl = this.txtVideoURL.Text;
        string imgurl = this.txtImgurl.Text;
        imgurl = WebControlsHelper.FileUploadImage(this.FileUpload1, "link", imgurl);

        Tiantu.DB.Model.Links model = dalLinks.GetModel(linkid);
        model = (model == null ? new Tiantu.DB.Model.Links() : model);

        model.LINKID = linkid;
        model.IMGURL = imgurl;
        model.TITLE = title;
        model.TITLE_EN = title_en;
        model.LINKURL = linkurl;
        model.VIDEOURL = videourl;

        if (linkid > 0)
        {
            dalLinks.Update(model);
        }

        SL.Show(this.Page, "保存成功!", "LinksList.aspx");
    }
}