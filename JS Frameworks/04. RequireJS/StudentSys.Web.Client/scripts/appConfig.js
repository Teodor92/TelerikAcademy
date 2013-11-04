/// <reference path="libs/jquery-2.0.3.js" />
/// <reference path="libs/require.js" />
(function () {
    waitSeconds: 200,
    require.config({
        paths: {
            jquery: "libs/jquery-2.0.3",
            mustache: "libs/mustache",
            q: "libs/q",
            class: "libs/class",
            httpRequester: "httpRequester"
        }
    })

    require(["application"], function () {
         //Run that!
    });

})();