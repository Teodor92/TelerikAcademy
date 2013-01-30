using System;

class DesendingOrder
{
    static void Main()
    {
        int firstNum = 4;
        int secondNum = 101;
        int thirdNum = 100;
        int temp;
        if (secondNum > firstNum)
        {
            temp = firstNum;
            firstNum = secondNum;
            secondNum = temp;
            if (thirdNum > secondNum)
            {
                temp = thirdNum;
                thirdNum = secondNum;
                secondNum = temp;
            }
            if (secondNum > firstNum)
            {
                temp = firstNum;
                firstNum = secondNum;
                secondNum = temp;
            }
        }
        if (thirdNum > secondNum)
        {
            temp = thirdNum;
            thirdNum = secondNum;
            secondNum = temp;
            if (secondNum > firstNum)
            {
                temp = firstNum;
                firstNum = secondNum;
                secondNum = temp;
            }
        }
        Console.WriteLine("{0}, {1}, {2}", firstNum, secondNum, thirdNum);
    }
}
