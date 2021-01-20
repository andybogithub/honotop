using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _shop_admin_game_List : System.Web.UI.Page
{
    Tiantu.DB.DAL.ShopStore dalShopStore = new Tiantu.DB.DAL.ShopStore();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowList();
        }
    }

    private void ShowList()
    {
        string strWhere = "";
        if (!string.IsNullOrEmpty(this.txtGameName.Text))
        {
            strWhere = string.Format(" GAMENAME LIKE '%{0}%' ", this.txtGameName.Text);
        }

        DataSet dsList = dalShopStore.GetShopGameList(strWhere);
        if (dsList!=null)
        {
            this.RepeaterList.DataSource = dsList.Tables[0];
            this.RepeaterList.DataBind();
        }
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        ShowList();
    }
}