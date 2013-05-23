var treeView = function () {
    var tree = document.getElementById('tree');
    var uls = tree.getElementsByTagName('ul');
    var lis = tree.getElementsByTagName('li');

    function hideSubItems() {
        for (var i = 0; i < uls.length; i++) {

            uls[i].style.display = 'none';
        }
    }

    function onElementClick(event) {
        var item = event.target;
        if (item.childElementCount != 0) {
            if (item.firstElementChild.style.display == "block") {
                item.firstElementChild.style.display = "none";
            }
            else {
                item.firstElementChild.style.display = "block";
            }
        }
    }

    for (var i = 0; i < lis.length; i++) {
        lis[i].addEventListener('click', onElementClick, false);
    }

    HTMLElement.prototype.addNode = function () {
        var ulCollection = this.getElementsByTagName('ul');
        var liElement;

        if (ulCollection.length > 0) {
            liElement = document.createElement('li');
            ulCollection[0].appendChild(liElement);
            return liElement;
        } else {
            var ulElement = document.createElement('ul');
            liElement = document.createElement('li');
            ulElement.appendChild(liElement);
            this.appendChild(ulElement);
            return liElement;
        }
    }

    return {
        hideSubs: hideSubItems,
    };
}();

treeView.hideSubs();
var tree = document.getElementById('tree');
var test = tree.addNode();
test.innerHTML = 'test';
var test2 = test.addNode();
test2.innerHTML = 'test';
console.log(tree.firstChild);
console.log(tree.firstElementChild);