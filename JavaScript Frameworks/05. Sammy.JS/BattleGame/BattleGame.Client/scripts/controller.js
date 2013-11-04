/// <reference path="libs/require.js" />

define(["jquery", "oopClass", "ui-controls", "persister", "q", "gameController"],
    function ($, oopClass, uiControls, persisters, Q, gameController) {

    var MainContoller = oopClass.create({

        init: function (rootUrl) {
            this.persister = new persisters.getPersiter(rootUrl);
            this.openGamesListControl = new uiControls.OpenGamesListControl();
            this.activeGamesListControl = new uiControls.ActiveGamesListControl();
            this.gameFieldControl = new uiControls.GameFieldControl();
            this.messageControl = new uiControls.MessageControl();
            this.baseUI = new uiControls.BaseUIControl();
            this.scoreBoard = new uiControls.ScoreBoardControl();
            this.UIRefresher;
            this.gameBoardRefresher;
            this.currentSelectedGameID;
            this.currentPlayingGame;
            this.currentCoords;
            this.isMyTurn;
            this.currentGameMyCollor;
        },

        loadUi: function (selector) {
            if (this.persister.isUserLoggedIn()) {
                this.loadGameUi(selector);
            }
            else {
                this.loadLoginFormUi(selector);
            }

            this.attachUIEventHadnlers(selector);
        },

        loadLoginFormUi: function (selector) {

            // login Form UI Build
            var myLogin = new uiControls.LoginForm();
            var loginForm = myLogin.build();
            $(selector).html(loginForm);
        },

        loadGameUi: function (selector) {
            var self = this;

            // baseUI build
            $(selector).empty().append(uiControls.buildNamvMenu());

            var html = '<div id="top-menu"><div id="current-user"><span id="user-nickname">' +
			    self.persister.getNickname() +
		    '</span>' + self.baseUI.build();

            $(selector).append(html);

            //test

            self.persister.user.scores().then(function (data) {
                console.log(data);
            }, function (error) {
                console.log("Messages show faild. Error obj -->");
                console.log(error);
            }).done();

            this.UIRefresher = setInterval(function () {

                self.persister.message.unread().then(function (data) {
                    console.log(data);
                    console.log(self.currentPlayingGame);
                    if (self.checkIfCurrentGameIsWon(data)) {
                        clearInterval(self.guessGridRefresher);

                        var msg = '<h3>Game ended</h3>'

                        $('#game-holder').html(msg);
                    };
                }, function (error) {
                    console.log(error);
                }).done();

                //self.loadOpendGames(selector);

                //self.loadActiveGames(selector);

                self.loadMessages(selector);

                self.loadScores(selector);


            }, 2000);
        },

        loadOpendGames: function (selector) {
            var self = this;

            $(selector).empty().append(uiControls.buildNamvMenu());

            // Open Games
            self.persister.game.open().then(function (games) {
                var list = self.openGamesListControl.build(games);

                //$(selector + ' #open-games').empty().html(list);
                $(selector).append(list);
            }).done();

            this.loadOpendGamesPageEvents(selector);
        },

        loadOpendGamesPageEvents: function (selector) {
            var self = this;
            var wrapper = $(selector);

            wrapper.on("click", "#open-games-list li a", function () {
                $("#game-join-inputs").remove();

                var html =
					'<div id="game-join-inputs">' +
                    '<h2>Enter game info</h2>' +
						'Password: <input type="text" id="tb-game-pass"/>' +
						'<button id="btn-join-game">Join</button>' +
					'</div>';

                self.currentSelectedGameID = $(this).parents("li").first().data("game-id");

                $(this).after(html);
            });
        },

        loadActiveGames: function (selector) {
            var self = this;

            $(selector).empty().append(uiControls.buildNamvMenu());

            // Active games
            self.persister.game.myActive().then(function (games) {
                var list = self.activeGamesListControl.build(games);

                $(selector).append(list);

                $(selector + ' .full').after('<button id="btn-start-game">Start</button>');
                $(selector + ' .in-progress').after('<button id="btn-enter-game">Enter Game</button>');
            }, function (error) {
                console.log(error);
            });

            this.loadActiveGamesPageEvents(selector);
        },

        loadActiveGamesPageEvents: function (selector) {
            var self = this;
            var wrapper = $(selector);

            // start game event
            wrapper.on('click', '#btn-start-game', function () {
                var gameID = $(this).parents("li").first().data("game-id");
                var creator = $(this).parents("li").first().data("creator");

                if (creator == self.persister.getNickname()) {
                    self.persister.game.start(gameID).then(function () {

                    }, function (error) {
                        console.log("Game start failed! Error obj -->");
                        console.log(error);
                    }).done;
                }
                else {
                    $('.error-msg').remove();
                    var errorMsg = $('<p class="error-msg"></p>').html("You can not start this game. You are not the creator.");
                    $(this).before(errorMsg);
                }
            });

            //enter game Event
            wrapper.on('click', '#btn-enter-game', function () {
                var gameID = $(this).parents("li").first().data("game-id");
                self.currentPlayingGame = gameID;

                clearInterval(self.gameBoardRefresher);

                self.gameBoardRefresher = setInterval(function () {

                    self.persister.game.field(gameID).then(function (data) {
                        self.getMyCurrentGameCollor(data);
                        console.log(self.currentGameMyCollor);
                        var gameContoller = new gameController.getMainGameControl(data);
                        var html = self.gameFieldControl.build(data, gameContoller.gameMatrix);
                        console.log(data);
                        window.location = "http://localhost:27849/#/game";
                        $(selector).empty().append(uiControls.buildNamvMenu());
                        $(selector).append(html);

                    }, function (error) {
                        console.log(data);
                    }).done();

                }, 3000);

            });
        },

        loadMessages: function (selector) {
            var self = this;

            // Messages
            self.persister.message.all().then(function (data) {

                var messsages = self.messageControl.build(data);

                $(selector + ' #messages-holder').empty().html(messsages);

            }, function (error) {
                console.log("Messages show faild. Error obj -->");
                console.log(error);
            }).done();
        },

        loadScores: function (selector) {
            var self = this;

            self.persister.user.scores().then(function (data) {
                var html = self.scoreBoard.build(data);

                $('#score-box').html(html);
            }, function (data) {

            }).done();
        },

        escapeHTML: function (stringToEscape) {
            return
            stringToEscape.replace(/&/g, '&amp;')
                .replace(/</g, '&lt;')
                .replace(/>/g, '&gt;');
        },

        checkIfCurrentGameIsWon: function (data) {

            for (var i = 0; i < data.length; i++) {

                if (data[i].gameId == this.currentPlayingGame &&
                    data[i].type == "game-finished") {
                    console.log("IS WON" + data[i].gameId);
                    return true;
                }
            }

            return false;
        },

        getMyCurrentGameCollor: function (data) {
            if (data.blue.nickname == this.persister.getNickname()) {
                this.currentGameMyCollor = "blue";
            } else {
                this.currentGameMyCollor = "red";
            }
        },

        attachUIEventHadnlers: function (selector) {
            var wrapper = $(selector);
            var self = this;

            // login event
            wrapper.on('click', '#btn-login', function () {
                var user = {
                    username: $(selector + " #tb-login-username").val(),
                    password: $(selector + " #tb-login-password").val()
                };

                console.log(user.username);
                self.persister.user.login(user).then(function () {
                    self.loadGameUi(selector);
                }, function (error) {
                    $('.error-msg').remove();
                    var errorMsg = $('<p class="error-msg"></p>').html(error.responseJSON.Message);
                    $('#btn-login').before(errorMsg);
                }).done();
            });

            // show register form event
            wrapper.on('click', '#btn-show-register', function () {
                $(selector + ' #register-form').toggle();
            });

            // register event
            wrapper.on('click', '#btn-register', function () {

                var newUser = {
                    username: $(selector + ' #tb-register-username').val(),
                    nickname: $(selector + ' #tb-register-nickname').val(),
                    password: $(selector + ' #tb-register-password').val(),
                }

                self.persister.user.register(newUser).then(function (data) {
                    self.loadGameUi(selector);
                }, function (error) {
                    // error handling
                    $('.error-msg').remove();
                    var errorMsg = $('<p class="error-msg"></p>').html(error.responseJSON.Message);
                    $('#btn-register').before(errorMsg);
                }).done();

            });

            // logout event
            wrapper.on('click', '#btn-logout', function () {
                self.persister.user.logout().then(function (data) {
                    clearInterval(self.UIRefresher);
                    clearInterval(self.gameBoardRefresher);
                    self.loadLoginFormUi(selector);
                }, function (error) {
                    console.log('Logout Failed --> error obj:');
                    console.log(error);
                }).done();
            });

            // login form shower
            wrapper.on("click", "open-games-list li a", function () {
                $("#game-join-inputs").remove();

                alert('click');

                var html =
					'<div id="game-join-inputs">' +
                    '<h2>Enter game info</h2>' +
						'Password: <input type="text" id="tb-game-pass"/>' +
						'<button id="btn-join-game">Join</button>' +
					'</div>';

                self.currentSelectedGameID = $(this).parents("li").first().data("game-id");

                $('#create-game-holder').after(html);
            });

            // join game event
            wrapper.on("click", "#btn-join-game", function () {
                var game = {
                    id: self.currentSelectedGameID
                };

                var password = $("#tb-game-pass").val();

                if (password) {
                    game.password = password;
                }

                self.persister.game.join(game).then(function () {
                    $('.error-msg').remove();
                }, function (error) {
                    $('.error-msg').remove();
                    var errorMsg = $('<p class="error-msg"></p>').html(error.responseJSON.Message);
                    $('#btn-join-game').before(errorMsg);
                }).done();
            });

            // create game event
            wrapper.on("click", "#btn-create-game", function () {
                var game = {
                    title: $("#tb-create-title").val(),
                    number: $("#tb-create-number").val(),
                }
                var password = $("#tb-create-pass").val();
                if (password) {
                    game.password = password;
                }

                self.persister.game.create(game).then(function () {
                    $('.error-msg').remove();
                }, function (error) {
                    $('.error-msg').remove();
                    var errorMsg = $('<p class="error-msg"></p>').html(error.responseJSON.Message);
                    $('#btn-create-game').before(errorMsg);
                }).done();
            });

            // select Uint
            wrapper.on('click', '.unit', function () {
                var currentClass = $(this).attr('class');

                if (currentClass == self.currentGameMyCollor + " unit") {
                    $('#clicked').attr('id', '');
                    $(this).attr('id', 'clicked');
                    self.currentCoords = {
                        x: $(this).data('x'),
                        y: $(this).data('y'),
                        id: $(this).data('unit-id')
                    }
                }
            })

            // move unit
            wrapper.on('click', '.empty', function () {

                var moveInfo = {
                    unitId: self.currentCoords.id,
                    position: {
                        x: $(this).data('x'),
                        y: $(this).data('y')
                    }
                };

                self.persister.battle.move(self.currentPlayingGame, moveInfo).done(function (data) {
                    console.log(data);

                }, function (error) {
                    var errorMsg = $('<p class="error-msg"></p>').html(error.responseJSON.Message);
                    $("#error-console").prepend(errorMsg);
                });
            });

            // defend unit
            wrapper.on('click', '.defend-btn', function (ev) {
                ev.stopPropagation();
                var unitInfo = $(this).parents("td").first().data("unit-id");

                self.persister.battle.defend(self.currentPlayingGame, unitInfo).then(function (data) {
                    console.log(data);
                }, function (error) {
                    var errorMsg = $('<p class="error-msg"></p>').html(error.responseJSON.Message);
                    $("#error-console").prepend(errorMsg);
                });
            });

            return false;
        }

    });

    return {
        getMainContoller: function (rootUrl) {
            return new MainContoller(rootUrl);
        }
    };
});