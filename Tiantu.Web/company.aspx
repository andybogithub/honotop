<%@ Page Title="" Language="C#" MasterPageFile="~/MainUI.master" AutoEventWireup="true" CodeFile="company.aspx.cs" Inherits="company" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        navon(4);
    </script>

    <div class="tab">
        <div class="wp cl">
            <div class="curr">
                <span><a href="index.aspx">天图物流</a></span> > <span><a href="investors.aspx">投资者关系</a></span>
                > <span><a href="company.aspx">公司公告</a></span>
            </div>
        </div>
    </div>

    <div class="container wp">
        <div class="company">
            <div class="insvesnav cl">
                <ul>
                    <li class="cont_1"><a href="report.aspx">定期报告</a></li>
                    <li class="cont_2"><a href="company.aspx">公司公告</a></li>
                    <li class="cont_3"><a href="stock.aspx">股票信息</a></li>
                    <li class="cont_4"><a href="instructions.aspx">招股说明书</a></li>
                </ul>
            </div>
            <div class="main">
                <asp:Repeater ID="RepeaterList" runat="server">
                    <ItemTemplate>
                        <div class="consunews">
                            <dl>
                                <dd>
                                    <a href="companyde.aspx?noticeid=<%# Eval("NOTICEID") %>">
                                        <h4><%# Eval("TITLE") %></br><span><%# ((DateTime)Eval("PUBDATE")).ToString("yyyy-MM-dd")%></span></h4>
                                    </a>
                                    <a href="companyde.aspx?noticeid=<%# Eval("NOTICEID") %>">
                                        <div class="download">
                                            <a href="<%# Eval("PDFURL") %>" download>
                                                <input type="button" />下载</a>
                                        </div>
                                    </a>
                                </dd>
                            </dl>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <%--<div class="more"><a href="#">加载更多</a></div>--%>
            </div>

            <!--翻页-->
            <link rel="stylesheet" type="text/css" href="style/css/simplePagination.css" />
            <script src="js/jquery.simplePagination.js"></script>
            <script>
                $(function(){
                    $('#light-pagination').pagination({
                        items: <%=this.RecordCount%>,
                        itemsOnPage: 12,
                        currentPage:<%=this.PageIndex%>,
                            hrefTextPrefix: 'company.aspx?pageid=',
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

        </div>
    </div>
</asp:Content>

