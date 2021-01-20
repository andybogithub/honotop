<%@ Page Title="" Language="C#" MasterPageFile="~/thisisbackstage/Webadmin.master" AutoEventWireup="true" CodeFile="WordList.aspx.cs" Inherits="thisisbackstage_WordList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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
                         
                            <div class="widget-content tab-content">
                                <div id="tab1" class="tab-pane active">
                                    <div class="control-group">
                                        <label class="control-label">关键词 :</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtFilterWord" Width="80%" Height="800" 
                                                CssClass="span11" TextMode="MultiLine" />
                                            （使用空格隔开）
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
        subMenu('mwl');
    </script>


</asp:Content>

