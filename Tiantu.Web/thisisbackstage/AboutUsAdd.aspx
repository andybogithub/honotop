<%@ Page Title="" Language="C#" MasterPageFile="~/thisisbackstage/Webadmin.master" AutoEventWireup="true" CodeFile="AboutUsAdd.aspx.cs" Inherits="webadmin_AboutUsAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row-fluid">
        <div class="span0">
            <div class="widget-box">
                <div class="widget-title">
                    <span class="icon"><i class="icon-align-justify"></i></span>
                    <h5>关于天图</h5>
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
                                    <div class="control-group" style="display:none;">
                                        <label class="control-label short">标题 :</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtTitle" Width="90%" placeholder="标题" MaxLength="250" />
                                        </div>
                                    </div>
                                    <div class="control-group" >
                                        <label class="control-label">内容 :</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtContents" Height="600" Width="90%" CssClass="span11 KE" TextMode="MultiLine" placeholder="内容" />
                                        </div>
                                    </div>
                                </div>

                                <div id="tab2" class="tab-pane">
                                    <div class="control-group" style="display:none;">
                                        <label class="control-label short">英文标题 :</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtTitle_en" Width="90%" placeholder="标题" MaxLength="250" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">英文内容 :</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtContents_en" Height="600" Width="90%" CssClass="span11 KE" TextMode="MultiLine" placeholder="内容" />
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
            <asp:HiddenField ID="hfAboutid" runat="server" Value="0" />
            <asp:HiddenField ID="hfSortid" runat="server" Value="0"/>
        </div>
    </div>



    <script src="content/kindeditor/kindeditor-all.js"></script>
    <script src="content/kindeditor/kindeditor-simple.js"></script>

    <script>
        subMenu('mAbout<%=abid %>');
        var ct100 = 'ctl00_ContentPlaceHolder1_';
    </script>

</asp:Content>

