<%@ Page Title="" Language="C#" MasterPageFile="~/thisisbackstage/Webadmin.master" AutoEventWireup="true" CodeFile="LoginLog.aspx.cs" Inherits="thisisbackstage_LoginLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid stores">
        <div class="span12">
            <div class="controls">
                <div data-toggle="buttons-radio" class="btn-group">
                    <asp:Literal ID="lblMenu" runat="server"></asp:Literal>
                </div>
            </div>

            <div class="widget-box">
                <div class="widget-title">
                    <span class="icon"><i class="icon-th"></i></span>
                    <h5>登录日志</h5>
                </div>

                <div class="widget-content nopadding">
                    <table class="table table-bordered table-striped">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>管理员</th>
                                <th style="width: 180px;">IP</th>
                                <th style="width: 180px;">登录日期</th>

                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RepeaterStores" >
                                <ItemTemplate>
                                    <tr>
                                        <td style="width: 30px"><%# Container.ItemIndex+1 %></td>
                                        <td><%# Eval("LoginName") %></td>
                                        <td><%# Eval("LoginIp") %></td>                                     
                                        <td><%# Eval("LoginTime", "{0:yyyy-MM-dd HH:mm:ss}") %></td>

                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>


                    <div class="pagination alternate widget-toolbar">
                        <asp:Literal ID="lblPagination" runat="server" />
                    </div>

                </div>


            </div>
        </div>
    </div>


    <script>
        subMenu('mLog');
    </script>


</asp:Content>

