/// <reference path="libs/class.js" />
/// <reference path="httpRequester.js" />

define(["httpRequester", "class"], function (httpRequester, Class) {
    var StudentSystem = StudentSystem || {};
    console.log(Class);

    StudentSystem.Data = (function () {
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

            getAll: function () {
                var url = this.rootUrl;
                return httpRequester.getJson(url);
            },

            getMarksById: function (studentId) {
                var url = this.rootUrl + "/" + studentId + "/marks";
                return httpRequester.getJson(url);
            }
        });

        return {
            get: function (url) {
                return new MainPersister(url);
            }
        };
    }());

    return StudentSystem;
});

