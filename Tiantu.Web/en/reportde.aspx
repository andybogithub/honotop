<%@ Page Title="" Language="C#" MasterPageFile="~/en/MainEnUI.master" AutoEventWireup="true" CodeFile="reportde.aspx.cs" Inherits="en_reportde" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript" src="/js/jquery.media.js"></script>

    <script type="text/javascript">
        $(function () {
            $('a.media').media({ width: 800, height: 800 });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        navon(4);
    </script>


    <div class="tab">
        <div class="wp cl">
            <div class="curr">
                <span><a href="index.aspx">TIANTU LOGISTICS</a></span> > <span><a href="investors.aspx">Investor Relations</a></span>
                > <span><a href="report.aspx">Periodical reports</a></span> > <span><a href="reportde.aspx">Reports detail</a></span>
            </div>
        </div>
    </div>
    <!--/header-->


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
                    <div class="typepdf">
                        <a class="media" href="<%=pageModel.PDFURL_EN==""?pageModel.PDFURL:pageModel.PDFURL_EN %>"></a>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

