<%@ Page Title="" Language="C#" MasterPageFile="~/mobile/MobileUI.master" AutoEventWireup="true" CodeFile="companyde.aspx.cs" Inherits="mobile_companyde" %>

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
                source: "<%=pageModel.PDFURL %>",
            });
        });
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="newsWap">

        <div class="title cl">
            <a href="company.aspx">
                <h3>公司公告详情</h3>
            </a>
        </div>
        <div class="main">
          
            <div id="myPDF" style="height: 450px; width: 95%; margin: auto;"></div>
        </div>
    </div>
</asp:Content>

