<%@ Page Title="" Language="C#" MasterPageFile="~/mobile/MobileUI.master" AutoEventWireup="true" CodeFile="report.aspx.cs" Inherits="mobile_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="investorsWap">
        <div class="title cl">
            <a href="report.aspx">
                <h3>定期报告</h3>
            </a>
        </div>
        <div class="newstop cl">
            <ul>
                <li class="on"><a href="report.aspx">定期报告</a></li>
                <li><a href="company.aspx">公司公告</a></li>
                <li><a href="stock.aspx">股票信息</a></li>
                <li><a href="instructions.aspx">招股说明书</a></li>
            </ul>
        </div>
        <div class="main cl report_list">
            <ul>
                <asp:Repeater ID="RepeaterList" runat="server">
                    <ItemTemplate>                     
                        <li>
                            <img src="<%# Eval("IMGURL") %>"/>
                            <div  class="download">
                                <a href="<%# Eval("PDFURL") %>" download>下载</a>
                            </div>
                            <p><%# Eval("TITLE") %></p>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>

        


        </div>
            <div class="more" id="loadMore"><a href="#">加载更多</a></div>
    </div>

     <script>

        var loadMore = $("#loadMore");
        var appendList = $(".report_list ul");
        var pageId = 1;  //开始2页
        function loading() {
            $.ajax({
                url: "report.aspx",
                data: {
                    'pageid': pageId,
                    'method': 'ajax',
                    'r': Math.random()
                },
                beforeSend: function () {
                    loadMore.html("<a href='#'>数据加载中...</a>");
                },
                success: function (data) {
                    loadMore.html("<a href='#'>加载更多</a>");
                    if (data != null && data.length > 0) {
                        insertData(data);
                        pageId += 1;
                    } else {
                        loadMore.hide();
                    }
                }
            });
        }


        function insertData(dataString) {
            appendList.append(dataString).trigger('create');
        }

        loadMore.click(function () {
            loading();
        });

        $(document).ready(function () {
            loading();

        })

        //滚动条事件       
        $(window).scroll(function () {
            if ($(window).scrollTop() == $(document).height() - $(window).height()) {
                loading();
            }
        });
    </script>

</asp:Content>

