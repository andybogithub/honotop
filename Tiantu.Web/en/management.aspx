<%@ Page Title="" Language="C#" MasterPageFile="~/en/MainEnUI.master" AutoEventWireup="true" CodeFile="management.aspx.cs" Inherits="en_management" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script>
        $(function () {
            $(window).resize(function () {
                var vw = $(this).width();
                $('.managefirst .bg').width(vw);
            });
        });

        $(function () {
            $(".maclick ").on("click", function () {
                var index = $(this).index() + 1;
                var pinH = $("#main_" + index).offset().top;
                $("body,html").animate({ scrollTop: pinH }, 900);

                $('#main_' + index).find('.introduction').hide();
                $('#main_' + index).find('.character').show();
            });
            $('.manmore').on('click', function () {
                $(this).parents('.character').hide().next().show();
            });
            $('.return').on('click', function () {
                $(this).parents('.introduction').hide().prev().show();
            });
        })



    </script>
    <script>
        $(function () {
            $(".maclick dt").hover(function () {
                var thisdd = $(this).next("dd");
                if (thisdd.is(":hidden")) {
                    $(this).next().show();
                } else {
                    $(this).next().hide();
                }


            })
        })
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="tab">
        <div class="wp cl">
            <div class="curr">
                <span><a href="index.aspx">TIANTU LOGISTICS</a></span> > <span><a href="about.aspx">About Tiantu</a></span>
                > <span><a href="management.aspx">Management Team</a></span>
            </div>
        </div>
    </div>
    <!--/header-->


    <div class="management" id="management">
        <div class="managefirst cl">
            <div class="bg">
                <img src="/style/images/about/1.jpg" />
            </div>
            <div class="b">
                <div class="l aboutnav">
                    <ul>
                        <li><a href="about.aspx">Chairman’s Message</a></li>
                        <li><a href="develop.aspx">Enterprise Milestone</a></li>
                        <li class="on"><a href="management.aspx">Management Team</a></li>
                        <li><a href="culture.aspx">Entrepreneurship</a></li>
                        <li><a href="responsibility.aspx">Social Responsibility</a></li>
                        <li><a href="honor.aspx">Honor and Qualification</a></li>
                    </ul>
                </div>
                <div class="l managefirstpic">
                    <div class="first_1 cl maclick">
                        <dl>
                            <dt><a name="#main_1" href="#main_1">+</a></dt>
                            <dd>
                                <p><span>Angela Cao</span> Vice President</p>
                            </dd>
                        </dl>
                    </div>
                    <div class="first_2 cl maclick">
                        <dl>
                            <dt><a name="#main_2" href="#main_2">+</a></dt>
                            <dd>
                                <p><span>Bill Chan</span> Vice President</p>
                            </dd>
                        </dl>
                    </div>
                    <!--<div class="first_3 cl maclick">
                        <dl>
                            <dt><a name="#main_3" href="#main_3">+</a></dt>
                            <dd>
                                <p><span>Delia Zhai</span> Vice President</p>
                            </dd>
                        </dl>
                    </div>-->
                    <div class="first_4 cl maclick">
                        <dl>
                            <dt><a name="#main_3" href="#main_3">+</a></dt>
                            <dd>
                                <p><span>Fred Wu</span> Chairman</p>
                            </dd>
                        </dl>
                    </div>
                    <!--<div class="first_5 maclick">
                        <dl>
                            <dt><a name="#main_5" href="#main_5">+</a></dt>
                            <dd>
                                <p><span>Michael Gao</span>Vice President</p>
                            </dd>
                        </dl>
                    </div>-->
                    	
                    <!--时间：2017-05-25-->
                    <!--<div class="first_6 maclick">
                        <dl>
                            <dt><a name="#main_6" href="#main_6">+</a></dt>
                            <dd>
                                <p><span>Peggy Liu</span>Vice President</p>
                            </dd>
                        </dl>
                    </div>-->
                    <!--/时间：2017-05-25-->
                    <div class="first_7 cl maclick">
                        <dl>
                            <dt><a name="#main_4" href="#main_4">+</a></dt>
                            <dd>
                                <p><span>Vice President</span>Vice president</p>
                            </dd>
                        </dl>
                    </div>
                </div>
            </div>

        </div>
        <div class="manegesecond" id="main_3">
            <div class="mansecond character">
                <div class="wp">
                    <div class="main_1">
                        <h5>“We are embracing the future!”</h5>
                        <p>-  Fred Wu, Chairman</p>
                        <div class="manmore">View</div>
                    </div>
                </div>

            </div>
            <div class="mansecondde introduction" style="display: none;">
                <div class="wp">
                    <div class="mainde_1 mangede">
                        <h5>Fred Wu</h5>
                        <div class="return">Back</div>
                        <p>
                            Chairman
                        </p>
                    </div>
                    <div class="mainde_2">
                        <p>
                            With almost 20 years working experience in the logistics field, he set up Tiantu in 2010. 
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <div class="manegethird" id="main_1">
            <div class="manthird character">
                <div class="wp">
                    <div class="main_2">
                        <h5>“Be an interesting person and live a fascinating life.”</h5>
                        <p>-  Angela Cao, Vice President</p>
                        <div class="manmore">View</div>
                    </div>
                </div>

            </div>
            <div class="manthirdde introduction" style="display: none;">
                <div class="wp">
                    <div class="mainde_1 mangede">
                        <h5>Angela Cao</h5>
                        <div class="return">Back</div>
                        <p>
                            Vice President
                        </p>
                    </div>
                    <div class="mainde_2">
                        <p>
                            She has rich working experience in both E-commerce and logistics industries, and a unique sense for the market. 
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <div class="manegefourth" id="main_4">
            <div class="manfourth character">
                <div class="wp">
                    <div class="main_1">
                        <h5>“Be inclusive of everything, be grateful, be flexible as a sublime virtue.”</h5>
                        <p>-  JillCrocodile Wang, Vice president</p>
                        <div class="manmore">View</div>
                    </div>
                </div>

            </div>
            <div class="manfourthde introduction" style="display: none;">
                <div class="wp">
                    <div class="mainde_1 mangede">
                        <h5>JillCrocodile Wang</h5>
                        <div class="return">Back</div>
                        <p>
                            Vice president
                        </p>
                    </div>
                    <div class="mainde_2">
                        <p>
                            She has more than 20 years’ experience in logistics and is proficient in supply chain management. 
                           She also has rich knowledge about different industries, including retailing, manufacturing, food circulation and automobile parts.
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <div class="manegefifth" id="main_2">
            <div class="manfifth character">
                <div class="wp">
                    <div class="main_2">
                        <h5>“Before making life meaningful, make it interesting. Live in the moment.”</h5>
                        <p>-  Bill Chan, Vice President</p>
                        <div class="manmore">View</div>
                    </div>
                </div>

            </div>
            <div class="manfifthde introduction" style="display: none;">
                <div class="wp">
                    <div class="mainde_1 mangede">
                        <h5>Bill Chan</h5>
                        <div class="return">Back</div>
                        <p>
                            Vice President
                        </p>
                    </div>
                    <div class="mainde_2">
                        <p>
                            Before joining Tiantu, Bill had worked in an American listed logistics company for 16 years.
                            <br />
                            He started his career as Operations Assistant to Distribution Manager of Asia-Pacific Region for IT division.   
