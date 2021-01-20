<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_admin/Share.master" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="_shop_admin_game_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="page-title">
        <h3>金币游戏管理</h3>
        <a href="list.aspx" class="active"><i class="fa fa-list"></i>金币游戏列表</a>
        <a href="add.aspx"><i class="fa fa-plus"></i>添加金币游戏</a>
    </div>
    <!--end page title-->





    <div class="row">
        <div class="col-sm-12">
            <div class="panel-box">
                <div class="form-inline">

                    <div class="form-group">
                        <label>游戏名称</label>
                        <asp:TextBox runat="server" ID="txtGameName"  CssClass="form-control" />
                    </div>
                    <asp:Button Text="查询" ID="btnQuery" CssClass="btn btn-warning" runat="server" OnClick="btnQuery_Click" />
                </div>
            </div>
        </div>
    </div>


    <div class="row">
        <div class="col-sm-12">

            <div class="panel-box">
                <h4>金币游戏列表 </h4>
                <div class="table-responsive">
                    <div class="dataTables_wrapper form-inline dt-bootstrap">

                        <table id="basic-datatables" class="table table-hover" cellspacing="0" width="100%">
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>图片</th>
                                    <th>游戏名称</th>
                                    
                                    <th class="text-center" style="width: 60px">操作</th>
                                </tr>
                            </thead>

                            <tbody>
                                <asp:Repeater runat="server" ID="RepeaterList">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex+1 %></td>
                                            <td>
                                                 
                                                <div>
                                                    <img src='<%# Tiantu.DB.Common.SL.GetHttpImageURL(Eval("imageurl")) %>' width="64" height="64" />
                                                </div>
                                            </td>
                                            <td>

                                           
                                                <h4 style="font-weight:normal;"><%# Eval("gamename") %></h4>

                                                <div>
                                                   <span>链接地址：<b><%# Eval("LinkUrl") %></b></span>
                                                </div>
                                             
                                                
                                            </td>
                                      
                                         
                                            <td class="text-center"><a href="add.aspx?gameid=<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("gameid").ToString()) %>" class="btn btn-default btn-xs">修改</a></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <hr />
                        <div class="row">
                            <asp:Literal ID="lblPager" runat="server" />
                        </div>
                    </div>

                    <div class="clearfix">
                    </div>
                </div>
            </div>
        </div>
    </div>

    <link href="../style/js/datatable/dataTables.colVis.css" rel="stylesheet" />
    <link href="../style/js/datatable/dataTables.bootstrap.css" rel="stylesheet" />
</asp:Content>

