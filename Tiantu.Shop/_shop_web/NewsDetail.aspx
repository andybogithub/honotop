<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_web/Share.master" AutoEventWireup="true" CodeFile="NewsDetail.aspx.cs" Inherits="_shop_web_NewsDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container wp">
        <div class="helpWrap">
            <div class="helpSide">
                <div class="sideTit">最新消息</div>
                <div class="helpMenu">
                    <ul>
                        <asp:Repeater runat="server" ID="RepeaterTitleList">
                            <ItemTemplate>
                                <li><a href="/news/<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("newsid").ToString()) %>.html"><%# Eval("newsTitle") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <div class="helpContent">
                <div class="helpTit"><strong><%=model.NewsTitle %></strong></div>
                <div class="newslistMain">
                    <ul>
                        <%--<li><a href="newsde.html"><i class="newslistbg1"><%=model.PubTime.ToString("yyyy-MM-dd") %></i><span>每日签到获金币，走过路过不要错。</span></a></li>--%>
                        <div class="newsdemain">
                            <%=model.NewsBody %>
                        </div>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

