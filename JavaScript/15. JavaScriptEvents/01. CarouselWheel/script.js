function addHandler(element, eventType, eventHandler) {
    if (element.addEventListener) {
        element.addEventListener(eventType, eventHandler, false);
    } else {
        // IE support
        element.attachEvent("on" + eventType, eventHandler);
    }
}

function onLoad() {
    var currentSlide = document.getElementById('slider-img');
    var imgDB = ['images/nature1.jpg', 'images/nature2.jpg', 'images/nature3.jpg', 'images/nature4.jpg'];
    var leftArrow = document.getElementById('left-arrow');
    var rightArrow = document.getElementById('right-arrow');
    var dbLength = imgDB.length;

    // event handlers
    function back() {
        var imgSrc = currentSlide.getAttribute('src');
        var currentIndex = imgDB.indexOf(imgSrc);
        if (currentIndex === 0) {
            currentIndex = dbLength;
        }

        currentSlide.setAttribute('src', imgDB[currentIndex - 1]);
    }

    function forward() {
        var imgSrc = currentSlide.getAttribute('src');
        var currentIndex = imgDB.indexOf(imgSrc);

        if (currentIndex === dbLength - 1) {
            currentIndex = -1;
        }

        currentSlide.setAttribute('src', imgDB[currentIndex + 1]);
    }

    setInterval(forward, 3000);

    // register events
    addHandler(leftArrow, 'click', back);
    addHandler(rightArrow, 'click', forward);
}