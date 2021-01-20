<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_admin/Share.master" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="_shop_admin_product_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
        $(document).ready(function () {
            //商品查询
            $("#btnquery").click(function () {
                var queryUrl = 'list.aspx?action=query';

                var _productname = $("#productname").val();
                var _qtystatus = $("#qtystatus").val();
                var _showhometag = $("#showhometag").prop("checked") ? 1 : 0;
                var _skilltag = $("#skilltag").prop("checked") ? 1 : 0;
                var _tjtag = $("#tjtag").prop("checked") ? 1 : 0;
                var _hottag = $("#hottag").prop("checked") ? 1 : 0;

                queryUrl += '&p1=' + _productname + '&p2=' + _qtystatus + '&p3=' + _showhometag + '&p4=' + _skilltag + '&p5=' + _tjtag + '&p6=' + _hottag;
                document.location.href = queryUrl;
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-title">
        <h3>商品管理</h3>
        <a href="list.aspx" class="active"><i class="fa fa-list"></i>商品查询</a>
        <a href="add.aspx"><i class="fa fa-plus"></i>添加商品</a>
    </div>
    <!--end page title-->





    <div class="row">
        <div class="col-sm-12">
            <div class="panel-box">
                <div class="form-inline">

                    <div class="form-group">
                        <label>产品名称</label>
                        <input type="text" class="form-control" id="productname" placeholder="请输入名字" value="<%=p1 %>" />
                    </div>

                    <label class="checkbox-inline"></label>

                    <div class="form-group">
                        <label>库存状态</label>
                        <select class="form-control" id="qtystatus">
                            <option value="">全部</option>
                            <option value="库存充足" <%="库存充足".Equals(p2)?"selected":"" %>>库存充足</option>
                            <option value="库存紧张" <%="库存紧张".Equals(p2)?"selected":"" %>>库存紧张</option>
                            <option value="无货" <%="无货".Equals(p2)?"selected":"" %>>无货</option>
                        </select>
                    </div>

                    <label class="checkbox-inline"></label>
                    <div class="checkbox">

                        <label class="checkbox-inline">
                            <input type="checkbox" id="showhometag" <%="1".Equals(p3)?"checked":"" %> />首页显示</label>
                        <label class="checkbox-inline">
                            <input type="checkbox" id="skilltag" <%="1".Equals(p4)?"checked":"" %> />秒杀产品</label>
                        <label class="checkbox-inline">
                            <input type="checkbox" id="tjtag" <%="1".Equals(p5)?"checked":"" %> />推荐商品</label>
                        <label class="checkbox-inline">
                            <input type="checkbox" id="hottag" <%="1".Equals(p6)?"checked":"" %> />热门商品</label>

                    </div>

                    <label class="checkbox-inline"></label>
                    <input type="button" id="btnquery" value="查询" class="btn btn-warning" />
                </div>
            </div>
        </div>
    </div>


    <div class="row">
        <div class="col-sm-12">

            <div class="panel-box">
                <h4>商品列表 (<asp:Literal Text="0" ID="lblTotalProducts" runat="server" /> 个商品)</h4>
                <div class="table-responsive">
                    <div class="dataTables_wrapper form-inline dt-bootstrap">

                        <table id="basic-datatables" class="table table-hover" cellspacing="0" width="100%">
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>商品分类</th>
                                    <th>商品名称</th>
                                    
                                    <th class="text-center" style="width: 60px">操作</th>
                                </tr>
                            </thead>

                            <tbody>
                                <asp:Repeater runat="server" ID="RepeaterList">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex+1 %></td>
                                            <td>
                                                <div><%# Eval("categoryName") %></div>
                                                <div>
                                                    <img src='<%# Tiantu.DB.Common.SL.GetHttpImageURL(Eval("imageicon")) %>' width="64" height="64" />
                                                </div>
                                            </td>
                                            <td>

                                                <p>
                                                    <%# Convert.ToBoolean(Eval("showHomeTag"))?"<span class='badge' style='background:orange'>首页显示</span>":"" %>
                                                    <%# Convert.ToBoolean(Eval("hotTag"))?"<span class='badge'  style='background:red'>热门</span>":"" %>
                                                    <%# Convert.ToBoolean(Eval("tjTag"))?"<span class='badge'  style='background:blue'>推荐</span>":"" %>
                                                </p>

                                                <h4 style="font-weight:normal;"><%# Eval("productName") %></h4>

                                                <p><%# Convert.ToBoolean(Eval("SeckillTag"))?"<span class='bg-danger' style='padding:10px'>秒杀产品" + " 结束时间："+Convert.ToDateTime(Eval("SeckillEndTime")).ToString("yyyy-MM-dd HH:mm") +  (DateTime.Now.Subtract(Convert.ToDateTime(Eval("SeckillEndTime"))).TotalSeconds >0?" <span class='badge'>已结束</span>":"<span class='badge' style='background:green'>进行中</span>") +  "</span>" : "" %></p>
                                                <div>
                                                   <span>购买价格：<b><%# Eval("point") %></b></span>
                                                 
                                                   <span>快递保险费：<b><%# Eval("InsurancePrice") %></b> </span>
                                                   <span>发货方式：<b><%# Eval("shipment") %></b> </span>
                                                </div>
                                                <div>
                                                       <span>库存数量：<b><%# Eval("qty") %></b></span>
                                                   <span>库存状态：<b><%# GetQtyStatus(Eval("qtyStatus")) %></b> </span>
                                                </div>
                                                <div>
                                                     上架时间：<%# Eval("pubtime","{0:yyyy-MM-dd HH:mm}") %> &nbsp;
                                                     <b><%# Convert.ToBoolean(Eval("isOnLine"))?"线上":"已下架" %></b>
                                                </div>
                                            </td>
                                      
                                         
                                            <td class="text-center"><a href="add.aspx?productid=<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("productId").ToString()) %>" class="btn btn-default btn-xs">修改</a></td>
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

