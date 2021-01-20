<%@ Page Title="" Language="C#" MasterPageFile="~/en/MainEnUI.master" AutoEventWireup="true" CodeFile="about.aspx.cs" Inherits="en_about" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        navon(1);
    </script>


    <div class="tab">
        <div class="wp cl">
            <div class="curr">
                <span><a href="index.aspx">TIANTU LOGISTICS</a></span> > <span><a href="about.aspx">About Tiantu</a></span>
                > <span><a href="about.aspx">Chairman’s Message</a></span>
            </div>
        </div>
    </div>
    <!--/header-->


    <div class="about">
        <div class="wp">
            <div class="aboutmain cl">
                <div class="l aboutnav">
                    <ul>
                        <li class="on"><a href="about.aspx">Chairman’s Message</a></li>
                        <li><a href="develop.aspx">Enterprise Milestone</a></li>
                        <li><a href="management.aspx">Management Team</a></li>
                        <li><a href="culture.aspx">Entrepreneurship</a></li>
                        <li><a href="responsibility.aspx">Social Responsibility</a></li>
                        <li><a href="honor.aspx">Honor and Qualification</a></li>
                    </ul>
                </div>
                <div class="l aboutpic">
                    <img src="/style/images/en/about_2.png" />
                    <p>With Passion and a Dream, a group of logistics experts founded Tiantu Logistics in 2010 and began the journey to our future.</p>
                    <p>
                        According to the Book of Changes , “changing” and “unchanging” are the two sides of the coin. 
                         The Chinese logistics industry is going through a period of “change”. With the integration of the internet, that change is becoming "revolutionary".
                         Hence, we improved our business model: shifting from basic warehousing service to focus on holistic supply chain solutions. As a result of the innovation,
                         we now stand at the forefront of the industry.
                    </p>
                    <p>
                        Meanwhile, persist in “unchanging” makes our team stable and strong. We announcing “to respect, to cherish, to self-improve, to innovate” as Company Culture 
         in the early stage. This quotation has always been our guideline and agglomerate us together.
                    </p>
                    <p>
                        Keeping the passion during such a long journey, Holding hands together, Keeping strong and united with courage and determination when facing obstacles，
Along with steadfastness, we firmly believe we are embracing the future!                
                    </p>
                    <div class="qmdsz">
                        <img src="/style/images/en/about_3.png" /></div>
                    <%--<div class="qmdsz"><img src="/style/images/about/about_3.png" /></div>--%>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

