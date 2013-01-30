// Write a program that safely compares floating-point numbers with 
//precision of 0.000001. Examples:(5.3 ; 6.01)  false;  (5.00000001 ; 5.00000003)  true


using System;

class FloatingPointComparison
{
    static void Main()
    {
        decimal firstNumber = 1235.6666666666666666666666666M;
        decimal secondNumber = 6.01M;
        decimal roundedOne = Math.Round(firstNumber, 6);
        Console.WriteLine(roundedOne);
        decimal roundedTwo = Math.Round(secondNumber, 6);
        if (roundedOne == roundedTwo)
        {
            Console.WriteLine("The numbers are equal!");
        }
        else if (roundedOne > roundedTwo)
        {
            Console.WriteLine("The first number is greater than the second!");
        }
        else
        {
            Console.WriteLine("The second number is greater than the first!");
        }
    }
}
