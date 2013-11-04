;(function onButtonClick(event, arguments) {
    var currentWinodw = window;
    var browserType = currentWinodw.navigator.appCodeName;
    var isMozzilla = false;

    if (browserType === "Mozilla") {
        isMozzilla = true;
    }

    if (isMozzilla) {
        alert("Yes");
    }
    else {
        alert("No");
    }
})();
