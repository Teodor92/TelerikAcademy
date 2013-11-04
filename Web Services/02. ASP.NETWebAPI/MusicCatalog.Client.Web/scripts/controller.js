/// <reference path="class.js" />
/// <reference path="http-requester.js" />
/// <reference path="persister.js" />
/// <reference path="libs/jquery-2.0.3.js" />
/// <reference path="libs/jquery-2.0.3.intellisense.js" />

(function () {
    var persister = persisters.get("http://localhost:46202/api/");
    //persister.song.getAllSongs(function (data) {
    //    console.log(data);
    //}, function (error) {
    //    console.log(error);
    //});
    persister.song.deleteSong(12, function () {
        console.log('Sucess');
    }, function () {
        console.log('Fail');
    });
})();