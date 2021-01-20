<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_admin/Share.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="_shop_admin_game_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="page-title">
        <h3>
            <asp:Literal Text="添加" ID="lblAction" runat="server" />金币游戏</h3>
    </div>
    <!--end page title-->

    <div class="row">
        <div class="col-sm-12">
            <div class="panel-box">
                <p>游戏名称</p>
                <div>
                    <asp:TextBox runat="server" ID="txtGameName"  CssClass="input-lg"  Width="100%"/>
                </div>
                   <p>链接地址</p>
                <div>
                    <asp:TextBox runat="server" ID="txtLinkUrl"   CssClass="input-lg"    Width="100%"/>
                </div>
                <p>上传图片</p>
                <div>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <br />
                    <asp:HiddenField ID="hfImageUrl" runat="server" />
                    <asp:Literal  ID="lblImageUrl" runat="server" />
                </div>

       
                <div align="center">
                    <asp:Button Text="保存" CssClass="btn btn-warning" runat="server" ID="btnAdd" OnClick="btnAdd_Click" />
                    <asp:Button Text="删除" OnClientClick="javascript:return window.confirm('确认要删除吗?');" ID="btnDelete" CssClass="btn btn-danger" runat="server" Visible="false" OnClick="btnDelete_Click" />
                </div>
                <asp:HiddenField ID="hfGameId" runat="server" Value="0" />
            </div>

        </div>
    </div>
</asp:Content>

