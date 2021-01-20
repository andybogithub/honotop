<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_admin/Share.master" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="_shop_admin_order_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
        $( document ).ready( function ()
        {
            //查询
            $( "#btnSearch" ).click( function ()
            {
                var _prodname = $( "#prodname" ).val();
                var _username = $( "#username" ).val();
                var _shipstatus = $( "#shipstatus" ).prop( "checked" ) == true ? 1 : 0;
                var queryUrl = 'list.aspx?action=query&p1=' + _prodname + '&p2=' + _username + '&p3=' + _shipstatus;
                document.location.href = queryUrl;
            } );
        } );
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-title">
        <h3>订单中心</h3>
        <a class="active">订单查询</a>
    </div>
    <!--end page title-->


    <div class="row">

        <div class="col-lg-12">
            <div class="panel-box clearfix">

                <h4>订单查询</h4>

                <div class="col-sm-4">
                    <div class="form-group">
                        <div class="input-group m-b">
                            <span class="input-group-addon">商品名称</span>
                            <input type="text" id="prodname" placeholder="请输入关键词" value="<%=searchKey1 %>" class="form-control" />
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="form-group">
                        <div class="input-group m-b">
                            <span class="input-group-addon">收货人</span><input type="text" id="username" placeholder="请输入关键词" value="<%=searchKey2 %>" class="form-control" />
                        </div>
                    </div>
                </div>
                <div class="col-sm-2">
                    <input type="checkbox" name="shipstatus" id="shipstatus" value="1" <%="1".Equals(searchKey3)?"checked":"" %> />
                    <label for="shipstatus">已发货</label>
                </div>
                <div class="col-sm-2">
                    <input type="button" id="btnSearch" value="搜索" class="btn btn-warning" />
                </div>
            </div>
        </div>

    </div>





    <div class="row">
        <div class="col-sm-12">
            <div class="panel-box">

                <div class="table-responsive">
                    <div class="dataTables_wrapper form-inline dt-bootstrap">

                        <table id="basic-datatables" class="table" cellspacing="0" width="100%">
                            <thead>
                                <tr>
                                    <th>订单类型</th>
                                    <th>订单日期</th>
                                    <th>订单号</th>
                                    <th>商品信息</th>
                                    <th>订购数量</th>
                                    <th>购买价格</th>
                                    <th>配送方式</th>
                                    <th>保险费用</th>
                                    <th>订单状态</th>
                                    <th>操作</th>

                                </tr>
                            </thead>

                            <tbody>
                                <asp:Repeater runat="server" ID="RepeaterList">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%# Convert.ToInt32(Eval("DubaoWinNo"))>0?"夺宝商品":"商品" %>
                                            </td>
                                            <td><%# Eval("OrderTime","{0:yyyy-MM-dd}") %></td>
                                            <td><%# Convert.ToInt32(Eval("orderId"))+1000000 %></td>
                                            <td>
                                                <div class="pic">
                                                    <a href="http://shop.honotop.com/proDe/<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("productId").ToString().ToLower()) %>.html">
                                                        <img src="<%# Tiantu.DB.Common.SL.GetHttpImageURL(Eval("ImageIcon")) %>" width="60" height="60" onload="javascript:DrawImage(this, 60, 60)" /></a>
                                                </div>
                                                <div class="con"><%# Eval("productName") %></div>
                                            </td>


                                            <td><%# Eval("OrderQty") %></td>
                                            <td><%# Eval("OrderPoint") %></td>
                                            <td><%# Eval("Shipment") %></td>
                                            <td><%# Convert.ToBoolean(Eval("IsInsurance"))?Convert.ToDouble(Eval("OrderInsurancePrice")).ToString("N2")+"元":"" %></td>
                                            <td><%# Eval("ShipStatus") %></td>
                                            <td>
                                                <a href="details.aspx?opid=<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("opid").ToString()) %>">查看</a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <hr />
                        <div class="row">
                            <asp:Literal ID="lblPager" runat="server" />
                        </div>
                    </div>

                    <div class="clearfix">
                    </div>
                </div>
            </div>
        </div>
    </div>

    <link href="../style/js/datatable/dataTables.colVis.css" rel="stylesheet" />
    <link href="../style/js/datatable/dataTables.bootstrap.css" rel="stylesheet" />

</asp:Content>

