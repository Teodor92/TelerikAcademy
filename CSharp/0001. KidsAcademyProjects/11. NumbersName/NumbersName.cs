namespace _11.NumbersName
{
    using System;
    using System.Text;

    public class NumbersName
    {
        internal static void Main()
        {
            var numberInp = Console.ReadLine();
            var firstNumber = int.Parse(numberInp);
            var numberInpTwo = new StringBuilder();
            numberInpTwo
                .Append(numberInp[1])
                .Append(numberInp[0])
                .Append(numberInp[3])
                .Append(numberInp[2]);

            var secondNumber = numberInpTwo.ToString();
            var second = int.Parse(secondNumber);

            Console.WriteLine(firstNumber + second);    
        }
    }
}
