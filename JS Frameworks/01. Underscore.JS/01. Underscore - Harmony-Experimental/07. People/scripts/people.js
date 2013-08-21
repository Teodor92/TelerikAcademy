/// <reference path="libs/class.js" />
/// <reference path="libs/underscore.js" />

var Person = Class.create({
    init: function (firstname, lastname) {
        this.firstname = firstname;
        this.lastname = lastname;
    },

    toString: function () {
        return "First Name: " + this.firstname + " Last Name: " + this.lastname;
    }
});

var peopleUtils = (() => {
    "use strict"

    function findMostCommonFirstName(people) {

        var grouped = _.groupBy(people, person => person.firstname);

        var sorted = _.sortBy(grouped, group => group.length);

        var common = _.first(_.values(sorted))[0].firstname;

        return common;
    };

    function findMostCommonLastName(people) {
        var grouped = _.groupBy(people, person => person.lastname);

        var sorted = _.sortBy(grouped, group => group.length);

        var common = _.first(_.values(sorted))[0].lastname;

        return common;
    };

    return {
        findMostCommonFirstName: findMostCommonFirstName,
        findMostCommonLastName: findMostCommonLastName
    };

})();