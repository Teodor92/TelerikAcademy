using System;
using System.IO;
using System.Text;


// CSharpCleanCode - 40/100
class CSharpCleanCode
{
    static void Main()
    {
        // input 
        int numOfLines = int.Parse(Console.ReadLine());

        // flags
        bool inString = false;
        bool multilineCom = false;
        bool multiLineString = false;

        // main logic


        StringBuilder endText = new StringBuilder();

        for (int i = 0; i < numOfLines; i++)
        {
            string line = Console.ReadLine();
            int currentLineLen = line.Length;

            for (int j = 0; j < currentLineLen; j++)
            {
                if (line[j] == '"' && j != 0 && line[j - 1] != '\\' && multiLineString == false)
                {
                    inString = !inString;
                }
                if (line[j] == '@' && j + 1 < currentLineLen && line[j + 1] != '"')
                {
                    multiLineString = true;
                }
                if (line[j] == '"' && j != 0 && line[j - 1] != '\\' && multiLineString == true)
                {
                    multiLineString = false;
                }
                if (inString == false && multiLineString == false)
                {
                    if (line[j] == '/' && j + 1 < currentLineLen && line[j + 1] == '/' && multilineCom == false)
                    {
                        if (j + 2 >= line.Length || line[j + 2] != '/')
                        {
                            break;
                        }
                        else
                        {
                            // Inline documentation (///)
                            endText.Append("///");
                            j += 2;
                            continue;
                        }
                    }
                    if (line[j] == '/' && j + 1 < currentLineLen && line[j + 1] == '*')
                    {
                        multilineCom = true;
                        continue;
                    }
                    if (line[j] == '*' && j + 1 < currentLineLen && line[j + 1] == '/')
                    {
                        multilineCom = false;
                        j++;
                        continue;
                    }
                }

                if (multilineCom == false)
                {
                    endText.Append(line[j]);
                }
            }

            if (multilineCom == false)
            {
                endText.AppendLine();
            }
        }


        StringReader sr = new StringReader(endText.ToString());
        string lineToPrint = null;
        while ((lineToPrint = sr.ReadLine()) != null)
        {
            if (!string.IsNullOrWhiteSpace(lineToPrint))
            {
                Console.WriteLine(lineToPrint);
            }
        }
    }
}
