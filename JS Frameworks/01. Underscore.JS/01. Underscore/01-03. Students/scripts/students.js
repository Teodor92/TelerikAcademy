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

var studentUtils = (function () {

    function findStudentsByName(students) {
        var filtered = _.filter(students, function (student) {
            return student.firstname > student.lastname;
        });

        var sorted = _.sortBy(filtered, function (student) {
            return student.fullName();
        });

        sorted.reverse();

        return sorted;
    };

    function findStudentsByAge(students) {
        var filtered = _.filter(students, function (student) {
            return (student.age >= 18 && student.age <= 24);
        });

        return filtered;
    };

    function findStudentsByHeighestMarks(students) {
        return _.max(students, function (student) {
            return _average(student.marks);
        })
    };

    function _average(arr) {
        return _.reduce(arr, function (memo, num) {
            return memo + num;
        }, 0) / arr.length;
    }

    return {
        findStudentsByName: findStudentsByName,
        findStudentsByAge: findStudentsByAge,
        findStudentsByHeighestMarks: findStudentsByHeighestMarks
    };

})();