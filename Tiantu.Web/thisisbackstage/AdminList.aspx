<%@ Page Title="" Language="C#" MasterPageFile="~/thisisbackstage/Webadmin.master" AutoEventWireup="true" CodeFile="AdminList.aspx.cs" Inherits="webadmin_AdminList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row-fluid">
        <div class="span12">

            <div class="widget-box">
                <div class="widget-title">
                    <span class="icon"><i class="icon-th"></i></span>
                    <h5>管理员列表</h5>
                </div>

                <div class="widget-content nopadding">
                    <table class="table table-bordered table-striped">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>登录账号</th>
                                <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RepeaterBook">
                                <ItemTemplate>
                                    <tr>
                                        <td style="width: 30px"><%# Container.ItemIndex+1 %></td>
                                        <td><%# Eval("ADMINNAME") %></td>
                                        <td style="width: 60px"><a href="AdminAdd.aspx?id=<%# Eval("ADMINID") %>" class="btn btn-info">编辑</a></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>

                    <div class="widget-bottom">
                        <a href="adminAdd.aspx" class="btn btn-success">添加</a>
                    </div>

                </div>
            </div>


        </div>
    </div>


    <script>
        subMenu('mAdmin');
    </script>

</asp:Content>

