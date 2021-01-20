using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiantu.DB.Common;

public partial class webadmin_CateAdd : System.Web.UI.Page
{
    Tiantu.DB.DAL.Categorys dalCategorys = new Tiantu.DB.DAL.Categorys();
    protected int clzid = 0;
    protected int cateid = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.clzid = SL.GetQueryIntValue("clzid");
            this.cateid = SL.GetQueryIntValue("cateid");
            ShowInfo(this.cateid);

        }
    }


    private void ShowInfo(int cateid)
    {
        Tiantu.DB.Model.Categorys model = dalCategorys.GetModel(cateid);
        if (model != null)
        {
            this.txtCatename.Text = model.CATENAME;
            this.hfCateid.Value = model.CATEID.ToString();
            this.hfClzid.Value = model.CLZID.ToString();
            this.hfParentid.Value = model.PARENTID.ToString();
            this.txtSortid.Text = model.SORTID.ToString();
        }
        else
        {
            this.hfClzid.Value = this.clzid.ToString();
            this.txtSortid.Text = "0";
        }
    }


    //保存
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int cateid = Convert.ToInt32(this.hfCateid.Value);
        int clzid = Convert.ToInt32(this.hfClzid.Value);
        string catename = this.txtCatename.Text;
        int parentid = Convert.ToInt32(this.hfParentid.Value);
        int sortid = Convert.ToInt32(this.txtSortid.Text);

        Tiantu.DB.Model.Categorys model = dalCategorys.GetModel(cateid);
        model = (model == null ? new Tiantu.DB.Model.Categorys() : model);
        model.CATEID = cateid;
        model.CLZID = clzid;
        model.CATENAME = catename;
        model.PARENTID = parentid;
        model.SORTID = sortid;
        //model.NOTES = notes;

        if (cateid > 0)
        {
            dalCategorys.Update(model);
        }
        else
        {
            dalCategorys.Add(model);
        }
        Response.Redirect("CateList.aspx?clzid=" + clzid);


    }
}