<%@ Page Title="" Language="C#" MasterPageFile="~/thisisbackstage/Webadmin.master" AutoEventWireup="true" CodeFile="Configure.aspx.cs" Inherits="webadmin_Configure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid">
        <div class="span0">
            <div class="widget-box">
                <div class="widget-title">
                    <span class="icon"><i class="icon-align-justify"></i></span>
                    <h5>
                        <asp:Literal ID="lblTitle" Text="网站配置" runat="server" /></h5>
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
                                        <label class="control-label">底部版权 :</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtCopyright" Width="600px" Height="200" CssClass="span11 KE" TextMode="MultiLine" placeholder="底部版权" />
                                        </div>
                                    </div>
                                </div>
                                <div id="tab2" class="tab-pane">
                                    <div class="control-group">
                                        <label class="control-label">底部版权英文 :</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtCopyright_en" Width="600px" Height="200" CssClass="span11 KE" TextMode="MultiLine" placeholder="底部版权" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label">Logo:</label>
                            <div class="controls">
                                <asp:Literal ID="lblLogo" runat="server"></asp:Literal>
                                <br />
                                <asp:FileUpload ID="fieluploadLogo" runat="server" />
                                <asp:HiddenField ID="hfLogo" runat="server" Value="0" />
                                图片尺寸：200px * 60px
                            </div>
                        </div>

                        <div class="form-actions">
                            <asp:Button Text="保存" ID="btnAdd" CssClass="btn btn-success" runat="server"
                                OnClick="btnAdd_Click" />
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>


    <script src="content/kindeditor/kindeditor-all.js"></script>
    <script src="content/kindeditor/kindeditor-simple.js"></script>

    <script>
        subMenu('mConfig');
    </script>

</asp:Content>

