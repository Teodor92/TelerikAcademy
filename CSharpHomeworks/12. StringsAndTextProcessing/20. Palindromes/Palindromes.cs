using System;
using System.Text.RegularExpressions;

class Palindromes
{
    static void Main()
    {
        string text = Console.ReadLine();

        MatchCollection words = Regex.Matches(text, @"\b[a-zA-z]+\b");

        foreach (var item in words)
        {
            string temp = item.ToString();
            bool isPali = true;
            for (int i = 0; i < temp.Length/2 + 1; i++)
            {
                if (temp[i] != temp[temp.Length - 1 - i])
                {
                    isPali = false;
                }
            }

            if (isPali)
            {
                Console.WriteLine(temp);
            }
        }
    }
}
