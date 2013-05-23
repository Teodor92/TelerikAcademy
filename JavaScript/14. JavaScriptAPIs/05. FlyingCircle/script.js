(function () {

    var ball = document.getElementById("ball");
    var box = document.getElementById("box");
    var directionTop = 1;
    var directionLeft = 1;
    var leftPos = 100;
    var topPos = 450;

    setInterval(function () {
        topPos += directionTop;
        leftPos += directionLeft;

        if (topPos == box.offsetHeight) {
            directionTop *= -1;
        }

        if (leftPos == box.offsetWidth) {
            directionLeft *= -1;
        }

        if (topPos == 10) {
            directionTop *= -1;
        }

        if (leftPos == 10) {
            directionLeft *= -1;
        }

        ball.style.left = leftPos + "px";
        ball.style.top = topPos + "px";
    }, 5);

}());