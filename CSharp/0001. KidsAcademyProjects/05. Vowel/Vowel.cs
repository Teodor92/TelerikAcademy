namespace _05.Vowel
{
    using System;

    public class Vowel
    {
        internal static void Main()
        {
            var input = Console.ReadLine();
            var vowlCounter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case 'a':
                        vowlCounter++;
                        break;
                    case 'e':
                        vowlCounter++;
                        break;
                    case 'i':
                        vowlCounter++;
                        break;
                    case 'o':
                        vowlCounter++;
                        break;
                    case 'u':
                        vowlCounter++;
                        break;
                    case 'y':
                        vowlCounter++;
                        break;
                    default: 
                        throw new ArgumentOutOfRangeException();
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
}
