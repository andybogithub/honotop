<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_web/Share.master" AutoEventWireup="true" CodeFile="QA.aspx.cs" Inherits="_shop_web_QA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container wp">
        <div class="helpWrap">
            <div class="helpSide">
                <div class="sideTit">常见问题</div>
                <div class="helpMenu">
                    <ul>
                        <asp:Repeater runat="server" ID="RepeaterTitleList">
                            <ItemTemplate>
                                <li><a href="/rules/<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("newsid").ToString()) %>.html"><%# Eval("nsTitle") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>

                    </ul>
                </div>
            </div>
            <div class="helpContent">
                <div class="helpTit"><strong><%=nsTitle %></strong></div>
                <div class="helpMain">
                    <%=nsBody %>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

