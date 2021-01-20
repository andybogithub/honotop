<%@ Page Title="" Language="C#" MasterPageFile="~/thisisbackstage/Webadmin.master" AutoEventWireup="true" CodeFile="AboutUsList.aspx.cs" Inherits="webadmin_AboutUsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="row-fluid">
        <div class="span12">
            <div class="widget-box">
                <div class="widget-title">
                    <span class="icon"><i class="icon-th"></i></span>
                    <h5>关于天图</h5>
                </div>

                <div class="widget-content nopadding">
                    <table class="table table-bordered table-striped">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>标题</th>
                                <th style="width:80px;">操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RepeaterBook" OnItemCommand="RepeaterBook_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td style="width: 30px"><%# Container.ItemIndex+1 %></td>
                                        <td><%# Eval("TITLE") %></td>
                                        <td style="width: 60px;">
                                            <a href="AboutUsAdd.aspx?abid=<%# Eval("ABOUTID") %>" class="btn btn-info">编辑</a>
                                            <asp:LinkButton CommandName="delete" CommandArgument='<%# Eval("ABOUTID") %>' Text="删除" ID="btnDelete"
                                                CssClass="btn btn-danger" OnClientClick="javascript:return window.confirm('确认要删除吗?');" runat="server" Visible="false" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>

                    <div class="widget-bottom" style="display:none;">
                        <a href="AboutUsAdd.aspx?cateid=<%=cateId%>" class="btn btn-success">添加</a>
                    </div>

                </div>
            </div>
        </div>
    </div>

    <script>
        subMenu('mAbout');
    </script>



</asp:Content>

