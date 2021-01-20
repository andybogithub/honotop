<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_web/Share.master" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="_shop_web_Products" %>
<%@ MasterType VirtualPath="~/_shop_web/Share.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .proMain ul li{height:440px;}
    .proMain .info h4{height:50px;} 
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    	<div class="container wp">
			<div class="productWrap cl">
				<div class="proMenu">
					<ul>
						<li class="on"><a href="/products.html">全部分类</a></li>
                        <asp:Repeater runat="server" ID="RepeaterCategoryList">
                            <ItemTemplate>
                                <li><a href="/products.html?cateid=<%# Eval("categoryId") %>"><%# Eval("categoryName") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater> 
					</ul>
				</div>
				<div class="proMain">
					<ul>
                        <asp:Repeater runat="server" ID="RepeaterProductList">
                            <ItemTemplate>
                                <li>
							    <div class="pic"><a href="/proDe/<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("productid").ToString()).ToLower() %>.html" title="<%# Eval("productname") %>"><img src='<%# Tiantu.DB.Common.SL.GetHttpImageURL(Eval("imageIcon")) %>' width="264" height="264" style="padding:3px;" /></a></div>
							    <div class="info">
								    <h4><a href="/proDe/<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("productid").ToString()).ToLower() %>.html" title="<%# Eval("productname") %>"><%# Tiantu.DB.Common.SL.CutString(Eval("productName"),30) %></a></h4>
								    <p>¥ <%# Eval("point") %></p>
							    </div>
                                     <%if (Master.user.USERID==0) {%>
							    <div class="changeBtn"><a onclick="javascript:login();">立即购买</a></div>
                                    <% } else{ %>
                                    <div class="changeBtn"><a onclick="javascript:exChangeNow('<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("productId").ToString()) %>')">立即购买</a></div>
                                    <%} %>
						    </li>
                            </ItemTemplate>
                        </asp:Repeater>
						 
					</ul>
				</div>
				
            <%if (totalRecords > 0)
                { %>
                    <div class="pageTurning cl">
                        <div class="r">
                            <span class="allNum"><%=pageId %> / <%=pageCount %>页 |  共 <b><%=totalRecords %></b> 条</span>
                            <ul id="light-pagination" class="pagination"></ul>
                        </div>
                    </div>
                <%} %>
                <asp:Literal  ID="lblPager" runat="server" />
                    
				 
				
			</div>
		</div>
    
    <script>
        $('.nav li').eq(1).addClass('on').siblings().removeClass('on');
    </script>
</asp:Content>

