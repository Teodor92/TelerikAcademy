/// <reference path="jquery-2.0.3.js" />
/// <reference path="class.js" />
var controls = controls || {};
(function (c) {
	var TableView = Class.create({
		init: function (itemsSource, cols, rows) {
			if (!(itemsSource instanceof Array)) {
				throw "The itemsSource of a ListView must be an array!";
			}

			this.itemsSource = itemsSource;
			this.cols = cols;
			this.rows = rows;
		},

		render: function (template) {
		    var table = document.createElement("table");

		    if (this.cols) {
		        for (var i = 0; i < this.itemsSource.length; i++) {

		            var currentRow;

		            if (i % this.cols == 0 || i == 0) {
		                currentRow = table.appendChild(document.createElement("tr"));
		            }

		            var dataCell = document.createElement("td");
		            var item = this.itemsSource[i];
		            dataCell.innerHTML = template(item);
		            currentRow.appendChild(dataCell);

		        }
		    } else {

		        var numberOfCells = this.itemsSource.length;
		        this.cols = Math.ceil(numberOfCells / this.rows)

		        for (var i = 0; i < numberOfCells; i++) {

		            var currentRow;

		            if (i % this.cols == 0 || i == 0) {
		                currentRow = table.appendChild(document.createElement("tr"));
		            }

		            var dataCell = document.createElement("td");
		            var item = this.itemsSource[i];
		            dataCell.innerHTML = template(item);
		            currentRow.appendChild(dataCell);

		        }

		    }

		    return table.outerHTML;
		}
	});

	c.getTableView = function (itemsSource, cols, rows) {
	    return new TableView(itemsSource, cols, rows);
	}
}(controls || {}));