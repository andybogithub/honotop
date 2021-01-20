<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_web/Share.master" AutoEventWireup="true" CodeFile="IndianaDetail.aspx.cs" Inherits="_shop_web_IndianaDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style>
        .indianader .indianaright .mynumbers { width: 250px; background: #f0f0f0; padding: 10px 0; text-align: center; margin-top: 15px; }
    </style>


    <div class="container wp">
        <div class="proDeTop">
            <div class="current"><a href="/indianas.html">限时秒杀</a> > <%=productmodel.ProductName %></div>
            <div class="proDeInfo">
                <div class="dePic">
                    <img src="<%=productmodel.ImageIcon %>" width="350" height="350" />
                </div>
                <div class="deInfoCon">
                    <h3><%=productmodel.ProductName %></h3>


                    <div class="infoUl indianader" style="display: block;">
                        <div class="l indianaleft">
                            <div class="indjoin">
                                <%
                                    if (ProgressId == 1 || ProgressId == 2)
                                    { %>
                                <div class="title">
                                    <p>总需：<%=productmodel.DBNeedTotal %>人次<span>每满总需人次，即抽取1人获得该商品</span></p>
                                </div>
                                <div class="progressBar"><span class="joinprogress" style='width: <%=JoinedPrecent%>%'></span></div>
                                <div class="progresstxt">
                                    <div class="l part">
                                        <p>已参加人次<b><%=JoinedTotal %></b></p>
                                    </div>
                                    <div class="r surplus">
                                        <p>剩余人次<b><%=LeftJoinedTotal %></b></p>
                                    </div>
                                </div>
                                <div class="item changePrice">
                                    <strong>夺宝价格：</strong>
                                    <div class="itemRight"><span>¥ <%=productmodel.SeckillPoint %></span><%--<a href="/earn.html"><b>赚取金币</b></a>--%></div>
                                </div>
                                <%} %>

                                <!--  参与人次 -->
                                <%
                                    if (ProgressId == 1)
                                    { %>
                                <div class="item exchange">
                                    <strong>参与人次：</strong>
                                    <div class="itemRight">
                                        <div class="exchangeNum partin">
                                            <i class="minus disabled">-</i>
                                            <input type="text" name="joinnumber" id="joinnumber" value="1" class="count"
                                                maxnum="<%=productmodel.DBAllowJoin %>"
                                                leftnum="<%=LeftJoinedTotal %>"
                                                onkeypress="if((event.keyCode<48 || event.keyCode>57) && event.keyCode!=46 || /\.\d\d$/.test(value))event.returnValue=false"
                                                onkeyup="if(this.value.length==1){this.value=this.value.replace(/[^1-9]/g,'')}else{this.value=this.value.replace(/\D/g,'')}"
                                                onafterpaste="if(this.value.length==1){this.value=this.value.replace(/[^1-9]/g,'')}else{this.value=this.value.replace(/\D/g,'')}" />
                                            <i class="plus">+</i>
                                        </div>

                                    </div>
                                </div>
                                <%} %>

                                <!--  参与按钮 -->
                                <%
                                    if (ProgressId == 1)    //报名中
                                    {
                                        if (bLogin)
                                        {
                                            //已登录，报名中
                                            Response.Write("<div class='nochangeBtn' style='display:none;' id='joinprogress'>报名中...</div>");
                                            Response.Write(string.Format("<div class='changeBtn' id='joinnow'><a class='joinnow btnjoinnow' relid='{0}'>立即参与</a></div>", Tiantu.DB.Common.SL.DESEncrypt(productmodel.ProductId.ToString())));
                                        }
                                        else
                                        {
                                            //未登录
                                            Response.Write("<div class='changeBtn'><a class='joinnow' onclick='javascript:login();'>立即参与</a></div>");
                                        }
                                    }
                                    else if (ProgressId == 2) //已达到上限，准备开奖中
                                    {
                                        string overtimeHtml = string.Format(@"<div class='item dhprice'>
                                            <strong>截止时间：</strong>
                                            <div class='itemRight'><span>{0}</span></div>
                                        </div>", productmodel.SeckillEndTime.AddMinutes(-2).ToString("yyyy-MM-dd HH:mm:ss"));
                                        Response.Write(overtimeHtml);
                                    }
                                %>
                            </div>

                            <!--已开奖-->
                            <%if (ProgressId == 3)
                                { %>
                            <div class="lottery">
                                <div class="luckynumber">
                                    <p>— 开奖号码 —</p>
                                    <p class="luckno"><%=LuckNo %></p>
                                </div>
                                <div class="luckmain">
                                    <asp:Literal ID="lblLuckInfo" runat="server" />
                                </div>

                            </div>
                            <%} %>
                        </div>
                        <div class="r indianaright">
                            <!--开奖倒计时-->
                            <%
                                if (ProgressId == 2)
                                {
                                    string countdownHtml = string.Format(@"
                                                        <div class='countdown' style='display: block;'>
                                                            <div class='countDownDiv'>
                                                                <strong>开奖倒计时：</strong>
                                                                <div class='lastTime conttimeFun' endtime='{0}'>
                                                                </div>
                                                            </div>
                                                        </div>", productmodel.SeckillEndTime.ToString("MM/dd/yyyy HH:mm:ss"));
                                    Response.Write(countdownHtml);
                                }
                            %>

                            <asp:Literal ID="lblJoinStatus" runat="server" />
                        </div>
                        <div class="cl"></div>

                        <%if (ProgressId == 3)
                            { %>
                        <div class="howtoget">
                            <table>
                                <thead>
                                    <tr>
                                        <td colspan="5"><strong>如何计算？</strong></td>
                                        <td></td>
                                        <td style="padding-left: 20px;">
                                            <b>变化数值</b>是取下面公式的余数
                                        </td>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td align="center"><b><%=LuckNo %></b><br />
                                            本期幸运号码</td>
                                        <td align="center">= </td>
                                        <td align="center"><b>10000001</b><br />
                                            固定数值</td>
                                        <td align="center">+ </td>
                                        <td align="center"><b><%=TimeSum%productmodel.DBNeedTotal %></b><br />
                                            变化数值</td>
                                        <td style="border-right: 1px dashed #dcdcdc;">&nbsp;
                                        </td>
                                        <td style="padding-left: 20px;">
                                            <p><%=TimeSum %> ÷ <%=productmodel.DBNeedTotal %> = <%=TimeSum/productmodel.DBNeedTotal %> 余 <%=TimeSum%productmodel.DBNeedTotal %></p>
                                            <p>所有参与报名时间求和 ÷ 总需人次 = (值) 和 (余) </p>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <%} %>
                    </div>





                </div>
            </div>
        </div>
        <div class="indianaDeMain">
            <div class="navdiv cl">
                <ul>
                    <li class="on nali_1"><a>商品详情</a></li>
                    <li class="nali_2"><a>规则介绍</a></li>
                    <li class="nali_3"><a>参与记录</a></li>
                    <asp:Literal ID="lblWinTakeStepTitle" runat="server" />
                </ul>
            </div>
            <!--商品详情 -->
            <div class="tabMain deMainCon" style="display: block">
                <div class="deIntroduce">
                    <%=productmodel.ProductDetails %>
                </div>
            </div>

            <!--规则介绍-->
            <div class="tabMain ruleCon" style="display: none">
                <div class="rulemain">
                    <div class="bottom">
                        <h5>限时秒杀计算规则：</h5>
                        <p>
                            1、取该商品最后购买时间前网站所有商品的购买时间记录。<br />
                            2、按时、分、秒、毫秒排列取值之和（得出数值A）除以该商品总参与人次后取余数。<br />
                            3、（数值A+数值B）除以该商品总需人次得到的余数 + 原始数10000001，即为幸运号码。<br />
                            4、余数是指整数除法中被除数未被除尽部分， 如7÷3 = 2 ......1，1就是余数 。<br />
                        </p>
                    </div>
                </div>
            </div>


            <!--参与记录-->
            <div class="tabMain reconrdCon" style="display: none">
                <div class="reconrdright"></div>
                <div class="recondtime">
                    <ul id="dataList">
                    </ul>
                </div>
            </div>

            <!-- 奖品领取步骤-->
            <div class="tabMain ruleCon" style="display: none">
                <div style="margin: 10px">
                    <asp:Literal ID="lblWinTakeStepBody" runat="server" />
                </div>
            </div>
        </div>

    </div>




    <script type="text/javascript">
        var _tb_productno = '<%=Tiantu.DB.Common.SL.DESEncrypt(productmodel.ProductId.ToString())%>';

        $(document).ready(function () {


            //倒数计时
            $('.conttimeFun').each(function () {
                var time = $(this).attr('endTime');
                openWinCountDownTime(this, time);
            });


            // 参与人次：加
            $('.exchangeNum .plus').on('click', function () {
                var num = $('.count').val();
                var maxnum = parseInt($('#joinnumber').attr("maxnum"));
                var leftnum = parseInt($('#joinnumber').attr("leftnum"));
                if (num < maxnum && num < leftnum) {
                    $('.exchangeNum .minus').removeClass('disabled');
                    $('.count').val(parseInt(num) + 1);
                }
            });

            //参与人次：减
            $('.exchangeNum .minus').on('click', function () {
                var num = $('.count').val();
                if (num > 1) {
                    $('.count').val(parseInt(num) - 1);
                    //$(this).addClass('disabled');
                }
                else {
                    $('.count').val(1);
                }
            });

            // 点击参加
            $(".btnjoinnow").bind("click", function () {
                $("#joinnow").hide();
                $("#joinprogress").show();

                var _num = $("#joinnumber").val();
                var _pno = $(this).attr("relid");
                $.ajax({
                    type: "POST",
                    url: "/api/joined.html",
                    data: { p1: _pno, p2: _num },
                    dataType: "json",
                    success: function (jsonData) {
                        if (jsonData.code == 2) {
                            //报名成功
                            document.location.reload();
                            //$("#joinprogress").html("已报名");
                        }
                        else if (jsonData.code == 3) {
                            //报名成功，准备开奖
                            document.location.reload();
                        }
                        else {
                            alert(jsonData.message);

                            $("#joinnow").show();
                            $("#joinprogress").hide();
                        }
                    }
                });
            });


            //导航
            $(".indianaDeMain .navdiv li").on("click", function () {
                var _index = $(this).index();
                $(this).addClass("on").siblings().removeClass("on");
                $(".indianaDeMain .tabMain").hide().eq(_index).show();
            });

            // 夺宝参与用户列表
            var _pno = '<%=Tiantu.DB.Common.SL.DESEncrypt(productmodel.ProductId.ToString())%>';
            $.ajax({
                type: "POST",
                url: "/api/getUserList.html",
                data: { p: _pno },
                dataType: "json",
                success: function (jsonData) {
                    if (jsonData != null) {
                        var _html = '';
                        for (var i = 0; i < jsonData.list.length; i++) {
                            var _item = jsonData.list[i];
                            _html += '<li><i class="timeimg"></i><b>' + _item.time + '</b><strong>' + _item.user + '</strong>（IP：' + _item.ip + '）<span>参与了' + _item.total + ' 人次</span></li>';
                        }
                        $("#dataList").html(_html);
                    }
                }
            });

            //查看中奖者所有号码
            $(".showallwinnernumber").bind("click", function () {
                $("#allwinnernumber").show();
            });

        });
    </script>


    <script>
        $('.nav li').eq(2).addClass('on').siblings().removeClass('on');
    </script>
</asp:Content>

