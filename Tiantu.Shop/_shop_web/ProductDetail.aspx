<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_web/Share.master" AutoEventWireup="true" CodeFile="ProductDetail.aspx.cs" Inherits="_shop_web_ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container wp">
        <div class="proDeTop">
            <div class="current"><a href="/products.html">全部商品</a> > <%=productmodel.ProductName %></div>
            <div class="proDeInfo">
                <div class="dePic">
                    <img src="<%=Tiantu.DB.Common.SL.GetHttpImageURL(productmodel.ImageIcon) %>" style="width: 352px; height: 352px;" />
                </div>
                <div class="deInfoCon">
                    <h3><%=productmodel.ProductName %></h3>
                    <div class="infoUl">
                        <%if (!productmodel.SeckillTag)
                            { %>
                        <div class="item changePrice">
                            <strong>购买价格：</strong>
                            <div class="itemRight"><span>¥<%=productmodel.Point %> </span></div>
                        </div>
                        <%}
                            else
                            {
                        %>
                        <div class="item changePrice">
                            <strong>秒杀价格：</strong>
                            <div class="itemRight"><span>¥<%=productmodel.SeckillPoint %> </span></div>
                        </div>

                        <%} %>

                        <div class="item stock">
                            <strong>库存情况：</strong>
                            <div class="itemRight"><span><%=productmodel.Qty==0?"无货":productmodel.QtyStatus %></span></div>
                        </div>
                        <div class="item logistics">
                            <strong>物流方式：</strong>
                            <div class="itemRight">
                                <%=productmodel.Shipment %>
                            </div>
                        </div>
                        <div class="item exchange">
                            <strong>购买数量：</strong>
                            <div class="itemRight">
                                <div class="exchangeNum">
                                    <i class="minus disabled">-</i>
                                    <input type="text" name="qty" id="qty" value="1" class="count" readonly="true" />
                                    <i class="plus">+</i>
                                </div>
                            </div>
                        </div>
                        <script type="text/javascript">
                            $(function(){
                                $('.exchangeNum .plus').on('click',function(){
                                    var num = $('.count').val();
                                    $('.exchangeNum .minus').removeClass('disabled');
                                    var total = parseInt(num);
                                    var maxid = <%=productmodel.Qty%>;
                                    if(total<maxid) total++;
                                    $('.count').val(total);
                                });
                                $('.exchangeNum .minus').on('click',function(){
                                    var num = $('.count').val();
                                    if(num == 2){
                                        $('.count').val(parseInt(num));
                                        $(this).addClass('disabled');
                                    }
                                    if(num < 2){
											
                                    }else{
                                        $('.count').val(parseInt(num) - 1);
                                    }
										
                                });
                            });
                        </script>
                    </div>

                    <!-- 
                        1） 秒杀产品，是否结束或抢光
                        -->

                    <%
                        int productStatus = 0;

                        if (productmodel.SeckillTag)
                        {
                            #region 秒杀产品
                            if (DateTime.Now.Subtract(productmodel.SeckillEndTime).TotalSeconds > 0)
                            {
                                //活动已结束
                                productStatus = 1;
                            }
                            else if (productmodel.Qty == 0)
                            {
                                //已抢光
                                productStatus = 2;
                            }
                            else
                            {
                                //抢购中
                                productStatus = 3;
                            }
                            #endregion
                        }
                        else
                        {
                            #region 不是秒杀产品
                            if (productmodel.Qty == 0)
                            {
                                //无库存
                                productStatus = 4;
                            }
                            else if (!IsLogin)
                            {
                                //没有登录
                                productStatus = 5;
                            }
                            else
                            {
                                //可购买
                                productStatus = 6;
                            }
                            #endregion
                        }

                        string buyButton = "";
                        if (productStatus == 3 || productStatus == 6)
                        {
                            buyButton = string.Format("<div class='changeBtn'><a onclick=\"javascript:exChange('{0}')\" '>立即购买</a></div>",
                                Tiantu.DB.Common.SL.DESEncrypt(productmodel.ProductId.ToString()));
                        }
                        else if (productStatus == 5)
                        {
                            buyButton = " <div class='changeBtn'><a onclick='javascript:login();'>立即购买</a></div>";
                        }
                        else if (productStatus == 1)
                        {
                            buyButton = "<div class='changeBtn disabled'><a>活动已结束</a></div>";
                        }
                        else if (productStatus == 2)
                        {
                            buyButton = "<div class='changeBtn disabled'><a>已抢光</a></div>";
                        }
                        else if (productStatus == 4)
                        {
                            buyButton = "<div class='changeBtn disabled'><a>暂无库存</a></div>";
                        }
                        else
                        {
                            buyButton = "<div class='changeBtn disabled'><a>立即购买</a></div>";
                        }

                        Response.Write(buyButton);
                    %>
                </div>
            </div>
        </div>
        <style type="text/css">
            .deInfoCon .disabled a { background: #808080; }
        </style>
        <div class="proDeMain">
            <div class="deMainTitle">
                <strong>商品详情</strong>
            </div>
            <div class="deMainCon">
                <div class="deParameter">
                </div>
                <div class="deIntroduce">
                    <%=productmodel.ProductDetails %>
                </div>
            </div>
        </div>
    </div>

    <script>
        //购买
        function exChange(productNo) {
            var _qty=$("#qty").val();
            exChangeNow(productNo,_qty);
        }
    </script>

    <script>
        $('.nav li').eq(1).addClass('on').siblings().removeClass('on');
    </script>
</asp:Content>

