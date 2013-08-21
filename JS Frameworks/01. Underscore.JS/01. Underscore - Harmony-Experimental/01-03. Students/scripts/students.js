/// <reference path="libs/class.js" />
/// <reference path="libs/underscore.js" />

var Student = Class.create({
    init: function (firstname, lastname, age, marks) {
        this.firstname = firstname;
        this.lastname = lastname;
        this.age = age;
        this.marks = marks;
    },

    fullName: function () {
        return this.firstname + " " + this.lastname; 
    },

    toString: function () {
        return "First name: " + this.firstname + " Last name: " + this.lastname + " Age: " + this.age + " Marks: " + this.marks.join(" , ");
    }
});

var studentUtils = (() => {
    "use strict"

    function findStudentsByName(students) {
        var filtered = _.filter(students, st => st.firstname > st.lastname);
        var sorted = _.sortBy(filtered, st => st.fullName());

        sorted.reverse();

        return sorted;
    };

    function findStudentsByAge(students) {
        var filtered = _.filter(students, st => st.age >= 18 && st.age <= 24);

        return filtered;
    };

    function findStudentsByHeighestMarks(students) {
        return _.max(students, st => _average(st.marks));
    };

    function _average(arr) {
        return _.reduce(arr, (memo, num) => memo + num, 0) / arr.length;
    }

    return {
        findStudentsByName: findStudentsByName,
        findStudentsByAge: findStudentsByAge,
        findStudentsByHeighestMarks: findStudentsByHeighestMarks
    };

})();