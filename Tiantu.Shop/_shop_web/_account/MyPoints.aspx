<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_web/Share.master" AutoEventWireup="true" CodeFile="MyPoints.aspx.cs" Inherits="_shop_web__account_MyPoints" %>
<%@ Register TagPrefix="uc" TagName="top" Src="~/_shop_web/_account/Top.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="container wp">
        <div class="centerWrap">
            <uc:top ID="uctop" runat="server" />
            <div class="centerMainWrap centerIntegralWrap">
                <div class="centerTitle"><strong>消费明细</strong></div>
                <div class="centerMain">
                    <table border="0" cellspacing="0" cellpadding="0" class="table">
							<tr>
								<th class="col_1">日期</th>
								<th class="col_2">用途/来源</th>
								<th class="col_3">充值/消费</th>
							</tr>
					 

                        <asp:Repeater runat="server" ID="RepeaterPointList">
                            <ItemTemplate>
                                <tr>
                                    <td class="col_1">
                                        <%# Eval("PubDate","{0:yyyy-MM-dd}") %>
                                    </td>
                                    <td class="col_2"><%# getContrn(Convert.ToInt32(Eval("MODELNO"))) %></td>
                                    <td class="col_3">
                                        <%# string.Format("<span class='{0}'>{1}{2}</span>",Convert.ToInt32(Eval("POINTS"))>0?"jian":"jia",
                                                Convert.ToInt32(Eval("POINTS")) > 0 ? "+":"" , Convert.ToInt32(Eval("POINTS"))) %> 元</td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                    </table>

                    <div class="pageTurning cl">
                        <ul id="light-pagination" class="pagination" style="width:500px;"></ul>
                    </div>
                    <asp:Literal ID="lblPager" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

