if (!document.querySelector) {
    document.querySelector = function (selector) {
        return Sizzle(selector)[0];
    };
}

if (!document.querySelectorAll) {
    document.querySelectorAll = function (selector) {
        return Sizzle(selector);
    };
}

// some test
var testWrapper = document.getElementById('test-wrapper');

var idTest = document.querySelector('#id-select-test');

testWrapper.innerHTML += idTest;

var classSelectTest = document.querySelectorAll('.class-select-test');
for (var i = 0; i < classSelectTest.length; i++) {
    testWrapper.innerHTML += classSelectTest[i];
}