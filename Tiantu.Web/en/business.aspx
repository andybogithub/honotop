<%@ Page Title="" Language="C#" MasterPageFile="~/en/MainEnUI.master" AutoEventWireup="true" CodeFile="business.aspx.cs" Inherits="en_business" %>

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
                > <span><a href="business.aspx">Trade Flow</a></span>
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
        <div class="business">
            <div class="wp">
                <div class="main">
                    <div class="bustop">
                        <p>
                            In the circulation of commodities, eliminate unnecessary segments and provide a comprehensive total solution from manufacturers to distributors.
                        </p>
                    </div>
                    <div class="buspic">
                        <img src="/style/images/business_1.png" />
                    </div>
                    <div class="busbot cl">
                        <ul>
                              <%--<li>
                                <div class="top">
                                    <img src="/style/images/business_2.png" width="50" height="50" />
                                    <h5>Cross-Border Supply Chain</h5>
                                </div>
                                <p>
                                    Cross-Border Supply Chain covers diversified products and services along with the international supply chain, 
                                    such as global sourcing, logistics, distribution and financing services, and to provide the “Internet+” total solution and shortcut 
                                    for SME towards the international E-commerce retail market.           
                                </p>
                            </li>
                            <li>
                                <div class="top">
                                    <img src="/style/images/business_3.png" width="50" height="50" />
                                    <h5>Agricultural Products</h5>
                                </div>
                                <p>
                                    As an expert in total supply chain solutions for agricultural products, Tiantu innovatively create Farmer to Business (“F2B”) mode.
                                     Consolidate demand from distributors and purchase directly from farmer side, eliminating multiple middlemen and creating an efficient “F2B” circulation for agricultural products. 
                                </p>
                            </li>--%>
                          <li>
                                <div class="top">
                                    <img src="/style/images/business_4.png" width="50" height="50" />
                                    <h5>Appliances 3C</h5>
                                </div>
                                <p>
                                    Focus on providing total supply chain solutions for home appliance products in E-commerce for brand traders and distributors.
                                     Service scope includes inventory management, logistics, sales channels, after-sales service and financial support, etc.
                                </p>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

