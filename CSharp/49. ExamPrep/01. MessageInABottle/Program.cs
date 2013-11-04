namespace MessageInABottle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        private static List<KeyValuePair<char, string>> codes = new List<KeyValuePair<char, string>>();

        private static List<string> results = new List<string>();

        private static string number = string.Empty;

        public static void Main()
        {
            number = Console.ReadLine();

            string decoder = Console.ReadLine();

            char key = '\0';
            StringBuilder value = new StringBuilder();

            for (int i = 0; i < decoder.Length; i++)
            {
                if (char.IsLetter(decoder[i]))
                {
                    if (key != '\0')
                    {
                        codes.Add(new KeyValuePair<char, string>(key, value.ToString()));
                        value.Clear();
                    }
                    
                    key = decoder[i];
                }
                else
                {
                    value.Append(decoder[i]);
                }
            }

            if (key != '\0')
            {
                codes.Add(new KeyValuePair<char, string>(key, value.ToString()));
                value.Clear();
            }

            Solve(new StringBuilder(), 0);

            Console.WriteLine(results.Count);
            results.Sort();
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }

        public static void Solve(StringBuilder output, int subStringIndex)
        {
            if (subStringIndex == number.Length)
            {
                results.Add(output.ToString());
                return;
            }

            foreach (var item in codes)
            {
                if (number.Substring(subStringIndex).StartsWith(item.Value))
                {
                    output.Append(item.Key);
                    Solve(output, subStringIndex + item.Value.Length);
                    output.Length--;
                }
            }
        }
    }
}
