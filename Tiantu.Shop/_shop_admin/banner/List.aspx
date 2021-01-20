<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_admin/Share.master" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="_shop_admin_banner_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-title">
        <h3>首页轮播广告</h3>
        <a href="list.aspx" class="active"><i class="fa fa-list"></i>广告列表</a>
        <a href="add.aspx"><i class="fa fa-plus"></i>添加广告</a>
    </div>
    <!--end page title-->


    <div class="row">

        <asp:Repeater runat="server" ID="RepeaterBannerList">
            <ItemTemplate>
                <div class="col-xs-6">
                    <div class="panel-box">
                        <h4>图 <%# Container.ItemIndex+1 %>
                            <span class="pull-right">
                                <a href="add.aspx?bnid=<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("bnid").ToString()) %>" title="编辑">
                                    <i class="fa fa-edit"></i>
                                </a>
                            </span>
                        </h4>
                        <p><a href="add.aspx?bnid=<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("bnid").ToString()) %>"><img src="<%# Tiantu.DB.Common.SL.GetHttpImageURL(Eval("imgurl")) %>" width="100%" height="300" /></a></p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>



    </div>



</asp:Content>

