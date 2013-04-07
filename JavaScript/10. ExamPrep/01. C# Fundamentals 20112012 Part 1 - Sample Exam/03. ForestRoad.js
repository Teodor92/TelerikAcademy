function newString(char, times) {
    var outString = "";

    for (var i = 0; i < times; i++) {
        outString += char;
    }

    return outString;
}

function Solve(args) {
    var n = parseInt(args[0]);
    var outStr = "";
    var i = 0;
    //first part
    for (i = 0; i < n; i++) {
        outStr += newString(".", i);
        outStr += newString("*", 1);
        outStr += newString(".", n - 1 - i);
        outStr += "\n";
    }
    // second part
    for (i = 1; i < n; i++) {
        outStr += newString(".", n - 1 - i);
        outStr += newString("*", 1);
        outStr += newString(".", i);
        outStr += "\n";
    }

    return outStr;
}