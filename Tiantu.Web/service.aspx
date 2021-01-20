<%@ Page Title="" Language="C#" MasterPageFile="~/MainUI.master" AutoEventWireup="true" CodeFile="service.aspx.cs" Inherits="service" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/jplayer/jquery.jplayer.min.js"></script>
    <link href="/jplayer/blue.monday/jplayer.blue.monday.css" rel="stylesheet" type="text/css" />

    <script>
        function mediaPlay(id, src, btn, w, h, classN) {
            $(id).jPlayer({
                ready: function () {
                    $(this).jPlayer("setMedia", {
                        m4v: src
                    });
                },
                swfPath: "jplayer",
                supplied: "m4v",
                cssSelectorAncestor: btn,
                size: {
                    width: w,
                    height: h,
                    cssClass: classN
                },
                useStateClassSkin: true,
                autoBlur: false,
                smoothPlayBar: true,
                keyEnabled: true,
                remainingDuration: true,
                toggleDuration: true
            });
        }

        $(function () {
            $(window).resize(function () {
                var vw = $(this).width();
                $('.service_banner').width(vw);

            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        navon(2);
    </script>
    <div class="tab">
        <div class="wp cl">
            <div class="curr">
                <span><a href="index.aspx">天图物流</a></span> > <span><a href="service.aspx">天图服务</a></span>
            </div>
        </div>
    </div>
    <!--/header-->
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

    <div class="container wp">
        <div class="srrvinav cl">
            <ul>
                <li class="cont_1"><a href="service.aspx">天图SaaS介绍 </a></li>
                <li class="cont_2"><a href="logistics.aspx">物流模块  </a></li>
                <li class="cont_3"><a href="business.aspx">商流模块  </a></li>
                <li class="cont_4"><a href="money.aspx">供应链模块  </a></li>
                <li class="cont_1"><a href="IT.aspx">IT</a></li>
                <li class="cont_2"><a href="HR.aspx">人力资源及管理</a></li>
            </ul>
        </div>
        <div class="service">          
            <div class="introduce">
				<h5>天图SaaS介绍</h5>			
				<div class="saasvideo">
					<div class="a">
						<div id="amedia" class="tmedia">
							<script type="text/javascript">
							    $(function () {
							        mediaPlay("#media_ba", "/jplayer/SAAS.mp4", "#media_ba_con", "1200px", "600px", "jp-video-v2");
							    });
	                        </script>
	                        <div id="media_ba_con" class="jp-video jp-video-v1" role="application" aria-label="media player">
	                            <div class="jp-type-single">
	                                <div id="media_ba" class="jp-jplayer"></div>
	                                <div class="jp-gui">
	                                    <div class="jp-video-play">
	                                        <button class="jp-video-play-icon" role="button" tabindex="0">play</button>
	                                    </div>
	                                    <div class="jp-interface">
	                                        <div class="jp-progress">
	                                            <div class="jp-seek-bar">
	                                                <div class="jp-play-bar"></div>
	                                            </div>
	                                        </div>
	                                        <div class="jp-current-time" role="timer" aria-label="time">&nbsp;</div>
	                                        <div class="jp-duration" role="timer" aria-label="duration">&nbsp;</div>
	                                        <div class="jp-controls-holder">
	                                            <div class="jp-controls">
	                                                <button class="jp-play" role="button" tabindex="0">play</button>
	                                                <button class="jp-stop" role="button" tabindex="0">stop</button>
	                                            </div>
	                                            <div class="jp-volume-controls">
	                                                <button class="jp-mute" role="button" tabindex="0">mute</button>
	                                                <button class="jp-volume-max" role="button" tabindex="0">max volume</button>
	                                                <div class="jp-volume-bar">
	                                                    <div class="jp-volume-bar-value"></div>
	                                                </div>
	                                            </div>
	                                            <div class="jp-toggles">
	                                                <button class="jp-repeat" role="button" tabindex="0">repeat</button>
	                                                <button class="jp-full-screen" role="button" tabindex="0">full screen</button>
	                                            </div>
	                                        </div>
	                                    </div>
	                                </div>
	                            </div>
	                        </div>
						</div>
					</div>
				</div>
			
			</div>

        </div>
    </div>
</asp:Content>

