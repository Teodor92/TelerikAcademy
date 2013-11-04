
var persisters = (function () {

    var everliveConfig = {
        appKey: "",
        url: "",
        token: ""
    };

    var MainPersister = Class.create({
        init: function (rootUrl, apiKey) {
            this.rootUrl = rootUrl + apiKey + "/";
            everliveConfig.url = this.rootUrl;
            everliveConfig.appKey = apiKey;
            this.user = new UserPersister(this.rootUrl);
            this.post = new PostPersister(this.rootUrl);
            this.tag = new TagPersister(this.rootUrl);
        }
    });

    var UserPersister = Class.create({
        init: function (root) {
            this.rootUrl = root;
        },

        register: function (data) {
            var url = this.rootUrl + 'Users';
            return request.postJson(url, data).then(function (result) {
                everliveConfig.token = result.Result.access_token;
            });
        },

        login: function (data) {
            var url = this.rootUrl + "oauth/token";
            return request.postJson(url, data).then(function (result) {
                everliveConfig.token = result.Result.access_token;
                console.log(everliveConfig.token);
            });
        },

        logout: function () {

        },

        getAll: function () {
            var url = this.rootUrl + 'Users';
            var headers = { "Authorization": "Bearer " + everliveConfig.token };
            return request.getJson(url, headers);
        }
    });

    var PostPersister = Class.create({
        init: function (root) {
            this.rootUrl = root + 'Post';
        },

        create: function (post) {
            var headers = { "Authorization": "Bearer " + everliveConfig.token };
            return request.postJson(this.rootUrl, post, headers);
        },

        getAll: function () {
            var headers = { "Authorization": "Bearer " + everliveConfig.token };
            return request.getJson(this.rootUrl, headers);
        }
    });

    var TagPersister = Class.create({
        init: function (root) {
            this.rootUrl = root + "Tag";
        },

        getAll: function () {
            var headers = { "Authorization": "Bearer " + everliveConfig.token };
            return request.getJson(this.rootUrl, headers);
        }
    });

    return {
        getPersiter: function (url, apiKey) {
            return new MainPersister(url, apiKey);
        }
    };

}());