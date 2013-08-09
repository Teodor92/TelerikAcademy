namespace Phonebook
{
    /* 
     * * A text file phones.txt holds information about people, 
     * their town and phone number:
     * 
     * Mimi Shmatkata          | Plovdiv  | 0888 12 34 56
     * Kireto                  | Varna    | 052 23 45 67
     * Daniela Ivanova Petrova | Karnobat | 0899 999 888
     * Bat Gancho              | Sofia    | 02 946 946 946
     * 
     * Duplicates can occur in people names, towns and phone numbers.
     * Write a program to read the phones file and execute a 
     * sequence of commands given in the file commands.txt:
     * find(name) – display all matching records by given name (first, middle, last or nickname)
     * find(name, town) – display all matching records by given name and town 
     */

    using System;
    using System.IO;

    public class Program
    {
        public static void Main()
        {
            BiDictionary<string, string, string> phonebook = new BiDictionary<string, string, string>(true);

            using (StreamReader inputReader = new StreamReader(@"../../phone.txt"))
            {
                string line = inputReader.ReadLine();

                while (line != null)
                {
                    string[] splitedLine = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    phonebook.AddByBothKeys(splitedLine[0].Trim(), splitedLine[1].Trim(), splitedLine[2].Trim());

                    phonebook.AddByFirstKey(splitedLine[0].Trim(), splitedLine[2].Trim());
                    phonebook.AddBySecondKey(splitedLine[1].Trim(), splitedLine[2].Trim());

                    line = inputReader.ReadLine();
                }
            }

            // command parser
            using (StreamReader inputReader = new StreamReader(@"../../commands.txt"))
            {
                string line = inputReader.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line);
                    string[] splitedLine = line.Split(new char[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);

                    if (splitedLine.Length == 2)
                    {
                        var result = phonebook.FindByFirstKey(splitedLine[1]);
                        foreach (var element in result)
                        {
                            Console.WriteLine(element);
                        }
                    }
                    else
                    {
                        var result = phonebook.FindByFirstAndSecondKey(splitedLine[1].Trim(), splitedLine[2].Trim());
                        foreach (var element in result)
                        {
                            Console.WriteLine(element);
                        }
                    }

                    line = inputReader.ReadLine();
                }
            }
        }
    }
}
