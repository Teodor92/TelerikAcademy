/* Write a method that returns the last digit of 
 * given integer as an English word. 
 * Examples: 512  "two", 1024  "four", 12309  "nine".
 */

using System;

public class LastDigitName
{
    public static string LastDigitNameFinder(int number)
    {
        int digit = number % 10;
        switch (digit)
        {
            case 0: return "Zero"; 
                break;
            case 1: return "One";
                break;
            case 2: return "Two";
                break;
            case 3: return "Three";
                break;
            case 4: return "Four";
                break;
            case 5: return "Five";
                break;
            case 6: return "Six";
                break;
            case 7: return "Seven";
                break;
            case 8: return "Eight";
                break;
            case 9: return "Nine";
                break;
            default: return "Error";
                break;
        }
    }

    public static void Main()
    {
        Console.WriteLine(LastDigitNameFinder(1001));
    }
}
