function addHandler(element, eventType, eventHandler) {
    if (element.addEventListener) {
        element.addEventListener(eventType, eventHandler, false);
    } else {
        element.attachEvent("on" + eventType, eventHandler);
    }
}

function onMenuClick(event) {
    if (typeof this.getElementsByTagName('ul')[0] === 'undefined') {
        return;
    }

    if (this === event.target &&
        this.getElementsByTagName('ul')[0].style.display === 'block'
        ) {

        this.getElementsByTagName('ul')[0].style.display = 'none';
    } else {
        this.getElementsByTagName('ul')[0].style.display = 'block';
    }
}

HTMLElement.prototype.addNode = function () {
    var ulCollection = this.getElementsByTagName('ul');
    var liElement;

    if (ulCollection.length > 0) {
        liElement = document.createElement('li');
        addHandler(liElement, 'click', onMenuClick);
        ulCollection[0].appendChild(liElement);
        return liElement;
    } else {
        var ulElement = document.createElement('ul');
        liElement = document.createElement('li');
        addHandler(liElement, 'click', onMenuClick);
        ulElement.appendChild(liElement);
        this.appendChild(ulElement);
        return liElement;
    }
}

HTMLElement.prototype.content = function (text) {
    var anchorElement = document.createElement('a');
    anchorElement.href = '#';
    anchorElement.innerHTML = text;
    addHandler(anchorElement, 'click', onMenuClick);
    this.appendChild(anchorElement);
}

var controls = (function () {

    function treeView(queryString) {
        var wrapper;
        var splitedString;

        // wrapper
        if (queryString.indexOf('.') != -1) {
            splitedString = queryString.split('.');
            wrapper = document.createElement(splitedString[0]);
            wrapper.className = splitedString[1];
        } else if (queryString.indexOf('#') != -1) {
            splitedString = queryString.split('#');
            wrapper = document.createElement(splitedString[0]);
            wrapper.id = splitedString[1];
        }
        else {
            wrapper = document.createElement(queryString);
        }

        document.body.appendChild(wrapper);

        return wrapper;
    }

    return {
        treeView: treeView
    };
}());

var treeView = controls.treeView("div.tree-view");
var jsnode = treeView.addNode();
jsnode.content("JavaScript");

var js1subnode = jsnode.addNode();
js1subnode.content("JavaScript - part 1");

var js2subnode = jsnode.addNode();
js2subnode.content("JavaScript - part 2");

var subNodeTest = js2subnode.addNode();
subNodeTest.content('Test 1');

var subNodeTest2 = js2subnode.addNode();
subNodeTest2.content('Test 2');

var jslibssubnode = jsnode.addNode();
jslibssubnode.content("JS Libraries");

var jsframeworksnode = jsnode.addNode();
jsframeworksnode.content("JS Frameworks and UI");

var webnode = treeView.addNode();
webnode.content("Web");