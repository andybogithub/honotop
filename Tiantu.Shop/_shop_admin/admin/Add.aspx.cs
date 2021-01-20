using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_admin_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }





    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string strErr = "";

        string adminName = this.txtAdminName.Text;
        string adminPass = this.txtAdminPass.Text;
        if (string.IsNullOrEmpty(adminName)) strErr = "请输入用户名";
        else if (string.IsNullOrEmpty(adminPass)) strErr = "请输入密码";
        if (strErr.Length > 0)
        {
            
        }
    }
}