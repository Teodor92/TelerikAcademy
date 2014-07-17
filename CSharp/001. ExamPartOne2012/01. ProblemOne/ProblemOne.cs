namespace _01.ProblemOne
{
    using System;
    using System.Linq;
    using System.Text;

    public class ProblemOne
    {
        internal static void Main()
        {
            var k = Console.ReadLine();
            var number = k.ToList();

            if (number.Count > 2)
            {
                var build = new StringBuilder();

                if (number[number.Count - 3] != '0')
                {
                    build.Append(number[number.Count - 3]);
                }

                if (number[number.Count - 2] != '0')
                {
                    build.Append(number[number.Count - 2]);
                }

                if (number[number.Count - 1] != '0')
                {
                    build.Append(number[number.Count - 1]);
                }

                for (int i = 0; i < number.Count - 3; i++)
                {
                    build.Append(number[i]);
                }

                Console.WriteLine(build.ToString());
            }
            else if (number.Count == 2)
            {
                if (number[1] != '0')
                {
                    Console.Write(number[1]);
                }

                Console.Write(number[0]);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(number[0]);
            }
        }
    }
}
