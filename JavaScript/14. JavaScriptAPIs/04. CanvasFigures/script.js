(function () {
    (function drawHead() {

        var canvas = document.getElementById("headCanvas");
        var ctx = canvas.getContext("2d");

        ctx.strokeStyle = "#1F505A";
        ctx.fillStyle = "#90CAD7";
        ctx.lineWidth = 2;
        // head
        drawElipse(ctx, 80, 145, 45, 0, 2 * Math.PI, false, 1, 0.90);

        // eyes
        drawElipse(ctx, 55, 180, 10, 0, 2 * Math.PI, false, 1, 0.65);
        drawElipse(ctx, 87, 180, 10, 0, 2 * Math.PI, false, 1, 0.65);

        ctx.fillStyle = "#1F505A";
        drawElipse(ctx, 88, 117, 5.5, 0, 2 * Math.PI, false, 0.60, 1);
        drawElipse(ctx, 142, 117, 5.5, 0, 2 * Math.PI, false, 0.60, 1);

        ctx.fillStyle = "#90CAD7";

        // nose
        ctx.moveTo(70, 118);
        ctx.lineTo(60, 138);
        ctx.moveTo(70, 132);
        ctx.lineTo(60, 138);
        ctx.stroke();

        // mouth
        ctx.save();
        rotateFromPoint(ctx, 20, 495, 0.15);
        ctx.scale(1, 0.30);
        ctx.beginPath();
        ctx.arc(20, 495, 20, 0, 2 * Math.PI, false);
        ctx.stroke();
        ctx.restore();

        // hat
        ctx.strokeStyle = "#25221F";
        ctx.fillStyle = "#396693";
        drawElipse(ctx, 80, 360, 50, 0, 2 * Math.PI, false, 1, 0.25);
        drawRectangle(ctx, 50, 20, 60, 60);
        drawElipse(ctx, 80, 200, 30, 0, 2 * Math.PI / 2, false, 1, 0.40);
        ctx.fillRect(50, 20, 60, 60);
        drawElipse(ctx, 80, 50, 30, 0, 2 * Math.PI, false, 1, 0.40);


    })();

    (function drawBycicle() {
        var canvas = document.getElementById("cycleCanvas");
        var ctx = canvas.getContext("2d");

        ctx.strokeStyle = "#1F505A";
        ctx.fillStyle = "#90CAD7";
        ctx.lineWidth = 2;

        // cycles
        drawElipse(ctx, 80, 140, 45, 0, 2 * Math.PI, false, 1, 1);
        drawElipse(ctx, 260, 140, 45, 0, 2 * Math.PI, false, 1, 1);

        // steer
        ctx.moveTo(260, 140);
        ctx.lineTo(240, 40);
        ctx.moveTo(200, 50);
        ctx.lineTo(240, 40);
        ctx.moveTo(275, 10);
        ctx.lineTo(240, 40);
        ctx.stroke();

        // paddeles
        ctx.beginPath();
        ctx.arc(160, 140, 15, 0, 2 * Math.PI, false);
        ctx.stroke();
        ctx.moveTo(150, 130);
        ctx.lineTo(138, 118);
        ctx.moveTo(170, 150);
        ctx.lineTo(182, 162);
        ctx.stroke();

        // seet
        ctx.moveTo(160, 140);
        ctx.lineTo(120, 50);
        ctx.moveTo(100, 50);
        ctx.lineTo(140, 50);
        ctx.stroke();

        // frame
        ctx.moveTo(160, 140);
        ctx.lineTo(80, 140);
        ctx.moveTo(130, 70);
        ctx.lineTo(80, 140);
        ctx.moveTo(245, 70);
        ctx.lineTo(130, 70);
        ctx.moveTo(245, 70);
        ctx.lineTo(160, 140);
        ctx.stroke();

    })();

    (function drawHouse() {

        var canvas = document.getElementById("houseCanvas");
        var ctx = canvas.getContext("2d");

        ctx.strokeStyle = "#000";
        ctx.fillStyle = "#975B5B";
        ctx.lineWidth = 3;

        //roof
        ctx.save();
        rotateFromPoint(ctx, 150, 0, Math.PI / 4);
        drawRectangle(ctx, 150, 0, 196, 196);
        ctx.restore();

        // chimny
        drawRectangle(ctx, 210, 30, 32, 85); ctx.beginPath();
        ctx.fillRect(211, 30, 30, 90);
        drawElipse(ctx, 226, 75, 16, 0, 2 * Math.PI, false, 1, 0.4);

        // house
        drawRectangle(ctx, 10, 141, 280, 210);

        // door
        drawRectangle(ctx, 40, 275, 80, 76);

        drawElipse(ctx, 80, 550, 40, 0, 2 * Math.PI / 2, true, 1, 0.5);
        ctx.save();
        ctx.scale(1, 0.5);
        ctx.beginPath();
        ctx.arc(80, 555, 38.5, 0, 2 * Math.PI);
        ctx.fill();
        ctx.restore();
        ctx.beginPath();
        ctx.moveTo(80, 351);
        ctx.lineTo(80, 254);
        ctx.stroke();

        drawElipse(ctx, 65, 323, 5, 0, 2 * Math.PI, true, 1, 1);
        drawElipse(ctx, 95, 323, 5, 0, 2 * Math.PI, true, 1, 1);

        // windows
        ctx.strokeStyle = "#975B5B";
        ctx.fillStyle = "#000";
        drawRectangle(ctx, 30, 165, 50, 35); ctx.beginPath();
        drawRectangle(ctx, 82, 165, 50, 35); ctx.beginPath();
        drawRectangle(ctx, 168, 165, 50, 35); ctx.beginPath();
        drawRectangle(ctx, 220, 165, 50, 35); ctx.beginPath();
        drawRectangle(ctx, 30, 202, 50, 35); ctx.beginPath();
        drawRectangle(ctx, 82, 202, 50, 35); ctx.beginPath();
        drawRectangle(ctx, 168, 202, 50, 35); ctx.beginPath();
        drawRectangle(ctx, 220, 202, 50, 35); ctx.beginPath();

        // bottom window
        drawRectangle(ctx, 168, 260, 50, 35); ctx.beginPath();
        drawRectangle(ctx, 220, 260, 50, 35); ctx.beginPath();
        drawRectangle(ctx, 168, 297, 50, 35); ctx.beginPath();
        drawRectangle(ctx, 220, 297, 50, 35); ctx.beginPath();

    })();
}());



function drawElipse(ctx, x, y, radius, start, end, clockwise, scaleX, scaleY) {
    ctx.save();
    ctx.scale(scaleX, scaleY);
    ctx.beginPath();
    ctx.arc(x, y, radius, start, end, clockwise);
    ctx.fill();
    ctx.stroke();
    ctx.restore();
}
function drawRectangle(ctx, x, y, xLen, yLen) {
    ctx.beginPath();
    ctx.fillRect(x, y, xLen, yLen);
    ctx.strokeRect(x, y, xLen, yLen);
}
function rotateFromPoint(ctx, x, y, r) {
    ctx.translate(x, y);
    ctx.rotate(r);
    ctx.translate(-x, -y);
};