/// <reference path="../kendo/js/kendo.mobile.min.js" />
/// <reference path="../kendo/js/jquery.min.js" />
/// <reference path="app/home.js" />
/// <reference path="app/notes.js" />

var app = app || {};

(function (a) {
    document.addEventListener("deviceready", function () {
        var kendoApp = new kendo.mobile.Application(document.body);
        a.application = kendoApp;
    });

    document.addEventListener("online", function () {
        app.home.refreshConnectionState();
    }, false);

    document.addEventListener("offline", function () {
        app.home.refreshConnectionState();
    }, false);
}(app));