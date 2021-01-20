using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Tiantu.DB.Model;

public partial class _shop_web__account_Top : System.Web.UI.UserControl
{
    public string UserNickName = "";
    public string UserIcon = "";
    public string UserTel = "";


    Tiantu.DB.DAL.Users dalUser = new Tiantu.DB.DAL.Users();

    Tiantu.DB.DAL.ShopStore dalShopStore = new Tiantu.DB.DAL.ShopStore();


    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        //会员登录认证
        int userId = dalUser.GetUserIdFromCookie();
        if (userId == 0)
        {
            Response.Redirect("/");
        }
        else if (!dalUser.Exists(userId))
        {
            Response.Redirect("/");
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        int userId = dalUser.GetUserIdFromCookie();
        Users user = dalUser.GetModel(userId);
        UserNickName = user.USERNAME;
        UserIcon = user.IMGURL.IsEmpty("/style/images/proImg_2.jpg");
        UserTel = user.USERTEL;
    }


}