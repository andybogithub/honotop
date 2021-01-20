using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;


public partial class admin_Login : System.Web.UI.Page
{
    Tiantu.DB.DAL.Admins dalAdmins = new Tiantu.DB.DAL.Admins();
    protected void Page_Load(object sender, EventArgs e)
    {

        #region 退出登录
        if ("logout".Equals(Request["action"]))
        {
            FormsAuthentication.SignOut();
            dalAdmins.Logout();
            Response.Redirect("/_shop_admin/login.aspx");
        }
        #endregion


        #region MyRegion
        if (dalAdmins.IsLogin())
        {
            Response.Redirect("desk.aspx");
        }
        #endregion



    }




    protected void btnLogin_Click(object sender, EventArgs e)
    {
        this.PanelError.Visible = false;
        this.lblLoginResult.Text = "";


        string username = this.txtUserName.Text;
        string password = this.txtUserPass.Text;

        if (username.Length > 0 && password.Length > 0)
        {
            bool islogin = dalAdmins.Login(username, password);
            if (islogin)
            {
                FormsAuthentication.SetAuthCookie(username, true);
                Response.Redirect("desk.aspx");
            }
            else
            {
                this.lblLoginResult.Text = "账号与密码不正确";
                this.PanelError.Visible = true;
            }
        }
        else
        {
            this.lblLoginResult.Text = "账号与密码不正确";
            this.PanelError.Visible = true;
        }
       


    }
}