<%@ Page Title="" Language="C#" MasterPageFile="~/en/MainEnUI.master" AutoEventWireup="true" CodeFile="logistics.aspx.cs" Inherits="en_logistics" %>

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
                                    <li class=" on"><a href="logistics.aspx">W (Warehouses)</a></li>
                                    <li class="tras"><a href="transport.aspx">Transportation and Distribution</a></li>
                                </ul>
                            </div>
                            <div class="l title">
                                <h5><span>Warehouse Layout</span></h5>
                                <p>Covering 18 cities, 38 warehouses , 420,000 ㎡ storage area</p>
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
                <h5><span>Warehouse Type</span></h5>
            </div>
            <div class="main cl">
                <ul>
                    <li class="cont_1">
                        <div class="contop">Customized warehouses</div>
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
                            <p>Customized warehouses are project based, in compliance with customers'
                               specific requirements to provide suitable facilities, systems and suggestions as a total supply chain solution.</p>
                        </div>
                    </li>
                    <li class="cont_2">
                        <div class="contop">E-commerce Warehouse</div>
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
                            <p>Standard warehouses for general products. Warehouse available once orders received, thus fulfilling the demand of 
                                high velocity in E-commerce business. </p>
                        </div>
                    </li>
                    <li class="cont_3">
                        <div class="contop">Temperature-controlled warehouses</div>
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
                            <p>All kinds of temperature-controlled warehouses, including refrigerating, freezing, constant temperature and cool ones, 
                                to provide stable and safe storage space. </p>
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

