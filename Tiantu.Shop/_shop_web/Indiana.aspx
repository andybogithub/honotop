<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_web/Share.master" AutoEventWireup="true" CodeFile="Indiana.aspx.cs" Inherits="_shop_web_Indiana" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="container wp">
        <div class="indianaStep">
            <img src="/style/images/step_dubao.png" /></div>
        <div class="indianaWrap cl">

            <div class="indianaList">
                <ul>

                    <asp:Repeater runat="server" ID="RepeaterProductList">
                        <ItemTemplate>
                            <li class="<%# GetDubaoLiCss(Convert.ToInt32(Eval("DubaoStatus"))) %>">
                                <%# GetDubaoStatus(Convert.ToInt32(Eval("DubaoStatus"))) %>
                                <div class="pic"><a href="/idaDe/<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("productid").ToString()).ToLower() %>.html">
                                    <img src="<%# Tiantu.DB.Common.SL.GetHttpImageURL(Eval("ImageIcon"))  %>" width="270" height="270" /></a></div>
                                <div class="con">
                                    <h4><%# Eval("ProductName") %></h4>
                                    <p class="allNum">总需：<b><%# Eval("DBNeedTotal") %>人次</b></p>
                                    <p class="progress">
                                        <span style='width: <%# GetPercent(Convert.ToInt32(Eval("DBNeedTotal")),Convert.ToInt32(Eval("joinedTotal"))) %>%' class="progressLine"></span>
                                    </p>
                                    <p class="detailsNum cl">
                                        <span class="l"><i><%# Eval("joinedTotal") %></i><em>已参加人次</em></span>
                                        <span class="r"><i><%# Convert.ToInt32(Eval("DBNeedTotal")) - Convert.ToInt32(Eval("joinedTotal")) %></i><em>剩余人次</em></span>
                                    </p>
                                </div>
                                <div class="status">
                                    <%# GetStatus(Convert.ToInt32(Eval("productId")), Convert.ToInt32(Eval("DubaoStatus")),Eval("SeckillEndTime") ) %>
                                </div>

                            </li>
                        </ItemTemplate>
                    </asp:Repeater>



                </ul>
            </div>

            <!--翻页-->
            <%if (totalRecords > 0)
                { %>
            <div class="pageTurning cl">
                <div class="r">
                    <span class="allNum"><%=pageId %> / <%=pageCount %>页 |  共 <b><%=totalRecords %></b> 条</span>
                    <ul id="light-pagination" class="pagination"></ul>
                </div>
            </div>
            <%} %>
            <asp:Literal ID="lblPager" runat="server" />

        </div>
    </div>

    <script type="text/javascript">
        $(function () {
            $('.conttimeFun').each(function () {
                var time = $(this).attr('endTime');
                countDown(this, time);
            });
        });
    </script>

    <script>
        $('.nav li').eq(2).addClass('on').siblings().removeClass('on');
    </script>

</asp:Content>

