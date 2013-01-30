/* Write a method that adds two positive 
 * integer numbers represented as arrays of
 * digits (each array element arr[i] contains
 * a digit; the last digit is kept in arr[0]). 
 * Each of the numbers that will be added could 
 * have up to 10 000 digits.
 */

using System;

public class NumbersAddingByArrays
{
    public static void NumberAdder(int[] firstNumber, int[] secondNumber)
    {
        int neededLength = 0;
        if (firstNumber.Length > secondNumber.Length)
        {
            neededLength = firstNumber.Length + 1;
        }
        else
        {
            neededLength = secondNumber.Length + 1;
        }

        int[] newNumber = new int[neededLength];
        for (int i = 0; i < newNumber.Length; i++)
        {
            if (i < firstNumber.Length)
            {
                newNumber[i] = newNumber[i] + firstNumber[i];
                if (newNumber[i] >= 10)
                {
                    newNumber[i] = newNumber[i] - 10;
                    newNumber[i + 1] = newNumber[i + 1] + 1;
                }
            }

            if (i < secondNumber.Length)
            {
                newNumber[i] = newNumber[i] + secondNumber[i];
                if (newNumber[i] >= 10)
                {
                    newNumber[i] = newNumber[i] - 10;
                    newNumber[i + 1] = newNumber[i + 1] + 1;
                }
            }
        }

        Array.Reverse(newNumber);
        for (int i = 0; i < newNumber.Length; i++)
        {
            Console.Write(newNumber[i]);
        }

        Console.WriteLine();
    }

    public static void Main()
    {
        int[] firstNum = { 5, 5, 5 };
        int[] secNum = { 9, 9, 9, 9, 9 };
        NumberAdder(firstNum, secNum);
    }
}
