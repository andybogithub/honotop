using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class _shop_web_Carts : System.Web.UI.Page
{
    public int UserId = 0;
    public int EmplId = 0;

    Tiantu.DB.DAL.Users dalUsers = new Tiantu.DB.DAL.Users();
    Tiantu.DB.DAL.ShopStore dalShopStore = new Tiantu.DB.DAL.ShopStore();

    protected void Page_Load(object sender, EventArgs e)
    {
        int userId = dalUsers.GetUserIdFromCookie();
        if (userId == 0)
        {
            //未登录
            Response.Redirect("/");
        }


        //
        UserId = dalUsers.GetUserIdFromCookie();
        EmplId = 0;

        //会员地址
        DataSet addressList = dalShopStore.GetShopAddressList(UserId, EmplId);
        if (addressList != null)
        {
            this.RepeaterAddressList.DataSource = addressList.Tables[0];
            this.RepeaterAddressList.DataBind();
        }


        //会员金币
        int userPoints = dalShopStore.GetShopUserPoint(UserId);
        this.lblUserPoints.Text = userPoints.ToString();

        //购买产品列表
        int totalQty = 0;
        int totalPoints = 0;
        double totalInsurancePrice = 0;
        DataSet cartList = dalShopStore.GetShopCartList(UserId, EmplId);
        if (cartList != null)
        {
            this.RepeaterProductsList.DataSource = cartList.Tables[0];
            this.RepeaterProductsList.DataBind();

            //商品合计
            foreach (DataRow row in cartList.Tables[0].Rows)
            {
                totalQty += Convert.ToInt32(row["orderQty"]);
                totalPoints += totalQty * Convert.ToInt32(row["orderPoint"]);
                if (Convert.ToBoolean(row["IsInsurance"]))
                {
                    totalInsurancePrice += Convert.ToDouble(row["InsurancePrice"]);
                }
            }


            this.lblTotalQty.Text = totalQty.ToString();
            this.lblTotalPoints.Text = totalPoints.ToString();
            this.lblInsurancePrice.Text = totalInsurancePrice.ToString("N2");
        }

        //
        if (totalQty > 0 && userPoints >= totalPoints)
        {
            this.lblExchangeNow.Text = "<a id='btnExchangeNow'>立即购买</a>";
        }




    }
}