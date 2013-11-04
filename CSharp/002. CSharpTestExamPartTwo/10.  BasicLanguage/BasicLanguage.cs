using System;
using System.Collections.Generic;
using System.Text;

class BasicLanguage
{
    static List<string> commands = new List<string>();

    static void Main()
    {
        StringBuilder wholeString = new StringBuilder();
        while (true)
        {
            string line = Console.ReadLine();
            wholeString.AppendLine(line);
            if (line.Contains("EXIT;"))
            {
                break;
            }
            
        }

        string allComands = wholeString.ToString();
        wholeString.Clear();
        bool inBrackets = false;

        foreach (var token in allComands)
        {
            wholeString.Append(token);
            if (token == ';')
            {
                commands.Add(wholeString.ToString());
                wholeString.Clear();
            }
        }

        wholeString.Clear();
        bool exited = false;
        int coms = 0;

        while (!exited)
	    {
            long counter = 1;
            string[] subCommands = commands[coms].Split(')');
            coms++;

            for (int j = 0; j < subCommands.Length; j++)
            {
                string sub = subCommands[j].TrimStart();

                if (sub.StartsWith("EXIT"))
                {
                    exited = true;
                    break;
                }
                else if (sub.StartsWith("PRINT"))
                {
                    int startContentIndex = sub.IndexOf('(') + 1;
                    string content = sub.Substring(startContentIndex);
                    if (content.Length > 0 && counter > 0)
                    {
                        for (int k = 0; k < counter; k++)
                        {
                            wholeString.Append(content);
                        }
                    }
                }
                else if (sub.StartsWith("FOR"))
                {
                    if (sub.IndexOf(',') == -1)
                    {
                        int startContentIndex = sub.IndexOf('(') + 1;
                        string content = sub.Substring(startContentIndex);
                        int value = int.Parse(content);
                        counter = counter * value;
                    }
                    else
                    {
                        int startContentIndex = sub.IndexOf('(') + 1;
                        string content = sub.Substring(startContentIndex);
                        string[] twoValues = content.Split(',');
                        int value = int.Parse(twoValues[1]) - int.Parse(twoValues[0]) + 1;
                        counter = counter * value;
                    }
                }
            }
	    }
            

        Console.WriteLine(wholeString.ToString());
    }
}
