/// <reference path="libs/require.js" />
/// <reference path="persister.js" />
/// <reference path="libs/crypto.js" />


(function () {
    waitSeconds: 200,

    require.config({
        paths: {
            jquery: "libs/jquery-2.0.2",
            crypto: "libs/crypto",
            sammy: "libs/sammy-0.7.4",
            q: "libs/q",
            oopClass: "libs/oopClass",
            mustache: "libs/mustache"
        }
    })
    
    require(["jquery", "persister", "crypto", "q", "sammy", "controller"], function ($, persisters, cypt, Q, sammy, controller) {

        var control = controller.getMainContoller("http://localhost:22954/api/");

        var selector = "#wrapper";

        var app = sammy("#wrapper", function () {
            this.get("#/", function () {
                control.loadUi(selector);
            });

            this.get("#/open", function () {

                control.loadOpendGames(selector);
            });

            this.get("#/active", function () {
                control.loadActiveGames(selector);
            });

            this.get("#/game", function () {
                console.log("game");
            });
        });

        app.run("#/");

    });
}());