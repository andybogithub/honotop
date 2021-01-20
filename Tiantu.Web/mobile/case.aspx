<%@ Page Title="" Language="C#" MasterPageFile="~/mobile/MobileUI.master" AutoEventWireup="true" CodeFile="case.aspx.cs" Inherits="mobile_case" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="caseWap">
        <div class="title cl">
            <a href="case.html">
                <h3>我们的客户</h3>
            </a>
        </div>
        <div class="main cl">
            <div class="cases_list">
                <ul>
                </ul>
            </div>
        </div>

        <div class="more" id="loadMore"><a href="#">加载更多</a></div>
    </div>



    <script>

        var loadMore = $("#loadMore");
        var appendList = $(".cases_list ul");
        var pageId = 1;  //开始2页
        function loading() {
            $.ajax({
                url: "case.aspx",
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

