<%@ Page Title="" Language="C#" MasterPageFile="~/MainUI.master" AutoEventWireup="true" CodeFile="management.aspx.cs" Inherits="management" %>

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
                <span><a href="index.aspx">天图物流</a></span> > <span><a href="about.aspx">关于天图</a></span>
                > <span><a href="management.aspx">管理层</a></span>
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
                        <li><a href="about.aspx">董事长致辞</a></li>
                        <li><a href="develop.aspx">发展历程</a></li>
                        <li class="on"><a href="management.aspx">管理层</a></li>
                        <li><a href="culture.aspx">企业文化</a></li>
                        <li><a href="responsibility.aspx">社会责任</a></li>
                        <li><a href="honor.aspx">荣誉与资质</a></li>
                    </ul>
                </div>
                <div class="l managefirstpic">
                    <div class="first_1 cl maclick">
                        <dl>
                            <dt><a name="#main_1" href="#main_1">+</a></dt>
                            <dd>
                                <p><span>曹霞</span>，副总裁</p>
                            </dd>
                        </dl>
                    </div>
                    <div class="first_2 cl maclick">
                        <dl>
                            <dt><a name="#main_2" href="#main_2">+</a></dt>
                            <dd>
                                <p><span>陈永扬</span>，副总裁</p>
                            </dd>
                        </dl>
                    </div>
                    <!--时间：2017-06-26-->
                    <!--<div class="first_3 cl maclick">
                        <dl>
                            <dt><a name="#main_3" href="#main_3">+</a></dt>
                            <dd>
                                <p><span>翟丹春</span>，副总裁</p>
                            </dd>
                        </dl>
                    </div>-->
                    <div class="first_4 cl maclick">
                        <dl>
                            <dt><a name="#main_3" href="#main_3">+</a></dt>
                            <dd>
                                <p><span>吴泽友</span>，董事长</p>
                            </dd>
                        </dl>
                    </div>
                    <div class="first_7 cl maclick">
                        <dl>
                            <dt><a name="#main_4" href="#main_4">+</a></dt>
                            <dd>
                                <p><span>王京鄂</span>，副总裁</p>
                            </dd>
                        </dl>
                    </div>
                    <!--时间：2017-06-26-->
                    <!--<div class="first_5 maclick">
                        <dl>
                            <dt><a name="#main_5" href="#main_5">+</a></dt>
                            <dd>
                                <p><span>高平</span>，副总裁</p>
                            </dd>
                        </dl>
                    </div>-->
                    <!--时间：2017-05-25-->
                    <!--<div class="first_6 maclick">
                        <dl>
                            <dt><a name="#main_6" href="#main_6">+</a></dt>
                            <dd>
                                <p><span>刘宇</span>，副总裁</p>
                            </dd>
                        </dl>
                    </div>-->
                    <!--/时间：2017-05-25-->
                   
                </div>
            </div>

        </div>
        <div class="manegesecond" id="main_3">
            <div class="mansecond character">
                <div class="wp">
                    <div class="main_1">
                        <h5>“未来在微笑着迎接我们！”</h5>
                        <p>-  吴泽友，董事长</p>
                        <div class="manmore">查看简介</div>
                    </div>
                </div>

            </div>
            <div class="mansecondde introduction" style="display: none;">
                <div class="wp">
                    <div class="mainde_1 mangede">
                        <h5>吴泽友</h5>
                        <div class="return">返回</div>
                        <p>
                            <span>职位</span><br />
                            董事长
                        </p>
                    </div>
                    <div class="mainde_2">
                        <p>
                            作为中国早期物流从业人员，在物流行业从基层做起，积累了十余年深厚经验之后，于2010年创立了天图物流。
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <div class="manegethird" id="main_1">
            <div class="manthird character">
                <div class="wp">
                    <div class="main_2">
                        <h5>“做有趣的人，过有趣的生活”</h5>
                        <p>-  曹霞，副总裁</p>
                        <div class="manmore">查看简介</div>
                    </div>
                </div>

            </div>
            <div class="manthirdde introduction" style="display: none;">
                <div class="wp">
                    <div class="mainde_1 mangede">
                        <h5>曹霞</h5>
                        <div class="return">返回</div>
                        <p>
                            <span>职位</span><br />
                            副总裁
                        </p>
                    </div>
                    <div class="mainde_2">
                        <p>
                            在电商及物流行业有着多年从业经验，对中国市场有独特的理解力和准确的掌控力。
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <div class="manegefourth" id="main_4">
            <div class="manfourth character">
                <div class="wp">
                    <div class="main_1">
                        <h5>“含弘光大，敬畏感恩，上善若水”</h5>
                        <p>-  王京鄂，副总裁</p>
                        <div class="manmore">查看简介</div>
                    </div>
                </div>

            </div>
            <div class="manfourthde introduction" style="display: none;">
                <div class="wp">
                    <div class="mainde_1 mangede">
                        <h5>王京鄂</h5>
                        <div class="return">返回</div>
                        <p>
                            <span>职位</span><br />
                            副总裁
                        </p>
                    </div>
                    <div class="mainde_2">
                        <p>
                            拥有20多年物流行业管理经验，精通国内、国际物流及供应链管理，对传统物流及电商物流均有
							深入的实践经验及战略研究，涉足领域遍及零售、生产制造、食品流通、汽车零配件。

                        </p>
                    </div>
                </div>
            </div>
        </div>
        <div class="manegefifth" id="main_2">
            <div class="manfifth character">
                <div class="wp">
                    <div class="main_2">
                        <h5>“人生若要有意义，生活先要有意思, 活在当下”</h5>
                        <p>-  陈永扬，副总裁</p>
                        <div class="manmore">查看简介</div>
                    </div>
                </div>

            </div>
            <div class="manfifthde introduction" style="display: none;">
                <div class="wp">
                    <div class="mainde_1 mangede">
                        <h5>陈永扬</h5>
                        <div class="return">返回</div>
                        <p>
                            <span>职位</span><br />
                            副总裁
                        </p>
                    </div>
                    <div class="mainde_2">
                        <p>
                            前16年任职于美国上市物流公司,从运营作助理到亚太区配送经理-信息技术,从运输专业到仓配专业再到IT专业.<br />
                            天图是我服务生涯内的第二个家,在多元化业务发展下,可以发挥无限的想象力打造独家的业务系统。

                        </p>
                    </div>
                </div>
            </div>
        </div>
        <!--时间：2017-06-26-->
        <!--<div class="manegesixth" id="main_3">
            <div class="mansixth character">
                <div class="wp">
                    <div class="main_1">
                        <h5>“严谨务实、追求公正”</h5>
                        <p>-  翟丹春，副总裁</p>
                        <div class="manmore">查看简介</div>
                    </div>
                </div>

            </div>
            <div class="mansixthde introduction" style="display: none;">
                <div class="wp">
                    <div class="mainde_1 mangede">
                        <h5>翟丹春</h5>
                        <div class="return">返回</div>
                        <p>
                            <span>职位</span><br />
                            翟丹春
                        </p>
                    </div>
                    <div class="mainde_2">
                        <p>
                            拥有制造、IT、品牌零售连锁等多个行业的综合管理经验。

                        </p>
                    </div>
                </div>
            </div>
        </div>
        <div class="manegeseventeen" id="main_5">
            <div class="manseventeen character">
                <div class="wp">
                    <div class="main_2">
                        <h5>“敬业、成就、自我”</h5>
                        <p>-  高平，副总裁</p>
                        <div class="manmore">查看简介</div>
                    </div>
                </div>

            </div>
            <div class="manseventeende introduction" style="display: none;">
                <div class="wp">
                    <div class="mainde_1 mangede">
                        <h5>高平</h5>
                        <div class="return">返回</div>
                        <p>
                            <span>职位</span><br />
                            副总裁
                        </p>
                    </div>
                    <div class="mainde_2">
                        <p>
                            从事石油行业、IT行业、汽修行业、物流行业近40年，在美资企业Chevron（雪佛兰）、Texaco（德士古）、意资企业Agip（阿吉普）、法资企业Totol（道达尔）、东南亚企业Sinar Mas（金光集团）、ECS（佳杰科技）等知名企业拥有25年工作经验。
                                2016年5月加入天图物流。
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
                        <h5>“真正的喜欢抵得上所有”</h5>
                        <p>-  刘宇，副总裁</p>
                        <div class="manmore">查看简介</div>
                    </div>
                </div>

            </div>
            <div class="maneighteende introduction" style="display: none;">
                <div class="wp">
                    <div class="mainde_1 mangede">
                        <h5>刘宇</h5>
                        <div class="return">返回</div>
                        <p>
                            <span>职位</span><br />
                            副总裁
                        </p>
                    </div>
                    <div class="mainde_2">
                        <p>
                            在直销、快速消费品行业的供应链领域里拥有17年经验。
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

