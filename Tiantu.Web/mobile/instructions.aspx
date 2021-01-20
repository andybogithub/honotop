<%@ Page Title="" Language="C#" MasterPageFile="~/mobile/MobileUI.master" AutoEventWireup="true" CodeFile="instructions.aspx.cs" Inherits="mobile_instructions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link href="style/css/jquery.touchPDF.css" rel="stylesheet" media="screen" />
    <script type="text/javascript" src="js/pdf.compatibility.js"></script>
    <script type="text/javascript" src="js/pdf.js"></script>
    <script type="text/javascript" src="js/jquery.touchSwipe.js"></script>
    <script type="text/javascript" src="js/jquery.touchPDF.js"></script>
    <script type="text/javascript" src="js/jquery.panzoom.js"></script>
    <script type="text/javascript" src="js/jquery.mousewheel.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#myPDF").pdf({
                source: "<%= instructions_pdf %>",
            });
        });
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="instructWap">

        <div class="title cl">
            <a href="instructions.aspx">
                <h3>招股说明书</h3>
            </a>
        </div>
        <div class="newstop cl">
            <ul>
                <li><a href="report.aspx">定期报告</a></li>
                <li><a href="company.aspx">公司公告</a></li>
                <li><a href="stock.aspx">股票信息</a></li>
                <li class="on"><a href="instructions.aspx">招股说明书</a></li>
            </ul>
        </div>
        <div class="main">
            <div class="instruct">
                <h5>招股说明书</h5>
                <div id="myPDF" style="height: 450px; width: 95%; margin: auto;"></div>
                <div class="download">
                    <a href="<%= instructions_pdf %>" download>
                        <input type="button" value="下载"/></a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

