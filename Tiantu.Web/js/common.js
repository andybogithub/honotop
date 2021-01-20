$(function(){
	
	
	//显示二维码
	$(".ui_follow").hover(function(){
		$(this).find(".followImg").show();
	},function(){
		$(this).find(".followImg").hide();
	});
})



//图片按比例放大缩小
function DrawImage(ImgD, FitWidth, FitHeight) {
    var image = new Image();
    image.src = ImgD.src;
    if (image.width > 0 && image.height > 0) 
    {
        if (image.width / image.height >= FitWidth / FitHeight){
			if (image.width > FitWidth) {
				//ImgD.width = FitWidth;
				ImgD.height = FitHeight;
				var ml = ((image.width * FitHeight) / image.height - FitWidth)/2;
				ImgD.style.marginLeft = -ml + "px";
			}else{
				//ImgD.width = FitWidth;
				ImgD.height = FitHeight;
			}
		}else {
			if (image.height > FitHeight) {
				//ImgD.height = FitHeight;
				ImgD.width = FitWidth;
			}else {
				ImgD.width = FitWidth;
				//ImgD.height = FitHeight;
			}
		}
	}
}

$(function(){
	$(".follow_w li:eq(0)").hover(function(){
		$(this).find(".followImg").show();
	},function(){
		$(".follow_w li .followImg").hide();
	})
})
$(function(){
	$(".follow_w li:eq(1)").hover(function(){
		$(this).find(".followImgwb").show();
	},function(){
		$(".follow_w li .followImgwb").hide();
	})
})

//预约
    $(function ()
    {
        $(".indexvideo").click(function ()
        {
            $(".reservebg,.reservePopup").fadeIn();
        })
        $(".reserveclose").click(function ()
        {
            $(".reservebg,.reservePopup").fadeOut();
        })
    })

