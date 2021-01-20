<%@ Page Title="" Language="C#" MasterPageFile="~/thisisbackstage/Webadmin.master" AutoEventWireup="true" CodeFile="Honors.aspx.cs" Inherits="webadmin_Honors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid stores">
        <div class="span12">




            <div class="widget-box">
                <div class="widget-title">
                    <span class="icon"><i class="icon-picture"></i></span>
                    <h5>荣誉与资质</h5>
                </div>
                <div class="widget-content">
                    <ul class="thumbnails">
                        <asp:Repeater runat="server" ID="RepeaterStores" OnItemCommand="RepeaterStores_ItemCommand">
                            <ItemTemplate>
                                <li class="span2">
                                    <a href="#">
                                        <img src="<%# Eval("IMGURL") %>" alt="" style="width:200px;height:150px;">

                                        <div style="font-size:18px;font-weight:bold;color:goldenrod;">
                                        <asp:LinkButton CommandName="head" CommandArgument='<%# Eval("HONORID") %>' Text="首位" ID="LinkButton1"
                                            CssClass="bt" runat="server" />   
                                    
                                        <asp:LinkButton CommandName="end" CommandArgument='<%# Eval("HONORID") %>' Text="末尾" ID="LinkButton2"
                                            CssClass="bt"
                                            runat="server" />
                                        </div>

                                    </a>
                                    <div class="actions">                                        
                                        <asp:LinkButton CommandName="delete" CommandArgument='<%# Eval("HONORID") %>' Text="<i class='icon-trash'></i>" ID="btnDelete"
                                            CssClass="bt" OnClientClick="javascript:return window.confirm('确认要删除吗?');" runat="server" />
                                        <a class="lightbox_trigger" href="<%# Eval("IMGURL") %>"><i class="icon-search"></i></a>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>

                <div class="pagination alternate widget-toolbar">
                    <asp:Literal ID="lblPagination" runat="server" />
                </div>

            </div>


            <div class="widget-box">

                <div class="widget-content nopadding">
                    <div class="form-horizontal">
                        <div class="control-group">
                            <label class="control-label">选择照片：</label>
                            <div class="controls">
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                <br />
                                图片尺寸：600px * 450px
                            </div>
                        </div>
                        <div class="form-actions">
                            <asp:Button Text="上传" ID="btnAdd" CssClass="btn btn-success" runat="server"
                                OnClick="btnAdd_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <script>
        subMenu('mHonor');
    </script>


</asp:Content>

