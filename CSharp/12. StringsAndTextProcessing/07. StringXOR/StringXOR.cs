using System;

class StringXOR
{
    static void Main()
    {
        string chifer = "ab";
        string text = "Nakov";

        int ciferLen = chifer.Length;
        for (int i = 0; i < text.Length; i++)
        {
            Console.WriteLine(@"\u{0:x4}", text[i]^chifer[i % ciferLen]);
        }
    }
}
