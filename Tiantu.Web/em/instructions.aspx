<%@ Page Title="" Language="C#" MasterPageFile="~/em/MobileEnUI.master" AutoEventWireup="true" CodeFile="instructions.aspx.cs" Inherits="em_instructions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link href="/mobile/style/css/jquery.touchPDF.css" rel="stylesheet" media="screen" />
    <script type="text/javascript" src="/mobile/js/pdf.compatibility.js"></script>
    <script type="text/javascript" src="/mobile/js/pdf.js"></script>
    <script type="text/javascript" src="/mobile/js/jquery.touchSwipe.js"></script>
    <script type="text/javascript" src="/mobile/js/jquery.touchPDF.js"></script>
    <script type="text/javascript" src="/mobile/js/jquery.panzoom.js"></script>
    <script type="text/javascript" src="/mobile/js/jquery.mousewheel.js"></script>
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
                <h3>Prospectus</h3>
            </a>
        </div>
        <div class="newstop cl">
            <ul>
                <li><a href="report.aspx">Periodical reports</a></li>
                <li><a href="company.aspx">Company announcement</a></li>
                <li><a href="stock.aspx">Stock information</a></li>
                <li class="on"><a href="instructions.aspx">Prospectus</a></li>
            </ul>
        </div>
        <div class="main">
            <div class="instruct">
                <h5>Prospectus</h5>
                <div id="myPDF" style="height: 450px; width: 95%; margin: auto;"></div>
                <div class="download">
                    <a href="<%= instructions_pdf %>" download>
                        <input type="button" value="Download"/></a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

