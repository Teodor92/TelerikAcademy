function isPossoble(vally, nextPostion) {
    if (nextPostion > vally.length - 1 || nextPostion < 0) {
        return false;
    }
    else {
        return true;
    }
}

function patternProc(vally, pattern) {
    var currentAmount = 0;
    var viseted = [];
    var i = 0;
    var isStoped = false;
    for (var i = 0; i < vally.length; i++) {
        viseted[i] = false;
    }

    currentAmount = vally[0];
    viseted[0] = true;
    var nextDigit = 0;

    while (!isStoped) {
        for (i = 0; i < pattern.length; i++) {
            nextDigit = nextDigit + pattern[i];
            if (!isPossoble(vally, nextDigit) || viseted[nextDigit] == true) {
                isStoped = true;
                break;
            }
            currentAmount = currentAmount + vally[nextDigit];
            viseted[nextDigit] = true;
        }
    }

    return currentAmount;
}

function Solve(args) {
    var vallyStr = args[0].split(",");
    var vally = [];
    var i = 0;
    var j = 0;

    for (i = 0; i < vallyStr.length; i++) {
        vally.push(parseInt(vallyStr[i]));
    }

    var numOfPatterns = parseInt(args[1]);
    var maxNumber = -9999999999;

    for (i = 0; i < numOfPatterns; i++) {
        var index = i + 2;
        var patternStr = args[index].split(',');
        var pattern = [];
        for (j = 0; j < patternStr.Length; j++) {
            pattern.push(parseInt(patternStr[j]));
        }

        maxNumber = Math.max(patternProc(vally, pattern), maxNumber);
    }


    return maxNumber;
}