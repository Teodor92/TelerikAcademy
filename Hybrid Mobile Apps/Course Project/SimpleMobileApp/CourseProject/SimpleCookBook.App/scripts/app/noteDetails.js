/// <reference path="../data/customApiDataPersister.js" />
/// <reference path="../libs/rsvp.min.js" />
/// <reference path="../data/dataPersister.js" />
/// <reference path="../libs/httpRequester.js" />
var app = app || {};

(function (a) {

    function init(e) {
        var noteId = e.view.params.noteId;

        app.data.customApiDataPerister.getNoteById(noteId).then(function (data) {

            var template = kendo.template($("#note-template").html());
            var processed = template(data);
            $("#note-container").html(processed);

        }, function (error) {
            navigator.notification.alert("Note load failed!", function () { })
        });
    }

    a.noteDetails = {
        init: init
    };

}(app));
