var movingShapes = (function () {

    function add(shape) {
        if (shape === 'rect') {
            var rectStage = document.getElementById('rect-stage');
            var rectDiv = createDiv();
            rectDiv.className = 'rect';

            rectStage.appendChild(rectDiv);

            animateRectangle(rectDiv);

        } else if (shape === 'ellipse') {
            var circleStage = document.getElementById('circle-stage');
            var circleDiv = createDiv();
            circleDiv.style.borderRadius = '50%';
            circleDiv.className = 'circle';

            circleStage.appendChild(circleDiv);

            animateCircle(circleDiv);
        }
    }

    // animation funcs
    window.requestAnimationFrame = (function () {
        return window.requestAnimationFrame
            || window.webkitRequestAnimationFrame
            || window.mozRequestAnimationFrame
            || function (a) {
                window.setTimeout(a, 1E3 / 60);
            };
    })();

    function animateCircle(element) {
        var angle = 0;
        var increase = 1;
        var fps = 5;

        (function draw() {
            setTimeout(function () {
                window.requestAnimationFrame(draw);

                x = 100 * Math.cos(angle) + 200;
                y = 100 * Math.sin(angle) + 100;
                element.style.left = x + "px";
                element.style.top = y + "px";

                angle += increase;

                angle += 0.1;
                angle %= (2 * Math.PI);
            }, 1000 / fps);
        })();
    }

    function animateRectangle(element) {
        var top = 0;
        var left = 0;

        var fps = 100;

        (function draw() {
            setTimeout(function () {
                window.requestAnimationFrame(draw);

                if (top <= 200 && left === 0) {
                    top++;
                } else if (left <= 200 && top > 199) {
                    left++;
                } else if (left > 199 && top >= 0) {
                    top--;
                } else if (top < 1 && left >= 0) {
                    left--;
                }

                element.style.top = top + "px";
                element.style.left = left + "px";
            }, 1000 / fps);
        })();
    }

    // helper funcs
    function createDiv() {
        // consts
        var DIV_WIDTH = '20px';
        var DIV_HEIGHT = '20px';

        // main logic
        var div = document.createElement('div');
        var style = div.style;
        style.width = DIV_WIDTH;
        style.height = DIV_HEIGHT;
        style.backgroundColor = getRandomRGBColor();
        style.fontSize = getRandomRGBColor();
        style.borderStyle = 'solid';
        style.borderColor = getRandomRGBColor();
        style.borderWidth = getRandomInt(5, 10) + 'px';
        style.position = 'absolute';

        return div;
    }

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

    // methods expose 
    return {
        add: add
    };
}());

