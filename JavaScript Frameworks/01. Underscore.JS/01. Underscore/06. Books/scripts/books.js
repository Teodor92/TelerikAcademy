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

var booksUtils = (function () {

    function findMostFamousAuthor(books) {
        var mostFamous = _.max(
            _.groupBy(books, function (book) {
                return book.author;
            })
            , function (bookGroupd) {
                return bookGroupd.length;
            });

        return _.first(mostFamous).author;
    }

    return {
        findMostFamousAuthor: findMostFamousAuthor
    };

})();