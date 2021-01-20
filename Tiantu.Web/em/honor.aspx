<%@ Page Title="" Language="C#" MasterPageFile="~/em/MobileEnUI.master" AutoEventWireup="true" CodeFile="honor.aspx.cs" Inherits="em_honor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="honorWap">
        <div class="title cl">
            <a href="honor.aspx">
                <h3>Honor and Qualification</h3>
            </a>
        </div>
        <div class="abouttop cl">
            <ul>
                <li><a href="about.aspx">Chairman’s Message</a></li>
                <li><a href="develop.aspx">Enterprise Milestone</a></li>
                <li><a href="management.aspx">Management Team</a></li>
                <li><a href="culture.aspx">Entrepreneurship</a></li>
                <li><a href="responsibility.aspx">Social Responsibility</a></li>
                <li class="on"><a href="honor.aspx">Honor and Qualification</a></li>
            </ul>
        </div>
        <div class="main cl">
            <ul>
                <asp:Literal ID="lblPhotoList" runat="server"></asp:Literal>
            </ul>
        </div>
    </div>
</asp:Content>

