<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_admin/Share.master" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="_shop_admin_qa_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-title">
        <h3>帮助中心</h3>
        <a href="list.aspx" class="active"><i class="fa fa-list"></i>帮助文章列表</a>
        <a href="add.aspx"><i class="fa fa-plus"></i>添加帮助文章</a>
    </div>
    <!--end page title-->

 


    <div class="row">
        <div class="col-sm-12">
            <div class="panel-box">

                <div class="form-horizontal">
                    <div class="row">
                        <div class="col-sm-4">
                            <div class="form-group">
                                <div class="col-sm-12">
                                    <div class="input-group m-b">
                                        <span class="input-group-addon">文章标题</span><input type="text" id="searchKey" placeholder="请输入关键词" value="<%=searchKey %>" class="form-control" />
                                        <span class="input-group-addon" onclick="javascript:doSearch();"><i class="fa fa-search"></i></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="table-responsive">
                    <div class="dataTables_wrapper form-inline dt-bootstrap">

                        <table id="basic-datatables" class="table" cellspacing="0" width="100%">
                            <thead>
                                <tr>
                                    <th width="30">#</th>
                                    <th>文章标题</th>
                                    <th width="120">上传时间</th>
                                    <th class="text-center" style="width: 60px">操作</th>
                                </tr>
                            </thead>

                            <tbody>
                                <asp:Repeater runat="server" ID="RepeaterList">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex+1 %></td>
                                            <td><a href="add.aspx?newsid=<%# Eval("newsId") %>"><%# Eval("newsTitle") %></a></td>
                                            <td><%# Eval("pubtime","{0:yyyy-MM-dd}") %></td>
                                            <td class="text-center"><a href="add.aspx?newsId=<%# Eval("newsId") %>" class="btn btn-default btn-xs">修改</a></td>
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
    <script>
        function doSearch() {
            var queryUrl = "list.aspx?action=query";
            var _searchKey = $("#searchKey").val();
            if (_searchKey != null)
                queryUrl += "&key=" + _searchKey;
            document.location.href = queryUrl;
        }

        $(document).ready(function () {
            $("#searchKey").keypress(function (e) {
                if (e.keyCode == 13) {
                    doSearch();
                    return false;
                }
            });
        });
    </script>
</asp:Content>

