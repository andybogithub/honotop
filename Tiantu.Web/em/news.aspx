<%@ Page Title="" Language="C#" MasterPageFile="~/em/MobileEnUI.master" AutoEventWireup="true" CodeFile="news.aspx.cs" Inherits="em_news" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="newsWap">
        <div class="title cl">
            <a href="news.aspx">
                <h3>News Center</h3>
            </a>
        </div>
        <div class="newstop cl">
            <ul>
                <li <%=cateid==0?"class='on'":"" %>><a href="news.aspx">Latest news</a></li>
                <li <%=cateid==1?"class='on'":"" %>><a href="news.aspx?ca=1">Media center</a></li>
                <li <%=cateid==2?"class='on'":"" %>><a href="news.aspx?ca=2">News reports</a></li>
                <li <%=cateid==3?"class='on'":"" %>><a href="news.aspx?ca=3">Magazine</a></li>
            </ul>
        </div>
        <div class="main">
            <div class="news_list">
            </div>
            <div class="more" id="loadMore"><a href="#">More</a></div>
        </div>
    </div>


    <script>

        var loadMore = $("#loadMore");
        var appendList = $(".news_list");
        var cateid= '<%=cateid%>';
        var pageId = 1;  //开始2页
        function loading() {
            $.ajax({
                url: "news.aspx",
                data: {
                    'pageid': pageId,
                    'method': 'ajax',
                    'ca': cateid,
                    'r': Math.random()
                },
                beforeSend: function () {
                    loadMore.html("<a href='#'>Loding...</a>");
                },
                success: function (data) {
                    loadMore.html("<a href='#'>More</a>");
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

