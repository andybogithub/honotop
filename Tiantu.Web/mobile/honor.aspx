<%@ Page Title="" Language="C#" MasterPageFile="~/mobile/MobileUI.master" AutoEventWireup="true" CodeFile="honor.aspx.cs" Inherits="mobile_honor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="honorWap">
        <div class="title cl">
            <a href="honor.aspx">
                <h3>荣誉与资质</h3>
            </a>
        </div>
        <div class="abouttop cl">
            <ul>
                <li><a href="about.aspx">董事长致辞</a></li>
                <li><a href="develop.aspx">发展历程</a></li>
                <li><a href="management.aspx">管理层</a></li>
                <li><a href="culture.aspx">企业文化</a></li>
                <li><a href="responsibility.aspx">社会责任</a></li>
                <li class="on"><a href="honor.aspx">荣誉与资质</a></li>
            </ul>
        </div>
        <div class="main cl">
            <ul>
                <asp:Literal ID="lblPhotoList" runat="server"></asp:Literal>
            </ul>
        </div>
    </div>
</asp:Content>

