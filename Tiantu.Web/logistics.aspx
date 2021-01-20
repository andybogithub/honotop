<%@ Page Title="" Language="C#" MasterPageFile="~/MainUI.master" AutoEventWireup="true" CodeFile="logistics.aspx.cs" Inherits="logistics" %>

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
                > <span><a href="logistics.aspx">物流模块</a></span>
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
        <div class="logistics">
            <div class="logisticstop">
                <div class="wp">
                    <div class="main">
                        <div class="logmaintop cl">
                            <div class="l mainnav">
                                <ul>
                                    <li class=" on"><a href="logistics.aspx">储（仓储）</a></li>
                                    <li><a href="transport.aspx">运配（运输及配送）</a></li>
                                </ul>
                            </div>
                            <div class="l title">
                                <h5><span>仓</span>库分<span>布</span></h5>
                                <p>13个城市，联动全国仓储资源，业务覆盖32个省份 <br/>Covering 13 cities, 32 warehouses </p>
                            </div>
                        </div>
                        <div class="logmainbot">
                            <img src="/style/images/logistics_2.png" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="logtype wp">
            <div class="title">
                <h5><span>仓</span>库分<span>类</span></h5>
            </div>
            <div class="main cl">
                <ul>
                    <li class="cont_1">
                        <div class="contop">项目定制仓</div>
                        <div class="conlunbo">
                            <div class="focusBox">
                                <ul class="pic">
                                    <asp:Repeater ID="RepeaterList1" runat="server">
                                        <ItemTemplate>
                                            <li>
                                                <img src="<%# Eval("IMGURL") %>" width="260" height="310" />
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                                <a class="prev" href="javascript:void(0)"></a>
                                <a class="next" href="javascript:void(0)"></a>
                            </div>
                        </div>
                        <div class="conword">
                            <p>项目型、定制型仓库，为有特殊要求的客户度身定制仓储场地及方案，提供合乎要求的设备、系统及顾问式供应链服务。</p>
                        </div>
                    </li>
                    <li class="cont_2">
                        <div class="contop">电商仓</div>
                        <div class="conlunbo">
                            <div class="focusBox">
                                <ul class="pic">
                                    <asp:Repeater ID="RepeaterList2" runat="server">
                                        <ItemTemplate>
                                            <li>
                                                <img src="<%# Eval("IMGURL") %>" width="260" height="310" />
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                                <a class="prev" href="javascript:void(0)"></a>
                                <a class="next" href="javascript:void(0)"></a>
                            </div>
                        </div>
                        <div class="conword">
                            <p>通用型标准仓库，适用于各类产品储存。即约即进仓，满足各类电商企业快进快出的需求。</p>
                        </div>
                    </li>
                    <li class="cont_3">
                        <div class="contop">恒温仓</div>
                        <div class="conlunbo">
                            <div class="focusBox">
                                <ul class="pic">
                                    <asp:Repeater ID="RepeaterList3" runat="server">
                                        <ItemTemplate>
                                            <li>
                                                <img src="<%# Eval("IMGURL") %>" width="260" height="310" />
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                                <a class="prev" href="javascript:void(0)"></a>
                                <a class="next" href="javascript:void(0)"></a>
                            </div>
                        </div>
                        <div class="conword">
                            <p>冷藏、冷冻、阴凉等各类型仓库，采用先进的控温设备，提供稳定、安全的存储空间。</p>
                        </div>
                    </li>
                </ul>
            </div>
            <script type="text/javascript">

                jQuery(".focusBox").slide({ mainCell: ".pic", effect: "fold", autoPlay: true, delayTime: 600, trigger: "click" });
            </script>
        </div>
    </div>

</asp:Content>

