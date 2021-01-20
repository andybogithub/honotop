<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_web/Share.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="_shop_web_News" %>

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
                <div class="helpTit"><strong>最新消息</strong></div>
                <div class="newslistMain">
                    <ul>
                        <asp:Repeater runat="server" ID="RepeaterNewsList">
                            <ItemTemplate>
                                <li><a href="/news/<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("newsid").ToString()) %>.html"><i class="newslistbg1"><%# Convert.ToDateTime(Eval("PubTime")).ToString("yyyy-MM-dd") %></i><span><%# Eval("newstitle") %></span></a></li>
                            </ItemTemplate>
                        </asp:Repeater>

                    </ul>
                </div>
                <!--翻页-->
             
                <div class="pageTurning cl">
                    <ul id="light-pagination" class="pagination"></ul>
                </div>
                   <asp:Literal  ID="lblPager" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>

