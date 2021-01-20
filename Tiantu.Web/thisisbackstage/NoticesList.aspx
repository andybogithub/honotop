<%@ Page Title="" Language="C#" MasterPageFile="~/thisisbackstage/Webadmin.master" AutoEventWireup="true" CodeFile="NoticesList.aspx.cs" Inherits="webadmin_NoticesList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row-fluid stores">
        <div class="span12">
           
            <div class="widget-box">
                <div class="widget-title">
                    <span class="icon"><i class="icon-th"></i></span>
                    <h5>公司公告</h5>
                </div>

                <div class="widget-content nopadding">
                    <table class="table table-bordered table-striped">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>标题</th>
                                <th style="width: 100px;">日期</th>
                                <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RepeaterStores" OnItemCommand="RepeaterStores_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td style="width: 30px"><%# Container.ItemIndex+1 %></td>
                                        <td><%# Eval("TITLE") %></td>
                                        <td><%# Eval("PUBDATE", "{0:yyyy-MM-dd}") %></td>
                                        <td style="width: 120px;">
                                            <a href="NoticesAdd.aspx?noticeid=<%# Eval("NOTICEID") %>" class="btn btn-info">编辑</a>
                                            <asp:LinkButton CommandName="delete" CommandArgument='<%# Eval("NOTICEID") %>' Text="删除" ID="btnDelete"
                                                CssClass="btn btn-danger" OnClientClick="javascript:return window.confirm('确认要删除吗?');" runat="server" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>


                    <div class="pagination alternate widget-toolbar">
                        <asp:Literal ID="lblPagination" runat="server" />
                    </div>

                    <div class="widget-bottom">
                        <a href="NoticesAdd.aspx" class="btn btn-success">添加</a>
                    </div>

                </div>


            </div>
        </div>
    </div>


    <script>
        subMenu('mNotice');
    </script>
</asp:Content>

