<%@ Page Title="" Language="C#" MasterPageFile="~/mobile/MobileUI.master" AutoEventWireup="true" CodeFile="newsde.aspx.cs" Inherits="mobile_newsde" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="newsWap">

        <div class="title cl">
            <a href="news.aspx">
                <h3>新闻中心详情</h3>
            </a>
        </div>
        <div class="main">
            <div class="newsde">
                <h5><%=pageModel.TITLE %></h5>
                <div class="time">发布时间：<%=pageModel.PUBDATE.ToString("yyyy-MM-dd") %></div>
               <%=pageModel.CONTENTS %>
            </div>
        </div>
    </div>
</asp:Content>

