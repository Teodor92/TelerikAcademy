namespace _07.Prize
{
    using System;

    public class Program
    {
        internal static void Main()
        {
            var input = Console.ReadLine().Split(' ');
            var grades = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                grades[i] = int.Parse(input[i]);
            }

            var hasTwo = false;
            var goodGradeCounter = 0;
            for (int i = 0; i < grades.Length; i++)
            {
                if (grades[i] == 2)
                {
                    hasTwo = true;
                    break;
                }

                if (grades[i] == 6)
                {
                    goodGradeCounter++;
                }
            }

            if (hasTwo || goodGradeCounter == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(new string('*', goodGradeCounter));
            }
        }
    }
}
