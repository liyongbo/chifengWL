(function($) {
	var printAreaCount = 0;
	$.fn.printArea = function(w,h,obj) {
		var ele = $(this);
		var idPrefix = "printArea_";
		removePrintArea(idPrefix + printAreaCount);
		printAreaCount++;
		var iframeId = idPrefix + printAreaCount;
		var iframeStyle = "display:none;width:" + w + "px;height:" + h + "px;";
		iframe = document.createElement('IFRAME');
		$(iframe).attr({
			style : iframeStyle,
			id : iframeId
		});
		document.body.appendChild(iframe);
		var doc = iframe.contentWindow.document;
		$(document).find("link").filter(function() {
			return $(this).attr("rel").toLowerCase() == "stylesheet";
		}).each(
				function() {
					doc.write('<link type="text/css" rel="stylesheet" href="'
							+ $(this).attr("href") + '" >');
				});
		$(ele).find(".qian").remove();
		$(ele).find(".btnPrint").remove();
		$(ele).find(".shenhe").remove();
		
		var tt = $(".whiteBG_Msg");
		$(tt).find(".searchWs").remove();
		if (obj == 1 || obj == 2)
		    $(ele).find(".procode").remove();
		doc.write('<div class="' + $(tt).attr("class") + '">' + $(tt).html() + '</div><div class="' + $(ele).attr("class") + '" style="width:968px;height:auto">' + $(ele).html()
				+ '</div>');
		doc.close();
		var frameWindow = iframe.contentWindow;
		frameWindow.close();
		frameWindow.focus();
		frameWindow.print();
	}
	var removePrintArea = function(id) {
		$("iframe#" + id).remove();
	};
})(jQuery);