<%@ Page Title="" Language="C#" MasterPageFile="~/em/MobileEnUI.master" AutoEventWireup="true" CodeFile="newsde.aspx.cs" Inherits="em_newsde" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="newsWap">

        <div class="title cl">
            <a href="news.aspx">
                <h3>News Detail</h3>
            </a>
        </div>
        <div class="main">
            <div class="newsde">
                <h5><%=pageModel.TITLE_EN %></h5>
                <div class="time"><%=pageModel.PUBDATE.ToString("yyyy/MM/dd") %></div>
               <%=pageModel.CONTENTS_EN %>
            </div>
        </div>
    </div>
</asp:Content>

