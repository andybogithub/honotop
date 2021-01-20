<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_admin/Share.master" AutoEventWireup="true" CodeFile="Desk.aspx.cs" Inherits="_shop_admin_Desk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-title">
        <h3>天图物流商城管理中心</h3>
    </div>
    <!--end page title-->



    <div class="row">

        <div class="col-sm-12">
            <div class="panel-box">
                <h4>最新商品购买记录</h4>
                <div class="table-responsive">
                    <table class="table">
                        <thead>
                            <tr>
                                <th>商品信息</th>
                                <th>订单号</th>
                                <th>成交日期</th>
                                <th>数量</th>
                                <th>价格</th>
                                <th>配送方式</th>
                                <th>交易状态</th>
                                <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RepeaterOrderProductList">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <div class="pic">
                                                <a href="http://shop.honotop.com/proDe/<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("productId").ToString()).ToLower() %>.html" target="_blank">
                                                    <img src="<%# Tiantu.DB.Common.SL.GetHttpImageURL(Eval("ImageIcon")) %>" style="width:60px;height:60px;" onload="javascript:DrawImage(this, 60, 60)" /></a>
                                            </div>
                                            <div class="con"><%# Eval("productName") %></div>
                                        </td>
                                        <td><%# Convert.ToInt32(Eval("orderId"))+1000000 %></td>
                                        <td><%# Eval("OrderTime","{0:yyyy-MM-dd}") %></td>
                                        <td><%# Eval("OrderQty") %></td>
                                        <td><%# Eval("OrderPoint") %></td>
                                        <td><%# Eval("Shipment") %></td>
                                        <td>购买成功</td>
                                        <td>
                                            <a href="/_shop_admin/order/details.aspx?opid=<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("opid").ToString()) %>">查看</a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>


                        </tbody>
                    </table>
                </div>
            </div>
        </div>


    </div>



</asp:Content>


