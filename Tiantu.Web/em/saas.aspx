﻿<%@ Page Title="" Language="C#" MasterPageFile="~/em/MobileEnUI.master" AutoEventWireup="true" CodeFile="saas.aspx.cs" Inherits="em_saas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="saasWap">
        <div class="title cl">
            <a href="saas.aspx">
                <h3>Introduction of Tiantu SaaS</h3>
            </a>
        </div>
        <div class="s_banner">
            <div id="large-header" class="slarge-header">
                <canvas id="demo-canvas"></canvas>
            </div>
            <div class="slineDiv"></div>
            <div class="simgDiv">
                <img class="ba_img1" src="/mobile/style/images/light.png" height="60" />
                <img class="ba_img2" src="/mobile/style/images/light.png" height="60" />
                <img class="ba_img3" src="/mobile/style/images/light.png" height="60" />
                <img class="ba_img4" src="/mobile/style/images/light.png" height="60" />
                <img class="ba_img5" src="/mobile/style/images/light.png" height="60" />
                <img class="ba_img6" src="/mobile/style/images/light.png" height="60" />
                <img class="ba_img7" src="/mobile/style/images/light.png" height="60" />
                <img class="ba_img8" src="/mobile/style/images/light.png" height="60" />
                <img class="ba_img9" src="/mobile/style/images/light.png" height="60" />
                <img class="ba_img10" src="/mobile/style/images/light.png" height="60" />
                <img class="ba_img11" src="/mobile/style/images/light.png" height="60" />
                <img class="ba_img12" src="/mobile/style/images/light.png" height="60" />
                <img class="ba_img13" src="/mobile/style/images/light.png" height="60" />
                <img class="ba_img14" src="/mobile/style/images/light.png" height="60" />
            </div>
        </div>
        <div class="main">
            <h5>Introduction of Tiantu SaaS</h5>
            <div class="video">
                <div id="a1" style="margin: 0 auto; width: 100%;"></div>
                <script type="text/javascript" src="/mobile/ckplayer/ckplayer.js" charset="utf-8"></script>
                <script type="text/javascript">
                    var flashvars = {
                        p: 1,
                        e: 1
                    };
                    var video = ['/jplayer/SAAS.mp4'];
                    var support = ['all'];
                    CKobject.embedHTML5('a1', 'ckplayer_a1', 300, 220, video, flashvars, support);
                </script>
            </div>
        </div>
    </div>
    <script src="/mobile/sideshow/TweenLite.min.js"></script>
    <script src="/mobile/sideshow/EasePack.min.js"></script>
    <script src="/mobile/sideshow/rAF.js"></script>
    <script src="/mobile/sideshow/demo-1.js"></script>

</asp:Content>

