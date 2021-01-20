<%@ Page Title="" Language="C#" MasterPageFile="~/em/MobileEnUI.master" AutoEventWireup="true" CodeFile="reportde.aspx.cs" Inherits="em_reportde" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    	<link href="/mobile/style/css/jquery.touchPDF.css" rel="stylesheet" media="screen" />
<script type="text/javascript" src="/mobile/js/pdf.compatibility.js"></script>
	<script type="text/javascript" src="/mobile/js/pdf.js"></script>
	<script type="text/javascript" src="/mobile/js/jquery.touchSwipe.js"></script>
	<script type="text/javascript" src="/mobile/js/jquery.touchPDF.js"></script>
	<script type="text/javascript" src="/mobile/js/jquery.panzoom.js"></script>
	<script type="text/javascript" src="/mobile/js/jquery.mousewheel.js"></script>
	<script type="text/javascript">
	
		$(function() {
			$("#myPDF").pdf( {
				source: "<%=pageModel.PDFURL_EN==""?pageModel.PDFURL:pageModel.PDFURL_EN %>",
			} );
		});

	</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="investorsWap">   	
    	<div class="title cl">
        	<a href="report.aspx"><h3>Periodical reports detail</h3></a>
       </div>        
        <div class="main cl">
        	<div id="myPDF" style="height: 450px; width: 95%; margin: auto;"></div>
        </div>  
    </div>

</asp:Content>

