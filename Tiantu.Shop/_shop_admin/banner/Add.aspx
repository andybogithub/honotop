<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_admin/Share.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="_shop_admin_banner_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="page-title">
        <h3>首页轮播广告</h3>
        <a href="list.aspx"><i class="fa fa-list"></i>广告列表</a>
        <a href="add.aspx" class="active"><i class="fa fa-plus"></i>添加广告</a>
    </div>
    <!--end page title-->

    <div class="row">
        <div class="col-sm-12">
            <div class="panel-box">
                <h4><a href="List.aspx">广告列表</a> <i class="fa fa-angle-right"></i> <asp:Literal Text="添加" ID="lblPageTitle" runat="server" />广告</h4>

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
                        <asp:Label Text="<em>*</em>上传广告" runat="server" CssClass="col-sm-2 control-label" />
                        <div class="col-sm-10">
                            <div class="input-group m-b">
                                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                                <span class="input-group-addon">格式：*.jpg|*.gif|*.png"</span>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label Text="广告链接地址" runat="server" CssClass="col-sm-2 control-label" />
                        <div class="col-sm-10">
                            <div class="input-group m-b">
                                <span class="input-group-addon">http://</span>

                                <asp:TextBox runat="server" ID="txtLinkUrl" placeholder="shop.honotop.com" CssClass="form-control" />
                            </div>
                        </div>
                    </div>

                     <div class="form-group">
                        <div class="col-sm-4 col-sm-offset-2">
                            <asp:Literal  ID="lblimgIcon" runat="server" />
                        </div>
                    </div>
                 
                    <div class="form-group">
                        <div class="col-sm-4 col-sm-offset-2">
                            <input type="reset" name="reset" value="重置" class="btn btn-white" />
                            <asp:Button Text="保存" ID="btnSave" CssClass="btn btn-warning" runat="server" OnClick="btnSave_Click" />                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hfimgurl" runat="server" />
    <asp:HiddenField ID="hfbnId" runat="server" />
</asp:Content>

