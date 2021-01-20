<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_admin/Share.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="admin_admin_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row">
        <div class="col-sm-3 col-md-2 sidebar">
            <ul class="nav nav-sidebar">
                <li class="nav-header">操作员管理</li>
                <li class="active"><a href="add.aspx">添加操作员</a></li>
                <li><a href="list.aspx">操作员列表</a></li>
            </ul>
        </div>
        <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">

            <form runat="server" id="aspNetForm">
                <fieldset>

                    <legend>添加操作员</legend>

                    <div>
                        <label>用户名：</label>
                        <asp:TextBox runat="server" ID="txtAdminName" CssClass="form-control" placeholder="请输入用户名…" />
                        <span class="help-block"></span>
                    </div>

                    <div>
                        <label>密码：</label>
                        <asp:TextBox runat="server" ID="txtAdminPass" CssClass="form-control" placeholder="请输入密码…" TextMode="Password" />
                        <span class="help-block"></span>
                    </div>

                    <div>
                        <label>确认密码：</label>
                        <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control" placeholder="请输入确认密码…" TextMode="Password" />
                        <span class="help-block"></span>
                    </div>

                    <p>&nbsp;</p>
                    <div align="center">
                        <asp:Button Text="保存" CssClass="btn btn-warning" runat="server" ID="btnAdd" OnClick="btnAdd_Click" />
                        <input type="reset" name="reset" value="重置" class="btn" />
                    </div>
                </fieldset>
            </form>

        </div>
    </div>


</asp:Content>

