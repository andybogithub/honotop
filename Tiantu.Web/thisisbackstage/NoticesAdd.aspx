<%@ Page Title="" Language="C#" MasterPageFile="~/thisisbackstage/Webadmin.master" AutoEventWireup="true" CodeFile="NoticesAdd.aspx.cs" Inherits="webadmin_NoticesAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="row-fluid">
        <div class="span0">
            <div class="widget-box">
                <div class="widget-title">
                    <span class="icon"><i class="icon-align-justify"></i></span>
                    <h5>
                        <asp:Literal ID="lblTitle" Text="公司公告" runat="server" /></h5>
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
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTitle" ErrorMessage="请填写标题"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">副标题 :</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtSubtitle" Height="100" Width="400" MaxLength="100" TextMode="MultiLine" placeholder="可选" />
                                        </div>
                                    </div>

                                    <div class="control-group" runat="server">
                                        <label class="control-label">PDF文件 :</label>
                                        <div class="controls">
                                            <asp:Literal ID="lblPDF" runat="server"></asp:Literal>
                                            <asp:FileUpload ID="fieluploadPDF" runat="server" />
                                            <asp:HiddenField ID="hfPDFURL" runat="server" Value="0" />
                                        </div>
                                    </div>
                                </div>

                                <div id="tab2" class="tab-pane">

                                    <div class="control-group">
                                        <label class="control-label">英文标题：</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtTitle_en" Width="400" placeholder="标题" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" ErrorMessage="请填写标题"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">英文副标题 :</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtSubtitle_en" Height="100" Width="400" MaxLength="100" TextMode="MultiLine" placeholder="可选" />
                                        </div>
                                    </div>

                                    <div class="control-group" runat="server">
                                        <label class="control-label">英文PDF文件 :</label>
                                        <div class="controls">
                                            <asp:Literal ID="lblPDF_EN" runat="server"></asp:Literal>
                                            <asp:FileUpload ID="fieluploadPDF_EN" runat="server" />
                                            <asp:HiddenField ID="hfPDFURL_EN" runat="server" Value="" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                      
                        <div class="control-group">
                            <label class="control-label">排序 :</label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtSortid" Width="200px" placeholder="排序" />
                                （数字大的排前面，默认为0）                                 
                            </div>

                        </div>

                        <div class="control-group">
                            <label class="control-label">发布时间 :</label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtPubdate" Width="100" placeholder="发布时间" />
                                <%--<img id="btnTime" src="/style/images/icon-rl.png" alt="" />--%>
                            </div>
                        </div>
                        <div class="form-actions">
                            <asp:Button Text="保存" ID="btnAdd" CssClass="btn btn-success" runat="server"
                                OnClick="btnAdd_Click" />
                        </div>
                    </div>
                </div>
            </div>


            <asp:HiddenField ID="hfNOTICEID" runat="server" Value="0" />
            <asp:HiddenField ID="hfSORTID" runat="server" Value="0" />


        </div>
    </div>

    <script src="content/kindeditor/kindeditor-all.js"></script>
    <script src="content/kindeditor/kindeditor-simple.js"></script>
    <script>
        subMenu('mNotice');
    </script>

</asp:Content>

