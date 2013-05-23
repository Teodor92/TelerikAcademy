var liTags = document.getElementsByTagName('li');

var i = 0;

for (i = 0; i < liTags.length; i++) {
    liTags[i].addEventListener('click', revealSubList);
}

function revealSubList(event) {
    if (typeof this.getElementsByTagName('ul')[0] == 'undefined') {
        return 0;
    }

    var ulElements = this.getElementsByTagName('ul');

    if (this === event.target &&
    ulElements[0].style.display == 'block') {
        ulElements[0].style.display = 'none';
    }
    else {
        ulElements[0].style.display = 'block';
    }
}