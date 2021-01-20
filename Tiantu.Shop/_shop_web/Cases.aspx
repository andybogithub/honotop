<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_web/Share.master" AutoEventWireup="true" CodeFile="Cases.aspx.cs" Inherits="_shop_web_Cases" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="container wp">
        <div class="indianaWrap cl adsajswap">

            <div class="earnwap">
                <ul>

                    <asp:Repeater ID="RepeaterCases" runat="server">
                        <ItemTemplate>
                            <li>
                                <a href="#">
                                    <div class="pic">
                                        <img src="http://www.honotop.com/<%# Eval("IMGURL") %>" onload="DrawImage(this, 260, 200)" alt="<%# Eval("NOTES") %>" />
                                    </div>
                                    <div class="info">
                                        <h4></h4>
                                    </div>
                                </a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>

            </div>


         <%--   <!--翻页-->
            <link rel="stylesheet" type="text/css" href="style/css/simplePagination.css" />
            <script src="js/jquery.simplePagination.js"></script>
            <script>
                $(function () {
                    $('#light-pagination').pagination({
                        pages: 20,
                        cssStyle: 'page-theme'
                    });
                })
            </script>
            <div class="pageTurning cl">
                <ul id="light-pagination" class="pagination"></ul>
            </div>--%>

        </div>
    </div>


</asp:Content>

