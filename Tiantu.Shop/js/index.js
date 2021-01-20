/// <reference path="jquery-1.11.0.js" />
$(document).ready(function ()
{
    //签到
    var checkTimes = 0;
    $('a.checkLogin').click(function ()
    {
        if (checkTimes > 0) return;
        checkTimes = 1;
        var el = $(this);
        el.removeClass("checkLogin").addClass('checkOn');
        el.html('签到中...');

        $.ajax({
            type: "POST",
            url: "/checkIn.html",
            dataType: "json",
            success: function (response)
            {
                if (response.errcode == 0)
                {
                    el.html('已签到');
                }
            }
        });
    });
});