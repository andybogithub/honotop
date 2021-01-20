<%@ Page Title="" Language="C#" MasterPageFile="~/em/MobileEnUI.master" AutoEventWireup="true" CodeFile="logistics.aspx.cs" Inherits="em_logistics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="logisticsWap">
        <div class="title cl">
            <a href="logistics.aspx">
                <h3>Logistics</h3>
            </a>
        </div>
        <div class="hrtop cl">
            <ul>
                <li class="on"><a href="logistics.aspx">W (Warehouses)</a></li>
                <li><a href="transport.aspx">Transportation and Distribution</a></li>
            </ul>
        </div>
        <div class="main cl">
            <div class="ltitle">
                <h5>Warehouse Layout</h5>
                <p>Covering 18 cities, 38 warehouses , 420,000 ㎡ storage area</p>
            </div>
            <div class="pic">
                <img src="/mobile/style/images/sto_1.jpg" />
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
                            <h5>Customized warehouses</h5>
                            <p>Customized warehouses are project based, in compliance with customers'
                               specific requirements to provide suitable facilities, systems and suggestions as a total supply chain solution.</p>
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
                            <h5>E-commerce Warehouse</h5>
                            <p>Standard warehouses for general products. Warehouse available once orders received, thus fulfilling the demand of 
                                high velocity in E-commerce business.</p>
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
                            <h5>Temperature-controlled warehouses</h5>
                            <p>All kinds of temperature-controlled warehouses, including refrigerating, freezing, constant temperature and cool ones, 
                                to provide stable and safe storage space.</p>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>

