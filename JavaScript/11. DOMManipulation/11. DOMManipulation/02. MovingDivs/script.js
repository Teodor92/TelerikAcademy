function createRandomDiv() {
    var randomDiv = document.createElement('div'),
        style = randomDiv.style;

    style.backgroundColor = getRandomRGBColor();
    style.color = getRandomRGBColor();

    style.borderRadius = '50%';
    style.borderStyle = 'solid';
    style.borderColor = getRandomRGBColor();
    style.borderWidth = '5px';

    randomDiv.className = 'circle';

    document.body.appendChild(randomDiv);
}

for (var i = 0; i < 5; i++) {
    createRandomDiv();
}

window.requestAnimationFrame = function () {
    return window.requestAnimationFrame
        || window.webkitRequestAnimationFrame
        || window.mozRequestAnimationFrame
        || function (a) {
            window.setTimeout(a, 1E3 / 60)
        }
}();

function animateCircles() {
    var circles = document.querySelectorAll('.circle');
    var angle = 0;
    var increase = 1;
    var fps = 5;

    (function draw() {
        setTimeout(function () {
            window.requestAnimationFrame(draw);
            for (var i = 0; i < circles.length; i++) {
                x = 100 * Math.cos(angle) + 200;
                y = 100 * Math.sin(angle) + 100;
                circles[i].style.left = x + "px";
                circles[i].style.top = y + "px";

                angle += increase;
            }

            angle += 0.1;
            angle %= (2 * Math.PI);
        }, 1000 / fps);
    })();
}

function onStartShinyButtonClick(e) {
    if (!e) e = window.event;
    //document.getElementById("start-btn").disabled = true;
    //document.getElementById("stop-btn").disabled = false;
    animateCircles();

    if (e.preventDefault) {
        e.preventDefault();
    }
    return false;
}

// TODO: Stop animation
//function onStopShinyButtonClick(e) {
//    if (!e) e = window.event;

//    window.cancelAnimationFrame;
//    document.getElementById("start-btn").disabled = false;
//    document.getElementById("stop-btn").disabled = true;

//    if (e.preventDefault) {
//        e.preventDefault();
//    }
//    return false;
//}

function getRandomRGBColor() {
    var result = 'rgb(';
    result += getRandomInt(0, 255) + ',';
    result += getRandomInt(0, 255) + ',';
    result += getRandomInt(0, 255) + ')';

    return result;
}

function getRandomInt(min, max) {
    var randomValue = Math.floor(Math.random() * (max - min + 1)) + min;
    return randomValue;
}

//TODO: FPS get
//function getFps() {
//    var fps = document.getElementById('fps-value');
//    if (!fps || isNaN(fps)) {
//        alert('Invalid value! Try again');
//    }
//    else {
//        return parseInt(fps);
//    }
//}
