/// <reference path="Kendo/jquery.min.js" />
/// <reference path="jquery.signalR-2.0.0-rc1.js" />

var rooms = [];

$(document).ready(function () {

    $.connection.hub.start();

    var chat = $.connection.chat;

    $('#send-message').click(function () {

        var msg = $('#message').val();
        debugger;
        //chat.server.sendMessage(msg);
        chat.server.sendMessageToRoom(msg, rooms);
    });

    $("#join-room").click(function () {

        var room = $('#room').val();

        chat.server.joinRoom(room);
    });

    $('#send-message-to-room').click(function () {

        var msg = $('#room-message').val();

        chat.server.sendMessageToRoom(msg, rooms);
    });

    chat.client.addMessage = addMessage;
    chat.client.joinRoom = joinRoom;
});

function addMessage(message) {
    $('#chat-window').append('<div>' + message + '</div>');
}

function joinRoom(room) {
    rooms.push(room);
    $('#currentRooms').append('<div>' + room + '</div>');
}