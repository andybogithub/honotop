<%@ Page Title="" Language="C#" MasterPageFile="~/en/MainEnUI.master" AutoEventWireup="true" CodeFile="honor.aspx.cs" Inherits="en_honor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        navon(1);
    </script>



    <div class="tab">
        <div class="wp cl">
            <div class="curr">
                <span><a href="index.aspx">TIANTU LOGISTICS</a></span> > <span><a href="about.aspx">About Tiantu</a></span>
                > <span><a href="honor.aspx">Honor and Qualification</a></span>
            </div>
        </div>
    </div>
    <!--/header-->


    <div class="honor" style="background: #2f405e;">
        <div class="wp">
            <div class="honormain cl">
                <div class="l aboutnav">
                    <ul>
                        <li><a href="about.aspx">Chairman’s Message</a></li>
                        <li><a href="develop.aspx">Enterprise Milestone</a></li>
                        <li><a href="management.aspx">Management Team</a></li>
                        <li><a href="culture.aspx">Entrepreneurship</a></li>
                        <li><a href="responsibility.aspx">Social Responsibility</a></li>
                        <li class="on"><a href="honor.aspx">Honor and Qualification</a></li>
                    </ul>
                </div>
                <div class="l honorpic">
                    <div class="honorpicmain">
                        <div class="logo">
                            <img src="/style/images/en/honor_logo.jpg" />
                        </div>
                        <div class="team">
                            <div class="honorl"><a href="javascript:void(0)" class="prev"></a></div>
                            <div class="picmain">
                                <div class="piclist photoList">
                                    <asp:Literal ID="lblPhotoList" runat="server"></asp:Literal>
                                </div>
                            </div>
                            <div class="honorr"><a href="javascript:void(0)" class="next"></a></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <script type="text/javascript">
        jQuery(".team").slide({ mainCell: ".piclist", effect: "leftLoop", autoPlay: true });
    </script>
    <script type="text/javascript" src="/js/script.js"></script>
    <script type="text/javascript" src="/js/jquery.prettyPhoto.js"></script>
    <link href="/style/css/prettyPhoto.css" rel="stylesheet" type="text/css" />


</asp:Content>

