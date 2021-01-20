using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;
using Tiantu.DB.Model;

public partial class _shop_admin_news_Add : System.Web.UI.Page
{
    Tiantu.DB.DAL.ShopStore dalShopStore = new Tiantu.DB.DAL.ShopStore();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int newsId = SL.GetQueryInt("newsid");

            if (newsId > 0)
            {
                ShowInfo(newsId);
            }
        }
    }


    /// <summary>
    /// 显示
    /// </summary>
    /// <param name="newsId"></param>
    private void ShowInfo(int newsId)
    {
        ShopNews model = dalShopStore.GetShopNewsModel(newsId);
        if (model != null)
        {
            this.hfNewsId.Value = model.NewsId.ToString();
            this.txtNewsTitle.Text = model.NewsTitle;
            this.txtNewsBody.Text = model.NewsBody;

            this.lblPageAction.Text = "修改";
            this.btnDelete.Visible = true;
        }
    }

    /// <summary>
    /// 保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string strErr = "";
        if (this.txtNewsTitle.Text.Trim().Length == 0)
        {
            strErr += "标题不能为空！\\n";
        }
        if (this.txtNewsBody.Text.Trim().Length == 0)
        {
            strErr += "内容不能为空！\\n";
        }


        if (strErr != "")
        {
            SL.Show(this, strErr);
            return;
        }

        try
        {
            int NewsId = int.Parse(this.hfNewsId.Value);
            string NewsTitle = this.txtNewsTitle.Text;
            string NewsBody = this.txtNewsBody.Text;
            int ClazzId = ShopStoreConfig.CLASS_NEWS;

            ShopNews model = new ShopNews();
            model.NewsId = NewsId;
            model.NewsTitle = NewsTitle;
            model.NewsBody = NewsBody;
            model.ClazzId = ClazzId;

            dalShopStore.AddOrUpdateShopNews(model);

            Response.Redirect("list.aspx");
        }
        catch (Exception ex)
        {
            SL.Show(this.Page, ex.Message);
        }
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int NewsId = int.Parse(this.hfNewsId.Value);

        dalShopStore.DeleteShopNews(NewsId);

        Response.Redirect("list.aspx");
    }
}