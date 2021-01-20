<%@ Page Title="" Language="C#" MasterPageFile="~/en/MainEnUI.master" AutoEventWireup="true" CodeFile="news.aspx.cs" Inherits="en_news" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        navon(5);
    </script>

    <div class="tab">
        <div class="wp cl">
            <div class="curr"><span><a href="index.aspx">TIANTU LOGISTICS</a></span> > <span><a href="news.aspx">News Center</a></span></div>
        </div>
    </div>

    <div class="container">
        <div class="wp">
            <div class="news">
                <div class="l newsnav">
                    <div class="title">
                        <p>
                            News <br />
                            <span>Center</span>
                        </p>
                    </div>
                    <div class="navmain">
                        <ul>
                            <asp:Literal ID="lblNav" runat="server"></asp:Literal>
                        </ul>
                    </div>
                </div>
                <div class="l newsmain">
                    <div class="maintop">
                        <img src="/style/images/newsbanner.jpg" width="920" height="400">
                    </div>
                    <div class="mainbot">
                        <div class="main_2">
                            <ul>
                                <asp:Repeater ID="RepeaterList" runat="server">
                                    <ItemTemplate>
                                        <li><a href="newsde.aspx?no=<%# Eval("NEWSID") %>"><%# Eval("TITLE_EN") %><span><%# ((DateTime)Eval("PUBDATE")).ToString("yyyy/MM/dd")%></span></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <!--翻页-->
                        <link rel="stylesheet" type="text/css" href="/style/css/simplePagination.css" />
                        <script src="/js/jquery.simplePagination.js"></script>
                        <script>
                            $(function(){
                                $('#light-pagination').pagination({
                                    items: <%=this.RecordCount%>,
                                    itemsOnPage: 10,
                                    currentPage:<%=this.PageIndex%>,
                                    hrefTextPrefix: 'news.aspx?ca=<%=cateid %>&pageid=',
                                    cssStyle: 'page-theme'
                                });
                            });
                        </script>
                        <div class="pageTurning cl">
                            <div class="r">
                                <span class="allNum"><%=this.PageIndex%> / <%=this.RecordCount/10+1%> Page |  Totle <b><%=this.RecordCount%></b></span>
                                <ul id="light-pagination" class="pagination"></ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

