<%@ Page Title="" Language="C#" MasterPageFile="~/mobile/MobileUI.master" AutoEventWireup="true" CodeFile="money.aspx.cs" Inherits="mobile_money" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="moneyWap">
        <div class="title cl">
            <a href="money.html">
                <h3>天图金融模块</h3>
            </a>
        </div>
        <div class="montop cl" style="display:none;">
            <ul>
                <li <%=caseid==4?"class='on'":"" %>><a href="money.aspx?ca=4">进货采购</a></li>
                <li <%=caseid==5?"class='on'":"" %>><a href="money.aspx?ca=5">销售</a></li>
                <li <%=caseid==6?"class='on'":"" %>><a href="money.aspx?ca=6">库存</a></li>
            </ul>
        </div>
        <div class="main cl">
            <ul style="display:none;">
                <asp:Repeater ID="RepeaterList" runat="server">
                    <ItemTemplate>
                        <li>
                            <img src="<%# Eval("IMGURL") %>" width="260" /><p>从原产地直接运输</p>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
             	<h5>供应链模块</h5>
       <%=pageModel.CONTENTS %>
        </div>



    </div>
</asp:Content>

