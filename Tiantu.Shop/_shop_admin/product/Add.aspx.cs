using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Tiantu.DB.Common;
using Tiantu.DB.Model;

public partial class _shop_admin_product_Add : System.Web.UI.Page
{
    private int ClazzId = 1; //商品系列
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
            this.txtSubName.Text = model.SubName;
            this.txtQty.Text = model.Qty.ToString();
            this.txtPrice.Text = model.InsurancePrice.ToString();
            this.txtPoint.Text = model.Point.ToString();
            this.rbtnShipment.SelectedValue = model.Shipment;
            this.hfimageIcon.Value = model.ImageIcon;

            this.chkSeckillTag.Checked = model.SeckillTag;
            if (model.SeckillTag)
            {
                this.txtSeckillEndTime.Text = model.SeckillEndTime.ToString("yyyy-MM-dd HH:mm:ss");
                this.txtSeckillPoint.Text = model.SeckillPoint.ToString();
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
                this.btnOffLine.Visible = true;
                this.btnOnLine.Visible = false;
                this.btnDelete.Visible = true;
            }
            else
            {
                this.btnOffLine.Visible = false;
                this.btnOnLine.Visible = true;
                this.btnDelete.Visible = true;
            }
        }
    }
    #endregion


    #region 保存
    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
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


            string errStr = "";
            if (string.IsNullOrEmpty(productName))
            {
                errStr = "请输入产品名称";
            }
            else if (point < 0)
            {
                errStr = "价格不正确";
            }
            else if (qty < 0)
            {
                errStr = "请输入正确的库存数量";
            }
            else if (qty == 0 && !"无货".Equals(qtyStatus))
            {
                errStr = "库存数量为0时库存状态必须为无货";
            }
            else if (qty > 0 && "无货".Equals(qtyStatus))
            {
                errStr = "库存数量大于0时库存状态不能为无货";
            }
            else if (string.IsNullOrEmpty(imageIcon) && !this.FileIcon.HasFile)
            {
                errStr = "请上传产品图片";
            }
            else if (seckillTag)
            {
                if (string.IsNullOrEmpty(seckillEndTime))
                {
                    errStr = "请输入秒杀结束时间";
                }
                else if (string.IsNullOrEmpty(seckillPoint))
                {
                    errStr = "请输入秒杀优惠价格";
                }
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
            model.SubName = subName;
            model.Point = point;
            model.Qty = qty;
            model.InsurancePrice = price;
            model.QtyStatus = qtyStatus;
            model.Shipment = shipment;
            model.ProductDetails = productDetails;

            model.ImageIcon = imageIcon;
            model.IsOnLine = true;
            model.SeckillTag = seckillTag;
            if (seckillTag)
            {
                model.SeckillEndTime = Convert.ToDateTime(seckillEndTime);
                model.SeckillPoint = Convert.ToInt32(seckillPoint);
            }
            model.HotTag = hotTag;
            model.TJTag = tjTag;
            model.ShowHomeTag = showhomeTag;
            model.PubTime = DateTime.Now;
            model.DBNeedTotal = 0;
            model.DBAllowJoin = 0;

            dalShopStore.AddOrUpdateShopProduct(model);

            Response.Redirect("list.aspx");
        }
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