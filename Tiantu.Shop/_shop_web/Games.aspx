<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_web/Share.master" AutoEventWireup="true" CodeFile="Games.aspx.cs" Inherits="_shop_web_Games" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
    .indianaWrap .proMenu ul{margin-top:20px;}
        .indianaList .game li{height:auto;text-align:center;}
        .indianaList .game li .pic{height:auto;}
        .pageTurning{margin:10px;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container wp">
        <div class="indianaWrap cl">
            <div class="proMenu">
					<ul>
						<li class="on"><a href="/games.html">金币游戏</a></li>
					</ul>
				</div>
            <div class="indianaList">
                <ul class="game">
                    <asp:Repeater runat="server" ID="RepeaterGameList">
                        <ItemTemplate>
                            <li>
                                <div class="pic"><a href="<%# Eval("linkUrl") %>" target="_blank">
                                    <img src="<%# Tiantu.DB.Common.SL.GetHttpImageURL(Eval("ImageURL"))  %>" width="270" height="270" /></a></div>
                                <div class="con">
                                    <h4><%# Eval("GameName") %></h4>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>

            <!--翻页-->
            <%if (totalRecords > 0)
              { %>
            <div class="pageTurning cl">
                <div class="r">
                    <span class="allNum"><%=pageId %> / <%=pageCount %>页 |  共 <b><%=totalRecords %></b> 条</span>
                    <ul id="light-pagination" class="pagination"></ul>
                </div>
            </div>
            <%} %>
            <asp:Literal ID="lblPager" runat="server" />
        </div>
    </div>


      <script>
        $('.nav li').eq(3).addClass('on').siblings().removeClass('on');
    </script>

</asp:Content>

