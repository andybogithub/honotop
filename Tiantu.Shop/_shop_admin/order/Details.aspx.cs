using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Tiantu.DB.Common;

public partial class _shop_admin_order_Details : System.Web.UI.Page
{
    public bool IsOpenWin = false;
    Tiantu.DB.DAL.ShopStore dalShopStore = new Tiantu.DB.DAL.ShopStore();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int opId = SL.GetQueryInt("opid", true);
            if (opId > 0)
            {
                DataRow row = dalShopStore.GetShopOrderProductRow(opId);
                if (row != null)
                {
                    this.hfopId.Value = opId.ToString();
                    this.lblOrderDate.Text = Convert.ToDateTime(row["OrderTime"]).ToString("yyyy-MM-dd HH:mm:ss");
                    this.lblUserName.Text = row["username"].ToString();
                    this.lblUserTel.Text = row["usertel"].ToString();
                    this.lblAddress.Text = row["city"].ToString() + " " + row["addrs"].ToString();
                    this.lblShipment.Text = row["shipment"].ToString();
                    this.lblInsurancePrice.Text = Convert.ToBoolean(row["IsInsurance"]) ? Convert.ToDouble(row["OrderInsurancePrice"]).ToString("N2") + "元" : "无";

                    this.txtShipCompany.Text = row["shipcompany"].ToString();
                    this.txtShipNo.Text = row["shipno"].ToString();

                    int productId = Convert.ToInt32(row["productId"]);
                    Tiantu.DB.Model.ShopProduct model =   dalShopStore.GetShopProductModel(productId);
                     if (model != null && model.DubaoWinNo > 0)
                     {
                         this.IsOpenWin = true;
                         this.lblWinNo.Text = model.DubaoWinNo.ToString();
                         this.lblWinDate.Text = model.DubaoWinDate.ToString("yyyy-MM-dd HH:mm:ss");
                     }
                }
            }
        }
    }

    /// <summary>
    /// 删除购买商品
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int opId = Convert.ToInt32(this.hfopId.Value);
        dalShopStore.DeleteShopOrderProduct(opId);

        Response.Redirect("list.aspx");
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        int opId = Convert.ToInt32(this.hfopId.Value);
        string shipCompany = this.txtShipCompany.Text;
        string shipNo = this.txtShipNo.Text;

        string err = "";
        if (string.IsNullOrEmpty(shipCompany))
            err = "请输入物流公司";
        else if (string.IsNullOrEmpty(shipNo))
            err = "请输入承运单号";

        if (err.Length > 0)
        {
            SL.Show(this.Page, err);
            return;
        }
        else
        {
            dalShopStore.UpdateShopOrderProductShipmentStatus(opId, shipCompany, shipNo);

            string pageUrl = string.Format("details.aspx?opid={0}", SL.DESEncrypt(opId.ToString()));
            SL.Show(this.Page, "已更新", pageUrl);
        }


    }
}