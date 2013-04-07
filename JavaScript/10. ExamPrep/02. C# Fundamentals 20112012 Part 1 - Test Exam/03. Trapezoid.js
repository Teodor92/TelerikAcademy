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

    // top
    outStr += newString(".", n);
    outStr += newString("*", n);
    outStr += "\n";

    //middle
    for (i = 0; i < n - 1; i++)
    {
        //first half
        outStr += newString(".", n - 1 - i);
        outStr += newString("*", 1);
        outStr += newString(".", i);
        //second half
        outStr += newString(".", n - 1);
        outStr += newString("*", 1);
        outStr += "\n";
    }
    //bottom
    outStr += newString("*", 2 * n);

    return outStr;
}