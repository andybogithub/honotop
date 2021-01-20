<%@ Page Title="" Language="C#" MasterPageFile="~/em/MobileEnUI.master" AutoEventWireup="true" CodeFile="company.aspx.cs" Inherits="em_company" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="newsWap">
        <div class="title cl">
            <a href="company.aspx">
                <h3>Company announcement</h3>
            </a>
        </div>
        <div class="newstop cl">
            <ul>
                <li><a href="report.aspx">Periodical reports</a></li>
                <li class="on"><a href="company.aspx">Company announcement</a></li>
                <li><a href="stock.aspx">Stock information</a></li>
                <li><a href="instructions.aspx">Prospectus</a></li>
            </ul>
        </div>
        <div class="main">
            <div class="notices_list">            
            </div>
            <div class="more" id="loadMore"><a href="#">More</a></div>
        </div>
    </div>


    <script>         

        var loadMore = $("#loadMore");
        var appendList = $(".notices_list");

        var pageId =1;  //开始2页
        function loading() {     
            $.ajax({
                url: "company.aspx",
                data: {
                    'pageid': pageId,                
                    'method': 'ajax',
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

