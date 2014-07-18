/// <reference path="../libs/httpRequester.js" />
var app = app || {};

(function (a) {

    var baseUrl = "http://maps.googleapis.com/maps/api/geocode/json?";

    function getAddress(lat, lon) {
        var url = baseUrl + "latlng=" + lat + "," + lon + "&sensor=false";
        return httpRequester.getJson(url);
    }

    a.data = a.data || {};
    a.data.googleApiDataPersister = {
        getAddress: getAddress
    };

}(app));
