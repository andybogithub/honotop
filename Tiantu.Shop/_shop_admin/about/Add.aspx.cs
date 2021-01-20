using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;
using Tiantu.DB.Model;

public partial class _shop_admin_about_Add : System.Web.UI.Page
{
    Tiantu.DB.DAL.ShopStore dalShopStore = new Tiantu.DB.DAL.ShopStore();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int AboutId = SL.GetQueryInt("aboutid");
            if (AboutId > 0)
            {
                ShopAbouts model = dalShopStore.GetAboutModel(AboutId);
                if (model != null)
                {
                    this.hfAboutId.Value = model.AboutId.ToString();
                    this.lblTitle.Text = model.Title;
                    this.txtDetails.Text = model.Details;
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int AboutId = Convert.ToInt32(this.hfAboutId.Value);
        string Title = this.lblTitle.Text;
        string Details = this.txtDetails.Text;

        try
        {
            dalShopStore.AddOrUpdateAbout(AboutId, Details);
            SL.Show(this.Page, "保存成功", string.Format("add.aspx?aboutid={0}", AboutId));
        }
        catch (Exception)
        {

            throw;
        }

    }
}