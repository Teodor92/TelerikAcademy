/* Write a program to calculate n! for each n in 
 * the range [1..100]. Hint: Implement first a 
 * method that multiplies a number represented 
 * as array of digits by given integer number. 
 */

using System;
using System.Collections.Generic;

public class BigFactorial
{
    public static List<int> NumberToDigitList(int number)
    {
        List<int> digitList = new List<int>();
        while (number > 0)
        {
            digitList.Add(number % 10);
            number = number / 10;
        }

        return digitList;
    }

    public static int[] DigitMultiplication(int[] firstNum, int secondNum)
    {
        List<int> secondNumList = NumberToDigitList(secondNum);
        int[] result = new int[firstNum.Length + secondNumList.Count];
        int startingCell = 0;
        for (int i = 0; i < firstNum.Length; i++)
        {
            startingCell = i;
            for (int j = 0; j < secondNumList.Count; j++)
            {
                result[startingCell] = result[startingCell] + (secondNumList[j] * firstNum[i]);
                startingCell++;
            }
        }

        return result;
    }

    public static int[] NumberAdder(int[] firstNumber, int[] secondNumber)
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

        return newNumber;
    }

    public static void FactorialCalc(int factorialNum)
    {
        int[] result = new int[32];
        result[0] = 1;
        for (int i = factorialNum; i > 0; i--)
        {
            result = NumberAdder(result, DigitMultiplication(result, i));
        }

        foreach (var item in result)
        {
            Console.Write(item);
        }

        Console.WriteLine();
    }

    public static void Main()
    {
        FactorialCalc(2);
    }
}
