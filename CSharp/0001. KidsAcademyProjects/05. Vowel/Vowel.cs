using System;

class Vowel
{
    static void Main()
    {
        string input = Console.ReadLine();
        int vowlCounter = 0;
        for (int i = 0; i < input.Length; i++)
        {
            switch (input[i])
            {
                case 'a': vowlCounter++; break;
                case 'e': vowlCounter++; break;
                case 'i': vowlCounter++; break;
                case 'o': vowlCounter++; break;
                case 'u': vowlCounter++; break;
                case 'y': vowlCounter++; break;
                default: ;
                    break;
            }
        }
        if (vowlCounter == input.Length - vowlCounter)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("{0} {1}", vowlCounter, input.Length - vowlCounter);
        }
    }
}
