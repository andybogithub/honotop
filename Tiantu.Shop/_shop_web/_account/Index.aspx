<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_web/Share.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="_shop_web__account_Index" %>
<%@ Register TagPrefix="uc" TagName="top" Src="~/_shop_web/_account/Top.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container wp">
        <div class="centerWrap">
          <uc:top ID="uctop" runat="server" />
            <div class="centerMainWrap centerOrderWrap">
                <div class="centerTitle"><strong>我的订单</strong></div>
                <div class="centerMain">
                    <table border="0" cellspacing="0" cellpadding="0" class="table">
                        <tr>
                                <th class="col_1">商品信息</th>
                                <th class="col_2">订单号</th>
                                <th class="col_3">成交日期</th>
                                <th class="col_4">数量</th>
                                <th class="col_5">价格</th>
                                <th class="col_6">交易状态</th>
                                <th class="col_7">操作</th>
                        </tr>
                        <asp:Repeater runat="server" ID="RepeaterProductList">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <div class="pic"><a href="/proDe/<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("productId").ToString()) %>.html">
                                            <img src="<%# Eval("ImageIcon") %>" width="60" height="60" /></a></div>
                                        <div class="con"><%# Eval("productName") %></div>
                                    </td>
                                    <td><%# Convert.ToInt32(Eval("orderId"))+1000000 %></td>
                                    <td><%# Eval("OrderTime","{0:yyyy-MM-dd}") %></td>
                                    <td><%# Eval("OrderQty") %></td>
                                    <td><%# Eval("OrderPoint") %> 元</td>
                                   
                                    <td><%# Eval("shipstatus") %></td>
                                    <td>
                                        <a href="/account/orderDetail.html?opid=<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("opid").ToString()) %>">查看</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                    </table>

                    <div class="pageTurning cl">
                        <ul id="light-pagination" class="pagination"></ul>
                    </div>
                    <asp:Literal ID="lblPager" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

