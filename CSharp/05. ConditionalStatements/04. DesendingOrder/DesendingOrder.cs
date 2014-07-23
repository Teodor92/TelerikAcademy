namespace _04.DesendingOrder
{
    using System;

    /// <summary>
    /// Sort 3 real values in descending order using nested if statements.
    /// </summary>
    public class DesendingOrder
    {
        internal static void Main()
        {
            int firstNum = 4;
            int secondNum = 101;
            int thirdNum = 100;
            int oldValue;
            if (secondNum > firstNum)
            {
                oldValue = firstNum;
                firstNum = secondNum;
                secondNum = oldValue;

                if (thirdNum > secondNum)
                {
                    oldValue = thirdNum;
                    thirdNum = secondNum;
                    secondNum = oldValue;
                }

                if (secondNum > firstNum)
                {
                    oldValue = firstNum;
                    firstNum = secondNum;
                    secondNum = oldValue;
                }
            }

            if (thirdNum > secondNum)
            {
                oldValue = thirdNum;
                thirdNum = secondNum;
                secondNum = oldValue;

                if (secondNum > firstNum)
                {
                    oldValue = firstNum;
                    firstNum = secondNum;
                    secondNum = oldValue;
                }
            }

            Console.WriteLine(
                "{0}, {1}, {2}",
                firstNum,
                secondNum,
                thirdNum);
        }
    }
}
