/// <reference path="../libs/httpRequester.js" />
/// <reference path="../libs/q.js" />

var app = app || {};

(function (a) {

    var baseUrl = "http://api.yummly.com/v1/api/";
    var appId = "ecf82ea7";
    var appKey = "c26a25ba29d1e565b99ad0a9867ca71b";
    var authentication = "_app_id=" + appId + "&_app_key=" + appKey;

    function searchByKeyWord(keyword) {
        var url = baseUrl + "recipes?" + authentication + "&q=" + keyword;
        return httpRequester.getJson(url);
    }

    function getRecipeById(recipiId) {
        var url = baseUrl + "recipe/" + recipiId + "?" + authentication;
        console.log(url);
        return httpRequester.getJson(url);
    }

    a.data = a.data || {};
    a.data.dataPersister = {
        searchByKeyWord: searchByKeyWord,
        getRecipeById: getRecipeById
    };
}(app));
