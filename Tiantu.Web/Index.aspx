<%@ Page Title="" Language="C#" MasterPageFile="~/MainUI.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

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
                    <li><a href="#">
                        <i>
                        <img src="/style/images/ui_weixin.png" /></i>微信关注</a>
                        <div class="followImg">
                            <img src="/style/images/follow_botewm.jpg" />
                            <p>扫一扫关注微信公众号</p>
                        </div>
                    </li>
                    <li><a href="#"><i>
                        <img src="/style/images/ui_weibo.png" /></i>微博关注</a>
                        <div class="followImgwb">
                            <img src="/style/images/follow_botewm.jpg" />
                            <p>扫一扫关注新浪微博</p>
                        </div>
                    </li>
                </ul>
            </div>
            <div class="language">
                <ul>
                    <li class="on"><a href="/index.aspx"">中文</a></li>
                    <li class="sn">|</li>
                    <li><a href="/en/index.aspx"">English</a></li>
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
                    <img src="/style/images/whale_font.png">
                </div>
                <div class="module cl">
                    <ul>
                        <li><a href="logistics.aspx">
                            <img src="/style/images/whale_1.png"><p>储运配</p>
                        </a></li>
                        <li><a href="business.aspx">
                            <img src="/style/images/whale_2.png"><p>产供销</p>
                        </a></li>
                        <li><a href="money.aspx">
                            <img src="/style/images/whale_3.png"><p>进销存</p>
                        </a></li>
                        <li><a href="IT.aspx">
                            <img src="/style/images/whale_4.png"><p>IT</p>
                        </a></li>
                        <li><a href="HR.aspx">
                            <img src="/style/images/whale_5.png"><p>管理外包</p>
                        </a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="second">
            <div class="wp">
                <div class="indnews">
                    <div class="title">最新消息</div>
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
                                                <h5><%# Eval("TITLE") %></h5>
                                                <p>
                                                    <%# Eval("SUBTITLE") %>
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
                        <img src="/style/images/investors.png"></a>
                </div>
                <div class="thimain">
                    <div class="l mainleft">
                        <ul>
                            <li class="cont_1"><a href="report.aspx">
                                <img src="/style/images/investors_1.png" width="65" height="65">
                                <p>定期报告>></p>
                            </a></li>
                            <li class="cont_2"><a href="company.aspx">
                                <img src="/style/images/investors_2.png" width="65" height="65">
                                <p>公司公告>></p>
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
                                <p>股票信息>></p>
                            </a></li>
                            <li class="cont_4"><a href="instructions.aspx">
                                <img src="/style/images/investors_4.png" width="65" height="65">
                                <p>招股说明书>></p>
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
                            <h5>天图文化</h5>
                            <p>广东天图物流股份有限公司坚持“敬天爱人，自强图新”的企业文化，</br>承诺协助政府履行相应的社会责任。</p>
                        </a>
                    </div>
                    <div class="main cl">
                        <ul>
                            <li class="cul_1"><a href="culture.aspx">
                                <div class="top"></div>
                                <div class="l pic">
                                    <img src="/style/images/culture_1.png">
                                </div>
                                <div class="cont">知天应命、顺势而为。怀敬畏之心，有所为有所不为。了解大势，关注环境。</div>
                            </a></li>
                            <li class="cul_2"><a href="culture.aspx">
                                <div class="top"></div>
                                <div class="l pic">
                                    <img src="/style/images/culture_2.png">
                                </div>
                                <div class="cont">树立公司与个人的诚信与声誉。关爱员工，创造良好的内部环境。团结伙伴、敬重对手、融和诚信。</div>
                            </a></li>
                            <li class="cul_3"><a href="culture.aspx">
                                <div class="top"></div>
                                <div class="l pic">
                                    <img src="/style/images/culture_3.png">
                                </div>
                                <div class="cont">树立信念，传递思想。激励同仁，自强不息。</div>
                            </a></li>
                            <li class="cul_4"><a href="culture.aspx">
                                <div class="top"></div>
                                <div class="l pic">
                                    <img src="/style/images/culture_4.png">
                                </div>
                                <div class="cont">保持饥渴感，永不自足。笃志好学，志存高远。以目标为导向，不断挑战新境界。</div>
                            </a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

