<%@ Page Title="" Language="C#" MasterPageFile="~/MainUI.master" AutoEventWireup="true" CodeFile="report.aspx.cs" Inherits="report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .report .reportnav li{background:#f4f4f4;color:#333;}
        .report .reportnav li a{color:#333;}
        .report .reportnav li.on a{color:#fff;}
        .reportmain a:hover{color:#427ad9;}
        .report .reportmain{border:none;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        navon(4);
    </script>

    <div class="tab">
        <div class="wp cl">
            <div class="curr">
                <span><a href="index.aspx">天图物流</a></span> > <span><a href="investors.aspx">投资者关系</a></span>
                > <span><a href="report.aspx">定期报告</a></span>
            </div>
        </div>
    </div>


    <div class="container wp">
        <div class="instructions">
            <div class="insvesnav cl">
                <ul>
                    <li class="cont_1"><a href="report.aspx">定期报告</a></li>
                    <li class="cont_2"><a href="company.aspx">公司公告</a></li>
                    <li class="cont_3"><a href="stock.aspx">股票信息</a></li>
                    <li class="cont_4"><a href="instructions.aspx">招股说明书</a></li>
                </ul>
            </div>
            <div class="report cl">
                <div class="l reportnav">
                    <ul>
                        <li style="background:#427ad9;"><a href="report.aspx" style="color:#fff;">全部</a></li>
                        <asp:Literal ID="lblNav" runat="server"></asp:Literal>
                    </ul>
                </div>
                <div class="l reportmain">
                    <ul class="a cl" style="padding:15px 0;">
                        <asp:Repeater ID="RepeaterList" runat="server">
                            <ItemTemplate>
                                <li style="display:block;width:96%;margin:15px;margin-left:30px;border-bottom:1px solid #f4f4f4;padding-bottom:10px;"> 
                                    <div class="reportde">
                                        <a href="reportde.aspx?reportid=<%# Eval("REPORTID") %>">
                                            <%# GetImageText(Eval("IMGURL"),Eval("TITLE")) %>
                                            </a>
                                    </div>
                                    <div class="repdown">
                                        <a href="<%# Eval("PDFURL") %>" title="点击下载pdf文件">
                                            <img src="/style/images/pdf.png" /></a>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <%--<div class="more"><a href="#">加载更多</a></div>--%>
                </div>
                <!--翻页-->
            
                <asp:PlaceHolder ID="PlaceHolderPager" runat="server" Visible="false">
                        <link rel="stylesheet" type="text/css" href="style/css/simplePagination.css" />
                <script src="js/jquery.simplePagination.js"></script>
                <script>
                    $(function () {
                        $('#light-pagination').pagination({
                            items: <%=this.RecordCount%>,
                            itemsOnPage: 50,
                            currentPage:<%=this.PageIndex%>,
                            hrefTextPrefix: 'report.aspx?ca=<%=cateid %>&pageid=',
                            cssStyle: 'page-theme'
                        });
                    });
                </script>
                <div class="pageTurning cl">
                    <div class="r" style="margin-top: 20px;">
                        <span class="allNum"><%=this.PageIndex%> / <%=this.RecordCount/12+1%>页 |  共 <b><%=this.RecordCount%></b> 条</span>
                        <ul id="light-pagination" class="pagination"></ul>
                    </div>
                </div>
                </asp:PlaceHolder>


            </div>


        </div>
    </div>
</asp:Content>

