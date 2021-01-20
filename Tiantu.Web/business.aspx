<%@ Page Title="" Language="C#" MasterPageFile="~/MainUI.master" AutoEventWireup="true" CodeFile="business.aspx.cs" Inherits="business" %>

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
                > <span><a href="business.aspx">商流模块</a></span>
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
        <div class="business">
            <div class="wp">
                <div class="main">
                    <div class="bustop">
                        <p>
                            围绕商品流通，利用天图储运配资源体系，<br />
                            构建从原产地/原厂到大B端的产供销链条，重构中国供应链。
                        </p>
                    </div>
                    <div class="buspic">
                        <img src="/style/images/business_1.png" />
                    </div>
                    <div class="busbot cl">
                        <ul>
                            <%--  <li>
                                <div class="top">
                                    <img src="/style/images/business_2.png" width="50" height="50" />
                                    <h5>跨境</h5>
                                </div>
                                <p>
                                    跨境供应链服务包括，跨境供应链品牌采购/代运营，跨境供应链物流配套服务，境内/境外渠道分销和跨境供应链金融服务，
									从而为中小型B端客户提供跨境的全方位供应链解决方案，并为正在外贸转型的中小型B端客户提供互联网+的跨境电商通道。
                                </p>                   
                            </li>
                            <li>
                                <div class="top">
                                    <img src="/style/images/business_3.png" width="50" height="50" />
                                    <h5>农产品</h5>
                                </div>
                                <p>
                                    作为非标农品全供应链解决方案专家，创新性提出FBB模式，通过整合B端分散的采购需求，
									并予以集约化，去掉原有复杂多层的中间环节，实现从产地F端到天图，从天图物流直达B端，打造高效的FBB农品产业链。
                                </p>
                            </li>--%>
                          <li>
                                <div class="top">
                                    <img src="/style/images/business_4.png" width="50" height="50" />
                                    <h5>家电3C</h5>
                                </div>
                                <p>定位为专业的电商集成服务，着重为家电、3C领域的品牌商、经销商提供完整的供应链解决方案，具体的服务内容有仓储、物流、售后、代运营等。</p>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

