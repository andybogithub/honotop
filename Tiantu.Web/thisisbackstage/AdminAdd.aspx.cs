using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class webadmin_AdminAdd : System.Web.UI.Page
{
    Tiantu.DB.DAL.Admins dalAdmins = new Tiantu.DB.DAL.Admins();



    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int adminId = SL.GetQueryIntValue("id");
            if (adminId > 0)
            {
                ShowInfo(adminId);
            }
        }
    }


    private void ShowInfo(int AdminId)
    {

        Tiantu.DB.Model.Admins model = dalAdmins.GetModel(AdminId);
        if (model != null)
        {
            this.btnRemove.Visible = true;
            this.lblH4.Text = "编辑";

            this.hfAdminId.Value = model.ADMINID.ToString();
            this.txtADMINNAME.Enabled = false;
            this.txtADMINNAME.Text = model.ADMINNAME;
            this.txtADMINPASS.Text = "";
        }
    }



    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            int AdminId = int.Parse(this.hfAdminId.Value);
            string AdminName = this.txtADMINNAME.Text;
            string AdminPass = this.txtADMINPASS.Text;

            Tiantu.DB.Model.Admins model = new Tiantu.DB.Model.Admins();
            model.ADMINID = AdminId;
            model.ADMINNAME = AdminName;
            model.ADMINPASS = SL.EncryptMD5(AdminPass);
            model.REALNAME = "";
            model.LASTLOGINTIME = DateTime.Now;
            model.LASTLOGINIP = "";

            if (AdminId > 0)
            {
                dalAdmins.Update(model);
            }
            else
            {
                dalAdmins.Add(model);
            }

            Response.Redirect("adminList.aspx");
        }
        catch
        {
            SL.Show(this.Page, "添加失败：请检查是否添加了重复的管理员账号!");
            return;
        }
    }


    protected void btnRemove_Click(object sender, EventArgs e)
    {
        int AdminId = Convert.ToInt32(this.hfAdminId.Value);
        int count = dalAdmins.GetRecordCount("");
        if (count == 1)
        {
            SL.Show(this.Page, "删除失败：系统需要至少一个管理员账号!");
        }
        else
        {
            dalAdmins.Delete(AdminId);
            Response.Redirect("adminList.aspx");
        }
    }
}