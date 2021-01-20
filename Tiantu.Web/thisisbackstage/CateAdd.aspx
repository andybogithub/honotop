<%@ Page Title="" Language="C#" MasterPageFile="~/thisisbackstage/Webadmin.master" AutoEventWireup="true" CodeFile="CateAdd.aspx.cs" Inherits="webadmin_CateAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid">
        <div class="span0">
            <div class="widget-box">
                <div class="widget-title">
                    <span class="icon"><i class="icon-align-justify"></i></span>
                    <h5>
                        <asp:Literal ID="lblTitle" Text="添加类别" runat="server" /></h5>
                </div>
                <div class="widget-content nopadding">
                    <div class="form-horizontal">

                        <div class="control-group">
                            <label class="control-label">名称 :</label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtCatename" Width="200px" placeholder="名称" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCatename" ErrorMessage="必填"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label">排序 :</label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtSortid" Width="200px" placeholder="排序" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="请输入规范数字" ControlToValidate="txtSortid" ValidationExpression="^\d*$"></asp:RegularExpressionValidator>
                                （数字大的排前面，默认为0） 
                            </div>
                        </div>

                        <div class="form-actions">
                            <asp:Button Text="保存" ID="btnAdd" CssClass="btn btn-success" runat="server"
                                OnClick="btnAdd_Click" />
                        </div>
                    </div>
                </div>
            </div>

            <asp:HiddenField ID="hfParentid" runat="server" Value="0" />
            <asp:HiddenField ID="hfCateid" runat="server" Value="0" />
            <asp:HiddenField ID="hfClzid" runat="server" Value="0" />
        </div>
    </div>


    <script>
        subMenu('mCate4');
    </script>

</asp:Content>

