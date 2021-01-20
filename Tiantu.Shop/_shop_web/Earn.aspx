<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_web/Share.master" AutoEventWireup="true" CodeFile="Earn.aspx.cs" Inherits="_shop_web_Earn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
     
    
      <div class="container wp">
        <div class="helpWrap">
            <div class="helpSide">
                <div class="sideTit">帮助中心</div>
                <div class="helpMenu">
                    <ul>
                        <asp:Repeater runat="server" ID="RepeaterTitleList">
                            <ItemTemplate>
                                <li><a href="/help/<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("newsid").ToString()).ToLower() %>.html"><%# Eval("newsTitle") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>

                    </ul>
                </div>
            </div>
            <div class="helpContent">
                <div class="helpTit"><strong>赚取金币</strong></div>
                <div class="helpMain">
                    <asp:Literal  ID="lblDetails" runat="server" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>

