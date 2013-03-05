function Zoom(zm) {
	img = document.getElementById("imgMindMap");

	if (img != undefined) {
		wid = img.width;
		ht = img.height;

		img.style.width = (wid * zm) + "px";
		img.style.height = (ht * zm) + "px";
	}
}

function GetQueryString(value) {
	var ret;

	var query = window.location.search.substring(1);
	var parms = query.split('&');
	for (var i = 0; i < parms.length; i++) {
		var pos = parms[i].indexOf('=');
		if (pos > 0 && value == parms[i].substring(0, pos)) {
			ret = parms[i].substring(pos + 1);
		}
	}
	return ret;
}


function findHHandWW() {
	var imgHeight = this.height;
	var imgWidth = this.width;

	var cWidth = document.body.clientWidth - 110;

	if (imgWidth > cWidth) {
		var ratio = cWidth / imgWidth;
		this.width = imgWidth * ratio;
		this.height = imgHeight * ratio;
	}
}

function ChangeImage() {
	var image = GetQueryString("image");

	if (image != undefined) {
		var img = document.getElementById('imgMindMap');
		if (img != undefined) {
			img.src = "images//" + image;
			img.onload = findHHandWW;
		}
		var title = GetQueryString("title");
		if (title != undefined) {
			var tit = document.getElementById('txtTitle');
			if (tit != undefined) {
				tit.innerHTML = decodeURIComponent(title);
			}
		}
	}
}

function GoToBookMenu() {
	//window.location = 'radial-book.html';
	history.go(-1);
}

function ResetImage() {
	window.location.reload();
}