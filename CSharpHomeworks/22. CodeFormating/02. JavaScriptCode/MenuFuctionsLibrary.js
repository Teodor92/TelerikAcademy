; (function () {
    "use strict";
    var aplicationName = navigator.appName,
        addScroll = false,
        theLayer,
        postionX = 0,
        postionY = 0;

    if ((navigator.userAgent.indexOf('MSIE 5') > 0) ||
        navigator.userAgent.indexOf('MSIE 6') > 0) {
        addScroll = true;
    }

    document.onmousemove = mouseMove;

    if (aplicationName === "Netscape") {
        document.captureEvents(Event.MOUSEMOVE);
    }

    function mouseMove(evn) {
        if (aplicationName === "Netscape") {
            postionX = evn.pageX - 5;
            postionY = evn.pageY;
        } else {
            postionX = event.x - 5;
            postionY = event.y;
        }

        if (aplicationName === "Netscape") {
            if (document.layers.ToolTip.visibility === 'show') {
                PopTip();
            }
        } else {
            if (document.all.ToolTip.style.visibility === 'visible') {
                PopTip();
            }
        }
    }
    function PopTip() {
        if (aplicationName === "Netscape") {
            theLayer = document.layers.ToolTip;
            if ((postionX + 120) > window.innerWidth) {
                postionX = window.innerWidth - 150;
            }

            theLayer.left = postionX + 10;
            theLayer.top = postionY + 15; 
            theLayer.visibility = 'show';
        } else {
            theLayer = document.all.ToolTip;

            if (theLayer) {
                postionX = event.x - 5;
                postionY = event.y;

                if (addScroll) {
                    postionX = postionX + document.body.scrollLeft;
                    postionY = postionY + document.body.scrollTop;
                }

                if ((postionX + 120) > document.body.clientWidth) {
                    postionX = postionX - 150;
                }

                theLayer.style.pixelLeft = postionX + 10;
                theLayer.style.pixelTop = postionY + 15;
                theLayer.style.visibility = 'visible';
            }
        }
    }

    function HideTip() {
        if (aplicationName === "Netscape") {
            document.layers.ToolTip.visibility = 'hide';
        } else {
            document.all.ToolTip.style.visibility = 'hidden';
        }
    }

    function HideMenu1() {
        if (aplicationName === "Netscape") {
            document.layers.menu1.visibility = 'hide';
        } else {
            document.all.menu1.style.visibility = 'hidden';
        }
    }

    function ShowMenu1() {
        if (aplicationName === "Netscape") {
            theLayer = document.layers.menu1;
            theLayer.visibility = 'show';
        } else {
            theLayer = document.all.menu1;
            theLayer.style.visibility = 'visible';
        }
    }

    function HideMenu2() {
        if (aplicationName === "Netscape") {
            document.layers.menu2.visibility = 'hide';
        } else {
            document.all.menu2.style.visibility = 'hidden';
        }
    }

    function ShowMenu2() {
        if (aplicationName === "Netscape") {
            theLayer = document.layers.menu2;
            theLayer.visibility = 'show';
        } else {
            theLayer = document.all.menu2;
            theLayer.style.visibility = 'visible';
        }
    }

    // UNTOUCHABLE COMMENT! :)
    // fostata
    // UNTOUCHABLE COMMENT! :)

})();