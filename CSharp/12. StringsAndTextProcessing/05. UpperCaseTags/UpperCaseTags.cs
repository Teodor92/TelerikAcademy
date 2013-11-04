using System;

public class UpperCaseTags
{
    public static void Main()
    {
        string input = Console.ReadLine();
        bool noString = false;
        int startSearchIndex = 0;
        int startIndex = 0;
        int endIndex = 0;
        string replacer = string.Empty;
        while (!noString)
        {
            if (input.IndexOf("<upcase>", startSearchIndex) != -1)
            {
                startIndex = input.IndexOf("<upcase>", startSearchIndex) + 8;
                startSearchIndex = input.IndexOf("<upcase>", startSearchIndex) + 1;
            }
            else
            {
                noString = true;
            }

            if (input.IndexOf("</upcase>", startSearchIndex) != -1)
            {
                endIndex = input.IndexOf("</upcase>", startSearchIndex);
                startSearchIndex = input.IndexOf("</upcase>", startSearchIndex) + 1;
            }
            else
            {
                noString = true;
            }

            for (int i = startIndex; i < endIndex; i++)
            {
                replacer = replacer + input[i];
            }

            input = input.Replace(replacer, replacer.ToUpper());
            replacer = string.Empty;
        }

        input = input.Replace("<upcase>", string.Empty);
        input = input.Replace("</upcase>", string.Empty);
        Console.WriteLine(input);
    }
}
