<%@ Page Title="" Language="C#" MasterPageFile="~/en/MainEnUI.master" AutoEventWireup="true" CodeFile="IT.aspx.cs" Inherits="en_IT" %>

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
                > <span><a href="IT.aspx">IT</a></span>
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
                    <li class="cont_1"><a href="service.aspx">SaaS </a></li>
                    <li class="cont_2"><a href="logistics.aspx">Logistics  </a></li>
                    <li class="cont_3"><a href="business.aspx">Trade Flow  </a></li>
                    <li class="cont_4"><a href="money.aspx">Financial  </a></li>
                    <li class="cont_1"><a href="IT.aspx">IT</a></li>
                    <li class="cont_2"><a href="HR.aspx">Human Resources</a></li>
                </ul>
            </div>
        </div>
        <div class="it wp">
            <div class="main cl">
                <div class="l itnav">
                    <ul>
                        <li class="on nali_1"><a href="javascript:void(0)">ERP</a></li>
                        <li class="nali_2"><a href="javascript:void(0)">TMS</a></li>
                        <li class="nali_3"><a href="javascript:void(0)">WMS</a></li>
                        <li class="nali_4"><a href="javascript:void(0)">Settlement system</a></li>
                    </ul>
                </div>
                <div class="l tabMain " style="display: block">
                    <div class="main">
                        <%= Tinatu.DB.DBHelper.GetAboutUs(3).CONTENTS_EN %>
                    </div>
                </div>
                <div class="l hrright tabMain " style="display: none">
                    <div class="main cl">
                        <%= Tinatu.DB.DBHelper.GetAboutUs(4).CONTENTS_EN %>
                    </div>
                </div>
                <div class="l hrright tabMain " style="display: none">
                    <div class="main">
                        <%= Tinatu.DB.DBHelper.GetAboutUs(5).CONTENTS_EN %>
                    </div>
                </div>
                <div class="l hrright tabMain " style="display: none">
                    <div class="main">
                        <%= Tinatu.DB.DBHelper.GetAboutUs(6).CONTENTS_EN %>
                    </div>
                </div>
            </div>
            <script>
                $(function () {
                    $(".it .itnav li").on("click", function () {
                        var _index = $(this).index();
                        $(this).addClass("on").siblings().removeClass("on");
                        $(".it .tabMain").hide().eq(_index).show();
                    })
                })
            </script>
        </div>
    </div>
</asp:Content>

