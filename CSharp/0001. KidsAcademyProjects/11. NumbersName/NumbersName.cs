using System;
using System.Text;

class NumbersName
{
    static void Main()
    {
        string numberInp = Console.ReadLine();
        int firstNumber = int.Parse(numberInp);
        StringBuilder numberInpTwo = new StringBuilder();
        numberInpTwo.Append(numberInp[1]).Append(numberInp[0]).Append(numberInp[3]).Append(numberInp[2]);
        string secondNumber = numberInpTwo.ToString();
        int second = int.Parse(secondNumber);
        Console.WriteLine(firstNumber + second);    
    }
}
