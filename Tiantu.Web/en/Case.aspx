<%@ Page Title="" Language="C#" MasterPageFile="~/en/MainEnUI.master" AutoEventWireup="true" CodeFile="Case.aspx.cs" Inherits="en_Case" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <script type="text/javascript">
        navon(3);
    </script>


    <div class="tab">
        <div class="wp cl">
            <div class="curr">
                <span><a href="index.aspx">TIANTU LOGISTICS</a></span> > <span><a href="case.aspx">Our Clients </a></span>
            </div>
        </div>
    </div>

    <div class="container wp">
        <div class="case">
            <div class="title">
                <h5>Our customers</h5>
            </div>
            <div class="main cl">
                <ul>
                    <asp:Repeater ID="RepeaterList" runat="server">
                        <ItemTemplate>
                            <li><a href="#">
                                <img src="<%# Eval("IMGURL") %>" width="260" height="200" alt="<%# Eval("NOTES") %>"></a></li>
                        </ItemTemplate>
                    </asp:Repeater>

                </ul>
            </div>
        </div>
    </div>
</asp:Content>

