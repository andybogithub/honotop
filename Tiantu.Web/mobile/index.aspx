﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="mobile_index" %>
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <title>天图物流</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
    <meta content="yes" name="apple-mobile-web-app-capable" />
    <meta content="black" name="apple-mobile-web-app-status-bar-style" />
    <meta name="format-detection" content="telephone=no">
    <script src="js/jquery.min.js"></script>
    <script src="js/TouchSlide.1.0.js"></script>
    <script src="js/common.js"></script>
    <link rel="stylesheet" href="style/css/style.css">


</head>

<body>

    <div class="iWarpper">
        <header class="i_home">
            <h1 class="logo"><a href="index.aspx"><img src="style/images/logo.png" height="35"></a></h1>
            <div class="tToolBar">
                <div class="language cl">
                    <ul>
                        <li class="on"><a href="/mobile/index.aspx">中文</a></li>
                        <li claxianzss="sn">|</li>
                        <li><a href="/em/index.aspx">English</a></li>
                    </ul>
                </div>
                <div class="call"><a href="#"><img src="style/images/index_call.png" width="32"></a></div>

            </div>
        </header>

        <div class="i_banner">

            <div id="large-header" class="large-header">
                <canvas id="demo-canvas"></canvas>
            </div>
            <div class="bg"><img src="style/images/bannerbg1.jpg"></div>
            <div class="lineDiv"></div>
            <div class="imgDiv">
                <img class="ba_img1" src="style/images/light.png" height="105" />
                <img class="ba_img2" src="style/images/light.png" height="105" />
                <img class="ba_img3" src="style/images/light.png" height="105" />
                <img class="ba_img4" src="style/images/light.png" height="105" />
                <img class="ba_img5" src="style/images/light.png" height="105" />
                <img class="ba_img6" src="style/images/light.png" height="105" />
                <img class="ba_img7" src="style/images/light.png" height="105" />
                <img class="ba_img8" src="style/images/light.png" height="105" />
                <img class="ba_img9" src="style/images/light.png" height="105" />
                <img class="ba_img10" src="style/images/light.png" height="105" />
                <img class="ba_img11" src="style/images/light.png" height="105" />
                <img class="ba_img12" src="style/images/light.png" height="105" />
                <img class="ba_img13" src="style/images/light.png" height="105" />
                <img class="ba_img14" src="style/images/light.png" height="105" />
            </div>
        </div>


        <script src="/mobile/sideshow/TweenLite.min.js"></script>
        <script src="/mobile/sideshow/EasePack.min.js"></script>
        <script src="/mobile/sideshow/rAF.js"></script>
        <script src="/mobile/sideshow/demo-1.js"></script>



        <footer>
            <ul>
                <li><a href="about.aspx"><span><img src="style/images/footer_1.png"></span><b>关于天图</b></a></li>
                <li><a href="service.aspx"><span><img src="style/images/footer_2.png"></span><b>天图服务</b></a></li>
                <li><a href="case.aspx"><span><img src="style/images/footer_3.png"></span><b>我们的客户</b></a></li>
                <li><a href="report.aspx"><span><img src="style/images/footer_4.png"></span><b>投资者关系</b></a></li>
                <li><a href="news.aspx"><span><img src="style/images/footer_5.png"></span><b>新闻中心</b></a></li>
            </ul>
        </footer>

    </div>

</body>
</html>
