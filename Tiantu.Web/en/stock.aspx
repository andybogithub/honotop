<%@ Page Title="" Language="C#" MasterPageFile="~/en/MainEnUI.master" AutoEventWireup="true" CodeFile="stock.aspx.cs" Inherits="en_stock" %>

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

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        navon(4);
    </script>

    <div class="tab">
        <div class="wp cl">
            <div class="curr">
                <span><a href="index.aspx">TIANTU LOGISTICS</a></span> > <span><a href="investors.aspx">Investor Relations</a></span>
                > <span><a href="stock.aspx">Stock information</a></span>
            </div>
        </div>
    </div>

    <div class="container wp">
        <div class="stock">
            <div class="stockvideo">

                <div id="tmedia" class="tmedia">
                    <script type="text/javascript">
                        $(function () {
                            mediaPlay("#media_ba", "/jplayer/tiantu.mp4", "#media_ba_con", "1200px", "600px", "jp-video-v2");
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
                <div class="insvesnav cl">
                    <ul>
                        <li class="cont_1"><a href="report.aspx">Periodical reports</a></li>
                        <li class="cont_2"><a href="company.aspx">Company announcement</a></li>
                        <li class="cont_3"><a href="stock.aspx">Stock information</a></li>
                        <li class="cont_4"><a href="instructions.aspx">Prospectus</a></li>
                    </ul>
                </div>

                <div class="stocknav cl">
                    <div class="l stockleft" style="display: none;">
                        <ul>
                            <asp:Literal ID="lblSubmenu" runat="server"></asp:Literal>
                        </ul>
                    </div>
                    <div class="stockmain">
                        <div class="main">
                            <%=pageModel.CONTENTS_EN %>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>

