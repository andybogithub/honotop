<%@ Page Title="" Language="C#" MasterPageFile="~/en/MainEnUI.master" AutoEventWireup="true" CodeFile="report.aspx.cs" Inherits="en_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        navon(4);
    </script>

    <div class="tab">
        <div class="wp cl">
            <div class="curr">
                <span><a href="index.aspx">TIANTU LOGISTICS</a></span> > <span><a href="investors.aspx">Investor Relations</a></span>
                > <span><a href="report.aspx">Periodical reports</a></span>
            </div>
        </div>
    </div>


    <div class="container wp">
        <div class="instructions">
            <div class="insvesnav cl">
                <ul>
                    <li class="cont_1"><a href="report.aspx">Periodical reports</a></li>
                    <li class="cont_2"><a href="company.aspx">Company announcement</a></li>
                    <li class="cont_3"><a href="stock.aspx">Stock information</a></li>
                    <li class="cont_4"><a href="instructions.aspx">Prospectus</a></li>
                </ul>
            </div>
            <div class="report cl">
                <div class="l reportnav">
                    <ul>
                        <asp:Literal ID="lblNav" runat="server"></asp:Literal>
                    </ul>
                </div>
                <div class="l reportmain">
                    <ul class="a cl">
                        <asp:Repeater ID="RepeaterList" runat="server">
                            <ItemTemplate>
                                <li>
                                    <div class="reportde">
                                        <a href="reportde.aspx?reportid=<%# Eval("REPORTID") %>">
                                            <img src="<%# Eval("IMGURL") %>" width="420" height="500" /></a>
                                    </div>
                                    <div class="repdown">
                                        <a href="<%# Eval("PDFURL_EN").ToString()=="" ?Eval("PDFURL"):Eval("PDFURL_EN") %>" download>
                                            <img src="/style/images/en/report_down.png" /></a>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <%--<div class="more"><a href="#">加载更多</a></div>--%>
                </div>
                <!--翻页-->
                <link rel="stylesheet" type="text/css" href="/style/css/simplePagination.css" />
                <script src="/js/jquery.simplePagination.js"></script>
                <script>
                    $(function(){
                        $('#light-pagination').pagination({
                            items: <%=this.RecordCount%>,
                            itemsOnPage: 12,
                            currentPage:<%=this.PageIndex%>,
                            hrefTextPrefix: 'report.aspx?ca=<%=cateid %>&pageid=',
                            cssStyle: 'page-theme'
                        });
                    });
                </script>
                <div class="pageTurning cl">
                    <div class="r" style="margin-top: 20px;">
                        <span class="allNum"><%=this.PageIndex%> / <%=this.RecordCount/12+1%> Page |  Totle <b><%=this.RecordCount%></b> </span>
                        <ul id="light-pagination" class="pagination"></ul>
                    </div>
                </div>
            </div>


        </div>
    </div>
</asp:Content>

