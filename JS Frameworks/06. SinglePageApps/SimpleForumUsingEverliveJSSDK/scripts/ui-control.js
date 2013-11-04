/// <reference path="libs/oopClass.js" />
/// <reference path="libs/jquery-1.4.4.js" />
/// <reference path="libs/rsvp.js" />


var ui = (function ($) {
    function buildLoginPage(selector) {

        var promise = new RSVP.Promise(function (resolve, reject) {
            $('<nav></nav>').load("../content/login.html", function (result) {
                resolve(result);
            }, function (error) {
                reject(error);
            });
        });

        return promise;
    }

    function buildHomePage(selector) {
        return _buildNav().then(function (data) {
            $(selector).empty().append(data);
        });
    }

    function _buildNav() {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $('<nav></nav>').load("../content/nav-menu.html", function (data) {
                resolve(data);
            });
        });

        return promise;
    }

    var ListView = Class.create({
        init: function (itemsSource) {
            if (!(itemsSource instanceof Array)) {
                throw "The itemsSource of a ListView must be an array!";
            }
            this.itemsSource = itemsSource;
        },
        render: function (template) {
            var list = document.createElement("ul");
            for (var i = 0; i < this.itemsSource.length; i++) {
                var listItem = document.createElement("li");
                var item = this.itemsSource[i];
                listItem.innerHTML = template(item);
                list.appendChild(listItem);
            }
            return list.outerHTML;
        }
    });

    return {
        buildLogin: buildLoginPage,
        buildHome: buildHomePage,
        getListView: function (itemsSource) {
            return new ListView(itemsSource);
        }
    };
})(jQuery);