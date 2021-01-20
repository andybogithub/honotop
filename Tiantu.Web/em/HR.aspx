<%@ Page Title="" Language="C#" MasterPageFile="~/em/MobileEnUI.master" AutoEventWireup="true" CodeFile="HR.aspx.cs" Inherits="em_HR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="hrWap">
        <div class="title cl">
            <a href="HR.aspx">
                <h3>Human Resources</h3>
            </a>
        </div>

        <div class="main cl">
            <%=pageModel.CONTENTS_EN %>
        </div>
    </div>
</asp:Content>

