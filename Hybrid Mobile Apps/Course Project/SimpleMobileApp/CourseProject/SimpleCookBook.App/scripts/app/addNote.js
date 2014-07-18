/// <reference path="../data/customApiDataPersister.js" />
/// <reference path="../../kendo/js/jquery.min.js" />
/// <reference path="../data/customApiDataPersister.js" />
/// <reference path="../libs/rsvp.min.js" />
/// <reference path="../../kendo/js/kendo.mobile.min.js" />
/// <reference path="../data/googleApiDataPersister.js" />

var app = app || {};

(function (a) {

    var addNoteViewModel = kendo.observable({
        title: "Test",
        author: "AuthorTest",
        content: "Content test moar chars",
        errorMsg: "",
        addNewNote: addNewNote
    });

    function init(e) {
            kendo.bind(e.view.element, addNoteViewModel);
    }

    function addNewNote() {
        var error = false;

        var title = addNoteViewModel.get("title");
        if (title.length < 3 || title.length > 400) {
            error = true;
            addNoteViewModel.set("errorMsg", "Title is invalid!");
        }

        var content = addNoteViewModel.get("content");
        if (content.length < 12) {
            error = true;
            addNoteViewModel.set("errorMsg", "Minimum content length is 12 characters.");
        }

        var author = addNoteViewModel.get("author");
        if (author.length != 0 && (author.length < 3 || author.length > 50)) {
            error = true;
            addNoteViewModel.set("errorMsg", "Author name must be between 3 and 50 characters.");
        }

        if (!error) {
            navigator.geolocation.getCurrentPosition(function (data) {
                var lat = data.coords.latitude;
                var lon = data.coords.longitude;

                app.data.googleApiDataPersister.getAddress(lat, lon).then(function (data) {

                    console.log(data);

                    var address = data.results[0].formatted_address;

                    var model = {
                        title: title,
                        content: content,
                        author: author,
                        postAddress: address,
                        latitude: lat,
                        lontitude: lon,
                        deviceId: device.uuid
                    };

                    app.data.customApiDataPerister.postNote(model).then(function () {
                        a.application.navigate("views/notes-view.html#notes-view");
                    }, function (error) {
                        navigator.notification.alert("Message save failed!", function () { })
                    });

                }, function (error) {
                    navigator.notification.alert("Address retrieval failed!", function () { })
                })

            }, function (error) {
                navigator.notification.alert("Geolocation failed!", function () { })
            });
        }
    }

    a.addNote = {
        init: init
    };

}(app));
