<%@ Page Title="" Language="C#" MasterPageFile="~/em/MobileEnUI.master" AutoEventWireup="true" CodeFile="companyde.aspx.cs" Inherits="em_companyde" %>

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
                source: "<%=pageModel.PDFURL_EN==""?pageModel.PDFURL:pageModel.PDFURL_EN %>",
            });
        });
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="newsWap">

        <div class="title cl">
            <a href="company.aspx">
                <h3>Company announcement detail</h3>
            </a>
        </div>
        <div class="main">
          
            <div id="myPDF" style="height: 450px; width: 95%; margin: auto;"></div>
        </div>
    </div>
</asp:Content>

