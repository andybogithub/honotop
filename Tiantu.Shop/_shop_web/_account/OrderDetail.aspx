<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_web/Share.master" AutoEventWireup="true" CodeFile="OrderDetail.aspx.cs" Inherits="_shop_web__account_OrderDetail" %>
<%@ MasterType VirtualPath="~/_shop_web/Share.master" %>
<%@ Register TagPrefix="uc" TagName="top" Src="~/_shop_web/_account/Top.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container wp">
			<div class="orderWrap">
				<div class="curr"><span><a href="/">商城</a></span> > <span><a href="/account/index.html">订单中心 </a></span> > <span><a>订单详细</a></span></div>
				<!--订单信息未邮寄-->
                <%if("已发货".Equals(orderRow["ShipStatus"].ToString())) { %>
                <!--订单信息已邮寄-->
				<div class="orderInfomail cl" >
					<div class="l stateInfo">
						<p>订单号：<%=Convert.ToInt32(orderRow["orderid"])+1000000 %></p>
						<div class="infosucces">已邮寄</div>
						<p><%=orderRow["ShipDate"]%></p>
					</div>
					<div class="l orderaddress">
						<ul>
							<li><strong>收货人信息</strong>
							</li>
							<li><b>收货人：</b><span><%=orderRow["username"] %></span></li>
							<li><b>地址：</b><span><%=orderRow["city"] %> <%=orderRow["addrs"] %></span></li>
							<li><b>邮编：</b><span><%=orderRow["zipcode"] %></span></li>
							<li><b>手机/电话：</b><span><%=orderRow["usertel"] %></span></li>
						</ul>
						<ul>
							<li><strong>配送信息</strong></li>
							<li><b>配送方式：</b><span><%=orderRow["shipment"] %></span></li>
							<li><b>保险运费：</b><span><%=Convert.ToInt32(orderRow["OrderInsurancePrice"])==0?"无":orderRow["OrderInsurancePrice"].ToString()+" 元" %></span></li>
							<li><b>物流公司：</b><span><%=orderRow["shipcompany"] %></span></li>
							<li><b>运单号：</b><span><%=orderRow["shipno"] %></span></li>
						</ul>
					</div>
				</div>
                <%}else { %>
                	<div class="orderInfomail cl">
					<div class="l stateInfo">
						<p>订单号：<%=Convert.ToInt32(orderRow["orderid"])+1000000 %></p>
						<div class="infosucces">购买成功</div>
						<p>等待确认发货</p>
					</div>
					<div class="l orderaddress" style="width:800px;">
                        <%if(bChooseAddress){ %>
						<ul>
							<li><strong>收货人信息</strong></li>
							<li><b>收货人：</b><span><%=orderRow["username"] %></span></li>
							<li><b>地址：</b><span><%=orderRow["city"] %> <%=orderRow["addrs"] %></span></li>
							<li><b>邮编：</b><span><%=orderRow["zipcode"] %></span></li>
							<li><b>手机/电话：</b><span><%=orderRow["usertel"] %></span></li>
						</ul>
                        <%}else{ %>
                         <asp:Literal ID="lblEditAddress" runat="server" />
               
                                	<table border="0" cellspacing="0" cellpadding="0" class="table" width="100%">
								<tr>
                                    <th>#</th>
									<th class="col_2">收货人</th>
									<th class="col_3">所在地区</th>
									<th class="col_4">街道地址</th>
									<th class="col_5">邮编</th>
									<th class="col_6">手机/电话</th>
							 
								</tr>
                                <asp:Repeater runat="server" ID="RepeaterAddressList">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <input type="radio" name="input_address" class="input_address" value='<%# Eval("addressId") %>' />
                                            </td>
									    <td class="col_2"><%# Eval("username") %></td>
									    <td class="col_3"><%# Eval("city") %></td>
									    <td class="col_4"><%# Eval("addrs") %></td>
									    <td class="col_5"><%# Eval("zipcode") %></td>
									    <td class="col_6"><%# Eval("usertel") %></td>
								        
								    </tr>
                                    </ItemTemplate>
                                </asp:Repeater>							 
							</table>
                        <div class="cl"></div>
                        <div style="text-align:right;margin-top:10px;">
                            <a style="background:#ff6a00;color:#FFF;padding:5px 10px;border-radius:4px;" id="btnSaveAddress">保存收货地址</a>
                        </div>
                        <%} %>
					</div>


              


				</div>

                <%} %>
			

				
				<div class="centerMainWrap centerOrderWrap">
					<div class="orderTitle"><strong>商品信息</strong></div>
					<div class="centerMain">
						<table border="0" cellspacing="0" cellpadding="0" class="table" style="width:100%;">
							<tr>
								<th class="col_1">商品信息</th>
								<th class="col_2">单个价格 </th>
								<th class="col_3">数量</th>
								<th class="col_4">合计</th>
								<th class="col_4">保险运费</th>
								<th class="col_5">发货状态</th>
							</tr>
							<asp:Repeater runat="server" ID="RepeaterProductList">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <div class="pic"><a href="/proDe/<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("productId").ToString()) %>.html">
                                            <img src="<%# Tiantu.DB.Common.SL.GetHttpImageURL(Eval("ImageIcon")) %>" onload="javascript:DrawImage(this, 60, 60)" /></a></div>
                                        <div class="con"><%# Eval("productName") %></div>
                                    </td>
                                    <td><%# Eval("OrderPoint") %> 元</td>
                                    <td><%# Eval("OrderQty") %></td>
                                    <td><%# Convert.ToInt32(Eval("OrderQty")) * Convert.ToInt32(Eval("OrderPoint")) %> 元</td>
                                   <td><%=Convert.ToInt32(orderRow["OrderInsurancePrice"])==0?"无":orderRow["OrderInsurancePrice"].ToString()+" 元" %></td>
                                    <td><%# Eval("ShipStatus") %></td>
                                    
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>				
						</table>

					</div>
				</div>			
 
			</div>
		</div>

    <script>
        $( document ).ready( function ()
        {
            $( "#btnSaveAddress" ).click( function ()
            {
                var _addressid = $( "input[name=input_address]:checked" ).val();
                if ( _addressid == null || _addressid == 'undefined' )
                {
                    alert( '请选择一个收货地址' );
                    return false;
                }
                else
                {
                    var _orderid = <%=Convert.ToInt32(orderRow["orderid"]) %>;
                    $.ajax( {
                        type: "POST",
                        url: "/account/address/choose.html",
                        data: { addressid: _addressid, orderid:_orderid },
                        success: function (  )
                        {
                            document.location.reload();
                        }
                    } );
                }
            } );
        } );
    </script>
</asp:Content>

