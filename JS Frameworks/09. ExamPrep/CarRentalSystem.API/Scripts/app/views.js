/// <reference path="../libs/_references.js" />
/// <reference path="../libs/q.js" />


window.viewsFactory = (function () {
    var rootUrl = "Scripts/partials/";

    var templates = {};

    function getTemplate(name) {

        var deferred = Q.defer();

        if (templates[name]) {
            deferred.resolve(templates[name])
        }
        else {
            $.ajax({
                url: rootUrl + name + ".html",
                type: "GET",
                success: function (templateHtml) {
                    templates[name] = templateHtml;
                    deferred.resolve(templateHtml);
                },
                error: function (err) {
                    deferred.reject(err);
                }
            });
        }

        return deferred.promise;
    }

    function getLoginView() {
        return getTemplate("login-form");
    }

    function getCarsView() {
        return getTemplate("cars");
    }

    return {
        getLoginView: getLoginView,
        getCarsView: getCarsView
    };
}());