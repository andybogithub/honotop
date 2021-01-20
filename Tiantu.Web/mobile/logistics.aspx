<%@ Page Title="" Language="C#" MasterPageFile="~/mobile/MobileUI.master" AutoEventWireup="true" CodeFile="logistics.aspx.cs" Inherits="mobile_logistics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="logisticsWap">
        <div class="title cl">
            <a href="logistics.aspx">
                <h3>天图物流模块</h3>
            </a>
        </div>
        <div class="hrtop cl">
            <ul>
                <li class="on"><a href="logistics.aspx">储（仓储）</a></li>
                <li><a href="transport.aspx">运配（运输及配送）</a></li>
            </ul>
        </div>
        <div class="main cl">
            <div class="ltitle">
                <h5>仓库分布</h5>
                <p>18个城市   38个云仓  42万㎡ 运作面积, 覆盖32个省份  </p>
            </div>
            <div class="pic">
                <img src="style/images/sto_1.jpg" />
            </div>
            <div class="stomain">
                <ul>
                    <li class="pic1 cl">
                        <div class="l c_pic">
                            <asp:Repeater ID="RepeaterList1" runat="server">
                                <ItemTemplate>
                                    <img src="<%# Eval("IMGURL") %>" width="120" height="100" />
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div class=" c_cont">
                            <h5>项目定制仓</h5>
                            <p>项目型、定制型仓库，为有特殊要求的客户度身定制仓储场地及方案，提供合乎要求的设备、系统及顾问式供应链服务。</p>
                        </div>
                    </li>
                    <li class="pic2 cl">
                        <div class="l c_pic">
                            <asp:Repeater ID="RepeaterList2" runat="server">
                                <ItemTemplate>
                                    <img src="<%# Eval("IMGURL") %>" width="120" height="100" />
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div class=" c_cont">
                            <h5>电商仓</h5>
                            <p>通用型标准仓库，适用于各类产品储存。即约即进仓，满足各类电商企业快进快出的需求。</p>
                        </div>
                    </li>
                    <li class="pic3 cl">
                        <div class="l c_pic">
                            <asp:Repeater ID="RepeaterList3" runat="server">
                                <ItemTemplate>
                                    <img src="<%# Eval("IMGURL") %>" width="120" height="100" />
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div class=" c_cont">
                            <h5>温控仓</h5>
                            <p>冷藏、冷冻、恒温、阴凉等各类型仓库，采用先进的控温设备，提供稳定、安全的存储空间</p>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>

