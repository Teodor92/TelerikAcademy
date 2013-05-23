function createRandomDiv() {
    var randomDiv = document.createElement('div'),
        style = randomDiv.style;
    style.width = getRandomInt(20, 100) + 'px';
    style.height = getRandomInt(20, 100) + 'px';

    style.backgroundColor = getRandomRGBColor();
    style.color = getRandomRGBColor();

    style.position = 'absolute';
    style.top = getRandomInt(0, 400) + 'px';
    style.left = getRandomInt(0, 400) + 'px';

    style.borderRadius = getRandomInt(0, 20) + 'px';
    style.borderStyle = 'solid';
    style.borderColor = getRandomRGBColor();
    style.borderWidth = getRandomInt(10, 20) + 'px';

    randomDiv.innerHTML = '<strong>Div<strong>';
    return randomDiv;
}

function getNumberOfDivs() {
    var numOfDivs = parseInt(document.getElementById('num-of-divs').value);
    if (!numOfDivs || isNaN(numOfDivs)) {
        alert('Wrong input! Try again!');
    }
    return numOfDivs;
}

function appendDivsToDOM() {
    var dFrag = document.createDocumentFragment(),
        numOfDivs = getNumberOfDivs(),
        canvas = document.getElementById('wrapper'),
        i = 0;

    for (i = 0; i < numOfDivs; i++) {
        dFrag.appendChild(createRandomDiv());
    }

    canvas.innerHTML = '';
    canvas.appendChild(dFrag);
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