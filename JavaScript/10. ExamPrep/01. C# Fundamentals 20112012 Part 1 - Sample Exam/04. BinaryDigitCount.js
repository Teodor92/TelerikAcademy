function Solve(args)
    {
        var digit = parseInt(args[0]);
        var n = parseInt(args[1]);
        var i = 0;
        var outArray = [];
        for (i = 0; i < n; i++)
        {
            var number = parseInt(i + 2);
            var digitCounter = 0;
            while(true)
            {
                if (number == 0)
                {
                    break;
                }
                if( number % 2 == digit)
                {
                    digitCounter++;
                }
                number = number / 2;
            }
            outArray.push(digitCounter + "\n\r");
        }
 
    }