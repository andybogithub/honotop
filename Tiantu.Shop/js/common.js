

//2016.10.10
$(function ()
    {
        $(".addBtn").click(function ()
        {
            $(".indexbg,.aaa").fadeIn();
        })
        $(".close").click(function ()
        {
            $(".indexbg,.aaa").fadeOut();
        })
    })







$(function () {

    //导航定位
    var locationUrl = window.document.location.href;
    var navTag = 0;
    $(".header .nav li a").each(function () {
        var href = $(this).attr("href");
        if (href != null) {
            var filename = href.replace('.html', '').toLowerCase();  
            if (locationUrl.toLowerCase().indexOf(filename) > 0) {
                $(".header .nav li").removeClass("on");
                $(this).parent("li").addClass("on");
                navTag = 1;
            }
        }
    });

    //顶部退出
    $('.btnExit').click(function () {
        $('.toolBar ul:eq(0)').hide();
        $('.toolBar ul:eq(1)').show();
    });

});

//倒计时 时、分秒
function countDown(name, eTime) {
    function atime() {
        var endTime = new Date(eTime).getTime();
        var day = new Date();
        var nowTime = day.getTime();
        var time = endTime - nowTime;

        var cDay = Math.floor(time / (1000 * 60 * 60 * 24));
        var cHour = Math.floor(time / (1000 * 60 * 60)) % 24;
        var cMinute = Math.floor(time / (1000 * 60)) % 60;
        var cSecond = Math.floor(time / 1000) % 60;

        var cDay = cDay < 10 ? '0' + cDay : cDay;
        var cHour = cHour < 10 ? '0' + cHour : cHour;
        var cMinute = cMinute < 10 ? '0' + cMinute : cMinute;
        var cSecond = cSecond < 10 ? '0' + cSecond : cSecond;

        var cHour = cHour.toString().split("");
        var cMinute = cMinute.toString().split("");
        var cSecond = cSecond.toString().split("");

        if (time <= 0) {
            var txt = '';
            txt += '<b>0</b>';
            txt += '<b>0</b>';
            txt += '<span>:</span>';
            txt += '<b>0</b>';
            txt += '<b>0</b>';
            txt += '<span>:</span>';
            txt += '<b>0</b>';
            txt += '<b>0</b>';
            $(name).html(txt);
            $(name).parents('li').addClass('lootAll');
            $(name).parents('li').find('.btnChange a').html('已结束').removeAttr("href");
            clearInterval(anTime);
        } else {
            var txt = '';
            var hours = (parseInt(cDay) > 1 ? parseInt(cDay) * parseInt(cHour[0]) : cHour[0]);
            txt += '<b>' + hours + '</b>';
            txt += '<b>' + cHour[1] + '</b>';
            txt += '<span>:</span>';
            txt += '<b>' + cMinute[0] + '</b>';
            txt += '<b>' + cMinute[1] + '</b>';
            txt += '<span>:</span>';
            txt += '<b>' + cSecond[0] + '</b>';
            txt += '<b>' + cSecond[1] + '</b>';
            $(name).html(txt);
        }
    }

    var anTime = setInterval(atime, 1000);

}



//倒数
function countTime() {
    var times = 6 * 60 * 100; //倒数时间
  
    var ct = setInterval(function () {
        times = times-- < 0 ? 0 : times;

        //分
        var minute = Math.floor(times / 100 / 60);
        minute = minute < 10 ? '0' + minute : minute;
        minute = minute.toString().split("");

        //秒
        var second = Math.floor(times / 100) % 60;
        second = second < 10 ? '0' + second : second;
        second = second.toString().split("");

        //毫秒
        var millisecond = Math.floor(times % 100);
        millisecond = millisecond < 10 ? '0' + millisecond : millisecond;
        millisecond = millisecond.toString().split("");

        if (times == 0) {
            $('.conttimeFun b:eq(0)').text("0");
            $('.conttimeFun b:eq(1)').text("0");
            $('.conttimeFun b:eq(2)').text("0");
            $('.conttimeFun b:eq(3)').text("0");
            $('.conttimeFun b:eq(4)').text("0");
            $('.conttimeFun b:eq(5)').text("0");
            clearInterval(ct);
        } else {
            $('.conttimeFun b:eq(0)').text(minute[0]);
            $('.conttimeFun b:eq(1)').text(minute[1]);
            $('.conttimeFun b:eq(2)').text(second[0]);
            $('.conttimeFun b:eq(3)').text(second[1]);
            $('.conttimeFun b:eq(4)').text(millisecond[0]);
            $('.conttimeFun b:eq(5)').text(millisecond[1]);
        }

    }, 10);
}