Tiantu is the second milestone of his career. As the development of diversified businesses, we can build an exclusive system by using our imagination. 
                        </p>
                    </div>
                </div>
            </div>
        </div>
        
        <!--<div class="manegesixth" id="main_3">
            <div class="mansixth character">
                <div class="wp">
                    <div class="main_1">
                        <h5>“Precise, practical, fair and equitable.”</h5>
                        <p>-  Delia Zhai, Vice President</p>
                        <div class="manmore">View</div>
                    </div>
                </div>

            </div>
            <div class="mansixthde introduction" style="display: none;">
                <div class="wp">
                    <div class="mainde_1 mangede">
                        <h5>Delia Zhai</h5>
                        <div class="return">Back</div>
                        <p>
                            Delia Zhai
                        </p>
                    </div>
                    <div class="mainde_2">
                        <p>
                            She has comprehensive management experience in many industries, such as manufacturing, IT and retailing, etc.

                        </p>
                    </div>
                </div>
            </div>
        </div>-->
        <!--<div class="manegeseventeen" id="main_5">
            <div class="manseventeen character">
                <div class="wp">
                    <div class="main_2">
                        <h5>“Dedicate to work, pursue success, and achieve self-worth”</h5>
                        <p>-  Michael Gao, Vice President</p>
                        <div class="manmore">View</div>
                    </div>
                </div>

            </div>
            <div class="manseventeende introduction" style="display: none;">
                <div class="wp">
                    <div class="mainde_1 mangede">
                        <h5>Michael Gao</h5>
                        <div class="return">Back</div>
                        <p>
                            Vice President
                        </p>
                    </div>
                    <div class="mainde_2">
                        <p>
                            He has almost 40 years’ experience, of which 25 years was in famous companies like Chevron, Texaco, Agip, Total, Sinar Mas and ECS, etc<br />
                            He joined Tiantu in May 2016. 
                        </p>
                    </div>
                </div>
            </div>
        </div>-->
        <!--时间：2017-05-25-->
        <!--<div class="manegeeighteen" id="main_6">
            <div class="maneighteen character">
                <div class="wp">
                    <div class="main_1">
                        <h5>“True love is worth  all the sweat and tears.”</h5>
                        <p>-  Peggy Liu, Vice President</p>
                        <div class="manmore">View</div>
                    </div>
                </div>

            </div>
            <div class="maneighteende introduction" style="display: none;">
                <div class="wp">
                    <div class="mainde_1 mangede">
                        <h5>Peggy Liu</h5>
                        <div class="return">Back</div>
                        <p>
                            Vice President
                        </p>
                    </div>
                    <div class="mainde_2">
                        <p>
                            Over 17 years’ experience in supply chain, especially Healthcare and FMCG.
                        </p>
                    </div>
                </div>
            </div>
        </div>-->
        <!--/时间：2017-05-25-->
    </div>


    <script type="text/javascript">

        navon(1);

        //$(function () {
        //    $(".maclick dt").hover(function () {
        //        var thisdd = $(this).next("dd");
        //        if (thisdd.is(":hidden")) {
        //            $(this).next().show();
        //        } else {
        //            $(this).next().hide();
        //        }


        //    })
        //})

        //window.onload = function () {
        //    var oDiv = document.getElementById("management");
        //    var aBtn = oDiv.getElementsByClassName("manmore");
        //    var aDiv = oDiv.getElementsByClassName("return");
        //    var aBlock = oDiv.getElementsByClassName("introduction");
        //    var character = oDiv.getElementsByClassName("character");

        //    for (var i = 0; i < aBtn.length; i++) {
        //        aBtn[i].index = i;
        //        aBtn[i].onclick = function () {
        //            for (var i = 0; i < aBtn.length; i++) {
        //                aBlock[i].style.display = 'none'
        //                character[i].style.display = 'block';
        //            }
        //            aBlock[this.index].style.display = 'block';
        //            character[this.index].style.display = 'none';
        //        }

        //        aDiv[i].index = i;
        //        aDiv[i].onclick = function () {
        //            for (var i = 0; i < aBtn.length; i++) {
        //                aBlock[i].style.display = 'blcok'
        //            }
        //            aBlock[this.index].style.display = 'none';
        //            character[this.index].style.display = 'block';

        //        }
        //    }
        //}
    </script>
</asp:Content>

