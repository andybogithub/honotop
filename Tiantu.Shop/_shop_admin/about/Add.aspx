<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_admin/Share.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="_shop_admin_about_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
        <script src="../kindeditor/kindeditor-min.js"></script>
    <script src="../kindeditor/config.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="page-title">
        <h3>
            <asp:Literal ID="lblTitle" runat="server" /></h3>
    </div>
    <!--end page title-->

    <div class="row">
        <div class="col-sm-12">
            <div class="panel-box">
                       <p>内容详细</p>
                        <div><asp:TextBox runat="server" CssClass="form-control KE" TextMode="MultiLine" Height="300" ID="txtDetails" Width="100%" /></div>


                <p>&nbsp;</p>
                <div align="center">
                    <asp:Button Text="保存" CssClass="btn btn-warning" runat="server" ID="btnAdd" OnClick="btnAdd_Click" />
                </div>
                <asp:HiddenField ID="hfAboutId" runat="server" Value="0" />
            </div>

        </div>
    </div>
</asp:Content>

