using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using Tiantu.DB.Common;

public partial class _shop_web_IndianaDetail : System.Web.UI.Page
{
    public int ProgressId = 0;  //0：报名中，1：已完成报名，正在开奖中，2：已开奖
    public bool bLogin = false; //登录状态

    public int JoinedTotal = 0;//商品已报名人数
    public int JoinedPrecent = 0;//商品已报名百分比
    public int LeftJoinedTotal = 0; //商品可报名次数

 
    public int LuckNo = 0;
    public long TimeSum = 0;

    public Tiantu.DB.Model.ShopProduct productmodel;

    Tiantu.DB.DAL.Users dalUsers = new Tiantu.DB.DAL.Users();
    Tiantu.DB.DAL.ShopStore dalShopStore = new Tiantu.DB.DAL.ShopStore();


 
    protected void Page_Load(object sender, EventArgs e)
    {
       int  productId = SL.GetQueryInt("productno", true);

        if (productId > 0)
        {
            ShowInfo(productId);
        }
        else
        {
            Response.Redirect("/indianas.html");
        }
    }

    private void ShowInfo(int productId)
    {
        productmodel = dalShopStore.GetShopProductModel(productId);



        #region 参数验证
        if (null == productmodel || productmodel.ProductId == 0)
        {
          //  Response.Redirect("/indianas.html");
        }
        else if (productmodel.ClazzId == 1)
        {
           // Response.Redirect("/products.html");
        }
        #endregion

        string winTakeStepDetails = dalShopStore.GetAboutDetails(2);
        if (!string.IsNullOrEmpty(winTakeStepDetails) && winTakeStepDetails.Trim().Length > 1)
        {
            this.lblWinTakeStepTitle.Text = " <li class='nali_4'><a>奖品领取步骤</a></li>";
            this.lblWinTakeStepBody.Text = winTakeStepDetails;
        }

        // 是否参与过本次夺宝
        int UserId = dalUsers.GetUserIdFromCookie();
        int EmplId = 0;
        this.bLogin = UserId > 0;

        //商品已经报的总人数
        JoinedTotal = dalShopStore.GetNowJoinedTotal(productId);
        if (productmodel.DBNeedTotal <= JoinedTotal)    //达到开奖条件了
        {
            JoinedPrecent = 100;

            //是否已开奖
            if (productmodel.DubaoStatus==0 || productmodel.DubaoStatus==1)    //未开奖
            {
                //查看是否达到开奖时间了
                if (productmodel.SeckillEndTime!=null && productmodel.SeckillEndTime.Subtract(DateTime.Now).TotalSeconds < 0)
                {
                    // 开奖（全部开奖都只要这里调用）
                    bool success =  dalShopStore.DuobaoOpenWinner(productId);
                    if (success)
                    {
                        //添加订单
                        dalShopStore.AddShopDubaoOrder(UserId, EmplId, productId);
                    }

                    //开奖之后再获取一次商品对象
                    productmodel = dalShopStore.GetShopProductModel(productId);

                    //已开奖
                    ProgressId = 3;
                }
                else
                {
                    // 没有开奖
                    ProgressId = 2;
                }
            }
            else  
            {
                // 已开奖
                ProgressId = 3;
            }
        }
        else // 人还没有报满，还不能开奖
        {
            ProgressId = 1;

            JoinedPrecent = Convert.ToInt32(Convert.ToDouble(JoinedTotal / (productmodel.DBNeedTotal * 1.00)) * 100);
            LeftJoinedTotal = (productmodel.DBNeedTotal - JoinedTotal) > 0 ? (productmodel.DBNeedTotal - JoinedTotal) : 0;
        }



        if (ProgressId == 3)
        {
            #region 开奖信息
            JoinedPrecent = 100;
            LuckNo = productmodel.DubaoWinNo;
            TimeSum = dalShopStore.GetDuobaoAllTimeSum(productId);

            DataRow dataRow = dalShopStore.GetDuobaoWinInfo(productId);
            if (dataRow != null)
            {
                int winnerUserId = Convert.ToInt32(dataRow["USERID"]);
                int winnerEmplId = Convert.ToInt32(dataRow["EMPLID"]);

                string winner = dataRow["USERTEL"].ToString();
                if (winnerEmplId > 0)
                {
                    winner = dataRow["EMPLTEL"].ToString();
                }

                //中奖人信息
                string rndTime = Convert.ToDateTime(dataRow["rndtime"]).ToString("yyyy-MM-dd HH:mm:ss.fff");
                string winnerNos = "";
                List<string> winnerNoList = dalShopStore.GetDuobaoJoinedNumbers(productId, winnerUserId, winnerEmplId);
                for (int i = 0; i < winnerNoList.Count; i++)
                {
                    int buyNo = Convert.ToInt32(winnerNoList[i]);
                    bool isWinNo = (buyNo == LuckNo);
                    winnerNos += string.Format("<li {0}>{1}</li>",  isWinNo?"class='winno' title='中奖号码' ":"" , buyNo);
                }

                string luckInfo = string.Format(@" <h5>恭喜 <span>{0}</span> 获得本品</h5>
                            <p>
                                揭晓时间：{1}<br />
                                参与时间：{2}<br />
                                共参与 ：{3} 人次 &nbsp;<a class='showallwinnernumber'>查看TA的所有号码&gt;&gt;</a>
                            </p>
                            <div id='allwinnernumber' class='allwinnernumber' ><ul>{4}</ul><div class='cl'></div></div>", 
                           winner, 
                           productmodel.DubaoWinDate.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                           rndTime,
                           winnerNoList.Count, 
                           winnerNos);
                this.lblLuckInfo.Text = luckInfo;
            }
            #endregion
        }


        #region 用户参与信息
        if (bLogin)
        {
            bool bJoined = dalShopStore.GetDuobaoJoinedStatus(productId, UserId, EmplId);
            if (bJoined)
            {
                string joinStatusHtml = "<div class='loginpart'><p>您已参加本次夺宝</p></div>";

                string strMyNo = "";
                List<string> mynoList = dalShopStore.GetDuobaoJoinedNumbers(productId, UserId, EmplId);
                foreach (string item in mynoList)
                {
                    strMyNo += string.Format("{0} ", item);
                }
                joinStatusHtml += string.Format("<div class='mynumbers'>我的夺宝号：<ul>{0}</ul></div>", strMyNo);


                this.lblJoinStatus.Text = joinStatusHtml;
            }
            else
            {
                this.lblJoinStatus.Text = "<div class='loginpart'><p>您没有参加此次夺宝</p></div>";
            }
        }
        else
        {
            this.lblJoinStatus.Text = "<div class='cuelogin' onclick='javascript:login();'><p><b>请登录</b><br/>查看你的夺宝号码</p></div>";
        }

        #endregion

    }
}