/// <reference path="jquery.min.js" />

//sidebar toggle
$(document).ready(function () {

 
    /*
       if (window.location.href.toLowerCase().indexOf('/desk.aspx') > 0) {
        if ($(window).width() > 800) {
            $(".sidebar").addClass("active");
        } else {
            $(".sidebar").removeClass("active");
        }
    }

    $(window).resize(function () {
        if (window.location.href.toLowerCase().indexOf('/desk.aspx') > 0) {
            if ($(window).width() > 800) {
                $(".sidebar").addClass("active");
            } else {
                $(".sidebar").removeClass("active");
            }
        }
    });
    */

    //左导航定位
    var locationUrl = window.document.location.href;
    $(".nav-second-level li a").each(function () {
        var href = $(this).attr("href");
        if (href!=null && locationUrl.toLowerCase().indexOf(href.toLowerCase()) > 0) {
              $(this).parent("li").parent("ul").parent("li").addClass("active");
        }
    });
 

    $("#sidebar-toggle").click(function () {
        $(".sidebar").toggleClass("active");
    });

    $(".menu-toggle").click(function () {
        $("body").toggleClass("widescreen");
    });
    //slim
    $('.nicescroll').slimScroll({
        height: '100%',
        railOpacity: 0.9
    });
    //metis menu
    $("#menu").metisMenu();

 
    //tooltips
    $(function () {
        $('[data-toggle="tooltip"]').tooltip();
        $('[data-toggle="popover"]').popover();
    });

    var date = new Date();
    var hours = date.getHours();
    var minutes = date.getMinutes();
    var ampm = hours >= 12 ? 'PM' : 'AM';

    var month = date.getMonth();
    var day = date.getDate();
    var year = date.getFullYear();
    var dayname = date.getDay();

    var monthNames = ["01", "02", "03", "04", "05", "06",
        "07", "08", "09", "10", "11", "12"];
    var week = ["星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六"];

    //document.getElementById("para1").innerHTML = hours + "." + minutes + ampm;
    document.getElementById("para2").innerHTML = "今天是 " + year + "年" + monthNames[month] + "月" + day + "日";
    document.getElementById("para3").innerHTML = week[dayname];
});