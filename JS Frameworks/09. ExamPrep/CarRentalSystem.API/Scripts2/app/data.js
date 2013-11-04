/// <reference path="../libs/rsvp.min.js" />
/// <reference path="../libs/class.js" />
/// <reference path="http://crypto-js.googlecode.com/svn/tags/3.1.2/build/rollups/sha1.js />

window.persisters = (function () {

	function performPostRequest(requestUrl, requestData, headers) {
		var promise = new RSVP.Promise(function (resolve, reject) {
			$.ajax({
				url: requestUrl,
				type: "POST",
				dataType: "json",
				contentType: "application/json",
				data: JSON.stringify(requestData),
				headers: headers,
				success: function (data) {
					resolve(data);
				},
				error: function (err) {
					reject(err.message);
				}
			});
		});
		return promise;
	};

	function performGetRequest(requestUrl, headers) {
		var promise = new RSVP.Promise(function (resolve, reject) {
			$.ajax({
				url: requestUrl,
				type: "GET",
				dataType: "json",
				contentType: "application/json",
				headers: headers,
				success: function (data) {
					resolve(data);
				},
				error: function (err) {
					reject(err.message);
				}
			});
		});
		return promise;
	};

	var CarsPersister = Class.create({
		init: function (apiUrl) {
			this.apiUrl = apiUrl;
		},
		all: function () {
			return performGetRequest(this.apiUrl);

			//var promise = new RSVP.Promise(function (resolve, reject) {
			//	$.ajax({
			//		url: this.apiUrl,
			//		type: "GET",
			//		type: "json",
			//		contentType: "application/json",
			//		success: function (data) {
			//			resolve(data);
			//		},
			//		error: function (err) {
			//			reject(err.message);
			//		}
			//	});
			//});
			//return promise;
		}
	});

	var UsersPersister = Class.create({
		init: function (apiUrl) {
			this.apiUrl = apiUrl;
		},
		login: function (username, password) {
			var self = this;
			var promise = new RSVP.Promise(function (resolve, reject) {
				var user = {
					username: username,
					authCode: CryptoJS.SHA1(password).toString()
				};
				return performPostRequest(self.apiUrl + "login", user)
					.then(function (data) {
						this.sessionKey = data.sessionKey;
						debugger;
						resolve(data.displayName);
					});
			});
			return promise;
		},
		register: function (username, password) {
			var self = this;
			var promise = new RSVP.Promise(function (resolve, reject) {
				var user = {
					username: username,
					authCode: CryptoJS.SHA1(password).toString()
				};
				return performPostRequest(self.apiUrl + "register", user)
					.then(function (data) {
						this.sessionKey = data.sessionKey;
						resolve(data.nickname);
					});
			});
			return promise;
		}
	});

	var StorePersister = Class.create({
		init: function (apiUrl) {
			this.apiUrl = apiUrl;
		}
	});

	var DataPersister = Class.create({
		init: function (apiUrl) {
			this.apiUrl = apiUrl;
			this.cars = new CarsPersister(this.apiUrl + "/cars/");
			this.users = new UsersPersister(this.apiUrl + "/users/");
			this.stores = new StorePersister(this.apiUrl + "/stores/");
		}
	});

	return {
		get: function (apiUrl) {
			return new DataPersister(apiUrl);
		}
	};
}());