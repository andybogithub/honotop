<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_web/Share.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="_shop_web_Index" %>

<%@ MasterType VirtualPath="~/_shop_web/Share.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="/js/index.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container wp">
        <div class="rowGroup cl">
            <div class="l focusWrap">
                <div class="bd">
                    <ul>
                        <asp:Repeater runat="server" ID="RepeaterBanners">
                            <ItemTemplate>
                                <li><a href='<%# Eval("linkurl") %>'>
                                    <img src="<%# Tiantu.DB.Common.SL.GetHttpImageURL(Eval("IMGURL")) %>" /></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="hd">
                    <ul></ul>
                </div>
                <%  if (bannerTotal > 1)
                    { %>
                <span class="icon-btn prev" id="focus_btn_left">&#xe900;</span>
                <span class="icon-btn next" id="focus_btn_right">&#xe901;</span>

                <script type="text/javascript">
                    jQuery(".focusWrap").slide({ titCell: ".hd ul", mainCell: ".bd ul", effect: "fold", autoPlay: true, autoPage: true, trigger: "click" });
                </script>

                <%} %>
            </div>


            <%--<div class="r signedWrap">
                <div class="loginLink">
                    <ul>
                        <!--未登录-->
                        <%if (Master.user == null || Master.user.USERID == 0)
                            { %>
                        <li class="btnLogin"><a onclick="javascript:login();">登录</a></li>
                        <%}
                            else
                            { %>
                        <!--已登录-->
                        <li class="btnGoCenter"><a href="/account">进入金币中心</a></li>
                        <%} %>
                        <li><a href="/rule.html" class="btnRule">金币规则</a></li>
                    </ul>
                </div>
                <div class="checkIn">
                    <%if (Master.user == null || Master.user.USERID == 0)
                        { %>
                    <a onclick="javascript:login();"><i class="icon-chcek">&#xe905;</i><span>每日签到获金币</span></a>
                    <%}
                    else if (!todayIsCheckIn)
                    { %>
                    <a class="checkLogin"><i class="icon-chcek">&#xe905;</i><span>每日签到获金币</span></a>
                    <%}
                    else
                    { %>
                    <a class="checkOn">今日已签到</a>
                    <%} %>
                </div>

                <div class="i_newsList">
                    <h3><i class="icon-new">&#xe904;</i>最新消息</h3>
                    <div class="newsUl">
                        <ul>
                            <asp:Repeater runat="server" ID="RepeaterNews">
                                <ItemTemplate>
                                    <li><a href="/news/<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("newsId").ToString()).ToLower() %>.html"><%# Eval("newsTitle") %></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
            </div>
        </div>--%>




            <div class="i_recommendWrap cl">
                <div class="boxTit">
                    <strong><i class="icon-tj">&#xe906;</i>合作商家</strong>
                    <a href="" class="more">更多>></a>
                </div>
                <div class="boxCon homeProScroll">
                    <div class="bd">
                        <ul>
                            <asp:Repeater ID="RepeaterCases" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <a href="#">
                                            <div class="pic">
                                                <img src="http://www.honotop.com/<%# Eval("IMGURL") %>" onload="DrawImage(this, 260, 200)" alt="<%# Eval("NOTES") %>" />
                                            </div>
                                            <div class="info">
                                                <h4><%# Eval("NOTES") %></h4>

                                            </div>
                                        </a>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>

                        </ul>
                    </div>
                    <div class="hd">
                        <ul>
                        </ul>
                    </div>
                </div>
                <script type="text/javascript">
                    jQuery(".homeProScroll").slide({
                        titCell: ".hd ul",
                        mainCell: ".bd ul",
                        effect: "left",
                        delayTime: 800,
                        vis: 4,
                        scroll: 4,
                        pnLoop: false,
                        trigger: "click",
                        easing: "easeOutCubic",
                        autoPlay: "true",
                        autoPage: true,
                    });
                </script>
            </div>





            <div class="i_seckillWrap">
                <div class="seckillTitle">
                    <img src="/style/images/title.png" alt="限时秒杀" title="限时秒杀" />
                </div>
                <div class="seckillGroup">
                    <ul>
                        <asp:Repeater runat="server" ID="RepeaterSeckillProducts">
                            <ItemTemplate>
                                <li class="<%# Convert.ToInt32(Eval("QTY"))==0 ?"lootAll":"" %>">
                                    <div class="pic">
                                        <a href="/proDe/<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("productid").ToString()).ToLower() %>.html">
                                            <img src='<%# Tiantu.DB.Common.SL.GetHttpImageURL(Eval("imageicon"))%>' onload="javascript:DrawImage(this, 240, 240)" /></a>
                                    </div>
                                    <div class="con">
                                        <h4><%# Eval("productName") %></h4>
                                        <div class="note"><%# Eval("subName") %></div>
                                        <div class="price">
                                            <span class="nowPrice">¥<%# Eval("SeckillPoint") %></span>
                                            <span class="oldPrice">原价 ¥<%# Eval("Point") %></span>
                                        </div>
                                        <div class="btnChange"><a href="/proDe/<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("productid").ToString()).ToLower() %>.html"><%# Convert.ToInt32(Eval("QTY"))==0?"已抢光":"立即购买" %></a></div>



                                        <div class="lastTime lastTimeFun" endtime=" <%# Convert.ToDateTime(Eval("SeckillEndTime")).ToString("MM/dd/yyyy HH:mm:ss") %>">
                                            <b>0</b>
                                            <b>0</b>
                                            <span>:</span>
                                            <b>0</b>
                                            <b>0</b>
                                            <span>:</span>
                                            <b>0</b>
                                            <b>0</b>
                                        </div>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>

                    </ul>
                    <script type="text/javascript">
                        $(function () {
                            $('.lastTimeFun').each(function () {
                                var time = $(this).attr('endTime');
                                countDown(this, time);
                            });
                        });
                    </script>
                </div>
            </div>



            <%--<div class="i_recommendWrap cl">
                <div class="boxTit">
                    <strong><i class="icon-tj">&#xe906;</i>推荐商品</strong>
                    <a href="/products.html?action=tj" class="more">更多>></a>
                </div>
                <div class="boxCon homeProScroll">
                    <div class="bd">
                        <ul>
                            <asp:Repeater runat="server" ID="RepeaterTJList">
                                <ItemTemplate>
                                    <li>
                                        <a href="/proDe/<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("productid").ToString()).ToLower() %>.html">
                                            <div class="pic">
                                                <img src="<%# Tiantu.DB.Common.SL.GetHttpImageURL(Eval("imageIcon")) %>" onload="javascript:DrawImage(this, 270, 270)" />
                                            </div>
                                            <div class="info">
                                                <h4><%# Eval("productName") %></h4>
                                                <p>¥<%# Eval("point") %> </p>
                                            </div>
                                        </a>
                                    </li>
                                </ItemTemplate>

                            </asp:Repeater>
                        </ul>
                    </div>


                    <%if (tjProductTotal > 4)
                        { %>
                    <div class="hd">
                        <ul>
                        </ul>
                    </div>
                    <script type="text/javascript">
                        jQuery(".homeProScroll").slide({
                            titCell: ".hd ul",
                            mainCell: ".bd ul",
                            effect: "left",
                            delayTime: 800,
                            vis: 4,
                            scroll: 4,
                            pnLoop: false,
                            trigger: "click",
                            easing: "easeOutCubic",
                            autoPlay: "true",
                            autoPage: true,
                        });
                    </script>
                    <%} %>
                </div>

            </div>--%>



            <div class="rowGroup cl mg-t">
                <div class="l i_indianaIng">
                    <div class="boxTit">
                        <strong><i class="icon-tj">&#xe903;</i>热门商品</strong>
                        <a href="/products.html" class="more">更多>></a>
                    </div>
                    <div class="boxCon indianaIng">
                        <ul>
                            <asp:Repeater runat="server" ID="RepeaterDBList">
                                <ItemTemplate>
                                    <li>
                                        <div class="pic">
                                            <a href="/idaDe/<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("productid").ToString()).ToLower() %>.html">
                                                <img src="<%# Tiantu.DB.Common.SL.GetHttpImageURL(Eval("ImageIcon"))  %>" width="270" height="270" /></a>
                                        </div>
                                        <div class="con">
                                            <h4><%# Eval("productname") %></h4>
                                            <p class="allNum">开奖人数：<b><%# Eval("DBNeedTotal") %>人次</b></p>
                                            <p class="progress"><span style='width: <%# GetPercent(Convert.ToInt32(Eval("DBNeedTotal")),Convert.ToInt32(Eval("joinedTotal"))) %>%' class="progressLine"></span></p>
                                            <p class="detailsNum cl">
                                                <span class="l"><i><%# Eval("joinedTotal") %></i><em>已参加人次</em></span>
                                                <span class="r"><i><%# Convert.ToInt32(Eval("DBNeedTotal")) - Convert.ToInt32(Eval("joinedTotal")) %></i><em>剩余人次</em></span>
                                            </p>
                                            <p class="joinBtn"><a href="/idaDe/<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("productid").ToString()).ToLower() %>.html">查看详情</a></p>
                                        </div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>

                        </ul>
                    </div>
                </div>


                <div class="r i_hotChange">
                    <div class="boxTit">
                        <strong><i class="icon-tj">&#xe902;</i>推荐商品</strong>
                        <a href="/products.html?action=rm" class="more">更多>></a>
                    </div>
                    <div class="boxCon hotChange">
                        <ul>
                            <asp:Repeater runat="server" ID="RepeaterHotList">
                                <ItemTemplate>
                                    <li>
                                        <div class="pic">
                                            <a href="/proDe/<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("productid").ToString()).ToLower() %>.html" title="<%# Eval("productName") %>">
                                                <img src="<%# Tiantu.DB.Common.SL.GetHttpImageURL(Eval("imageIcon")) %>" alt="<%# Eval("productName") %>" onload="javascript:DrawImage(this, 100, 100)" /></a>
                                        </div>
                                        <div class="con">
                                            <h4><a href="/proDe/<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("productid").ToString()).ToLower() %>.html" title="<%# Eval("productName") %>"><%# Tiantu.DB.Common.SL.CutString(Eval("productName"),30) %></a></h4>
                                            <div class="progressRow">
                                                <span class="progress"><b style='width: <%# GetProductQtyProgress(Eval("qtystatus")) %>%' class="progressLine"></b></span>
                                                <em><%# Eval("qtystatus") %></em>
                                            </div>
                                            <p>购买价格：¥ <%# Eval("point") %></p>
                                            <p>已售：<%# Eval("orderQty") %>人</p>
                                        </div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>


            </div>

        </div>

    </div>
</asp:Content>

