using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class _shop_admin_game_Add : System.Web.UI.Page
{
    Tiantu.DB.DAL.ShopStore dalShopStore = new Tiantu.DB.DAL.ShopStore();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int gameId = SL.GetQueryInt("gameid",true);
            if (gameId>0)
            {
                ShowInfo(gameId);
            }
        }
    }

    private void ShowInfo(int gameId)
    {
        Tiantu.DB.Model.ShopGames model = dalShopStore.GetShopGameModel(gameId);
        if (model!=null)
        {
            this.hfGameId.Value = model.GameId.ToString();
            this.txtGameName.Text = model.GameName;
            this.txtLinkUrl.Text = model.LinkUrl;
            this.hfImageUrl.Value = model.ImageUrl;

            this.lblImageUrl.Text = string.Format("<img src='{0}' width='100'/>", model.ImageUrl);
            this.lblAction.Text = "修改";
            this.btnDelete.Visible = true;
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int GameId = int.Parse(this.hfGameId.Value);
        string GameName = this.txtGameName.Text;
        string LinkUrl = this.txtLinkUrl.Text;
        string ImageUrl = this.hfImageUrl.Value;
        try
        {
            if (GameName.Length > 0)
            {


                ImageUrl = WebControlsHelper.FileUploadImage(this.FileUpload1, "shop", ImageUrl);





                dalShopStore.AddOrUpdateGames(GameId, GameName, ImageUrl, LinkUrl);

                Response.Redirect("list.aspx");
            }
            else
            {
                SL.Show(this.Page, "请输入游戏名称");
                return;
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int GameId = int.Parse(this.hfGameId.Value);
        dalShopStore.DeleteShopGame(GameId);
        Response.Redirect("list.aspx");
    }
}