<%@ Page Title="" Language="C#" MasterPageFile="~/em/MobileEnUI.master" AutoEventWireup="true" CodeFile="managementde.aspx.cs" Inherits="em_managementde" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="manageWap">
        <div class="title cl">
            <a href="managementde.aspx">
                <h3>Management Team</h3>
            </a>
        </div>
        <div class="abouttop cl">
            <ul>
                <li><a href="about.aspx">Chairman’s Message</a></li>
                <li><a href="develop.aspx">Enterprise Milestone</a></li>
                <li class="on"><a href="management.aspx">Management Team</a></li>
                <li><a href="culture.aspx">Entrepreneurship</a></li>
                <li><a href="responsibility.aspx">Social Responsibility</a></li>
                <li><a href="honor.aspx">Honor and Qualification</a></li>
            </ul>
        </div>
        <div class="main">
            <div class="content">
                <div class="pic">
                    <img src="/mobile/style/images/managede_6.jpg" />
                </div>
                <div class="atitle">We are embracing the future!</div>
                <p>
                    With almost 20 years working experience in the logistics field, he set up Tiantu in 2010. 
                </p>
            </div>

            <div class="content">
                <div class="pic">
                    <img src="/mobile/style/images/managede_1.jpg" />
                </div>
                <div class="atitle">Be an interesting person and live a fascinating life.</div>
                <p>
                      She has rich working experience in both E-commerce and logistics industries, and a unique sense for the market. 
                </p>
            </div>

            <div class="content">
                <div class="pic">
                    <img src="/mobile/style/images/managede_5.jpg" />
                </div>
                <div class="atitle">Be inclusive of everything, be grateful, be flexible as a sublime virtue.</div>
                <p>
                    She has more than 20 years’ experience in logistics and is proficient in supply chain management. 
                           She also has rich knowledge about different industries, including retailing, manufacturing, food circulation and automobile parts.      
                </p>
            </div>

            <div class="content">
                <div class="pic">
                    <img src="/mobile/style/images/managede_8.jpg" />
                </div>
                <div class="atitle">Before making life meaningful, make it interesting. Live in the moment.</div>
                <p>
                   Before joining Tiantu, Bill had worked in an American listed logistics company for 16 years. <br/>
                            He started his career as Operations Assistant to Distribution Manager of Asia-Pacific Region for IT division.   
Tiantu is the second milestone of his career. As the development of diversified businesses, we can build an exclusive system by using our imagination. 
                </p>
            </div>

            <div class="content">
                <div class="pic">
                    <img src="/mobile/style/images/managede_7.jpg" />
                </div>
                <div class="atitle">Precise, practical, fair and equitable.</div>
                <p>
                    She has comprehensive management experience in many industries, such as manufacturing, IT and retailing, etc.
          
                </p>
            </div>

            <div class="content">
                <div class="pic">
                    <img src="/mobile/style/images/managede_3.jpg" />
                </div>
                <div class="atitle">Dedicate to work, pursue success, and achieve self-worth</div>
                <p>
                      He has almost 40 years’ experience, of which 25 years was in famous companies like Chevron, Texaco, Agip, Total, Sinar Mas and ECS, etc. 
                            He joined Tiantu in May 2016. 
                </p>
            </div>

            <div class="content" style="display: none;">
                <div class="pic">
                    <img src="/mobile/style/images/managede_4.jpg" />
                </div>
                <div class="atitle">True love is worth  all the sweat and tears.</div>
                <p>
                    Over 17 years’ experience in supply chain, especially Healthcare and FMCG.
                </p>
            </div>


        </div>




        <script type="text/javascript">
            var contentid = '<%=i%>'
            $('.manageWap .main .content').eq(contentid).show().siblings().hide();
        </script>



    </div>
</asp:Content>

