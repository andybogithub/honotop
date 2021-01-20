<%@ Page Title="" Language="C#" MasterPageFile="~/mobile/MobileUI.master" AutoEventWireup="true" CodeFile="service.aspx.cs" Inherits="mobile_service" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="sreviceWap">   	
    	<div class="title cl">
        	<a href="service.aspx"><h3>天图服务</h3></a>
        </div>    
       	<div class="s_banner">
			<div id="large-header" class="slarge-header">
				<canvas id="demo-canvas"></canvas>
			</div>
			<div class="slineDiv"></div>
			<div class="simgDiv">
				<img class="ba_img1" src="style/images/light.png" height="60"/>
				<img class="ba_img2" src="style/images/light.png" height="60"/>
				<img class="ba_img3" src="style/images/light.png" height="60"/>
				<img class="ba_img4" src="style/images/light.png" height="60"/>
				<img class="ba_img5" src="style/images/light.png" height="60"/>
				<img class="ba_img6" src="style/images/light.png" height="60"/>
				<img class="ba_img7" src="style/images/light.png" height="60"/>
				<img class="ba_img8" src="style/images/light.png" height="60"/>
				<img class="ba_img9" src="style/images/light.png" height="60"/>
				<img class="ba_img10" src="style/images/light.png" height="60"/>
				<img class="ba_img11" src="style/images/light.png" height="60"/>
				<img class="ba_img12" src="style/images/light.png" height="60"/>
				<img class="ba_img13" src="style/images/light.png" height="60"/>
				<img class="ba_img14" src="style/images/light.png"  height="60"/>
			</div>
		</div>
        <div class="main">
        	<ul>
	    		<li>
	    			<a href="saas.aspx">
		        		<div class="photo pic1"><img src="style/images/service_1.png"/></div>
		                <div class="cont"><h4>天图SaaS介绍</h4><p>SaaS是一种自由、灵活、易扩展的架构。天图将物流服务、商流服务、供应链服务、IT和人力资源及管理这些服务项下的子服务模块化，构成的一个可以自由组合的服务集合，以实现最高效率的组合及调整。</p></div>
		            </a>
	    		</li>
	    		<li>
	    			<a href="logistics.aspx">
		        		<div class="photo pic2"><img src="style/images/service_2.png"/></div>
		                <div class="cont"><h4>天图物流模块</h4><p>仓储、运输、配送；</p></div>
		            </a>
	    		</li>
	    		<li>
	    			<a href="business.aspx">
		        		<div class="photo pic3"><img src="style/images/service_3.png"/></div>
		                <div class="cont"><h4>天图商流模块</h4><p>原产地/原厂资源、供应链服务、销售渠道</p></div>
		            </a>
	    		</li>
	    		<li>
	    			<a href="money.aspx">
		        		<div class="photo pic4"><img src="style/images/service_4.png"/></div>
		                <div class="cont"><h4>天图供应链模块</h4><p>基于客户的“进货”、“ 销售”以及“库存”三个环节提供金融支持；</p></div>
		            </a>
	    		</li>
	    		<li>
	    			<a href="IT.aspx">
		        		<div class="photo pic1"><img src="style/images/service_5.png"/></div>
		                <div class="cont"><h4>天图IT</h4><p>为客户提供ERP、WMS、TMS、结算系统</p></div>
		            </a>
	    		</li>
	    		<li>
	    			<a href="HR.aspx">
		        		<div class="photo pic2"><img src="style/images/service_6.png"/></div>
		                <div class="cont"><h4>天图人力资源及管理</h4><p>业务托管及人力资源输出</p></div>
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

