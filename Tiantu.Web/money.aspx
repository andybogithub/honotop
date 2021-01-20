<%@ Page Title="" Language="C#" MasterPageFile="~/MainUI.master" AutoEventWireup="true" CodeFile="money.aspx.cs" Inherits="money" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        navon(2);
    </script>


    <div class="tab">
        <div class="wp cl">
            <div class="curr">
                <span><a href="index.aspx">天图物流</a></span> > <span><a href="service.aspx">天图服务</a></span>
                > <span><a href="money.aspx">供应链模块</a></span>
            </div>
        </div>
    </div>

   <div class="service_banner" style="display:none;">
        <div class="photo">
            <div class="bg">
                <img src="/style/images/service_banner.jpg" width="100%" />
            </div>
        </div>
        <div id="large-header" class="large-header">
            <canvas id="demo-canvas"></canvas>
        </div>
        <div class="servicelineDiv"></div>
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
        <div class="wp">
            <div class="srrvinav cl ">
                <ul>
                    <li class="cont_1"><a href="service.aspx">天图SaaS介绍 </a></li>
                    <li class="cont_2"><a href="logistics.aspx">物流模块  </a></li>
                    <li class="cont_3"><a href="business.aspx">商流模块  </a></li>
                    <li class="cont_4"><a href="money.aspx">供应链模块  </a></li>
                    <li class="cont_1"><a href="IT.aspx">IT</a></li>
                    <li class="cont_2"><a href="HR.aspx">人力资源及管理</a></li>
                </ul>
            </div>
        </div>
        <div class="money wp">
            <div class="title">
                <%--<h5><span>金</span>融模<span>块</span></h5>--%>
            </div>
            <div class="main">
                <div class="monstock cont_2" style="display: none;">
                    <div class="title">进货采购</div>
                    <div class="stockpic">
                        <ul class="piclist">
                            <asp:Repeater ID="RepeaterList1" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <img src="<%# Eval("IMGURL") %>" width="260" height="310" />
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
                <div class="monstock cont_1" style="display: none;">
                    <div class="title">销售</div>
                    <div class="stockpic">
                        <ul class="piclist">
                            <asp:Repeater ID="RepeaterList2" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <img src="<%# Eval("IMGURL") %>" width="260" height="310" />
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
                <div class="monstock cont_4" style="display: none;">
                    <div class="title">库存</div>
                    <div class="stockpic">
                        <ul class="piclist">
                            <asp:Repeater ID="RepeaterList3" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <img src="<%# Eval("IMGURL") %>" width="260" height="310" />
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
                <div class="moneybot">                 
                     <%=pageModel.CONTENTS %>
                </div>
            </div>
        </div>
        <script type="text/javascript">jQuery(".monstock").slide({
    mainCell: ".piclist",
    effect: "left", scroll: 4, vis: 4, autoPage: true
});</script>
    </div>
</asp:Content>

