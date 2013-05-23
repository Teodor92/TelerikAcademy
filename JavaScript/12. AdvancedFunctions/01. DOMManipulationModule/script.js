var domModule = (function () {
    var elementsBuffer = [];
    var MAX_BUFFER_SIZE = 100;

    function appendChild(child, parentSelector) {
        var element = getElement(parentSelector);
        element.appendChild(child);
    }

    function removeChild(parentSelector, childSelector) {
        var parentElement = getElement(parentSelector);
        var childElements = getElements(parentSelector + ' ' + childSelector);

        for (var i = 0; i < childElements.length; i++) {
            parentElement.removeChild(childElements[i]);
        }
    }

    function addHandler(selector, eventType, eventHandler) {
        var elements = getElements(selector);

        for (var i = 0; i < elements.length; i++) {
            if (elements[i].addEventListener) {
                elements[i].addEventListener(eventType, eventHandler, false);
            } else {
                elements[i].attachEvent('on' + eventType, eventHandler);
            }
            
        }
    }

    function appendToBuffer(selector, element) {
        if (!elementsBuffer[selector]) {
            elementsBuffer[selector] = document.createDocumentFragment();
        }

        elementsBuffer[selector].appendChild(element);

        if (elementsBuffer[selector].childNodes.length === MAX_BUFFER_SIZE) {
            var parentElement = getElement(selector);
            parentElement.appendChild(elementsBuffer[selector]);
            elementsBuffer[selector] = null;
        }
    }

    function getElement(selector) {
        var element = document.querySelector(selector);
        return element;
    }

    function getElements(selector) {
        var elements = document.querySelectorAll(selector);
        return elements;
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        appendToBuffer: appendToBuffer,
        getElement: getElement
    };
}());

// tests 
var testDiv = document.createElement('div');
testDiv.style.backgroundColor = '#F00';
testDiv.innerHTML += 'AppendTest';
domModule.appendChild(testDiv, 'body');

var buttonTest = document.createElement('button');
buttonTest.innerHTML += 'Click me!';
domModule.appendChild(buttonTest, 'body');

domModule.addHandler('button', 'click', function () { alert('Clicked'); });

domModule.removeChild('#remove-test', 'li');

