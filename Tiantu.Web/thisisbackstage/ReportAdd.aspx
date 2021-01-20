<%@ Page Title="" Language="C#" MasterPageFile="~/thisisbackstage/Webadmin.master" AutoEventWireup="true" CodeFile="ReportAdd.aspx.cs" Inherits="webadmin_ReportAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid">
        <div class="span0">
            <div class="widget-box">
                <div class="widget-title">
                    <span class="icon"><i class="icon-align-justify"></i></span>
                    <h5>
                        <asp:Literal ID="lblTitle" Text="定期报告" runat="server" /></h5>
                </div>
                <div class="widget-content nopadding">
                    <div class="form-horizontal">
                        <div class="control-group">
                            <label class="control-label">类别：</label>
                            <div class="controls">
                                <asp:DropDownList runat="server" ID="ddlCateid" AutoPostBack="True">
                                    <asp:ListItem Value="0">请选择</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label">标题 :</label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtTitle" Width="200px" placeholder="标题" />
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label">图片：</label>

                            <div class="controls">
                                <asp:Literal ID="lblImgurl" runat="server"></asp:Literal>
                                <asp:HiddenField ID="hfImgurl" runat="server" />
                                <asp:FileUpload ID="FileUpload1" runat="server"  />
                                <br />
                                图片尺寸：420px * 500px
                            </div>

                        </div>

                        <div class="control-group">
                            <div>
                                <ul class="nav nav-tabs">
                                    <li class="active"><a data-toggle="tab" href="#tab1">中文</a></li>
                                    <li><a data-toggle="tab" href="#tab2">英文</a></li>
                                </ul>
                            </div>

                            <div class="tab-content">
                                <div id="tab1" class="tab-pane active">
                                    <div class="control-group">
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
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="请输入规范数字" ControlToValidate="txtSortid" ValidationExpression="^\d*$"></asp:RegularExpressionValidator>
                                （数字大的排前面）                                 
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


            <asp:HiddenField ID="hfReportid" runat="server" Value="0" />
        </div>
    </div>

    <script>
        subMenu('mReport');
    </script>

</asp:Content>

