<%@ Page Title="" Language="C#" MasterPageFile="~/thisisbackstage/Webadmin.master" AutoEventWireup="true" CodeFile="AdminAdd.aspx.cs" Inherits="webadmin_AdminAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="row-fluid">
        <div class="span0">

            <div class="widget-box">
                <div class="widget-title">
                    <span class="icon"><i class="icon-align-justify"></i></span>
                    <h5>
                        <asp:Literal Text="新增" ID="lblH4" runat="server" />管理员</h5>
                </div>
                <div class="widget-content nopadding">
                    <div class="form-horizontal">
                        <div class="control-group">
                            <label class="control-label">登录账号：</label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtADMINNAME" class="span11" placeholder="登录账号" Width="400" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="*" ControlToValidate="txtADMINNAME" runat="server" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">登录密码：</label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtADMINPASS" TextMode="Password" class="span11" placeholder="登录密码" Width="400" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="*" ControlToValidate="txtADMINPASS" runat="server" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">确认密码：</label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtADMINPASS2" TextMode="Password" class="span11" placeholder="确认密码" Width="400" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="*" ControlToValidate="txtADMINPASS2" runat="server" />
                                <asp:CompareValidator ID="CompareValidator1" ErrorMessage="确认密码不正确" Display="Dynamic" ControlToValidate="txtADMINPASS2" ControlToCompare="txtADMINPASS" runat="server" />
                            </div>
                            <div class="form-actions">
                                <asp:Button Text="提交" ID="btnAdd" CssClass="btn btn-primary" runat="server" OnClick="btnAdd_Click" />
                                &nbsp;&nbsp;&nbsp;
                                      <asp:Button Text="删除" Visible="false" ID="btnRemove" CssClass="btn btn-danger"
                                          runat="server" OnClick="btnRemove_Click" OnClientClick="javascript:return window.confirm('确定要删除吗?');" />
                            </div>
                        </div>
                        <asp:HiddenField ID="hfAdminId" runat="server" Value="0" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script>
        subMenu('mAdmin');
    </script>
</asp:Content>

