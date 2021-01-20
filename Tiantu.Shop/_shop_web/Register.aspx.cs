using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;
using Tinatu.DB;

public partial class _shop_web_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btRegister_Click(object sender, EventArgs e)
    {



        string userTel = txtPhone.Text;
        string userpass = txtUserPass.Text;

        if (userTel.Length != 11)
        {
            Response.Write("<script>alert('电话号码错误');</script>");
        }
        else
        {
            DBHelper.dalUsers.Add(new Tiantu.DB.Model.Users()
            {
                USERID = 0,
                USERTEL = userTel,
                USERPASS = SL.EncryptMD5(userpass)

        });
            Response.Write("<script>alert('注册成功');document.location.href = '/';</script>");
        }


    }
}