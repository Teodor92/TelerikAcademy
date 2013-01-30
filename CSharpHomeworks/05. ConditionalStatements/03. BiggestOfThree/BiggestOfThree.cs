/* Write a program that finds the biggest 
 * of three integers using nested if statements.
 */

using System;

class BiggestOfThree
{   
    static int IsBigger(int first, int second)
    {
        
        if (first > second)
        {
            return first;
        }
        else
        {
            return second;
        }
    }
    static void Main()
    {
        int firstNum = 3;
        int secondNum = 5;
        int thirdNum = 8;
        int biggest = 0;
        biggest = IsBigger(firstNum, secondNum);
        biggest = IsBigger(biggest, thirdNum);
        Console.WriteLine(biggest);
    }
}