//开奖倒计时 时、分秒
function openWinCountDownTime(name, eTime) {
    function atime() {
        var endTime = new Date(eTime).getTime();
        var day = new Date();
        var nowTime = day.getTime();
        var time = endTime - nowTime;

        var cDay = Math.floor(time / (1000 * 60 * 60 * 24));
        var cHour = Math.floor(time / (1000 * 60 * 60)) % 24;
        var cMinute = Math.floor(time / (1000 * 60)) % 60;
        var cSecond = Math.floor(time / 1000) % 60;

        var cDay = cDay < 10 ? '0' + cDay : cDay;
        var cHour = cHour < 10 ? '0' + cHour : cHour;
        var cMinute = cMinute < 10 ? '0' + cMinute : cMinute;
        var cSecond = cSecond < 10 ? '0' + cSecond : cSecond;

        var cHour = cHour.toString().split("");
        var cMinute = cMinute.toString().split("");
        var cSecond = cSecond.toString().split("");

        if (time <= 0) {
            clearInterval(anTime);
            $(name).html('<font color="red">正在开奖...</font>');

            setTimeout(function () {
                var pageUrl = '/idaDe/' + _tb_productno + '.html';
                document.location.href = pageUrl;
            }, 1000);
        }
        else {
            var txt = '';
            var hours = (parseInt(cDay) > 1 ? parseInt(cDay) * parseInt(cHour[0]) : cHour[0]);
            txt += '<b>' + hours + '</b>';
            txt += '<b>' + cHour[1] + '</b>';
            txt += '<span>:</span>';
            txt += '<b>' + cMinute[0] + '</b>';
            txt += '<b>' + cMinute[1] + '</b>';
            txt += '<span>:</span>';
            txt += '<b>' + cSecond[0] + '</b>';
            txt += '<b>' + cSecond[1] + '</b>';
            $(name).html(txt);
        }
    }

    var anTime = setInterval(atime, 1000);

}


//图片按比例放大缩小
function DrawImage(ImgD, FitWidth, FitHeight) {
    var image = new Image();
    image.src = ImgD.src;
    if (image.width > 0 && image.height > 0) {
        if (image.width / image.height >= FitWidth / FitHeight) {
            if (image.width > FitWidth) {
                //ImgD.width = FitWidth;
                ImgD.height = FitHeight;
                var ml = ((image.width * FitHeight) / image.height - FitWidth) / 2;
                ImgD.style.marginLeft = -ml + "px";
            } else {
                //ImgD.width = FitWidth;
                ImgD.height = FitHeight;
            }
        } else {
            if (image.height > FitHeight) {
                //ImgD.height = FitHeight;
                ImgD.width = FitWidth;
            } else {
                ImgD.width = FitWidth;
                //ImgD.height = FitHeight;
            }
        }
    }
}


//购买商品，添加到购物车
function exChangeNow(productId, qtyNum) {
    if (productId) {
        var _qty = (qtyNum == null || qtyNum == 'undefined' ? 1 : parseInt(qtyNum));
        $.ajax({
            type: "GET",
            url: "/addtocart.html",
            data: { productno: productId, qty: _qty },
            dataType: "json",
            success: function (responseText) {
                if (responseText.errcode == 0) {
                    //已添加到购物车
                    document.location.href = '/carts.html';
                } else {
                    //添加失败
                    alert(responseText.errmsg);
                }
            }
        });
    }
}


