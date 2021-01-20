<%@ Page Title="" Language="C#" MasterPageFile="~/en/MainEnUI.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="en_Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
        $(function () {
            $(window).resize(function () {
                var vw = $(this).width();
                $('.i_banner').width(vw);

            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        navon(0);
    </script>


    <div class="m-tab">
        <div class="wp cl">
            <div class="follow_w">
                <ul>
                    <li><a href="#"><i>
                        <img src="/style/images/ui_weixin.png" /></i>Wechat</a>
                        <div class="followImg">
                            <img src="/style/images/follow_botewm.jpg" />
                            <p>Follow us</p>
                        </div>
                    </li>
                    <li><a href="#"><i>
                        <img src="/style/images/ui_weibo.png" /></i>Weibo</a>
                        <div class="followImgwb">
                            <img src="/style/images/follow_botewm.jpg" />
                            <p>Follow us</p>
                        </div>
                    </li>
                </ul>
            </div>
            <div class="language">
                <ul>
                    <li><a href="/index.aspx">中文</a></li>
                    <li class="sn">|</li>
                    <li class="on"><a href="/en/index.aspx">English</a></li>
                </ul>
            </div>
        </div>
    </div>
    <!--/header-->
    <div class="i_banner">
        <div class="photo">
            <div class="bg">
                <img src="/style/images/bannerbg.jpg" width="100%">
            </div>
        </div>
        <div id="large-header" class="large-header">
            <canvas id="demo-canvas"></canvas>
        </div>
        <div class="lineDiv"></div>
        <div class="imgDiv">
            <img class="ba_img1" src="/style/images/light3.png" />
            <img class="ba_img2" src="/style/images/light3.png" />
            <img class="ba_img3" src="/style/images/light3.png" />
            <img class="ba_img4" src="/style/images/light3.png" />
            <img class="ba_img5" src="/style/images/light3.png" />
            <img class="ba_img6" src="/style/images/light3.png" />
            <img class="ba_img7" src="/style/images/light3.png" />
            <img class="ba_img8" src="/style/images/light3.png" />
            <img class="ba_img9" src="/style/images/light3.png" />
            <img class="ba_img10" src="/style/images/light3.png" />
            <img class="ba_img11" src="/style/images/light3.png" />
            <img class="ba_img12" src="/style/images/light3.png" />
            <img class="ba_img13" src="/style/images/light3.png" />
            <img class="ba_img14" src="/style/images/light3.png" />
        </div>
    </div>


    <script src="/sideshow/TweenLite.min.js"></script>
    <script src="/sideshow/EasePack.min.js"></script>
    <script src="/sideshow/rAF.js"></script>
    <script src="/sideshow/demo-1.js"></script>
    <!--/ banner-->

    <div class="container">
        <div class="first">
            <div class="wp">
                <div class="walue">
                    <img src="/style/images/whale.jpg">
                </div>
                <div class="text">
                    <img src="/style/images/en/whale_font.png">
                </div>
                <div class="module cl">
                    <ul>
                        <li><a href="logistics.aspx">
                            <img src="/style/images/whale_1.png"><p>Logistics</p>
                        </a></li>
                        <li><a href="business.aspx">
                            <img src="/style/images/whale_2.png"><p>Trade Flow</p>
                        </a></li>
                        <li><a href="money.aspx">
                            <img src="/style/images/whale_3.png"><p>Financial</p>
                        </a></li>
                        <li><a href="IT.aspx">
                            <img src="/style/images/whale_4.png"><p>IT</p>
                        </a></li>
                        <li><a href="HR.aspx">
                            <img src="/style/images/whale_5.png"><p>Human Resources</p>
                        </a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="second">
            <div class="wp">
                <div class="indnews">
                    <div class="title">Latest News</div>
                    <div class="indnewsmain">
                        <div class="newspic">
                            <ul class="piclist">
                                <asp:Repeater ID="RepeaterListNews" runat="server">
                                    <ItemTemplate>
                                        <li><a href="newsde.aspx?no=<%# Eval("NEWSID") %>">
                                            <div class="cont_<%# Container.ItemIndex%4+1 %>">
                                                <img src="<%# Eval("IMGURL") %>" width="220" height="280">
                                            </div>
                                            <div class="picmain">
                                                <h5><%# Eval("TITLE_EN") %></h5>
                                                <p>
                                                    <%# Eval("SUBTITLE_EN") %>
                                                </p>
                                            </div>
                                        </a>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <div class="pageBtn">
                            <span class="prev"></span>
                            <span class="next"></span>
                        </div>
                    </div>
                 <script type="text/javascript">                        
                        $(document).ready(function () {                    
                            $(".indnewsmain ul li").clone(true).appendTo(".indnewsmain ul");
                            $(".indnewsmain ul li").clone(true).appendTo(".indnewsmain ul");
                            jQuery(".indnewsmain").slide({
                                mainCell: ".piclist",
                                effect: "left", scroll: 4, vis: 4, autoPage: true
                            });
                        });
                    </script>
                </div>

            </div>
        </div>
        <div class="third">
            <div class="wp">
                <div class="thitop">
                    <a href="investors.aspx">
                        <img src="/style/images/en/investors.png"></a>
                </div>
                <div class="thimain">
                    <div class="l mainleft">
                        <ul>
                            <li class="cont_1"><a href="report.aspx">
                                <img src="/style/images/investors_1.png" width="65" height="65">
                                <p>Periodical reports>></p>
                            </a></li>
                            <li class="cont_2"><a href="company.aspx">
                                <img src="/style/images/investors_2.png" width="65" height="65">
                                <p>Company announcement>></p>
                            </a></li>
                        </ul>
                    </div>
                    <div class="l mainvideo">
                        <a href="stock.aspx">
                            <img src="/style/images/video_1.jpg" width="680" height="330"><div class="video_icon">
                                <img src="/style/images/vedio_icon.png" height="90" width="90">
                            </div>
                        </a>
                    </div>
                    <div class="l mainright">
                        <ul>
                            <li class="cont_3"><a href="stock.aspx">
                                <img src="/style/images/investors_3.png" width="65" height="65">
                                <p>Stock information>></p>
                            </a></li>
                            <li class="cont_4"><a href="instructions.aspx">
                                <img src="/style/images/investors_4.png" width="65" height="65">
                                <p>Prospectus>></p>
                            </a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <div class="fourth">
            <div class="wp">
                <div class="indculture">
                    <div class="title">
                        <a href="culture.aspx">
                            <h5>Entrepreneurship</h5>
                            <p>
                                To respect, cherish, self-improve and innovate.
                            </p>
                        </a>
                    </div>
                    <div class="main cl">
                        <ul>
                            <li class="cul_1"><a href="culture.aspx">
                                <div class="top"></div>
                                <div class="l pic">
                                    <img src="/style/images/en/culture_1.png">
                                </div>
                                <div class="cont">To respect; morality differentiation between "good" (or right) and "bad" (or wrong)</div>
                            </a></li>
                            <li class="cul_2"><a href="culture.aspx">
                                <div class="top"></div>
                                <div class="l pic">
                                    <img src="/style/images/en/culture_2.png">
                                </div>
                                <div class="cont">To cherish; integrity  between employees, business partners and even competitors</div>
                            </a></li>
                            <li class="cul_3"><a href="culture.aspx">
                                <div class="top"></div>
                                <div class="l pic">
                                    <img src="/style/images/en/culture_3.png">
                                </div>
                                <div class="cont">To self-improve; embrace a willing to learn attitude and keep up the pace of progress</div>
                            </a></li>
                            <li class="cul_4"><a href="culture.aspx">
                                <div class="top"></div>
                                <div class="l pic">
                                    <img src="/style/images/en/culture_4.png">
                                </div>
                                <div class="cont">To innovate; application of better solutions that meet new requirements, inarticulated needs, or existing market needs</div>
                            </a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

