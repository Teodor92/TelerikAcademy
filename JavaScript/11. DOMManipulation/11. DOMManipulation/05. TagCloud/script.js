function getTags() {
    var tags = document.getElementById('tags').value;
    var splitedTags = [];
    splitedTags = tags.split(' ');

    var cloudsArray = [];

    for (var i = 0; i < splitedTags.length; i++) {
        if (cloudsArray.containsKey(splitedTags[i])) {
            cloudsArray[splitedTags[i]]++;
        }
        else {
            cloudsArray[splitedTags[i]] = 1;
        }
    }

    return cloudsArray;
}

function generateCloud() {
    var fontSizes = getFontSizes();
    var cloudWrapper = document.getElementById('cloud-wrapper');
    var tags = getTags();

    cloudWrapper.innerHTML = '';

    var buffer = generateTagCloud(tags, fontSizes.minSize, fontSizes.maxSize);

    cloudWrapper.appendChild(buffer);
}

function generateTagCloud(tagsCountObj, minSize, maxSize) {
    var i;
    var currentTagCount = 0;
    var newSpan;
    var maxTagCount = getMostCommonTag(tagsCountObj);
    var fontSizeDifference = maxSize - minSize;
    var buffer = document.createDocumentFragment();
    var size = 0;
    var verticalAlign;
    var style;

    for (i in tagsCountObj) {
        newSpan = document.createElement("span");
        newSpan.innerHTML = " " + i + " ";
        style = newSpan.style;

        if (!isNaN(tagsCountObj[i])) {
            currentTagCount = tagsCountObj[i];
        } else {
            continue;
        }

        size = minSize + parseInt(currentTagCount / maxTagCount * fontSizeDifference);
        verticalAlign = minSize + (Math.random() * fontSizeDifference);

        style.fontSize = size + "px";
        style.verticalAlign = verticalAlign + "px";
        style.color = getRandomRGBColor();

        buffer.appendChild(newSpan);
    }

    return buffer;
}

function getMostCommonTag(cloudArray) {
    var max = Number.NEGATIVE_INFINITY;
    var i;
    var localMax;
    for (i in cloudArray) {
        localMax = parseInt(cloudArray[i]);
        if (localMax > max) {
            max = localMax;
        }
    }

    return max;
}

function createLink(size) {
    var link = document.createElement('div');
    var style = link.style;

    style.color = getRandomRGBColor();
    style.fontSize = size;

    return link;
}

Array.prototype.containsKey = function (key) {
    for (var i in this) {
        if (i === key) {
            return true;
        }
    }

    return false;
}

function getFontSizes() {
    var max = parseInt(document.getElementById('max-font-size').value);
    var min = parseInt(document.getElementById('min-font-size').value);

    if (!max || !min || isNaN(max) || isNaN(min)) {
        alert('Ivalid input! Try again!');
    }
    else {
        var fontSizes = {
            maxSize: max,
            minSize: min
        };

        return fontSizes;
    }
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