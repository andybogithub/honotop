<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_admin/Share.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="_shop_admin_duobao_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../kindeditor/kindeditor-min.js"></script>
    <script src="../kindeditor/config.js"></script>

    <!--   datetimepicker -->
    <link href="../style/css/jquery.datetimepicker.css" rel="stylesheet" />
    <script src="../style/js/jquery.datetimepicker.js"></script>
    <script>

        $(document).ready(function () {
            jQuery.datetimepicker.setLocale('ch');
            $(".datetimepicker").datetimepicker({ step: 1 });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-title">
        <h3>夺宝商品管理</h3>
        <a href="list.aspx"><i class="fa fa-list"></i>夺宝商品查询</a>
        <a href="add.aspx" class="active"><i class="fa fa-plus"></i>添加夺宝商品</a>
    </div>
    <!--end page title-->


    <div class="row">
        <div class="col-sm-12">
            <div class="panel-box">
                <h4>
                    <span class="pull-right">
                        <a href="<%=Request.Url.PathAndQuery %>" class="btn btn-default">返回</a>
                    </span>
                    <a href="List.aspx">夺宝商品查询</a> <i class="fa fa-angle-right"></i>
                    <asp:Literal Text="添加" ID="lblPageAction" runat="server" />商品</h4>

                <hr />

                <asp:Panel ID="PanelError" runat="server" Visible="false">
                    <div class="alert alert-danger text-center">
                        <a class="close" data-dismiss="alert">&times;
                        </a>
                        <strong>提示：</strong>
                        <asp:Literal ID="lblError" runat="server" />
                    </div>
                </asp:Panel>

                <div class="form-horizontal">


                    <div class="form-group" style="display:none;">
                        <label class="col-sm-2 control-label"><em>*</em>商品分类</label>
                        <div class="col-sm-2">
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCategoryId">
                            </asp:DropDownList>
                        </div>
                    </div>


                    <div class="form-group">
                        <label class="col-sm-2 control-label"><em>*</em>商品名称</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="txtProductName" CssClass="form-control" />
                        </div>
                    </div>
                     
                    
                    <div class="form-group">
                        <label class="col-sm-2 control-label"><em>*</em>总需人次</label>
                        <div class="col-sm-2">
                            <div class="input-group m-b">
                                <asp:TextBox runat="server" ID="txtDBNeedTotal" CssClass="form-control" />
                                <span class="input-group-addon">次</span>
                            </div>
                        </div>
                    </div>

                  
                     

                    <div class="form-group" style="display:none;">
                        <label class="col-sm-2 control-label">商品备注</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="txtSubName" CssClass="form-control" />
                        </div>
                    </div>

                        <div class="form-group" >
                        <label class="col-sm-2 control-label"><em>*</em>夺宝价格</label>
                        <div class="col-sm-2">
                            <div class="input-group m-b">
                                <asp:TextBox runat="server" ID="txtSeckillPoint" CssClass="form-control" onkeyup="if(this.value.length==1){this.value=this.value.replace(/[^1-9]/g,'')}else{this.value=this.value.replace(/\D/g,'')}" onafterpaste="if(this.value.length==1){this.value=this.value.replace(/[^1-9]/g,'')}else{this.value=this.value.replace(/\D/g,'')}" />
                                <span class="input-group-addon">元</span>
                            </div>
                        </div>
                    </div>
                       <div class="form-group" style="display:none;">
                        <label class="col-sm-2 control-label">夺宝结束时间</label>
                        <div class="col-sm-2">
                            <div class="input-group m-b">
                                <asp:TextBox runat="server" ID="txtSeckillEndTime" CssClass="form-control datetimepicker" Width="200" />
                            </div>
                        </div>
                    </div>
                    <div class="form-group" style="display:none;">
                        <label class="col-sm-2 control-label"><em>*</em>购买价格</label>
                        <div class="col-sm-2">
                            <div class="input-group m-b">
                                <asp:TextBox runat="server" ID="txtPoint" CssClass="form-control" onkeyup="if(this.value.length==1){this.value=this.value.replace(/[^1-9]/g,'')}else{this.value=this.value.replace(/\D/g,'')}" onafterpaste="if(this.value.length==1){this.value=this.value.replace(/[^1-9]/g,'')}else{this.value=this.value.replace(/\D/g,'')}" />
                                <span class="input-group-addon">分</span>
                            </div>
                        </div>
                    </div>


                    <div class="form-group" style="display:none;">
                        <label class="col-sm-2 control-label"><em>*</em>库存数量</label>
                        <div class="col-sm-10">
                            <div class="input-group m-b">
                                <asp:TextBox runat="server"  ID ="txtQty" CssClass="form-control" onkeyup="if(this.value.length==1){this.value=this.value.replace(/[^1-9]/g,'')}else{this.value=this.value.replace(/\D/g,'')}" onafterpaste="if(this.value.length==1){this.value=this.value.replace(/[^1-9]/g,'')}else{this.value=this.value.replace(/\D/g,'')}" />
                                <span class="input-group-addon">库存数量为1~9999 件以内</span>
                            </div>
                        </div>
                    </div>

                    <div class="form-group"  style="display:none;">
                        <label class="col-sm-2 control-label"><em>*</em>库存状态</label>
                        <div class="col-sm-2">
                            <asp:DropDownList runat="server" ID="ddlQtyStatus" CssClass="form-control">
                                <asp:ListItem Text="库存充足" Value="库存充足" />
                                <asp:ListItem Text="库存紧张" Value="库存紧张" />
                                <asp:ListItem Text="无货" Value="无货" />
                            </asp:DropDownList>
                        </div>
                    </div>





                    <div class="form-group">
                        <label class="col-sm-2 control-label"><em>*</em>商品图片</label>
                        <div class="col-sm-10">
                            <div class="input-group m-b">
                                <asp:FileUpload ID="FileIcon" runat="server" CssClass="form-control" />
                                <span class="input-group-addon">尺寸：宽高均为 430px，格式：*.jpg|*.gif|*.png"，图片在1MB以内</span>
                            </div>
                        </div>
                    </div>


                    <div class="form-group">
                        <div class="col-sm-4 col-sm-offset-2">
                            <asp:Literal ID="lblimgIcon" runat="server" />
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-sm-2 control-label">快递保险费</label>
                        <div class="col-sm-2">
                            <div class="input-group m-b">
                                <asp:TextBox runat="server" ID="txtPrice" CssClass="form-control" />
                                <span class="input-group-addon">元</span>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-sm-2 control-label">快递方式</label>
                        <div class="col-sm-4 form-horizontal">
                            <asp:RadioButtonList runat="server" ID="rbtnShipment">
                                <asp:ListItem Text="运费到付" Value="运费到付" Selected="True" />
                                <asp:ListItem Text="包邮" Value="包邮" />
                            </asp:RadioButtonList>
                        </div>
                    </div>


                    <div class="form-group">

                        <div class="col-sm-10  col-sm-offset-2">

                            <ul class="list-group" >

                                <li class="list-group-item" style="display:none;">
                                    <asp:CheckBox Text="热门商品" ID="chkHotTag" runat="server" CssClass="checkbox-inline" />
                                    <asp:CheckBox Text="推荐商品" ID="chkTJTag" runat="server" CssClass="checkbox-inline" />
                                    <asp:CheckBox Text="首页显示" ID="chkShowHomeTag" runat="server" CssClass="checkbox-inline" />
                                </li>
                                <li class="list-group-item" style="display:none;">
                                    <table>
                                        <tr>

                                            <td>
                                                <div class="row">
                                                    <div class="col-sm-2">
                                                        <asp:CheckBox Text="夺宝商品" ID="chkSeckillTag" runat="server" CssClass="checkbox-inline"  Checked="true" />
                                                    </div>
                                                  
                                                </div>
                                            </td>
                                        </tr>
                                    </table>




                                </li>
                            </ul>

                        </div>
                    </div>



                    <div class="form-group">
                        <label class="col-sm-2 control-label">商品详细</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" CssClass="form-control KE" TextMode="MultiLine" Height="400" ID="txtDetails" Width="100%" />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-4 col-sm-offset-2">
                            <div class="row">

                                <div class="col-sm-3">
                                    <asp:Button Text="保存" ID="btnSave" CssClass="btn btn-warning btn-block" runat="server" OnClick="btnSave_Click" />
                                </div>
                                <div class="col-sm-3">
                                    <input type="reset" name="reset" value="重置" class="btn  btn-default  btn-block" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:Button Text="上架" ID="btnOnLine" CssClass="btn btn-info  btn-block" Visible="false" OnClientClick="javascript:return window.confirm('确认要上架吗?');" runat="server" OnClick="btnOnLine_Click" />
                                    <asp:Button Text="下架"  ID="btnOffLine" CssClass="btn btn-primary  btn-block" Visible="false" OnClientClick="javascript:return window.confirm('确认要下架吗?');" runat="server" OnClick="btnOffLine_Click" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:Button Text="删除" ID="btnDelete" CssClass="btn btn-danger  btn-block" Visible="false" OnClientClick="javascript:return window.confirm('确认要删除产品并清空相关购买记录吗？');" runat="server" OnClick="btnDelete_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hfimageIcon" runat="server" />
    <asp:HiddenField ID="hfproductId" runat="server" />


</asp:Content>

