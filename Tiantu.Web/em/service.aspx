<%@ Page Title="" Language="C#" MasterPageFile="~/em/MobileEnUI.master" AutoEventWireup="true" CodeFile="service.aspx.cs" Inherits="em_service" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="sreviceWap">   	
    	<div class="title cl">
        	<a href="service.aspx"><h3>Our Service</h3></a>
        </div>    
       	<div class="s_banner">
			<div id="large-header" class="slarge-header">
				<canvas id="demo-canvas"></canvas>
			</div>
			<div class="slineDiv"></div>
			<div class="simgDiv">
				<img class="ba_img1" src="/mobile/style/images/light.png" height="60"/>
				<img class="ba_img2" src="/mobile/style/images/light.png" height="60"/>
				<img class="ba_img3" src="/mobile/style/images/light.png" height="60"/>
				<img class="ba_img4" src="/mobile/style/images/light.png" height="60"/>
				<img class="ba_img5" src="/mobile/style/images/light.png" height="60"/>
				<img class="ba_img6" src="/mobile/style/images/light.png" height="60"/>
				<img class="ba_img7" src="/mobile/style/images/light.png" height="60"/>
				<img class="ba_img8" src="/mobile/style/images/light.png" height="60"/>
				<img class="ba_img9" src="/mobile/style/images/light.png" height="60"/>
				<img class="ba_img10" src="/mobile/style/images/light.png" height="60"/>
				<img class="ba_img11" src="/mobile/style/images/light.png" height="60"/>
				<img class="ba_img12" src="/mobile/style/images/light.png" height="60"/>
				<img class="ba_img13" src="/mobile/style/images/light.png" height="60"/>
				<img class="ba_img14" src="/mobile/style/images/light.png"  height="60"/>
			</div>
		</div>
        <div class="main">
        	<ul>
	    		<li>
	    			<a href="saas.aspx">
		        		<div class="photo pic1"><img src="/mobile/style/images/service_1.png"/></div>
		                <div class="cont"><h4>SaaS</h4><p>Introduction of Tiantu SaaS</p></div>
		            </a>
	    		</li>
	    		<li>
	    			<a href="logistics.aspx">
		        		<div class="photo pic2"><img src="/mobile/style/images/service_2.png"/></div>
		                <div class="cont"><h4>Logistics</h4><p>Warehouse, Transportation and distribution network</p></div>
		            </a>
	    		</li>
	    		<li>
	    			<a href="business.aspx">
		        		<div class="photo pic3"><img src="/mobile/style/images/service_3.png"/></div>
		                <div class="cont"><h4>Trade Flow </h4><p>Cross-Border Supply Chain,Agricultural Products,Appliances 3C</p></div>
		            </a>
	    		</li>
	    		<li>
	    			<a href="money.aspx">
		        		<div class="photo pic4"><img src="/mobile/style/images/service_4.png"/></div>
		                <div class="cont"><h4>Financial</h4><p>Focusing on business segment of E-commerce companies’ purchasing, sales, stocking, provide targeted financial support services.</p></div>
		            </a>
	    		</li>
	    		<li>
	    			<a href="IT.aspx">
		        		<div class="photo pic1"><img src="/mobile/style/images/service_5.png"/></div>
		                <div class="cont"><h4>Tiantu IT</h4><p>ERP,WMS,TMS,Settlement system</p></div>
		            </a>
	    		</li>
	    		<li>
	    			<a href="HR.aspx">
		        		<div class="photo pic2"><img src="/mobile/style/images/service_6.png"/></div>
		                <div class="cont"><h4>Human Resources</h4><p>Human Resources Exporting Solutions</p></div>
		            </a>
	    		</li>
	    	</ul>
        </div>
    </div>
    <script src="/mobile/sideshow/TweenLite.min.js"></script>
	<script src="/mobile/sideshow/EasePack.min.js"></script>
	<script src="/mobile/sideshow/rAF.js"></script>
	<script src="/mobile/sideshow/demo-1.js"></script>
    <style>
        body{background: #f2f2f2;}
    </style>
</asp:Content>

