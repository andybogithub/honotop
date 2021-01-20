<%@ Page Title="" Language="C#" MasterPageFile="~/thisisbackstage/Webadmin.master" AutoEventWireup="true" CodeFile="PhotosAdd.aspx.cs" Inherits="webadmin_PhotosAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid">
        <div class="span0">
            <div class="widget-box">
                <div class="widget-title">
                    <span class="icon"><i class="icon-align-justify"></i></span>
                    <h5>
                        <asp:Literal ID="lblTitle" Text="图片展示" runat="server" /></h5>
                </div>
                <div class="widget-content nopadding">
                    <div class="form-horizontal">
                        <div class="control-group">
                            <label class="control-label">类别：</label>
                            <div class="controls">
                                <asp:DropDownList runat="server" ID="ddlCateid">
                                    <asp:ListItem Value="1">项目定制仓</asp:ListItem>
                                    <asp:ListItem Value="2">电商仓</asp:ListItem>
                                    <asp:ListItem Value="3">温控仓</asp:ListItem>
                                 <%--   <asp:ListItem Value="4">进货采购</asp:ListItem>
                                    <asp:ListItem Value="5">销售</asp:ListItem>
                                    <asp:ListItem Value="6">库存</asp:ListItem>--%>
                                    <asp:ListItem Value="7">产品1</asp:ListItem>
                                    <asp:ListItem Value="8">产品2</asp:ListItem>
                                    <asp:ListItem Value="9">产品3</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label">图片：</label>

                            <div class="controls">
                                <asp:Literal ID="lblImgurl" runat="server"></asp:Literal>
                                <asp:HiddenField ID="hfImgurl" runat="server" />
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                <br />
                                图片尺寸：260px * 310px
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label">排序 :</label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtSortid" Width="200px" placeholder="排序" />
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


            <asp:HiddenField ID="hfPhotoid" runat="server" Value="0" />
        </div>
    </div>


    <script>
        subMenu('mPhoto');
    </script>

</asp:Content>

