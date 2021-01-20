using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class webadmin_Honors : System.Web.UI.Page
{

    Tiantu.DB.DAL.Honors dalHonors = new Tiantu.DB.DAL.Honors();

    protected void Page_Load(object sender, EventArgs e)
    {

        #region Banners
        string strWhere = "1=1";



        #region 分页
        int pageIndex = SL.GetQueryIntValue("pageid");
        int recordCount = dalHonors.GetRecordCount(strWhere);
        int startIndex = 0;
        int endIndex = 0;
        string strPager = SL.GetPagerNavigator(pageIndex, recordCount, "", 3, "/webadmin/Honors.aspx", out startIndex, out endIndex);
        this.lblPagination.Text = strPager;
        #endregion

        var list = dalHonors.GetListByPage(strWhere, "SORTID DESC, HONORID DESC", startIndex, endIndex);
        if (list != null)
        {
            this.RepeaterStores.DataSource = list;
            this.RepeaterStores.DataBind();
        }
        #endregion


    }

    protected void RepeaterStores_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        int relid = Convert.ToInt32(e.CommandArgument);
        if ("delete".Equals(e.CommandName))
        {
            Tiantu.DB.Model.Honors model = dalHonors.GetModel(relid);
            if (model != null)
            {
                //删除图片文件
                SL.TryDeleteImage(model.IMGURL);
            }
            dalHonors.Delete(relid);
            Response.Redirect("Honors.aspx");
        }
        else if ("head".Equals(e.CommandName))
        {
            dalHonors.SetMaxSortId(relid);
            Response.Redirect("Honors.aspx");
        }
        else if ("end".Equals(e.CommandName))
        {
            dalHonors.SetMinSortId(relid);
            Response.Redirect("Honors.aspx");
        }
    }

    protected string GetImg(object img)
    {
        string imgCont = "";
        if (img != null && img.ToString().Length > 0)
        {
            imgCont = string.Format("<img src='{0}' style='width:60px;height:60px;'/>", img.ToString());
        }
        else
        {
            imgCont = "无";
        }

        return imgCont;
    }

    //保存
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        if (this.FileUpload1.HasFile)
        {
            string imgurl = "";
            imgurl = WebControlsHelper.FileUploadImage(this.FileUpload1, "honors", imgurl);
            string smimgurl = string.Format("/upfile/{0}/SM{1}{2}", "honors", System.DateTime.Now.ToString("yyyyMMddHHmmssffff"), System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName));

            DateTime pubdate = DateTime.Now;
            if (!string.IsNullOrWhiteSpace(imgurl))
            {
                SL.ImageMakeThumbnail(Server.MapPath(imgurl), Server.MapPath(smimgurl), 200, 150, EUploadMode.HW);
                Tiantu.DB.Model.Honors model = new Tiantu.DB.Model.Honors();
                model.IMGURL = imgurl;
                model.SMIMGURL = smimgurl;
                dalHonors.Add(model);
                SL.Show(this.Page, "图片上传成功!", "Honors.aspx");
            }

            //SL.ImageCompression(imgurl, 40);
        }
        else
        {
            SL.Show(this.Page, "请选择图片后再按上传按钮!", "Honors.aspx");
        }

    }

}