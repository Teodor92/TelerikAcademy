$('#tab-container').easytabs();

$(function onDocumentReady() {
	$(".tab").on("click", function onShowRegisterBtnClick() {
		$("li.current").removeClass("current");
		$(this).addClass("current");
	});
});
