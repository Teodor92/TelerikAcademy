using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class basicBASIC
{
    static Dictionary<string, string> lines = new Dictionary<string, string>();

    static void ReadInput()
    {
        while (true)
        {
            string input = Console.ReadLine();

            if (input == "RUN")
            {
                break;
            }
            else
            {
                string lineNum = Regex.Match(input, @"^\d+").ToString();
                input = Regex.Replace(input, @"^\d+",string.Empty).ToString();
                input = input.Replace(" ", string.Empty);

                if (!lines.ContainsKey(lineNum))
                {
                    lines.Add(lineNum, input);
                }
            }
        }
    }

    static void Main()
    {
        ReadInput();
        foreach (var item in lines)
        {
            Console.WriteLine(item);
        }
    }
}
