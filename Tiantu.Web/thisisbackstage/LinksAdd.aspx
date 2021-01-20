<%@ Page Title="" Language="C#" MasterPageFile="~/thisisbackstage/Webadmin.master" AutoEventWireup="true" CodeFile="LinksAdd.aspx.cs" Inherits="webadmin_LinksAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid">
        <div class="span0">
            <div class="widget-box">
                <div class="widget-title">
                    <span class="icon"><i class="icon-align-justify"></i></span>
                    <h5>
                        <asp:Literal ID="lblTitle" Text="股票信息" runat="server" /></h5>
                </div>
                <div class="widget-content nopadding">
                    <div class="form-horizontal">

                        <div class="control-group">

                            <div class="widget-title">
                                <ul class="nav nav-tabs">
                                    <li class="active"><a data-toggle="tab" href="#tab1">中文</a></li>
                                    <li><a data-toggle="tab" href="#tab2">英文</a></li>
                                </ul>
                            </div>
                            <div class="widget-content tab-content">
                                <div id="tab1" class="tab-pane active">

                                    <div class="control-group">
                                        <label class="control-label">标题：</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtTitle" Width="400" placeholder="标题" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTitle" ErrorMessage="必填"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>

                                <div id="tab2" class="tab-pane">
                                    <div class="control-group">
                                        <label class="control-label">英文标题：</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtTitle_en" Width="400" placeholder="英文标题" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" ErrorMessage="必填"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="control-group" style="display: none;">
                            <label class="control-label">链接：</label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtLinkURL" Width="400" placeholder="链接" />
                            </div>
                        </div>
                        <div class="control-group" style="display: none;">
                            <label class="control-label">视频地址：</label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtVideoURL" Width="400" TextMode="MultiLine" placeholder="视频地址" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">图片：</label>
                            <div class="controls">
                                <asp:Literal ID="lblImgurl" runat="server"></asp:Literal>
                                <%--<asp:HiddenField ID="hfImgurl" runat="server" />--%>
                                <br />
                                <asp:TextBox runat="server" ID="txtImgurl" Width="400" placeholder="图片地址" />
                                <br />
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                图片尺寸：380px * 200px
                            </div>
                        </div>

                        <div class="form-actions">
                            <asp:Button Text="保存" ID="btnAdd" CssClass="btn btn-success" runat="server"
                                OnClick="btnAdd_Click" />
                        </div>
                    </div>
                </div>
            </div>


            <asp:HiddenField ID="hfLINKID" runat="server" Value="0" />


        </div>
    </div>


    <script>
        subMenu('mLink');
    </script>


</asp:Content>

