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

var animalsUtils = (function () {

    function groupAndOrderAnimals(animals) {

        var sorted = _.sortBy(
            _.groupBy(animals, function (animal) {
                return animal.species;
            }), function (animalGroup) {
                return _sumLegs(animalGroup);
            });

        return sorted;
    };

    function findAllLegs(animals) {
        return _sumLegs(animals);
    }

    function _sumLegs(arr) {
        return _.reduce(arr, function (memo, num) {
            return memo + num.numberOfLegs;
        }, 0)
    }

    return {
        groupAndOrderAnimals: groupAndOrderAnimals,
        findAllLegs: findAllLegs
    };

})();