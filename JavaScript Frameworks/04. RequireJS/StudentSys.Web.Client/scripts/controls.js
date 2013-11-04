/// <reference path="libs/require.js" />

define(["class", "mustache"], function (Class, Mustache) {
    var controls = controls || {};

    var ListView = Class.create({
        init: function (view, selector) {
            this.view = view;
            this.selector = selector;
        },
        loadList: function (template) {
            var personTemplate = Mustache.render(template, this.view);
            document.getElementById(this.selector).innerHTML = personTemplate;
        }
    });

    var TableView = Class.create({
        init: function (view, selector) {
            this.view = view;
            this.selector = selector;
        },
        loadTable: function (template) {
            var personTemplate = Mustache.render(template, this.view);
            document.getElementById(this.selector).innerHTML = personTemplate;
        }
    });

    controls.listView = function (itemsSource, selector) {
        return new ListView(itemsSource, selector);
    };

    controls.tableView = function (itemsSource, selector) {
        return new TableView(itemsSource, selector);
    };

    return controls;

});