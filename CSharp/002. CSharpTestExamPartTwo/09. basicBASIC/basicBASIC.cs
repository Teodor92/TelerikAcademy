namespace _09.BasicBASIC
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class BasicBasic
    {
        private static readonly Dictionary<string, string> Lines = new Dictionary<string, string>();

        internal static void Main()
        {
            ReadCube();
            foreach (var item in Lines)
            {
                Console.WriteLine(item);
            }
        }

        private static void ReadCube()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "RUN")
                {
                    break;
                }

                string lineNum = Regex.Match(input, @"^\d+").ToString();
                input = Regex.Replace(input, @"^\d+", string.Empty);
                input = input.Replace(" ", string.Empty);

                if (!Lines.ContainsKey(lineNum))
                {
                    Lines.Add(lineNum, input);
                }
            }
        }
    }
}
