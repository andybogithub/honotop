<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_admin/Share.master" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="_shop_admin_category_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-title">
        <h3>商品分类管理</h3> 
    </div>
    <!--end page title-->


    <div class="row">
        <div class="col-lg-8">
            <div class="panel-box">
                <h4>商品分类列表</h4>
                <hr />

                <div class="tabs-container">
                    <div class="tabs-left">
                        <ul class="nav nav-tabs">
                            <li class="active">
                                <a data-toggle="tab" href="#tab-01" aria-expanded="true">商品分类</a>
                            </li>
                            <li>
                                <a data-toggle="tab" href="#tab-02" aria-expanded="true">夺宝商品分类</a>
                            </li>
                        </ul>
                        <div class="tab-content">
                            <div id="tab-01" class="tab-pane active">
                                <div class="panel-body">

                                    <div class="table-responsive">
                                        <table class="table table-striped table-hover">
                                            <thead>
                                                <tr>
                                                    <th>#</th>
                                                    <th>商品分类名称</th>
                                                    <th>模块</th>
                                                    <th width="60">操作</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater runat="server" ID="RepeaterList01">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%# Container.ItemIndex+1 %></td>
                                                            <td><%# Eval("categoryName") %></td>
                                                            <td><%# GetClazzName(Eval("clazzId")) %></td>
                                                            <td><a href="List.aspx?categoryid=<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("categoryid").ToString())  %>" class="btn btn-default btn-xs">修改</a></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div id="tab-02" class="tab-pane">
                                <div class="panel-body">
                                    <div class="table-responsive">
                                        <table class="table table-striped table-hover">
                                            <thead>
                                                <tr>
                                                    <th>#</th>
                                                    <th>商品分类名称</th>
                                                    <th>模块</th>
                                                    <th width="60">操作</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater runat="server" ID="RepeaterList02">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%# Container.ItemIndex+1 %></td>
                                                            <td><%# Eval("categoryName") %></td>
                                                            <td><%# GetClazzName(Eval("clazzId")) %></td>
                                                            <td><a href="List.aspx?categoryid=<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("categoryid").ToString())  %>" class="btn btn-default btn-xs">修改</a></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    <div class="col-sm-8">
        <div class="panel-box">
            <h4>
                <asp:Literal ID="lblPageAction" Text="添加" runat="server" />商品分类
            </h4>
            <div class="form-horizontal">
                <hr />

                <asp:Panel ID="PanelError" runat="server" Visible="false">
                    <div class="alert alert-danger text-center">
                        <a class="close" data-dismiss="alert">&times;
                        </a>
                        <strong>提示：</strong>
                        <asp:Literal ID="lblError" runat="server" />
                    </div>
                </asp:Panel>

                <div class="form-group">
                    <label class="col-lg-2 control-label"><em>*</em>所属模块：</label>

                    <div class="col-lg-10">
                        <asp:DropDownList runat="server" ID="ddlClazzId" CssClass="form-control">
                            <asp:ListItem Text="商品" Value="1" />
                            <asp:ListItem Text="夺宝商品" Value="2" />
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-lg-2 control-label"><em>*</em>分类名称：</label>

                    <div class="col-lg-10">
                        <asp:TextBox runat="server" ID="txtCategoryName" CssClass="form-control" placeholder="请输入商品分类名称" />
                    </div>
                </div>

                <div class="form-group">
                    <div class=" col-lg-12 text-right">
                        <input type="reset" name="btnreset" value="重置" class="btn btn-white" />
                        <asp:Button Text="保存" ID="btnSave" CssClass="btn btn-sm btn-theme" runat="server" OnClick="btnSave_Click" />
                        <asp:Button Text="删除" ID="btnDelete" CssClass="btn btn-sm btn-danger" Visible="false" OnClientClick="javascript:return window.confirm('确认要删除吗?');" runat="server" OnClick="btnDelete_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>

    <asp:HiddenField ID="hfCategoryId" runat="server" />


    <link href="../style/js/datatable/dataTables.colVis.css" rel="stylesheet" />
    <link href="../style/js/datatable/dataTables.bootstrap.css" rel="stylesheet" />
    <script src="../style/js/datatable/jquery.dataTables.js"></script>
    <script src="../style/js/datatable/dataTables.colVis.js"></script>
    <script src="../style/js/datatable/dataTables.bootstrap.js"></script>
    <script src="../style/js/datatable/config-datatable.js"></script>
</asp:Content>

