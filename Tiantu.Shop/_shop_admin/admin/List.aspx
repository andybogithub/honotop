<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_admin/Share.master" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="admin_admin_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-sm-3 col-md-2 sidebar">
            <ul class="nav nav-sidebar">
                <li class="nav-header">操作员管理</li>
                <li><a href="Add.aspx">添加操作员</a></li>
                <li class="active"><a href="list.aspx">操作员列表</a></li>
            </ul>
        </div>
        <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">

        

            <form runat="server" id="aspNetForm">




                <fieldset>
                    <legend>操作员列表</legend>
                </fieldset>

                <div class="panel panel-default">
  <!-- Default panel contents -->
  <div class="panel-heading">操作员查询</div>
  <div class="panel-body">
    
    
                      <div class="input-group">
            <asp:TextBox runat="server"  CssClass="form-control"  placeholder="您可以输入用户名来查询..."/>
            <span class="input-group-addon">
                <i class="glyphicon glyphicon-search "></i> 查询</span>
      </div>
  </div>

  <!-- Table -->
  <table class="table">
       <thead>
            <tr>
            <th width="30">#</th><th>用户名</th><th>最后登录时间</th><th>最后登录IP</th><th width="60">操作</th>
        </tr>
       </thead>
      <tbody>
            <tr>
                      <td>1</td>
                      <td></td>
                      <td></td>
                      <td></td>
                      <td>
                          <a href="#">删除</a>
                      </td>
                  </tr>
          <asp:Repeater runat="server" ID="RepeaterList">
              <ItemTemplate>
                  <tr>
                      <td><%# Container.ItemIndex+1 %></td>
                      <td></td>
                      <td></td>
                      <td></td>
                      <td>
                          <a href="#" class="btn-link btn-danger btn-sm">删除</a>
                      </td>
                  </tr>
              </ItemTemplate>
          </asp:Repeater>
      </tbody>
  </table>
</div>
            </form>
        </div>
    </div>
</asp:Content>

