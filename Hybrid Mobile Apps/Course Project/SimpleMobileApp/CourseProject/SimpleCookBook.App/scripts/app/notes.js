/// <reference path="../libs/rsvp.min.js" />
/// <reference path="../../kendo/js/jquery.min.js" />
/// <reference path="../data/customApiDataPersister.js" />
var app = app || {};

(function (a) {

    function init() {
        a.data.customApiDataPerister.getAllNotes(device.uuid).then(function (data) {

            var dataSource = new kendo.data.DataSource({
                type: "odata",
                data: data,
                serverPaging: true,
                serverSorting: true,
                pageSize: 40
            });

            // Not supproted in simulator
            //navigator.globalization.getNumberPattern(function (data) {
            //    console.log(data.pattern);
            //}, function (error) {
            //    console.log(error);
            //});

            $("#all-notes").kendoMobileListView({
                dataSource: dataSource,
                template: $("#notes-template").text(),
                endlessScroll: true
            });

        }, function (error) {
            navigator.notification.alert("Notes load failed!", function () { })
        });
    }

    function mobileListViewEndlessScrolling() {

    }

    a.notes = {
        init: init
    };

}(app));