/// <reference path="../libs/rsvp.min.js" />
/// <reference path="../data/dataPersister.js" />

var app = app || {};

(function (a) {

    function init(e) {

        var id = e.view.params.rId;

        app.data.dataPersister.getRecipeById(id).then(function (data) {
            console.log(data);

            var template = kendo.template($("#recipe-detail-template").html());
            var processed = template(data);
            $("#recipe-container").html(processed);

        }, function (error) {
            navigator.notification.alert("Recipe load failed!", function () { })
        })
    }

    a.recipeDetails = {
        init: init
    };

}(app));
