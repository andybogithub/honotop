<%@ Page Title="" Language="C#" MasterPageFile="~/MainUI.master" AutoEventWireup="true" CodeFile="investors.aspx.cs" Inherits="investors" %>

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

            </div>
        </div>
    </div>

    <div class="indexBanner">
        <a href="#">
            <img src="/style/images/investors_banner.jpg" width="100%" /></a>
    </div>


    <div class="container wp">
        <div class="investors">
            <div class="title">
                <h5>投资者关系</h5>
                <p>Investor Relations</p>
            </div>
            <div class="invnav cl">
                <ul>
                    <li class="cont_1"><a href="report.aspx">
                        <div class="l pic">
                            <img src="/style/images/investors_icon1.png" width="100" height="100" />
                        </div>
                        <div class="c_cont">定期报告</div>
                    </a></li>
                    <li class="cont_2"><a href="company.aspx">
                        <div class="l pic">
                            <img src="/style/images/investors_icon2.png" width="100" height="100" />
                        </div>
                        <div class="c_cont">公司公告</div>
                    </a></li>
                    <li class="cont_3"><a href="stock.aspx">
                        <div class="l pic">
                            <img src="/style/images/investors_icon3.png" width="100" height="100" />
                        </div>
                        <div class="c_cont">股票信息</div>
                    </a></li>
                    <li class="cont_4"><a href="instructions.aspx">
                        <div class="l pic">
                            <img src="/style/images/investors_icon4.png" width="100" height="100" />
                        </div>
                        <div class="c_cont">招股说明书</div>
                    </a></li>
                </ul>
            </div>
            <div class="invreport">
                <div class="main cl">
                    <ul>
                        <asp:Repeater ID="RepeaterListReport" runat="server">
                            <ItemTemplate>
                                <li>
                                    <a href="reportde.aspx?reportid=<%# Eval("REPORTID") %>">
                                        <div class="cont_1">
                                            <img src="<%# Eval("IMGURL") %>" width="420" height="500">
                                        </div>
                                        <div class="picmain">
                                            <h5><%# Eval("TITLE") %></h5>
                                        </div>
                                    </a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="bottom">
                    <div class="more"><a href="report.aspx">查看全部</a></div>
                </div>
            </div>
            <div class="invcompany">
                <div class="comtitle">
                    <img src="/style/images/invcompany.jpg" />
                </div>
                <div class="incomtop cl">
                    <asp:Repeater ID="RepeaterListNotice" runat="server">
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
                </div>
            </div>
            <div class="invvideo cl">
                <ul>
                    <asp:Repeater ID="RepeaterListLink" runat="server">
                        <ItemTemplate>
                            <li>
                                <a href="<%# Eval("LINKURL") %>">
                                    <div class="indexvideo">
                                        <img src="<%# Eval("IMGURL") %>" width="382" height="200" />
                                        <div class="indexvideoicon">
                                            <img src="/style/images/video_icon.png" width="44" height="44" />
                                        </div>
                                    </div>
                                </a>
                                <h5><%# Eval("TITLE") %></h5>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <div class="invinstructions">
                <a href="instructions.aspx">
                    <div class="logo">
                        <img src="/style/images/investors_stocklogo.jpg" />
                    </div>
                    <div class="main">
                        <h5>招股说明书</h5>
                        <p>
                            <%=instructions_note %>
                        </p>
                    </div>
                    <div class="invstockcon">
                        <img src="/style/images/investors_stock.jpg">
                    </div>
                </a>
            </div>
        </div>
    </div>


</asp:Content>

