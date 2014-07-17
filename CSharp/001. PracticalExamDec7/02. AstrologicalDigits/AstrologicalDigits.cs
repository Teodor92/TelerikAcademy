namespace _02.AstrologicalDigits
{
    using System;

    public class AstrologicalDigits
    {
        internal static void Main()
        {
            string inputString = Console.ReadLine();
            long result = 0;
            bool stop = false;
            int goodDigit = 0;

            do
            {
                result = 0;
                foreach (var item in inputString)
                {
                    if (int.TryParse(item.ToString(), out goodDigit))
                    {
                        result = result + goodDigit;
                    }
                }

                if (result < 10)
                {
                    stop = true;
                }
                else
                {
                    inputString = result.ToString();
                }
            }
            while (stop == false);

            Console.WriteLine(result);
        }
    }
}
