<%@ Page Title="" Language="C#" MasterPageFile="~/mobile/MobileUI.master" AutoEventWireup="true" CodeFile="managementde.aspx.cs" Inherits="mobile_managementde" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="manageWap">
        <div class="title cl">
            <a href="managementde.aspx">
                <h3>管理层详情</h3>
            </a>
        </div>
        <div class="abouttop cl">
            <ul>
                <li><a href="about.aspx">董事长致辞</a></li>
                <li><a href="develop.aspx">发展历程</a></li>
                <li class="on"><a href="management.aspx">管理层</a></li>
                <li><a href="culture.aspx">企业文化</a></li>
                <li><a href="responsibility.aspx">社会责任</a></li>
                <li><a href="honor.aspx">荣誉与资质</a></li>
            </ul>
        </div>
        <div class="main">
            <div class="content">
                <div class="pic">
                    <img src="style/images/managede_6.jpg" />
                </div>
                <div class="atitle">未来在微笑着迎接我们！</div>
                <p>
                    作为中国早期物流从业人员，在物流行业从基层做起，积累了十余年深厚经验之后，于2010年创立了天图物流。
                </p>
            </div>

            <div class="content">
                <div class="pic">
                    <img src="style/images/managede_1.jpg" />
                </div>
                <div class="atitle">做有趣的人，过有趣的生活</div>
                <p>
                    在电商及物流行业有着多年从业经验，对中国市场有独特的理解力和准确的掌控力。
                </p>
            </div>

            <div class="content">
                <div class="pic">
                    <img src="style/images/managede_5.jpg" />
                </div>
                <div class="atitle">含弘光大，敬畏感恩，上善若水</div>
                <p>
                    拥有20多年物流行业管理经验，精通国内、国际物流及供应链管理，对传统物流及电商物流均有深入的实践经验及战略研究，涉足领域遍及零售、生产制造、食品流通、汽车零配件。                  
                </p>
            </div>

            <div class="content">
                <div class="pic">
                    <img src="style/images/managede_8.jpg" />
                </div>
                <div class="atitle">人生若要有意义，生活先要有意思, 活在当下</div>
                <p>
                    前16年任职于美国上市物流公司,从运营作助理到亚太区配送经理-信息技术,从运输专业到仓配专业再到IT专业。
                    天图是我服务生涯内的第二个家,在多元化业务发展下,可以发挥无限的想象力打造独家的业务系统。
                  
                </p>
            </div>

            <div class="content">
                <div class="pic">
                    <img src="style/images/managede_7.jpg" />
                </div>
                <div class="atitle">严谨务实、追求公正</div>
                <p>
                    拥有制造、IT、品牌零售连锁等多个行业的综合管理经验。                
                </p>
            </div>

            <div class="content">
                <div class="pic">
                    <img src="style/images/managede_3.jpg" />
                </div>
                <div class="atitle">敬业、成就、自我</div>
                <p>
                    从事石油行业、IT行业、汽修行业、物流行业近40年，在美资企业Chevron（雪佛兰）、Texaco（德士古）、
                    意资企业Agip（阿吉普）、法资企业Totol（道达尔）、东南亚企业Sinar Mas（金光集团）、ECS（佳杰科技）等知名企业拥有25年工作经验。
                                2016年5月加入天图物流。
                </p>
            </div>

            <div class="content" style="display: none;">
                <div class="pic">
                    <img src="style/images/managede_4.jpg" />
                </div>
                <div class="atitle">真正的喜欢抵得上所有</div>
                <p>
                    在直销、快速消费品行业的供应链领域里拥有17年经验。
                </p>
            </div>


        </div>




        <script type="text/javascript">
            var contentid = '<%=i%>'
            $('.manageWap .main .content').eq(contentid).show().siblings().hide();


        </script>
    </div>
</asp:Content>

