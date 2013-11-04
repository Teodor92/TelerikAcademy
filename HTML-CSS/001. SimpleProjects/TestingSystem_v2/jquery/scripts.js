$(document).ready(function() {
	$('#tab-container').easytabs();

	$('.tab img').css({
		opacity : 0.5
	});

	var getIdInUrl = location.href;
	var id = getIdInUrl.substring(getIdInUrl.lastIndexOf('#'));
	if (id!='#tabs1-css' || id=="#tabs1-cSharp") { //if cSharp is present
			$('.cSharpButton').animate({ //make cSharp opacity 1
				opacity : 1
			}, 500);
	}
	if (id=="#tabs1-css") { //if css is present
			$('.cssButton').animate({ //make css opacity 1
				opacity : 1
			}, 500);
	}

	if ($('.cSharpButton').data('clicked', true)) {//if cSharp is clicked
		$('.cSharpButton').click(function() {
			$('.cssButton').animate({//make cssButton opacity .5
				opacity : .5
			}, 500);
			$('.cSharpButton').animate({//make cSharp opacity 1
				opacity : 1
			}, 500);
		});
	}
	
	if ($('.cssButton').data('clicked', true)) {//if cssButton is clicked
		$('.cssButton').click(function() {
			$('.cSharpButton').animate({//make cSharp opacity .5
				opacity : .5
			}, 500);
			$('.cssButton').animate({//make cssButton opacity 1
				opacity : 1
			}, 500);
		});
	}

});
