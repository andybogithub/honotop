using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;
using Tiantu.DB.Model;
using Tinatu.DB;

public partial class _shop_admin_banner_Add : System.Web.UI.Page
{
    Tiantu.DB.DAL.Banners dalBanner = new Tiantu.DB.DAL.Banners();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            int bnId = SL.GetQueryInt("bnid", true);

            if (bnId > 0)
            {
                ShowInfo(bnId);
            }
        }
        catch
        {

        }
    }

    private void ShowInfo(int bnId)
    {
        Banners model = dalBanner.GetModel(bnId);
        if (model!=null)
        {
            this.hfbnId.Value = SL.DESEncrypt(bnId.ToString());
            this.txtLinkUrl.Text = model.LINKURL;
            this.hfimgurl.Value = model.IMGURL;
            if (!string.IsNullOrEmpty(model.IMGURL))
            {
                this.lblimgIcon.Text = string.Format("<a href='{0}' target='_blank'><img src='{0}' height='200'/></a>", SL.GetHttpImageURL(model.IMGURL));
            }
        }
    }


    /// <summary>
    /// 保存广告
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        HideError();

        int bnId = string.IsNullOrEmpty(this.hfbnId.Value) ? 0 : Convert.ToInt32(SL.DESDecrypt(this.hfbnId.Value));
        string linkUrl = this.txtLinkUrl.Text;
        string imgUrl = this.hfimgurl.Value;
        

        string errStr = "";
        if (!this.FileUpload1.HasFile && string.IsNullOrEmpty(imgUrl))
        {
            errStr = "您还没有上传广告图片";
        }
        else if (!SL.IsImageExt(this.FileUpload1.FileName))
        {
            errStr = "上传的广告图片格式不正确，只能为 *.jpg|*.gif|*.png";
        }

        if (errStr.Length > 0)
        {
            ShowError(errStr);
        }
        else
        {



            imgUrl = WebControlsHelper.FileUploadImage(this.FileUpload1, "banner", imgUrl);


            try
            {
                Banners model = new Banners();
                model.BNID = bnId;
                model.LINKURL = linkUrl;
                model.IMGURL = imgUrl;
                model.WEBID = DBHelper.WEBID_SHOP;
                model.TYPE = "商城首页";
                model.TITLE = "";
                model.SORTID = 0;
                model.MOBILE_LINKURL = "";

                dalBanner.Add(model);

                Response.Redirect("list.aspx");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
    }


    #region 私有方法
    private void ShowError(string errStr)
    {
        this.lblError.Text = errStr;
        this.PanelError.Visible = true;
    }
    private void HideError()
    {
        this.lblError.Text = "";
        this.PanelError.Visible = false;
    }
    #endregion
}