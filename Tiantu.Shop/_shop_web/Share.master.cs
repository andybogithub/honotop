using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Model;

public partial class _shop_web_Share : System.Web.UI.MasterPage
{
    Tiantu.DB.DAL.Users dalUsers = new Tiantu.DB.DAL.Users();

    protected void Page_Load(object sender, EventArgs e)
    {

    }


    /// <summary>
    /// 获取会员对象
    /// </summary>
    public Users user
    {
        get
        {
            Users model = new Users();
            int userId = dalUsers.GetUserIdFromCookie();
            if (userId > 0)
            {
                model = dalUsers.GetModel(userId);
            }
            return model;
        }
    }

    /// <summary>
    /// 会员编号
    /// </summary>
    public int UserId
    {
        get
        {
            int userId = dalUsers.GetUserIdFromCookie();
            return userId;
        }
    }



}
