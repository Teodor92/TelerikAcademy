/// <reference path="libs/class.js" />
/// <reference path="libs/underscore.js" />

var Book = Class.create({
    init: function (name, author) {
        this.name = name;
        this.author = author;
    },

    toString: function () {
        return "Name: " + this.name + " Author: " + this.author;
    }
});

var booksUtils = (() => {
    "use strict"

    function findMostFamousAuthor(books) {
        var mostFamous = _.max(_.groupBy(books, book => book.author), bookGroupd => bookGroupd.length);

        return _.first(mostFamous).author;
    }

    return {
        findMostFamousAuthor: findMostFamousAuthor
    };

})();