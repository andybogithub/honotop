using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _shop_web_Recharge : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    Tiantu.DB.DAL.ShopStore dalShopStore = new Tiantu.DB.DAL.ShopStore();
    protected void btnRecharge_Click(object sender, EventArgs e)
    {

        Tiantu.DB.DAL.Users dalUser = new Tiantu.DB.DAL.Users();
        string code = txtCode.Text;

        int userId = dalUser.GetUserIdFromCookie();
        if (code.Equals("ABCDEFG"))
        {


            if (userId > 0)
            {
                dalShopStore.AddUserPoint(new Tiantu.DB.Model.UserPoints()
                {
                    POINTID = 0,
                    MODELNO = 1,
                    USERID = userId,
                    EMPLID = 0,
                    POINTS = 100,
                    OPERTYPE = 1,
                    OPERID = 0,
                    PUBDATE = DateTime.Now
                });
            }

            Response.Write("<script>alert('充值成功');</script>");
        }
        else
        {
            Response.Write("<script>alert('充值卡号错误！');</script>");
        }
    }
}