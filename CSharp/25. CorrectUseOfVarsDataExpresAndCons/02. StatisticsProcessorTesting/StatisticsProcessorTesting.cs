using System;
using Statistics;

public class StatisticsProcessorTesting
{
    static void Main()
    {
        double[] myTestValues = { 1, 2, 3, 4, 5, 6, 7, 7 };

        StatisticsProcessor myTestProcessor = new StatisticsProcessor(myTestValues);

        myTestProcessor.PrintAvgerageValue();
        myTestProcessor.PrintMaxValue();
        myTestProcessor.PrintMinValue();
    }
}
