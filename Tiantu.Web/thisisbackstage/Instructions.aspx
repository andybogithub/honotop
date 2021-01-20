<%@ Page Title="" Language="C#" MasterPageFile="~/thisisbackstage/Webadmin.master" AutoEventWireup="true" CodeFile="Instructions.aspx.cs" Inherits="webadmin_Instructions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid">
        <div class="span0">
            <div class="widget-box">
                <div class="widget-title">
                    <span class="icon"><i class="icon-align-justify"></i></span>
                    <h5>
                        <asp:Literal ID="lblTitle" Text="招股说明书" runat="server" /></h5>
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
                                        <label class="control-label">说明 :</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtInstructionsNote" Width="600px" Height="200" CssClass="span11 KE" TextMode="MultiLine" placeholder="说明" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">PDF文件 :</label>
                                        <div class="controls">
                                            <asp:Literal ID="lblPDF" runat="server"></asp:Literal>
                                            <asp:FileUpload ID="fuPDF" runat="server" />
                                            <asp:HiddenField ID="hfPDFURL" runat="server" Value="0" />
                                        </div>
                                    </div>
                                </div>
                                <div id="tab2" class="tab-pane">

                                    <div class="control-group">
                                        <label class="control-label">英文说明 :</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtInstructionsNoteEn" Width="600px" Height="200" CssClass="span11 KE" TextMode="MultiLine" placeholder="说明" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">英文PDF文件 :</label>
                                        <div class="controls">
                                            <asp:Literal ID="lblPDF_EN" runat="server"></asp:Literal>
                                            <asp:FileUpload ID="fuPDF_EN" runat="server" />
                                            <asp:HiddenField ID="hfPDFURL_EN" runat="server" Value="0" />
                                        </div>
                                    </div>
                                </div>
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
        subMenu('mSet1');
    </script>

</asp:Content>

