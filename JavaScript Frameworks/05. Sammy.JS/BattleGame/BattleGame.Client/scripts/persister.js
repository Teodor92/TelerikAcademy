/// <reference path="libs/class.js" />
/// <reference path="libs/sha1.js" />
/// <reference path="httpRequester.js" />
/// <reference path="libs/jquery-2.0.2.js" />
/// <reference path="libs/q.js" />
/// <reference path="libs/require.js" />

define(["jquery", "oopClass", "httpRequester", "q", "crypto"], function ($, oopClass, httpRequester, Q) {
    var nickname = localStorage.getItem('nickname');
    var sessionKey = localStorage.getItem('sessionKey');



    function saveUserData(userData) {
        localStorage.setItem('nickname', userData.nickname);
        localStorage.setItem('sessionKey', userData.sessionKey);
        nickname = userData.nickname;
        sessionKey = userData.sessionKey;
    }

    function clearUserData() {
        localStorage.removeItem('nickname');
        localStorage.removeItem('sessionKey');
        nickname = '';
        sessionKey = '';
    }

    var MainPersiter = oopClass.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl;
            this.user = new UserPersiter(this.rootUrl);
            this.game = new GamePersiter(this.rootUrl);
            this.message = new MessagesPersiter(this.rootUrl);
            this.battle = new BattlePersister(this.rootUrl);
        },

        isUserLoggedIn: function () {
            return (sessionKey != null && nickname != null );
        },

        getNickname: function () {
            return nickname;
        }
    });

    var UserPersiter = oopClass.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl + 'user/';
        },

        login: function (user) {
            var url = this.rootUrl + 'login';

            var userData = {
                username: user.username,
                authCode: CryptoJS.SHA1(user.username + user.password).toString()
                //authCode: user.password
            };

            return httpRequester.postJson(url, userData).then(function (data) {
                saveUserData(data);
            });
        },

        // user register
        register: function (user) {
            var url = this.rootUrl + 'register';

            var userData = {
                username: user.username,
                nickname: user.nickname,
                authCode: CryptoJS.SHA1(user.username + user.password).toString()
                //authCode: user.password
            };

            return httpRequester.postJson(url, userData).then(function (data) {
                saveUserData(data);
            });
        },

        logout: function () {
            var url = this.rootUrl + 'logout/' + sessionKey;

            return httpRequester.putJson(url).then(function (data) {
                clearUserData();
            });
        },

        scores: function () {
            var url = this.rootUrl + 'scores/' + sessionKey;
            return httpRequester.getJson(url);
        }
    });

    var GamePersiter = oopClass.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl + 'game/';
        },

        create: function (gameInfo) {
            var url = this.rootUrl + 'create/' + sessionKey;

            if (gameInfo.password) {
                gameInfo.password = CryptoJS.SHA1(password).toString();
            }

            return httpRequester.postJson(url, gameInfo);
        },

        join: function (gameInfo) {
            var url = this.rootUrl + 'join/' + sessionKey;

            if (gameInfo.password) {
                gameInfo.password = CryptoJS.SHA1(password).toString();
            }

            return httpRequester.postJson(url, gameInfo);
        },

        start: function (gameID) {
            var url = this.rootUrl + gameID + '/start/' + sessionKey;
            return httpRequester.putJson(url);
        },

        myActive: function () {
            var url = this.rootUrl + 'my-active/' + sessionKey;
            return httpRequester.getJson(url);
        },

        open: function () {
            var url = this.rootUrl + 'open/' + sessionKey;
            return httpRequester.getJson(url);
        },

        field: function (gameID) {
            var url = this.rootUrl + gameID + '/field/' + sessionKey;
            return httpRequester.getJson(url);
        }
    });

    var BattlePersister = oopClass.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl + 'battle/';
        },

        move: function (gameId, moveInfo) {
            var url = this.rootUrl + gameId + '/move/' + sessionKey;
            return httpRequester.postJson(url, moveInfo);
        },

        attack: function (gameId, attackInfo) {
            var url = this.rootUrl + gameId + '/attack/' + sessionKey;
            return httpRequester.postJson(url, attackInfo);
        },

        defend: function (gameId, defendData) {
            var url = this.rootUrl + gameId + '/defend/' + sessionKey;
            return httpRequester.postJson(url, defendData);
        }
    });

    var MessagesPersiter = oopClass.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl + 'messages/';
        },

        unread: function () {
            var url = this.rootUrl + 'unread/' + sessionKey;
            return httpRequester.getJson(url);
        },

        all: function () {
            var url = this.rootUrl + 'all/' + sessionKey;
            return httpRequester.getJson(url);
        }
    });

    return {
        getPersiter: function (url) {
            return new MainPersiter(url);
        }
    };

});