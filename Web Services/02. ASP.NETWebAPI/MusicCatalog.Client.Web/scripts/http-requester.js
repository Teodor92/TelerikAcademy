/// <reference path="libs/jquery-2.0.3.js" />
/// <reference path="class.js" />
/// <reference path="libs/jquery-2.0.3.intellisense.js" />

var httpRequester = (function () {
	function getJson(url, success, error) {
		$.ajax({
			url: url,
			type: "GET",
			timeout: 5000,
			contentType: "application/json",
			success: success,
			error: error
		});
	}

	function postJson(url, data, success, error) {
		$.ajax({
			url: url,
			type: "POST",
			contentType: "application/json",
			timeout: 5000,
			data: JSON.stringify(data),
			success: success,
			error: error
		});
	}

	function deleteJson(url, success, error) {
	    $.ajax({
	        url: url,
	        type: "DELETE",
	        timeout: 5000,
	        contentType: "application/json",
	        success: success,
	        error: error
	    });
	}

	function putJson(url, data, success, error) {
	    $.ajax({
	        url: url,
	        type: "PUT",
	        contentType: "application/json",
	        timeout: 5000,
	        data: JSON.stringify(data),
	        success: success,
	        error: error
	    });
	}

	return {
	    getJson: getJson,
	    postJson: postJson,
	    deleteJson: deleteJson,
        putJson: putJson
	};
}());