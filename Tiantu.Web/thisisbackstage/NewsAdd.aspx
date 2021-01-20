<%@ Page Title="" Language="C#" MasterPageFile="~/thisisbackstage/Webadmin.master" AutoEventWireup="true" CodeFile="NewsAdd.aspx.cs" Inherits="webadmin_NewsAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid">
        <div class="span0">
            <div class="widget-box">
                <div class="widget-title">
                    <span class="icon"><i class="icon-align-justify"></i></span>
                    <h5>
                        <asp:Literal ID="lblTitle" Text="新闻管理" runat="server" /></h5>
                </div>
                <div class="widget-content nopadding">
                    <div class="form-horizontal">
                        <div class="control-group">
                            <label class="control-label">类别：</label>
                            <div class="controls">
                                <asp:DropDownList runat="server" ID="ddlCateid" OnSelectedIndexChanged="ddlCateid_SelectedIndexChanged" AutoPostBack="True">
                                    <asp:ListItem Value="1">新闻资讯</asp:ListItem>
                                    <asp:ListItem Value="2">新闻报道</asp:ListItem>
                                    <asp:ListItem Value="3">杂志报道</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

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

                                    <div class="control-group">
                                        <label class="control-label">新闻详情 :</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtContents" Height="400" Width="90%" CssClass="span11 KE" TextMode="MultiLine" placeholder="新闻详情" />
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

                                    <div class="control-group">
                                        <label class="control-label">英文新闻详情 :</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtContents_en" Height="400" Width="90%" CssClass="span11 KE" TextMode="MultiLine" placeholder="新闻详情" />
                                        </div>
                                    </div>                                  
                                </div>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label">首页显示图片：</label>

                            <div class="controls">
                                <asp:Literal ID="lblImgurl" runat="server"></asp:Literal>
                                <asp:HiddenField ID="hfImgurl" runat="server" />
                                   <br />
                                <asp:FileUpload ID="FileUpload1" runat="server" />                                
                                图片尺寸：220px * 280px
                            </div>
                            <div class="controls" style="display: inline-flex">
                                <asp:CheckBox ID="cbIsTop" runat="server" Text="是否首页显示" Visible="true" />
                            </div>                          
                        </div>

                        <div class="control-group" style="display:none">
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


            <asp:HiddenField ID="hfNEWSID" runat="server" Value="0" />
            <asp:HiddenField ID="hfSORTID" runat="server" Value="0" />


        </div>
    </div>

    <script src="content/kindeditor/kindeditor-all.js"></script>
    <script src="content/kindeditor/kindeditor-simple.js"></script>

    <script>
        subMenu('mNews');
    </script>




</asp:Content>

