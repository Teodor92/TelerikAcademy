function Solve(args) {
        var wantedSum = parseInt(args[0]);
        var numberOfElements = parseInt(args[1]);
        var elements = [];
        var counter = 0;
        var i = 0;

        for (i = 0; i < numberOfElements; i++)
        {
            index = i + 2;
            elements[i] = parseInt(args[index]);
        }

        var maxSubsets = Math.pow(2, numberOfElements) - 1;

        for (i = 1; i <= maxSubsets; i++)
        {
            var checkingSum = 0;
            var j = 0;
            for (j = 0; j <= numberOfElements; j++)
            {           
                var mask = 1 << j;       
                var nAndMask = i & mask; 
                var bit = nAndMask >> j;
                if (bit === 1)
                {
                    checkingSum = checkingSum + elements[j];
                }
            }
            if (checkingSum === wantedSum)
            {
                counter++;
            }
        }
        
        return counter;
}