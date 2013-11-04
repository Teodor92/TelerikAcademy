/// <reference path="libs/everlive.all.js" />
/// <reference path="libs/everlive.js" />


var persisters = (function () {

    var everliveConfig = {
        appKey: "",
    };

    var app;

    var MainPersister = Class.create({
        init: function (apiKey) {
            everliveConfig.appKey = apiKey;
            app = new Everlive(everliveConfig.appKey);
            app.setup.token = localStorage.getItem("token");

            this.user = new UserPersister();
            this.post = new PostPersister();
            this.tag = new TagPersister();
        },

        isLoggedIn: function () {
            if (localStorage.getItem("token")) {
                return true;
            }
            else {
                return false;
            }
        }
    });

    var UserPersister = Class.create({
        init: function () {
        },

        register: function (data) {
            return app.Users.register(data.username, data.password);
        },

        login: function (data) {
            return app.Users.login(data.username, data.password).then(function (result) {
                app.setup.token = result.result.access_token;
                localStorage.setItem("token", result.result.access_token);
                console.log(everliveConfig.token);
            });
        },

        logout: function () {
            app.setup.token = "";
            localStorage.removeItem("token");
        },

        getAll: function () {
            return app.Users.get().then(function (result) {
                console.log(result);
            });
        }
    });

    var PostPersister = Class.create({
        init: function (root) {
            this.data = Everlive.$.data('Post');
        },

        create: function (post) {
            return this.data.create(post);
        },

        getById: function (id) {
            return this.data.getById(id);
        },

        getAll: function () {
            var query = new Everlive.Query();
            query.orderDesc("CreatedAt");
            return this.data.get(query);
        }
    });

    var TagPersister = Class.create({
        init: function (root) {
            this.data = Everlive.$.data('Tag');
        },

        getAll: function () {
            return this.data.get();
        }
    });

    var CommentPersister = Class.create({
        init: function () {
            this.data = Everlive.$.data('Comment');
        },

        create: function (post) {
            return this.data.create(post);
        }
    });

    return {
        getPersiter: function (apiKey) {
            return new MainPersister(apiKey);
        }
    };

}());