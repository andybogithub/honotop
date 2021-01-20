using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Tiantu.DB.Common;
using Tiantu.DB.Model;

public partial class _shop_admin_category_List : System.Web.UI.Page
{
    Tiantu.DB.DAL.ShopStore dalShopStore = new Tiantu.DB.DAL.ShopStore();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int categoryId = SL.GetQueryInt("categoryid", true);
            if (categoryId > 0)
            {
                ShowInfo(categoryId);
            }

            ShowList();
        }
    }


    #region 详细
    private void ShowInfo(int categoryId)
    {
        ShopCategory model = dalShopStore.GetShopCategoryModel(categoryId);
        if (model!=null)
        {
            this.hfCategoryId.Value = SL.DESEncrypt(model.CategoryId.ToString());
            this.txtCategoryName.Text = model.CategoryName;
            this.ddlClazzId.SelectedValue = model.ClazzId.ToString();

            //
            this.lblPageAction.Text = "编辑";
            this.btnDelete.Visible = true;
        }
    }
    #endregion


    #region 列表
    private void ShowList()
    {
        DataSet dsList = dalShopStore.GetShopCategoryList();
        if (dsList!=null)
        {
            //
            DataView dataView01 = dsList.Tables[0].DefaultView;
            dataView01.RowFilter = "clazzid=1";
            this.RepeaterList01.DataSource = dataView01;
            this.RepeaterList01.DataBind();

            //
            DataView dataView02 = dsList.Tables[0].DefaultView;
            dataView01.RowFilter = "clazzid=2";
            this.RepeaterList02.DataSource = dataView01;
            this.RepeaterList02.DataBind();
        }
    }
    #endregion


    #region 保存

    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
        {
            int categoryId = string.IsNullOrEmpty(this.hfCategoryId.Value) ? 0 : Convert.ToInt32(SL.DESDecrypt(this.hfCategoryId.Value));
            string categoryName = this.txtCategoryName.Text;
            int clazzId = Convert.ToInt32(this.ddlClazzId.SelectedValue);

            var errStr = "";
            if (string.IsNullOrEmpty(categoryName))
            {
                errStr = "请输入商品分类名称";
            }
            if (errStr.Length > 0)
            {
                ShowError(errStr);
                return;
            }

            ShopCategory model = new ShopCategory();
            model.CategoryId = categoryId;
            model.CategoryName = categoryName;
            model.ClazzId = clazzId;

            dalShopStore.AddOrUpdateShopCategory(model);

            Response.Redirect("list.aspx");

        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
        }

    }
    #endregion


    #region 删除
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int categoryId = Convert.ToInt32(SL.DESDecrypt(this.hfCategoryId.Value));
            dalShopStore.DeleteShopCategory(categoryId);
        }
        catch  
        {
        }
        finally
        {
            Response.Redirect("list.aspx");
        }
    }
    #endregion

    #region 私有方法
    private void ShowError(string errStr)
    {
        this.lblError.Text = errStr;
        this.PanelError.Visible = true;
    }
    private void HideError()
    {
        this.lblError.Text = "";
        this.PanelError.Visible = false;
    }
    #endregion


    protected   string GetClazzName(object clazzId)
    {
        string clazzName = "商品";
        if (Convert.ToInt32(clazzId) == 2)
            clazzName = "夺宝商品";
        return clazzName;
    }

  
}