function getFontColor() {
    var fontColor = document.getElementById('font-color').value;
    return fontColor;
}

function getBackgroundColor() {
    var bgColor = document.getElementById('background-color').value;
    return bgColor;
}

function setTextarea() {
    var textarea = document.getElementById('textarea');
    textarea.style.color = getFontColor();
    textarea.style.backgroundColor = getBackgroundColor();
}