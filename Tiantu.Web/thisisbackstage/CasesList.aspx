<%@ Page Title="" Language="C#" MasterPageFile="~/thisisbackstage/Webadmin.master" AutoEventWireup="true" CodeFile="CasesList.aspx.cs" Inherits="webadmin_CasesList" %>

<%@ Import Namespace="Tiantu.DB.Common" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid stores">
        <div class="span12">
            <div class="widget-box">
                <div class="widget-title">
                    <span class="icon"><i class="icon-th"></i></span>
                    <h5>客户案例</h5>
                </div>

                <div class="widget-content nopadding">
                    <table class="table table-bordered table-striped">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>图片</th>
                                <th style="width: 40px;">排序</th>
                                <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RepeaterStores" OnItemCommand="RepeaterStores_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td style="width: 30px"><%# Container.ItemIndex+1 %></td>
                                        <td>
                                            <%# SL.OutImage(Eval("IMGURL"), 130, 100)%>
                                        </td>
                                        <td><%# Eval("SORTID") %></td>
                                        <td style="width: 120px;">
                                            <a href="CasesAdd.aspx?caseid=<%# Eval("CASEID") %>" class="btn btn-info">编辑</a>
                                            <asp:LinkButton CommandName="delete" CommandArgument='<%# Eval("CASEID") %>' Text="删除" ID="btnDelete"
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
                        <a href="CasesAdd.aspx" class="btn btn-success">添加</a>
                    </div>
                </div>

            </div>
        </div>
    </div>


    <script>
        subMenu('mCase');
    </script>
</asp:Content>

