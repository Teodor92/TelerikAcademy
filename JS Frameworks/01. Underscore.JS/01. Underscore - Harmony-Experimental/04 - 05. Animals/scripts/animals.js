/// <reference path="libs/class.js" />
/// <reference path="libs/underscore.js" />

var Animal = Class.create({
    init: function (name, species, numberOfLegs) {
        this.name = name;
        this.species = species;
        this.numberOfLegs = numberOfLegs;
    },

    toString: function () {
        return "Name: " + this.name + " Species: " + this.species + " Number of legs: " + this.numberOfLegs;
    }
});

var animalsUtils = (() => {
    "use strict"

    function groupAndOrderAnimals(animals) {

        var sorted = _.sortBy(_.groupBy(animals, animal => animal.species), animalGroup => _sumLegs(animalGroup));

        return sorted;
    };

    function findAllLegs(animals) {
        return _sumLegs(animals);
    }

    function _sumLegs(arr) {
        return _.reduce(arr, (memo, num) => memo + num.numberOfLegs, 0)
    }

    return {
        groupAndOrderAnimals: groupAndOrderAnimals,
        findAllLegs: findAllLegs
    };

})();