<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_admin/Share.master" AutoEventWireup="true" CodeFile="Details.aspx.cs" Inherits="_shop_admin_order_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-title">
        <h3>订单中心</h3>
        <a href="List.aspx">订单查询</a>
    </div>
    <!--end page title-->


    <div class="row">
        <div class="col-sm-6">
            <div class="panel-box">
                <h4>订单详细</h4>
                <hr />
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-sm-3">订单日期</label>
                        <div class="col-sm-9">
                            <asp:Literal ID="lblOrderDate" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3">收货人</label>
                        <div class="col-sm-9">
                            <asp:Literal ID="lblUserName" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3">联系方式</label>
                        <div class="col-sm-9">
                            <asp:Literal ID="lblUserTel" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3">收货地址</label>
                        <div class="col-sm-9">
                            <asp:Literal ID="lblAddress" runat="server" />
                        </div>
                    </div>
                    <hr />
                    <div class="form-group">
                        <div class="col-sm-9">
                            <a href="List.aspx" class="btn btn-default">返回</a>
                        </div>
                        <div class="col-sm-3">
                            <asp:Button Text="删除" ID="btnDelete" CssClass="btn btn-danger" OnClientClick="javascript:return window.confirm('确认要删除吗？');" runat="server" OnClick="btnDelete_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-6">
            <div class="panel-box">
                <h4>物流信息</h4>
                <hr />
                <div class="form-horizontal">
                    <div class="form-group">
                        <asp:Label Text="配送方式" runat="server" CssClass="col-sm-3 control-label" />
                        <div class="col-sm-9">
                            <asp:Literal ID="lblShipment" runat="server" />
                        </div>
                    </div>
                </div>
                <div class="form-horizontal">
                    <div class="form-group">
                        <asp:Label Text="保险费用" runat="server" CssClass="col-sm-3 control-label" />
                        <div class="col-sm-9">
                            <asp:Literal ID="lblInsurancePrice" runat="server" />
                        </div>
                    </div>
                </div>
                <div class="form-horizontal">

                    <div class="form-group">
                        <asp:Label Text="物流公司" runat="server" CssClass="col-sm-3 control-label" />
                        <div class="col-sm-9">
                            <asp:TextBox runat="server" ID="txtShipCompany" CssClass="form-control" />
                        </div>

                    </div>
                    <div class="form-group">
                        <asp:Label Text="承运单号" runat="server" CssClass="col-sm-3 control-label" />
                        <div class="col-sm-9">
                            <asp:TextBox runat="server" ID="txtShipNo" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-4 col-sm-offset-3">
                            <asp:Button Text="确认已寄出" ID="btnSave" CssClass="btn btn-warning" runat="server" OnClick="btnSave_Click" />
                            <asp:HiddenField ID="hfopId" runat="server" Value="0" />
                        </div>
                    </div>

                </div>
            </div>
        </div>

        <%if(IsOpenWin){ %>
          <div class="col-sm-6">
            <div class="panel-box">
                <h4>开奖信息</h4>
                <hr />
                <div class="form-horizontal">
                    <div class="form-group">
                        <asp:Label Text="中奖号码" runat="server" CssClass="col-sm-3 control-label" />
                        <div class="col-sm-9">
                            <asp:Literal ID="lblWinNo" runat="server" />
                        </div>
                    </div>
                </div>

                     <div class="form-horizontal">
                    <div class="form-group">
                        <asp:Label Text="开奖时间" runat="server" CssClass="col-sm-3 control-label" />
                        <div class="col-sm-9">
                            <asp:Literal ID="lblWinDate" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            </div>
        <%} %>
    </div>
</asp:Content>

