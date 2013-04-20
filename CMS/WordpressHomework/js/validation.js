// Number checker
function isNumber(n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}

// validation logic
function validateForm() {
    var firstNum = document.forms['myForm']['first_num'].value;
    var sign = document.forms['myForm']['sign'].value;
    var secondNum = document.forms['myForm']['second_num'].value;

    if (!firstNum) {
        alert("First number filed CAN'T be empty!");
        return false;
    }
    else if (!isNumber(firstNum)) {
        alert("First number filed input is not a vaild number!");
        return false;
    }

    if (!sign) {
        alert("Sign filed CAN'T be empty!");
        return false;
    }
    else if (
        sign !== "+" &&
        sign !== "-" && 
        sign !== "*" &&
        sign !== "/"
        ) {
        alert("Sign filed is NOT a valid sign!");
        return false;
    };

    if (!secondNum) {
        alert("Second number filed CAN'T be empty!");
        return false;
    }
    else if (!isNumber(secondNum)) {
        alert("Second filed input is not a vaild number!");
        return false;
    }
}