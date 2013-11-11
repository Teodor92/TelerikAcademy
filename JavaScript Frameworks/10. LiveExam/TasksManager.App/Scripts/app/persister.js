/// <reference path="../libs/q.js" />
/// <reference path="../libs/class.js" />
/// <reference path="../libs/jquery-2.0.3.js" />
/// <reference path="../libs/httpRequester.js" />
/// <reference path="../libs/cryptoJS.js" />

window.persisters = (function () {

    var authToken = localStorage.getItem("authToken");
    var headers = { "X-accessToken": authToken };

    function saveUserData(data) {
        authToken = data.accessToken;
        headers = { "X-accessToken": data.accessToken };
        localStorage.setItem("authToken", data.accessToken);
    }

    function clearUserData() {
        authToken = null;
        headers = null;
        localStorage.removeItem("authToken");
    }

    var MainPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl;
            this.users = new UserPersister(this.rootUrl);
            this.appointments = new AppointmentsPersister(this.rootUrl);
            this.lists = new ListsPersister(this.rootUrl);
            this.todos = new TodosPersister(this.rootUrl);
        },

        isUserLoggedIn: function () {
            return (authToken != null);
        }
    });

    var UserPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl;
        },

        register: function (user) {
            var url = this.rootUrl + "users/register/";
            user.authCode = CryptoJS.SHA1(user.password).toString();

            return httpRequester.postJson(url, user);
        },

        login: function (user) {
            var url = this.rootUrl + "auth/token/";
            user.authCode = CryptoJS.SHA1(user.password).toString();

            return httpRequester.postJson(url, user).then(function (data) {
                saveUserData(data);
            });
        },

        logout: function () {
            var url = this.rootUrl + "users/logout/";
            return httpRequester.putJson(url, null, headers).then(function () {
                clearUserData();
            });
        }
    });

    var AppointmentsPersister = new Class.create({
        init: function (root) {
            this.rootUrl = root + "appointments/";
        },

        create: function (data) {
            var url = this.rootUrl + "new/";
            return httpRequester.postJson(url, data, headers);
        },

        getAll: function () {
            var url = this.rootUrl + "all/";
            return httpRequester.getJson(url, headers);
        },

        getComming: function () {
            var url = this.rootUrl + "comming/";
            return httpRequester.getJson(url, headers);
        },

        getByDate: function (date) {
            var url = this.rootUrl + "?date=" + date;
            return httpRequester.getJson(url, headers);
        },

        getToday: function () {
            var url = this.rootUrl + "today/";
            return httpRequester.getJson(url, headers);
        },

        getCurrent: function () {
            var url = this.rootUrl + "current/";
            return httpRequester.getJson(url, headers);
        }
    });

    var ListsPersister = Class.create({
        init: function (root) {
            this.rootUrl = root + "lists/";
        },

        createMany: function (data) {
            var url = this.rootUrl;
            return httpRequester.postJson(url, data, headers)
        },

        createSingle: function (listid, data) {
            var url = this.rootUrl + "" + listid + "/todos";
            return httpRequester.postJson(url, data, headers)
        },

        getAll: function () {
            var url = this.rootUrl;
            return httpRequester.getJson(url, headers);
        },

        getSingle: function (listId) {
            var url = this.rootUrl + "/single?id=" + listId;
            return httpRequester.getJson(url, headers);
        }
    });

    var TodosPersister = Class.create({
        init: function (root) {
            this.rootUrl = root + "todos/"
        },

        changeStatus: function (todoId) {
            var url = this.rootUrl + todoId;
            return httpRequester.putJson(url, null, headers);
        }
    });

    return {
        get: function (root) {
            return new MainPersister(root);
        }
    }

})();