using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Tiantu.DB.Common;

public partial class _shop_web__account_OrderDetail : System.Web.UI.Page
{
    public bool bChooseAddress = true;
    public DataRow orderRow;

    Tiantu.DB.DAL.ShopStore dalShopStore = new Tiantu.DB.DAL.ShopStore();
    protected void Page_Load(object sender, EventArgs e)
    {
    
        int opId = SL.GetQueryInt("opid", true);
        if (opId > 0)
        {
            orderRow = dalShopStore.GetShopOrderProductRow(opId);
            int userId = Convert.ToInt32(orderRow["UserId"]);
            int emplId = Convert.ToInt32(orderRow["EmplId"]);
            if (userId != Master.user.USERID)
            {
                Response.Redirect("/account/index.html");
            }
            else
            {
                int productId = Convert.ToInt32(orderRow["productId"]);
                string City = orderRow["city"] != null ? orderRow["city"].ToString().Trim() : "";
                string Addrs = orderRow["Addrs"] != null ? orderRow["Addrs"].ToString().Trim() : "";
                string UserName = orderRow["UserName"] != null ? orderRow["UserName"].ToString().Trim() : "";
                string UserTel = orderRow["UserTel"] != null ? orderRow["UserTel"].ToString().Trim() : "";
                if (UserName.Length==0 || UserTel.Length==0)
                {
                    bChooseAddress = false;
                    this.lblEditAddress.Text = "<div style='background:#dcdcdc;width:100%;padding:10px 0;'>&nbsp;&nbsp;请选择收货地址：<a href='/account/address.html' style='color:blue;float:right;margin-right:10px;';>[添加地址]</a></div>";
                }

               Tiantu.DB.Model.ShopProduct product =  dalShopStore.GetShopProductModel(productId);
               bool IsDuobaoProduct = product != null && product.ClazzId == 2;

                string strWhere = string.Format("t.opId={0}", opId);
                int totalRecords = 0;
                DataSet dsList = null;
                if (IsDuobaoProduct)
                {
                    dsList = dalShopStore.GetShopDubaoProductList(1, 0, strWhere, "", out totalRecords);
                }
                else
                {
                    dsList = dalShopStore.GetShopOrderProductList(1, 0, strWhere, "", out totalRecords);
                }

                if (dsList != null)
                {
                    this.RepeaterProductList.DataSource = dsList.Tables[0];
                    this.RepeaterProductList.DataBind();
                }

                //
                ShowAddress(userId, emplId);
            }
        }
    }

    private void ShowAddress(int UserId,int EmplId)
    {
        DataSet dsList = dalShopStore.GetShopAddressList(UserId, EmplId);
        if (dsList != null)
        {
            this.RepeaterAddressList.DataSource = dsList.Tables[0];
            this.RepeaterAddressList.DataBind();
        }
    }
}