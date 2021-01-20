<%@ Page Title="" Language="C#" MasterPageFile="~/mobile/MobileUI.master" AutoEventWireup="true" CodeFile="transport.aspx.cs" Inherits="mobile_transport" %>

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
                <li><a href="logistics.aspx">储（仓储）</a></li>
                <li class="on"><a href="transport.aspx">运配（运输及配送）</a></li>
            </ul>
        </div>
        <div class="main cl">
            <div class="ltitle">
                <h5>运输网络</h5>
                <p>天图物流全国覆盖13个陆运港，6个空运集散中心，900台车辆，形成立体式联动干线网络 </p>
            </div>
            <div class="pic">
                <img src="style/images/logistics_1.jpg">
            </div>
            <div class="logmain">
                <ul>
                    <li class="pic1 cl">
                        <div class="l c_pic">
                            <asp:Literal ID="lblPic1" runat="server"></asp:Literal>
                        </div>
                        <div class=" c_cont">
                            <h5>普货运输</h5>
                            <p>全国干线，自有资源落地配、区域配送</p>
                        </div>
                    </li>
                    <li class="pic2 cl">
                        <div class="l c_pic">
                            <asp:Literal ID="lblPic2" runat="server"></asp:Literal>
                        </div>
                        <div class=" c_cont">
                            <h5>普货运输</h5>
                            <p>食品、医药</p>
                        </div>
                    </li>
                    <li class="pic3 cl">
                        <div class="l c_pic">
                            <asp:Literal ID="lblPic3" runat="server"></asp:Literal>
                        </div>
                        <div class=" c_cont">
                            <h5>大型项目运输</h5>
                            <p>冷藏、冷冻、恒温、阴凉等各类型仓库，采用先进的控温设备，提供稳定、安全的存储空间</p>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>

