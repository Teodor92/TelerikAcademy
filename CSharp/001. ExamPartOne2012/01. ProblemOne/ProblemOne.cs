using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

class ProblemOne
{
    static void Main()
    {
        string k = Console.ReadLine();
        List<char> number = new List<char>();
        for (int i = 0; i < k.Length; i++)
        {
            number.Add((char)k[i]);
        }
        if (number.Count> 2)
        {
            StringBuilder build = new StringBuilder();
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
        else if(number.Count == 2)
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
