<%@ Page Title="" Language="C#" MasterPageFile="~/MainUI.master" AutoEventWireup="true" CodeFile="transport.aspx.cs" Inherits="transport" %>

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

    <div class="service_banner">
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
                                    <li><a href="logistics.aspx">储（仓储）</a></li>
                                    <li class=" on"><a href="transport.aspx">运配（运输及配送）</a></li>
                                </ul>
                            </div>
                            <div class="l title">
                                <h5><span>运</span>输网<span>络</span></h5>
                                <p>
                                    打通全国各陆运集散中心、空运集散中心、水运港,干线、零担、城配车辆全国联动,形成立体式运输网络
                                    <br />
                                   Through the land distribution center, cargo distribution center, shipping port, trunk, LTL, 
                                    city vehicles with the linkage, forming a three-dimensional transportation network
                                </p>
                            </div>
                        </div>
                        <div class="logmainbot">
                            <img src="/style/images/logistics_1.png" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="logtype wp">
            <div class="title">
                <h5>产品</h5>
            </div>
            <div class="tranport cl">
                <ul>
                    <li>
                        <div class="conttop cont_1">
                            <h5>普货运输及配送</h5>
                            <p>全国干线，自有资源落地配、区域配送</p>
                        </div>
                        <div class="cont_pic">
                            <asp:Literal ID="lblPic1" runat="server"></asp:Literal>
                        </div>
                    </li>
                    <li>
                        <div class="conttop cont_2">
                            <h5>控温运输及配送</h5>
                            <p>食品、医药</p>
                        </div>
                        <div class="cont_pic">

                            <asp:Literal ID="lblPic2" runat="server"></asp:Literal>
                        </div>
                    </li>
                    <li class="last">
                        <div class="conttop cont_3">
                            <h5>大型工程项目运输</h5>
                            <p>冷藏、冷冻、恒温、阴凉等各类型仓库，采用先进的控温设备，提供稳定、安全的存储空间。</p>
                        </div>
                        <div class="cont_pic">

                            <asp:Literal ID="lblPic3" runat="server"></asp:Literal>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>

