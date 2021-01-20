using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class webadmin_CateList : System.Web.UI.Page
{
    Tiantu.DB.DAL.Categorys dalCategorys = new Tiantu.DB.DAL.Categorys();

    public int clzid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        this.clzid = SL.GetQueryIntValue("clzid");
        this.lblH5.Text = "定期报告类别管理";

        #region 显示列表
        string strWhere = "1=1";
        if (clzid > 0)
        {
            strWhere += " AND CLZID=" + clzid;
        }
        var list = dalCategorys.GetList(0, strWhere, "SORTID DESC, CATEID DESC");
        if (list != null)
        {
            this.RepeaterStores.DataSource = list;
            this.RepeaterStores.DataBind();
        }
        #endregion


    }

    protected void RepeaterStores_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if ("delete".Equals(e.CommandName))
        {
            int relid = Convert.ToInt32(e.CommandArgument);
            Tiantu.DB.Model.Categorys model = dalCategorys.GetModel(relid);
            dalCategorys.Delete(relid);
            Response.Redirect("CateList.aspx?clzid=" + this.clzid);
        }
    }

}