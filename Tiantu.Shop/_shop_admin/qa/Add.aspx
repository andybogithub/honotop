<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_admin/Share.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="_shop_admin_qa_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../kindeditor/kindeditor-min.js"></script>
    <script src="../kindeditor/config.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-title">
        <h3>帮助中心</h3>
        <a href="list.aspx"><i class="fa fa-list"></i>帮助文章列表</a>
        <a href="add.aspx" class="active"><i class="fa fa-plus"></i>添加帮助文章</a>
    </div>
    <!--end page title-->


    <div class="row">
        <div class="col-sm-12">
            <div class="panel-box">
                <h4><a href="List.aspx">帮助文章列表</a> <i class="fa fa-angle-right"></i>
                    <asp:Literal Text="添加" ID="lblPageAction" runat="server" />帮助文章</h4>
                <hr />

                <asp:Panel ID="PanelError" runat="server" Visible="false">

                    <div class="alert alert-danger text-center">
                        <a class="close" data-dismiss="alert">&times;
                        </a>
                        <strong>提示：</strong>
                        <asp:Literal ID="lblError" runat="server" />，请重试!
                    </div>
                </asp:Panel>

                <div class="form-horizontal">
                    <div class="form-group">
                        <asp:Label Text="<em>*</em>消息标题" runat="server" CssClass="col-sm-2 control-label" />
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="txtNewsTitle" CssClass="form-control" />
                        </div>
                    </div>


                    <div class="form-group">
                        <asp:Label Text="<em>*</em>正文内容" runat="server" CssClass="col-sm-2 control-label" />
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="txtNewsBody" CssClass="form-control KE" TextMode="MultiLine" Height="500" />
                        </div>
                    </div>


                    <div class="form-group">
                        <div class="col-sm-4 col-sm-offset-2">
                            <input type="reset" name="reset" value="重置" class="btn btn-white" />
                            <asp:Button Text="保存" ID="btnSave" CssClass="btn btn-warning" runat="server" OnClick="btnSave_Click" />
                            <asp:Button Text="删除" ID="btnDelete" CssClass="btn btn-danger" Visible="false" OnClientClick="javascript:return window.confirm('确认要删除产品并清空相关购买记录吗？');" runat="server" OnClick="btnDelete_Click" />
                            <asp:HiddenField ID="hfNewsId" runat="server" Value="0" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

