/// <reference path="../../kendo/js/jquery.min.js" />
/// <reference path="../libs/q.js" />
/// <reference path="../../kendo/js/kendo.mobile.min.js" />
/// <reference path="../data/dataPersister.js" />
var app = app || {};

(function (a) {

    var notesViewModel = kendo.observable({
        keyword: "",
        search: search
    });

    function init(e) {
        navigator.notification.vibrate(200);
        kendo.bind(e.view.element, notesViewModel);
    }

    function search() {
        var keyWord = notesViewModel.get("keyword");

        app.data.dataPersister.searchByKeyWord(keyWord).then(function (data) {

            var template = kendo.template($("#recipe-template").html());
            var processed = template(data.matches);
            $("#recipe-results").html(processed);

        }, function (error) {
            navigator.notification.alert("Recipes load failed!", function () { });
        });
    }

    a.recipes = {
        init: init
    };

}(app));