<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_admin/Share.master" AutoEventWireup="true" CodeFile="UserPointList.aspx.cs" Inherits="_shop_admin_user_UserPointList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-title">
        <h3>会员金币中心</h3>

        <a href="UserPointList.aspx"><i class="fa fa-list"></i>会员金币查询</a>
        <a href="EmployeePointList.aspx" class="on"><i class="fa fa-shopping-cart"></i>员工金币查询</a>
    </div>
    <!--end page title-->




    <div class="row">
        <div class="col-sm-12">
            <div class="panel-box">

                <div class="tab-content">
                    <div id="tab-1" class="tab-pane active">
                        <div class="panel-body">

                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="input-group m-b">
                                        <span class="input-group-addon">会员金币查询</span><input type="text" id="searchKey" placeholder="请输入您要查询的手机号码或姓名" value="<%=searchKey %>" class="form-control" />
                                        <span class="input-group-addon"><i class="fa fa-search"></i></span>
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <div class="dataTables_wrapper form-inline dt-bootstrap">

                                    <table id="basic-datatables" class="table table-hover" cellspacing="0" width="100%">
                                        <thead>
                                            <tr>
                                                <th>会员编号</th>
                                                <th>手机号码</th>
                                                <th>会员姓名</th>
                                                <th>当前金币</th>
                                                <th width="80" class="text-center">金币详细</th>
                                            </tr>
                                        </thead>

                                        <tbody>
                                            <asp:Repeater runat="server" ID="RepeaterList">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%# Eval("userid") %></td>
                                                        <td><%# Eval("usertel") %></td>
                                                        <td><%# Eval("username") %></td>
                                                        <td><%# Eval("points") %></td>
                                                        <td class="text-center"><a href="#" class="btn btn-default btn-xs">查看</a></td>
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

                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>

                </div>
            </div>
            <!--/tabs-container-->
        </div>
    </div>


    <link href="../style/js/datatable/dataTables.colVis.css" rel="stylesheet" />
    <link href="../style/js/datatable/dataTables.bootstrap.css" rel="stylesheet" />

    <script>
        $(document).ready(function () {
            $("#searchKey").keydown(function (e) {
                if (e.keyCode == 13) {
                    doSearch();
                    return false;
                }
            });
            function doSearch() {
                var _searchKey = $("#searchKey").val();
                var _searchPageUrl = '?action=query';
                if (_searchKey != null && _searchKey.length > 0)
                    _searchPageUrl += '&key=' + _searchKey;

                document.location.href = _searchPageUrl;
            }
        });
    </script>

</asp:Content>

