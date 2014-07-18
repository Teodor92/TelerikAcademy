/// <reference path="../../kendo/js/jquery.min.js" />
/// <reference path="../../kendo/js/kendo.mobile.min.js" />
var app = app || {};

(function (a) {

    var homeVM = kendo.observable({
        status: null,
    });

    function init(e) {
        kendo.bind(e.view.element, homeVM);
        refreshConnectionState();

        var media = new Media("", function () {
            console.log(2);
        }, function (error) {
            console.log(error);
        });

    }

    function refreshConnectionState() {
        homeVM.set("status", _getConnectionState());
    }

    function _getConnectionState() {
        var networkState = navigator.connection.type;
        var states = {};

        states[Connection.UNKNOWN] = 'Unknown connection';
        states[Connection.ETHERNET] = 'Ethernet connection';
        states[Connection.WIFI] = 'WiFi connection';
        states[Connection.CELL_2G] = 'Cell 2G connection';
        states[Connection.CELL_3G] = 'Cell 3G connection';
        states[Connection.CELL_4G] = 'Cell 4G connection';
        states[Connection.CELL] = 'Cell generic connection';
        states[Connection.NONE] = 'Warrnig! No network connection - most of the application functions will not be available';

        return states[networkState];
    }

    a.home = {
        init: init,
        refreshConnectionState: refreshConnectionState
    };

}(app));
