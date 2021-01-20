using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class webadmin_Login : System.Web.UI.Page
{
    Tiantu.DB.DAL.Admins dalAdmins = new Tiantu.DB.DAL.Admins();


    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            //
            this.lblLoginResult.Text = "";
            //
            string username = this.txtUsername.Text;
            string userpass = this.txtUserpass.Text;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(userpass))
            {
                bool validateResult = dalAdmins.Login(username, userpass);

          

                //验证
                if (validateResult)
                {
                    string loginIp = SL.GetIp();
                    dalAdmins.AddLoginLog(new Tiantu.DB.Model.LoginLog()
                    {
                        LoginName = username,
                        LoginIp = loginIp,
                        LoginTime = DateTime.Now
                    });


                    Response.Redirect("AboutUsList.aspx");
                }
                else
                {
                    //验证失败
                    this.lblLoginResult.Text = "<font color='red'>登录失败：账号或密码不正确!</font><br/>";
                }
            }
        }
        catch (Exception ex)
        {
            //日志...
            SL.WriteLog(ex.Message);
        }
    }
}