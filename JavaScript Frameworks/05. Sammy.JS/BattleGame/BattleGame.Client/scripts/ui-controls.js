/// <reference path="libs/jquery-2.0.2.js" />
/// <reference path="libs/class.js" />
/// <reference path="libs/require.js" />


//var BattleGame = BattleGame || {};

//BattleGame.uiControls = (function () {

define(["oopClass"], function (oopClass) {

    function BuildNavMenu() {
        var html =
            '<nav>' +
            '<ul id="navigation">' +
            '<li>' +
                '<a href="#/">Home</a>' +
            '</li>' +
            '<li>' +
                '<a href="#/active">Active</a>' +
            '</li>' +
            '<li>' +
                '<a href="#/open">Open</a>' +
            '</li>' +
            '</ul>' +
            '</nav>';

        return html;
    }

    var BaseUIControl = oopClass.create({
        build: function () {
            var html =
                '<button id="btn-logout">Logout</button><br/></div>' +
                '<div id="create-game-holder">' +
                '<h2>Create game</h2>' +
                    '<label for="tb-create-title">Title:</label><input type="text" id="tb-create-title" />' +
                    '<label for="tb-create-pass">Password:</label><input type="text" id="tb-create-pass" /></br>' +
                    '<button id="btn-create-game">Create</button>' +
                '</div></div>' +
                '<div id="game-state-wrapper">' +
                '</div>' +
                '<div id="join-form">' +
                '</div>' +
                '<div id="messages-holder">' +
                '</div>' +
                '<div id="score-box">' +
                '</div>' +
                '<div id="error-console">' +
                '</div>';

            return html;
        }
    });

    var LoginForm = oopClass.create({
        build: function () {
            var html = '<div id="login-form-holder">' +
					'<div id="login-form">' +
						'<label for="tb-login-username">Username: </label>' +
						'<input type="text" id="tb-login-username"><br />' +
						'<label for="tb-login-password">Password: </label>' +
						'<input type="text" id="tb-login-password"><br />' +
						'<button id="btn-login" class="button">Login</button>' +
					'</div>' +
					'<div id="register-form" style="display: none">' +
						'<label for="tb-register-username">Username: </label>' +
						'<input type="text" id="tb-register-username"><br />' +
						'<label for="tb-register-nickname">Nickname: </label>' +
						'<input type="text" id="tb-register-nickname"><br />' +
						'<label for="tb-register-password">Password: </label>' +
						'<input type="text" id="tb-register-password"><br />' +
						'<button id="btn-register" class="button">Register</button>' +
					'</div>' +
					'<a href="#" id="btn-show-register" class="button">Register</a>' +
            '</div>';

            return html;
        }
    });

    var OpenGamesListControl = oopClass.create({

        build: function (listData) {

            var listHtml

            if (listData.length === 0) {

                listHtml = '<p>No open games</p>'

            } else {
                listHtml = '<ul id="open-games-list">'

                for (var i = 0; i < listData.length; i++) {
                    listHtml +=
                        '<li data-game-id="' + listData[i].id + '">' +
                            '<a href="#" >' +
                                $("<div />").html(listData[i].title).text() +
                            '</a>' +
                            '<span> by ' +
                                listData[i].creator +
                            '</span>' +
                        '</li>';
                }

                listHtml += '</ul>';

                return listHtml;
            }
        }

    });

    var ActiveGamesListControl = oopClass.create({

        build: function (listData) {
            var listHtml;

            var gamesList = Array.prototype.slice.call(listData, 0);
            gamesList.sort(function (g1, g2) {
                if (g1.status == g2.status) {
                    return g1.title > g2.title;
                }
                else {
                    if (g1.status == "in-progress") {
                        return -1;
                    }
                }
                return 1;
            });

            if (gamesList.length === 0) {

                listHtml = '<p>No active games</p>'
                return listHtml;

            } else {
                listHtml = '<ul>'

                for (var i = 0; i < gamesList.length; i++) {
                    listHtml +=
                        '<li data-game-id="' + gamesList[i].id + '" data-creator="' + gamesList[i].creator + '">' +
                            '<a href="#" class="' + gamesList[i].status + '">' +
                                $("<div />").html(gamesList[i].title).text() +
                            '</a>' +
                            '<span> by ' +
                                gamesList[i].creator +
                            '</span>' +
                        '</li>';
                }

                listHtml += '</ul>';

                return listHtml;
            }


        }
    });

    var GameFieldControl = oopClass.create({
        build: function (data, unitMatrix) {

            // init params
            var title = data.title;
            var firstPlayer = data.blue.nickname;
            var secondPlayer = data.red.nickname;

            // html generation
            var html =
                ' <div id="game-holder"> \
                <table> \
                    <thead> \
                        <tr> \
                            <th colspan="9">' + title + '</th> \
                        </tr> \
                        <tr> \
                            <th colspan="9">' + firstPlayer + ' VS ' + secondPlayer + '</th> \
                        </tr> \
                    </thead> \
                    <tbody> \
            </div>'

            for (var i = 0; i < 9; i++) {

                html += '<tr>';

                for (var j = 0; j < 9; j++) {
                    if (unitMatrix[i][j]) {
                        html +=
                            '<td data-unit-id="' + unitMatrix[i][j].id + '" data-x="' + i + '" data-y="' + j + '" class="' + unitMatrix[i][j].collor + ' unit">' +
                                unitMatrix[i][j].type + (unitMatrix[i][j].mode == "attack" ? '<button class="defend-btn">D</button>' : '') +
                            '</td>';
                    } else {
                        html += '<td data-x="' + i + '" data-y="' + j + '" class="empty"></td>';
                    }
                }

                html += '</tr>';
            }

            html += '</tbody></table>';

            return html;

        }
    });

    var MessageControl = oopClass.create({
        build: function (data) {
            var html = '';

            for (var i = data.length - 1; i >= 0; i--) {
                html += '<p>' + data[i].text + '</p>';
            }

            return html;
        }
    });

    var ScoreBoardControl = oopClass.create({
        build: function (data) {
            var listHtml = '<ol>'

            var gamesList = Array.prototype.slice.call(data, 0);
            gamesList.sort(function (g1, g2) {
                if (g1.score > g2.score) {
                    return -1;
                }
                else if (g1.score = g2.score) {
                    return g1.nickname > g2.nickname;
                }
                else {
                    return 1;
                }
            });

            for (var i = 0; i < gamesList.length; i++) {
                listHtml += '<li>Nickname: ' + gamesList[i].nickname + ' | Score: ' + gamesList[i].score + '</li>'
            }

            listHtml += '</ol>'

            return listHtml;
        }
    });

    return {
        LoginForm: LoginForm,

        BaseUIControl: function () {
            return new BaseUIControl();
        },

        OpenGamesListControl: function () {
            return new OpenGamesListControl();
        },

        ActiveGamesListControl: function () {
            return new ActiveGamesListControl();
        },

        GameFieldControl: function () {
            return new GameFieldControl();
        },

        MessageControl: function () {
            return new MessageControl();
        },

        ScoreBoardControl: function () {
            return new ScoreBoardControl();
        },

        buildNamvMenu: BuildNavMenu
    };
});