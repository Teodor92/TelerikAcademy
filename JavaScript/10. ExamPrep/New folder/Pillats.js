function newMultiArray(rows, cols) {
    var matrix = [];
    var i = 0;
    var j = 0;

    for (i = 0; i < rows; i++) {
        matrix[i] = new Array(rows);
    }

    for (i = 0; i < rows; i++) {
        for (j = 0; j < cols; j++) {
            matrix[i][j] = 0;
        }
    }

    return matrix;
}

function Solve(args) {
    var matrix = new newMultiArray(8,8);
    var i = 0;
    var j = 0;

        //input
        for (i = 0; i < 8; i++)
        {
            var input = parseInt(args[i]);
            for (j = 0; j < 8; j++)
            {
                matrix[i][j] = input % 2;
                input = parseInt(input / 2);
            }
        }

        var pointsInLeft = 0;
        var pointsInRight = 0;
        var bestPillar = -1;
        var bestPoints = 0;
        //pillar
        for (i = 0; i < 8; i++)
        {
            //check right
            for (var rightRow = 0; rightRow < 8; rightRow++)
            {
                for (var rightCol = 0; rightCol < i; rightCol++)
                {
                    if (matrix[rightRow][rightCol] == 1)
                    {
                        pointsInRight++;
                    }
                }  
            }
            //Console.WriteLine("Point {0} pillar {1} right", pointsInRight, i);
             
            // check left
            for (var leftRow = 0; leftRow < 8; leftRow++)
            {
                for (var leftCol = i + 1; leftCol < 8; leftCol++)
                {
                    if (matrix[leftRow][leftCol] == 1)
                    {
                        pointsInLeft++;
                    }
                }
            }
            //Console.WriteLine("Point {0} pillar {1} left", pointsInLeft, i);
            // point cecker
            if (pointsInLeft == pointsInRight && i > bestPillar)
            {
                bestPoints = pointsInLeft;
                bestPillar = i;
            }
            pointsInLeft = 0;
            pointsInRight = 0;
        }
        if (bestPillar == -1)
        {
           return "No";
        }
        else
        {
            var outText = "";
            outText += bestPillar;
            outText += "\n";
            outText += bestPoints;

            return outText;
        }

}