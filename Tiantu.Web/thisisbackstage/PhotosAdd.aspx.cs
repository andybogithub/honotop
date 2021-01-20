using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class webadmin_PhotosAdd : System.Web.UI.Page
{
    Tiantu.DB.DAL.Photos dalPhotos = new Tiantu.DB.DAL.Photos();
    protected int photoid = SL.GetQueryIntValue("photoid");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.photoid = SL.GetQueryIntValue("photoid");
            ShowInfo(this.photoid);
        }
    }


    private void ShowInfo(int photoid)
    {
        Tiantu.DB.Model.Photos model = dalPhotos.GetModel(photoid);
        if (model != null)
        {
            this.hfPhotoid.Value = model.PHOTOID.ToString();
            this.txtSortid.Text = model.SORTID.ToString();
            SL.SetControlValue(ddlCateid, model.CATEID);
            this.hfImgurl.Value = model.IMGURL;
            if (SL.IsImageExt(model.IMGURL))
            {
                this.lblImgurl.Text = string.Format("<a href='{0}' target='_blank'>{1}</a>", model.IMGURL, SL.OutImage(model.IMGURL, 130, 155));
            }
        }
        else
        {
            int cateid = SL.GetQueryIntValue("cateid");
            SL.SetControlValue(ddlCateid, cateid);
            this.txtSortid.Text = "0";
        }
    }


    //保存
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int photoid = Convert.ToInt32(this.hfPhotoid.Value);
        int cateid = Convert.ToInt32(this.ddlCateid.SelectedValue);
        int sortid = Convert.ToInt32(this.txtSortid.Text);
        string thumbnail = "";
        string imgurl = this.hfImgurl.Value;
        imgurl = WebControlsHelper.FileUploadImage(this.FileUpload1, "photos", imgurl);

        Tiantu.DB.Model.Photos model = dalPhotos.GetModel(photoid);
        model = (model == null ? new Tiantu.DB.Model.Photos() : model);
        model.PHOTOID = photoid;
        model.CATEID = cateid;
        model.IMGURL = imgurl;
        model.THUMBNAIL = thumbnail;
        model.SORTID = sortid;

        if (photoid > 0)
        {
            dalPhotos.Update(model);
        }
        else
        {
            dalPhotos.Add(model);
        }
        //SL.Show(this.Page, "保存成功!", "PhotosList.aspx?cateid=" + cateid);
        Response.Redirect("PhotosList.aspx?cateid=" + cateid);


    }
}