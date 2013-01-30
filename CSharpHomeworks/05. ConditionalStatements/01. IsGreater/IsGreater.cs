/* Write an if statement that examines two integer variables 
 * and exchanges their values if the first one is greater 
 * than the second one.
 */
using System;

class IsGreater
{
    static void Main()
    {
        int firstNumber = 10;
        int secondNumber = 2;
        if (firstNumber > secondNumber)
        {
            Console.WriteLine("Exchange needed: {0} --> {1}", firstNumber, secondNumber);
            int tempNumber = 0;
            tempNumber = firstNumber;
            firstNumber = secondNumber;
            secondNumber = tempNumber;
            
            Console.WriteLine(firstNumber);
            Console.WriteLine(secondNumber);
        }
        else
        {
            Console.WriteLine("No exchange needed.");
        }
    }
}
