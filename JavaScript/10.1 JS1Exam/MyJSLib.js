function newString(char, times) {
    var outString = "";

    for (var i = 0; i < times; i++) {
        outString += char;
    }

    return outString;
}

function newArr(length) {
    var arr = new Array(length);
    for (var i = 0; i < length; i++) {
        arr[i] = 0;
    }
    return arr;
}

function newMultiArray(rows, cols) {
    var matrix = [];
    var i = 0;
    var j = 0;

    for (i = 0; i < rows; i++) {

        matrix[i] = new Array(rows);

        for (j = 0; j < cols; j++) {
            matrix[i][j] = 0;
        }
    }

    return matrix;
}

function reverseStr(str) {
    str = String(str);
    var outStr = "";
    for (var i = str.length - 1; i >= 0; i--) {
        outStr += str[i];
    }

    return outStr;
}

function formatString() {
    var output = arguments[0];

    for (var i = 1; i < arguments.length; i++)
        output = output.replace(new RegExp('\\{' + (i - 1) + '\\}', "gi"), arguments[i]);

    return output;
}