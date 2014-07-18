/// <reference path="../libs/httpRequester.js" />
var app = app || {};

(function (a) {

    var baseUrl = "http://localhost:5938/api/";

    function getAllNotes(deviceId) {
        var url = baseUrl + "notes?deviceId=" + deviceId;
        return httpRequester.getJson(url);
    }

    function getNoteById(noteId) {
        var url = baseUrl + "notes/" + noteId;
        return httpRequester.getJson(url);
    }

    function postNote(data) {
        var url = baseUrl + "notes";
        return httpRequester.postJson(url, data);
    }

    a.data = a.data || {};
    a.data.customApiDataPerister = {
        getAllNotes: getAllNotes,
        getNoteById: getNoteById,
        postNote: postNote
    };

}(app));
