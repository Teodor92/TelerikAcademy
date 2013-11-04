/// <reference path="libs/oopClass.js" />
/// <reference path="libs/jquery-2.0.3.js" />
/// <reference path="libs/underscore.js" />
/// <reference path="ui-control.js" />
/// <reference path="libs/rsvp.js" />
/// <reference path="persister.js" />
/// <reference path="libs/mustache.js" />

var controllers = (function () {

    var persister;

    var MainController = Class.create({
        init: function (apiKey, selector) {
            persister = persisters.getPersiter(apiKey);
            this.selector = selector;
            this.home = new HomePageController(this.selector);
            this.post = new PostPageController(this.selector);
            this.single = new SinglePostPageController(this.selector);
        }
    });

    var HomePageController = Class.create({
        init: function (selector) {
            this.selector = selector;
        },

        loadHomePage: function () {
            var self = this;

            if (persister.isLoggedIn()) {
                ui.buildHome(this.selector).then(function () {
                    self.attachEventsToHome();
                });
                
            }
            else {
                ui.buildLogin(this.selector).then(function (result) {
                    $(self.selector).html(result);
                    self.attachEvents();
                }, function (error) {
                    console.log(error);
                });
            }
        },

        attachEvents: function () {
            var self = this;
            $(self.selector).on("click", "#btn-register", function () {
                var user = {
                    Username: $("#tb-username").val(),
                    Password: $("#tb-password").val()
                }

                persister.user.register(user).then(function (result) {
                    console.log(result);
                }, function (error) {
                    console.log(error);
                });
            });

            $(self.selector).on("click", "#btn-login", function () {
                var user = {
                    username: $("#tb-username").val(),
                    password: $("#tb-password").val(),
                    grant_type: "password"
                };

                persister.user.login(user).then(function (result) {
                    self.loadHomePage();
                    app.setup.token = result.Result.access_token;
                }, function (error) {
                    console.log(error);
                });
            });
        },

        attachEventsToHome: function () {
            var self = this;

            $(self.selector).on("click", "#btn-logout", function () {
                persister.user.logout();
                self.loadHomePage();
            });
        }
    });

    var PostPageController = Class.create({
        init: function (selector) {
            this.selector = selector;
        },
        
        buildPostPage: function () {
            var self = this;

            persister.post.getAll().then(function (result) {
                $(self.selector).html(JSON.stringify(result));
                var postTemplate = Mustache.compile(document.getElementById("post-template").innerHTML);
                var listView = ui.getListView(result.result);
                var listViewHtml = listView.render(postTemplate);
                console.log(listViewHtml);
                $(self.selector).html(listViewHtml);
            });
        },
    });

    var SinglePostPageController = Class.create({
        init: function (selector) {
            this.selector = selector;
        },

        buildSinglePostPage: function (id) {
            var self = this;
            persister.post.getById(id).then(function (result) {
                $(self.selector)
                    .html(Mustache.render(document.getElementById("single-post-template").innerHTML, result.result));

                self.attachEvents();
            }, function (error) {
                console.log(error);
            });
        },

        attachEvents: function () {
            var self = this;
            var commentBox = $(".comment-box");
            commentBox.hide();
            $(self.selector).on("click", ".comment-toggle", function () {
                commentBox.toggle();
            });
        }
    });

    return {
        getMainController: function (apiKey, selector) {
            return new MainController(apiKey, selector);
        }
    };
})();