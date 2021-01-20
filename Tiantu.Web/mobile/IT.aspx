<%@ Page Title="" Language="C#" MasterPageFile="~/mobile/MobileUI.master" AutoEventWireup="true" CodeFile="IT.aspx.cs" Inherits="mobile_IT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="itWap">
        <div class="title cl">
            <a href="IT.html">
                <h3>天图IT</h3>
            </a>
        </div>
        <div class="newstop cl">
            <ul>
                <li class="on"><a href="#">ERP</a></li>
                <li><a href="#">TMS</a></li>
                <li><a href="#">WMS</a></li>
                <li><a href="#">系统结算</a></li>
            </ul>
        </div>
        <div class="main">
            <div class="tabMain">
                <%= Tinatu.DB.DBHelper.GetAboutUs(3).CONTENTS %>
            </div>

            <div class="tabMain" style="display: none;">
                <%= Tinatu.DB.DBHelper.GetAboutUs(4).CONTENTS %>
            </div>

            <div class="tabMain" style="display: none;">
                <%= Tinatu.DB.DBHelper.GetAboutUs(5).CONTENTS %>
            </div>

            <div class="tabMain" style="display: none;">
                <%= Tinatu.DB.DBHelper.GetAboutUs(6).CONTENTS %>
            </div>

        </div>
        <script>
            $(function () {
                $(".newstop li").on("click", function () {
                    var _index = $(this).index();
                    $(this).addClass("on").siblings().removeClass("on");
                    $(".main .tabMain").hide().eq(_index).show();
                });
            })
        </script>


    </div>
</asp:Content>

