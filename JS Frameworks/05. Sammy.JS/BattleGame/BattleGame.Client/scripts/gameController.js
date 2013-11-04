/// <reference path="libs/require.js" />

define(["oopClass"], function (oopClass) {

    var MainGameContoller = oopClass.create({
        init: function (startData) {
            this.startData = startData;
            this.gameMatrix = this.createGameFiled(9, 9);
            this.populateField();
        },

        createGameFiled: function (rows, cols) {
            var matrix = [];
            var i = 0;
            var j = 0;

            for (i = 0; i < rows; i++) {

                matrix[i] = new Array(cols);

                for (j = 0; j < cols; j++) {
                    matrix[i][j] = null;
                }
            }

            return matrix;
        },

        populateField: function () {
            
            var firstPlayerUnits = this.startData.blue.units;
            var secondPlayerUnits = this.startData.red.units;

            for (var i = 0; i < firstPlayerUnits.length; i++) {
                var x = firstPlayerUnits[i].position.x;
                var y = firstPlayerUnits[i].position.y;

                this.gameMatrix[x][y] = {
                    collor: firstPlayerUnits[i].owner,
                    type: firstPlayerUnits[i].type,
                    id: firstPlayerUnits[i].id,
                    mode: firstPlayerUnits[i].mode
                };
            }

            for (var i = 0; i < secondPlayerUnits.length; i++) {
                var x = secondPlayerUnits[i].position.x;
                var y = secondPlayerUnits[i].position.y;

                this.gameMatrix[x][y] = {
                    collor: secondPlayerUnits[i].owner,
                    type: secondPlayerUnits[i].type,
                    id: secondPlayerUnits[i].id,
                    mode: secondPlayerUnits[i].mode
                };
            }
        }
    });

    return {
        getMainGameControl: function (data) {
            return new MainGameContoller(data);
        }
    };
});