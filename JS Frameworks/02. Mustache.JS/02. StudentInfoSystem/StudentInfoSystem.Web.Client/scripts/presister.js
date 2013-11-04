/// <reference path="libs/class.js" />
/// <reference path="http-requester.js" />

var persisters = (function () {
    var MainPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl;
            this.student = new StudentPresiter(this.rootUrl);
        }
    });
   
    var StudentPresiter = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl + "students";
        },

        getAll: function (success, error) {
            var url = this.rootUrl;
            httpRequester.getJson(url, success, error);
        }
    });

    return {
        get: function (url) {
            return new MainPersister(url);
        }
    };
}());