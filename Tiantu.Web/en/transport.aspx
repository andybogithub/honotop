<%@ Page Title="" Language="C#" MasterPageFile="~/en/MainEnUI.master" AutoEventWireup="true" CodeFile="transport.aspx.cs" Inherits="en_transport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        navon(2);
    </script>

    <div class="tab">
        <div class="wp cl">
            <div class="curr">
                <span><a href="index.aspx">TIANTU LOGISTICS</a></span> > <span><a href="service.aspx">Our Service</a></span>
                > <span><a href="logistics.aspx">Logistics</a></span>
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

    <div class="container">
        <div class="wp">
            <div class="srrvinav cl ">
                <ul>
                    <li class="cont_1"><a href="service.aspx">SaaS </a></li>
                    <li class="cont_2"><a href="logistics.aspx">Logistics  </a></li>
                    <li class="cont_3"><a href="business.aspx">Trade Flow  </a></li>
                    <li class="cont_4"><a href="money.aspx">Financial  </a></li>
                    <li class="cont_1"><a href="IT.aspx">IT</a></li>
                    <li class="cont_2"><a href="HR.aspx">Human Resources</a></li>
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
                                    <li><a href="logistics.aspx">W (Warehouses)</a></li>
                                    <li class="tras on"><a href="transport.aspx">Transportation and Distribution</a></li>
                                </ul>
                            </div>
                            <div class="l title">
                                <h5><span>Transportation and distribution network</span></h5>
                                <p>                                  
                                    A transportation network，organically connecting 19 distribution hubs with more than 900 trucks.
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
                <h5>Product</h5>
            </div>
            <div class="tranport cl">
                <ul>
                    <li>
                        <div class="conttop cont_1">
                            <h5>Distribution service and distribution</h5>
                            <p>Transportation and distribution for general cargos; service scope includes nationwide truck routes, local and regional distribution, and courier services</p>
                        </div>
                        <div class="cont_pic">
                            <asp:Literal ID="lblPic1" runat="server"></asp:Literal>
                        </div>
                    </li>
                    <li>
                        <div class="conttop cont_2">
                            <h5>Temperature-controlled transportation and distribution </h5>
                            <p>Food and medicine</p>
                        </div>
                        <div class="cont_pic">

                            <asp:Literal ID="lblPic2" runat="server"></asp:Literal>
                        </div>
                    </li>
                    <li class="last">
                        <div class="conttop cont_3">
                            <h5>Oversized and project cargo transportation</h5>
                            <p>Storage of cold storage, refrigeration, constant temperature,  provide a stable and safe storage space.</p>
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

