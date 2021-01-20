<%@ Page Title="" Language="C#" MasterPageFile="~/em/MobileEnUI.master" AutoEventWireup="true" CodeFile="transport.aspx.cs" Inherits="em_transport" %>

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
                <li><a href="logistics.aspx">W (Warehouses)</a></li>
                <li class="on"><a href="transport.aspx">Transportation and Distribution</a></li>
            </ul>
        </div>
        <div class="main cl">
            <div class="ltitle">
                <h5>Transportation and distribution network</h5>
                <p>  A transportation network，organically connecting 19 distribution hubs with more than 900 trucks.
                            </p>
            </div>
            <div class="pic">
                <img src="/mobile/style/images/logistics_1.jpg"/>
            </div>
            <div class="logmain">
                <ul>
                    <li class="pic1 cl">
                        <div class="l c_pic">
                            <asp:Literal ID="lblPic1" runat="server"></asp:Literal>
                        </div>
                        <div class=" c_cont">
                            <h5>Distribution Service</h5>
                            <p>Transportation and distribution for general cargos; service scope includes nationwide truck routes, local and regional distribution, and courier services</p>
                        </div>
                    </li>
                    <li class="pic2 cl">
                        <div class="l c_pic">
                            <asp:Literal ID="lblPic2" runat="server"></asp:Literal>
                        </div>
                        <div class=" c_cont">
                            <h5>Temperature-controlled transportation and distribution</h5>
                            <p>Food and medicine</p>
                        </div>
                    </li>
                    <li class="pic3 cl">
                        <div class="l c_pic">
                            <asp:Literal ID="lblPic3" runat="server"></asp:Literal>
                        </div>
                        <div class=" c_cont">
                            <h5>Oversized and project cargo transportation</h5>
                            <p>Storage of cold storage, refrigeration, constant temperature,  provide a stable and safe storage space.</p>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>

