/* TODO: Reset button and some styles */

// helper functions
function addHandler(element, eventType, eventHandler) {
    if (element.addEventListener) {
        element.addEventListener(eventType, eventHandler, false);
    } else {
        // IE support
        element.attachEvent("on" + eventType, eventHandler);
    }
}

function getRandomInt(min, max) {
    var randomValue = Math.floor(Math.random() * (max - min + 1)) + min;
    return randomValue;
}



(function () {
    
    /* DRAG AND DROP LOGIC */

    var trashBin = document.getElementById('trash-bin');
    var trash = document.getElementsByClassName('trash');
    var trashCount = trash.length;
    console.log(trashBin);
    console.log(trash);

    // generate random positions for the trash
    for (var i = 0; i < trashCount; i++) {
        trash[i].style.position = "absolute";
        trash[i].style.top = getRandomInt(0, 300) + "px";
        trash[i].style.left = getRandomInt(300, 900) + "px";
    }


    // event handlers
    function trashBinDragover(ev) {
        trashBin.setAttribute('src', 'images/trash-bin-open.png');
        ev.preventDefault();
    }

    function trashBinDragout(ev) {
        trashBin.setAttribute('src', 'images/trash-bin-closed.png');
        ev.preventDefault();

    }

    function trashDragStart(ev) {
        ev.dataTransfer.setData("dragged-id", ev.target.id);
    }

    function trashDrop(ev) {
        var data = ev.dataTransfer.getData("dragged-id");
        document.body.removeChild(document.getElementById(data));
        trashBin.setAttribute('src', 'images/trash-bin-closed.png');
        ev.preventDefault();
    }


    // register events
    addHandler(trashBin, 'dragover', trashBinDragover);
    addHandler(trashBin, 'dragleave', trashBinDragout);
    addHandler(trashBin, 'drop', trashDrop);

    for (var i = 0; i < trashCount; i++) {
        addHandler(trash[i], 'dragstart', trashDragStart);
    }

    /* HIGHSCORE LOGIC */

    var nameEnterBox = document.getElementById('name-enter-box');
    var saveButton = document.getElementById('save-btn');
    var highScoreBox = document.getElementById("highscore-box");
    var startTime = new Date().getTime();
    var endTime;

    function checkIfCleared() {
        if (trash.length == 0) {
            endTime = new Date().getTime();
            nameEnterBox.style.display = 'block';
        } else {
            nameEnterBox.style.display = 'none';
        }
    }

    function savePlayerScore() {
        var playerName = document.getElementById('player-name').value;
        var score = (startTime - endTime) / 1000;

        localStorage.setItem(playerName, score);
        printResults();
    }

    function printResults() {
        var highScore = [];
        for (var i = 0; i < localStorage.length; i++) {

            highScore[i] = localStorage.key(i);
        }
        highScore.sort(function (a, b) { return a - b });

        highScoreBox.innerHTML = "";

        for (var j = 0; j < 5; j++) {
            var key = highScore[j];
            var value = parseFloat(localStorage.getItem(key));

            if (key) {
                highScoreBox.innerHTML += key + " - ";
                highScoreBox.innerHTML += value + "<br/>";
            }
        }
    }

    addHandler(saveButton, 'click', savePlayerScore);
    addHandler(trashBin, 'drop', checkIfCleared);
}())
