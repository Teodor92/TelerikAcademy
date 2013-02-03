using System;
using System.Text;

class GenomeDecoder
{
    static string FormatWhitespace(int m, string genomeSubString)
    {
        string genomeSubStringFormatted = "";
        int numberOfSubStrings = genomeSubString.Length / m;
        for (int i = 0; i < numberOfSubStrings; i++)
        {
            genomeSubStringFormatted += genomeSubString.Substring(i * m, m) + " ";
        }
        if (genomeSubString.Length % m != 0)
        {
            return genomeSubStringFormatted += genomeSubString.Substring(numberOfSubStrings * m, genomeSubString.Length % m);
        }
        else
        {
            return genomeSubStringFormatted.Substring(0, genomeSubStringFormatted.Length - 1);
        }
    }
    static void Main()
    {
        //line width and 
        string[] input = Console.ReadLine().Split(' ');
        int strPerLine = int.Parse(input[0]);
        int strPerSpace = int.Parse(input[1]);
        // encoded genom
        string genom = Console.ReadLine();
        // genom decoding
        StringBuilder decodedGenom = new StringBuilder();
        string strNum = string.Empty;
        int value = 1;
        for (int i = 0; i < genom.Length; i++)
        {
            if (genom[i] != 'A' && genom[i] != 'C' && genom[i] != 'G' && genom[i] != 'T')
            {
                strNum = strNum + genom[i];
            }
            else
            {
                char key = genom[i];
                if (strNum != "")
                {
                    value = int.Parse(strNum);
                }
                decodedGenom.AppendFormat("{0}", new string(key, value));
                strNum = string.Empty;
                value = 1;
            }

        }
        // formating of output
        string decodedGenomString = decodedGenom.ToString();
        //StringBuilder formatedGenom = new StringBuilder();
        //if (decodedGenomString.Length / strPerLine > 9)
        //{
        //    formatedGenom.Append(' ');
        //}
        //formatedGenom.Append('1');
        //formatedGenom.Append(' ');
        //int lines = 2;
        //int spaceCounter = 0;
        //for (int i = 0, formating = 1; i < decodedGenomString.Length; i++, formating++)
        //{
        //    formatedGenom.Append(decodedGenomString[i]);
        //    spaceCounter++;
        //    if (spaceCounter % strPerSpace == 0 && i != 0 && formating % strPerLine != 0)
        //    {
        //        formatedGenom.Append(' ');
        //    }
        //    if (formating % strPerLine == 0 && i != 0 && i != decodedGenomString.Length - 1)
        //    {
        //        if (decodedGenomString.Length / strPerLine > 9)
        //        {
        //            formatedGenom.Append('\n');
        //            if (lines < 10)
        //            {
        //                formatedGenom.Append(' ');   
        //            }
        //            formatedGenom.Append(lines);
        //            formatedGenom.Append(' ');
        //            lines++;
        //            spaceCounter = 0;
        //        }
        //        else
        //        {
        //            formatedGenom.Append('\n');
        //            formatedGenom.Append(lines);
        //            formatedGenom.Append(' ');
        //            lines++;
        //            spaceCounter = 0;
        //        }
        //    } 
        //}
        //Console.WriteLine(formatedGenom.ToString());
        int genomeRows = 0;
        if (decodedGenomString.Length % strPerLine != 0)
        {
            genomeRows = decodedGenomString.Length / strPerLine + 1;
        }
        else
        {
            genomeRows = decodedGenomString.Length / strPerLine;
        }
       
        int numberFormat = genomeRows.ToString().Length;
        StringBuilder formatedOut = new StringBuilder();
        for (int i = 1; i <= genomeRows; i++)
        {
            if (i * strPerLine <= decodedGenom.Length)
            {
                formatedOut.AppendLine(String.Format("{0," + numberFormat + "}", i.ToString()) + " " + FormatWhitespace(strPerSpace, decodedGenomString.Substring((i - 1) * strPerLine, strPerLine)));
            }
            else
            {
                formatedOut.AppendLine(String.Format("{0," + numberFormat + "}", i.ToString()) + " " + FormatWhitespace(strPerSpace, decodedGenomString.Substring((i - 1) * strPerLine, decodedGenom.Length % strPerLine)));
                }
        }
        Console.WriteLine(formatedOut);
    }
}
