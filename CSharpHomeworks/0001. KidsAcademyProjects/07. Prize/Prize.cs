using System;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        int[] grades = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            grades[i] = int.Parse(input[i]);
        }
        bool hasTwo = false;
        int goodGradeCounter = 0;
        for (int i = 0; i < grades.Length; i++)
        {
            if (grades[i] == 2)
            {
                hasTwo = true;
                break;
            }
            else if (grades[i] == 6)
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
