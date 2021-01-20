using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class webadmin_CasesList : System.Web.UI.Page
{

    Tiantu.DB.DAL.Cases dalCases = new Tiantu.DB.DAL.Cases();

    protected void Page_Load(object sender, EventArgs e)
    {

        string strWhere = "1=1";

        var list = dalCases.GetList(0, strWhere, "SORTID DESC, CASEID DESC");
        if (list != null)
        {
            this.RepeaterStores.DataSource = list;
            this.RepeaterStores.DataBind();
        }
    }

    protected void RepeaterStores_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if ("delete".Equals(e.CommandName))
        {
            int relid = Convert.ToInt32(e.CommandArgument);
            Tiantu.DB.Model.Cases model = dalCases.GetModel(relid);
            if (model != null)
            {
                //删除图片文件
                SL.TryDeleteImage(model.IMGURL);
            }
            dalCases.Delete(relid);
            Response.Redirect("CasesList.aspx");
        }
    }



}