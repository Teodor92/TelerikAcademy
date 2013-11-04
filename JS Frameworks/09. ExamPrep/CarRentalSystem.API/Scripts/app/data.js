/// <reference path="../libs/httpRequester.js" />
window.persisters = (function () {
    var sessionKey = localStorage.getItem('sessionKey');
    var bashUsername = localStorage.getItem('bashUsername');


	function saveUserData(userData) {
	    localStorage.setItem('bashUsername', userData.displayName);
	    localStorage.setItem('sessionKey', userData.sessionKey);
	    nickname = userData.nickname;
	    sessionKey = userData.sessionKey;
	}

	function clearUserData() {
	    localStorage.removeItem('bashUsername');
	    localStorage.removeItem('sessionKey');
	    nickname = '';
	    sessionKey = '';
	}

	var UsersPersister = Class.create({
		init: function (apiUrl) {
			this.apiUrl = apiUrl;
		},
		login: function (username, password) {
			var user = {
				username: username,
				authCode: CryptoJS.SHA1(password).toString()
			};


			return httpRequester.postJson(this.apiUrl + "login", user)
				.then(function (data) {
				    saveUserData(data);
				});
		},
		register: function (username, password) {
			var user = {
				username: username,
				authCode: CryptoJS.SHA1(password).toString()
			};

			return httpRequester.postJson(this.apiUrl + "register", user)
				.then(function (data) {
					saveUserData(data)
				});
		},
		logout: function () {
			if (!sessionKey) {
				//gyrmi.. no shit ?
			}
			var headers = {
				"X-sessionKey": sessionKey
			};

			return httpRequester.putJson(this.apiUrl + "logout", headers).then(function () {
			    clearUserData();
			});
		},
		currentUser: function () {
			return bashUsername;
		}
	});

	var CarsPersister = Class.create({
		init: function (apiUrl) {
			this.apiUrl = apiUrl;
		},
		all: function () {
			return httpRequester.getJson(this.apiUrl);
		},

		rented: function () {
		    var url = this.apiUrl + "rented/";
		    return httpRequester.getJson(url);
		}
	});

	var StoresPersister = Class.create({
	})

	var DataPersister = Class.create({
		init: function (apiUrl) {
			this.apiUrl = apiUrl;
			this.users = new UsersPersister(apiUrl + "users/");
			this.cars = new CarsPersister(apiUrl + "cars/");
			this.stores = new StoresPersister(apiUrl + "stores/");
		}
	});

	return {
		get: function (apiUrl) {
			return new DataPersister(apiUrl);
		}
	}
}());