using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Tiantu.DB.Common;
using Tiantu.DB.Model;

public partial class _shop_admin_duobao_Add : System.Web.UI.Page
{
    private int ClazzId = 2;    //夺宝商品系列
    Tiantu.DB.DAL.ShopStore dalShopStore = new Tiantu.DB.DAL.ShopStore();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitData();

            int productId = SL.GetQueryInt("productId", true);
            if (productId > 0)
            {
                ShowInfo(productId);
            }
        }
    }



    #region 初始化数据
    private void InitData()
    {
        DataSet dsCategory = dalShopStore.GetShopCategoryList(string.Format("clazzId={0}", ClazzId));
        if (dsCategory != null)
        {
            this.ddlCategoryId.DataSource = dsCategory.Tables[0];
            this.ddlCategoryId.DataValueField = "categoryId";
            this.ddlCategoryId.DataTextField = "categoryName";
            this.ddlCategoryId.DataBind();
        }
    }
    #endregion


    #region 详细
    private void ShowInfo(int productId)
    {
        ShopProduct model = dalShopStore.GetShopProductModel(productId);
        if (model != null)
        {
            this.hfproductId.Value = SL.DESEncrypt(model.ProductId.ToString());
            this.txtProductName.Text = model.ProductName;
            this.txtDBNeedTotal.Text = model.DBNeedTotal.ToString();
            this.txtSubName.Text = model.SubName;
            this.txtQty.Text = model.Qty.ToString();
            this.txtSeckillPoint.Text = model.SeckillPoint.ToString();
            this.txtPrice.Text = model.InsurancePrice.ToString();
            this.txtPoint.Text = model.Point.ToString();
            this.rbtnShipment.SelectedValue = model.Shipment;
            this.hfimageIcon.Value = model.ImageIcon;

            this.chkSeckillTag.Checked = model.SeckillTag;
            if (model.SeckillTag)
            {
                this.txtSeckillEndTime.Text = model.SeckillEndTime.ToString("yyyy-MM-dd HH:mm:ss");
            }

            this.chkHotTag.Checked = model.HotTag;
            this.chkTJTag.Checked = model.TJTag;
            this.chkShowHomeTag.Checked = model.ShowHomeTag;
            this.txtDetails.Text = model.ProductDetails;


            if (!string.IsNullOrEmpty(model.ImageIcon))
            {
                this.lblimgIcon.Text = string.Format("<a href='{0}' target='_blank'><img src='{0}' height='200'/></a>", SL.GetHttpImageURL(model.ImageIcon));
            }

            //
            this.lblPageAction.Text = "修改";


            if (model.IsOnLine)
            {
                //this.btnOffLine.Visible = true;
                this.btnOnLine.Visible = false;
                this.btnDelete.Visible = true;
            }
            else
            {
                //  this.btnOffLine.Visible = false;
                this.btnOnLine.Visible = true;
                this.btnDelete.Visible = true;
            }
        }
    }
    #endregion


    #region 保存
    protected void btnSave_Click(object sender, EventArgs e)
    {


        HideError();

        int productId = (string.IsNullOrEmpty(this.hfproductId.Value) ? 0 : Convert.ToInt32(SL.DESDecrypt(this.hfproductId.Value)));
        string productName = this.txtProductName.Text;
        int qty = 0;
        int.TryParse(this.txtQty.Text, out qty);
        string qtyStatus = this.ddlQtyStatus.SelectedValue;

        int point = 0;
        int.TryParse(this.txtPoint.Text, out point);

        int price = 0;
        int.TryParse(this.txtPrice.Text, out price);
        string subName = this.txtSubName.Text;
        string shipment = this.rbtnShipment.SelectedValue;
        int categoryId = int.Parse(this.ddlCategoryId.SelectedValue);
        string imageIcon = this.hfimageIcon.Value;
        string productDetails = this.txtDetails.Text;

        //秒杀
        bool seckillTag = this.chkSeckillTag.Checked;
        string seckillEndTime = this.txtSeckillEndTime.Text;
        string seckillPoint = this.txtSeckillPoint.Text;

        bool tjTag = this.chkTJTag.Checked;
        bool hotTag = this.chkHotTag.Checked;
        bool showhomeTag = this.chkShowHomeTag.Checked;

        //夺宝
        int dbNeedTotal = 0;
        int.TryParse(this.txtDBNeedTotal.Text, out dbNeedTotal);





        string errStr = "";
        if (string.IsNullOrEmpty(productName))
        {
            errStr = "请输入产品名称";
        }
        else if (dbNeedTotal < 1)
        {
            errStr = "请输入总需人次";
        }

        else if (string.IsNullOrEmpty(seckillPoint))
        {
            errStr = "价格不正确";
        }
        else if (string.IsNullOrEmpty(imageIcon) && !this.FileIcon.HasFile)
        {
            errStr = "请上传产品图片";
        }


        if (errStr.Length > 0)
        {
            ShowError(errStr);
            return;
        }




        imageIcon = WebControlsHelper.FileUploadImage(this.FileIcon, "shop", imageIcon);




        ShopProduct model = new ShopProduct();
        model.ProductId = productId;
        model.ClazzId = ClazzId;
        model.CategoryId = categoryId;
        model.ProductName = productName;
        model.InsurancePrice = price;
        model.Shipment = shipment;
        model.ProductDetails = productDetails;
        model.ImageIcon = imageIcon;
        model.SeckillPoint = Convert.ToInt32(seckillPoint);
        model.DBNeedTotal = dbNeedTotal;
        model.DBAllowJoin = dbNeedTotal;


        dalShopStore.AddOrUpdateDuobaoProduct(model);

        Response.Redirect("list.aspx");
        try
        { }
        catch (Exception ex)
        {
            ShowError(ex.Message);
        }

    }
    #endregion


    #region  上/下架

    protected void btnOnLine_Click(object sender, EventArgs e)
    {
        int productId = Convert.ToInt32(SL.DESDecrypt(this.hfproductId.Value));
        dalShopStore.OffLineShopProduct(productId, true);
        Response.Redirect("list.aspx");
    }

    protected void btnOffLine_Click(object sender, EventArgs e)
    {
        int productId = Convert.ToInt32(SL.DESDecrypt(this.hfproductId.Value));
        dalShopStore.OffLineShopProduct(productId);
        Response.Redirect("list.aspx");
    }

    #endregion


    #region 删除
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int productId = Convert.ToInt32(SL.DESDecrypt(this.hfproductId.Value));
        ShopProduct model = dalShopStore.GetShopProductModel(productId);
        SL.FileDelete(model.ImageIcon);
        dalShopStore.DeleteShopProduct(productId);
        Response.Redirect("list.aspx");
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





}