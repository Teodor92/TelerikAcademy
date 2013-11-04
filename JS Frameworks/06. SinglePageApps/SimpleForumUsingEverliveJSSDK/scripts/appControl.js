/// <reference path="libs/sammy-0.7.4.js" />
/// <reference path="controller.js" />

$(function () {
    var wrapper = '#app-content';
    var controller = controllers.getMainController("v1wlAbFiiPWrUQSg", wrapper);

    var app = Sammy(wrapper, function () {
        this.get("#/", function () {
            console.log("Home");
            controller.home.loadHomePage();
        });

        this.get("#/home", function () {
            console.log("Home");
            controller.home.loadHomePage();
        });

        this.get("#/posts", function () {
            console.log("Posts");
            controller.post.buildPostPage();
        });

        this.get("#/posts/:id", function (id) {
            controller.single.buildSinglePostPage(this.params["id"]);
        });

        this.get("#/posts/:id/comment", function (id) {
            //controller.single.buildSinglePostPage(this.params["id"]);
        });
    });

    app.run("#/");
});