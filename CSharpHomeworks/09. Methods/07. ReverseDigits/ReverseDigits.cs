/* Write a method that reverses the digits of 
 * given decimal number. Example: 256  652  
 */

using System;
using System.Text;

public class ReverseDigits
{
    public static string DigitReverser(string inputNumber)
    {
        StringBuilder newNumber = new StringBuilder();
        for (int i = inputNumber.Length - 1; i >= 0; i--)
        {
            newNumber.Append(inputNumber[i]);
        }

        return newNumber.ToString();
    }

    public static void Main()
    {
        string myString = "1234556.5360";
        Console.WriteLine(DigitReverser(myString));
    }
}
