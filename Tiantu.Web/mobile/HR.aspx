<%@ Page Title="" Language="C#" MasterPageFile="~/mobile/MobileUI.master" AutoEventWireup="true" CodeFile="HR.aspx.cs" Inherits="mobile_HR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="hrWap">
        <div class="title cl">
            <a href="HR.html">
                <h3>天图人力资源及管理</h3>
            </a>
        </div>

        <div class="main cl">
            <%=pageModel.CONTENTS %>
        </div>
    </div>
</asp:Content>

