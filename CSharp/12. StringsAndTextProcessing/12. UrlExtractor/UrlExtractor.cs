using System;

public class UrlExtractor
{
    public static void Main()
    {
        string url = Console.ReadLine();
        string portocol = string.Empty;
        string server = string.Empty;
        string resourse = string.Empty;
        int endindex = 0;
        for (int i = 0; i < url.Length; i++)
        {
            if (url[i] != ':')
            {
                portocol = portocol + url[i];
            }
            else
            {
                endindex = i;
                break;
            }
        }

        for (int i = endindex + 3; i < url.Length; i++)
        {
            if (url[i] != '/')
            {
                server = server + url[i];
            }
            else
            {
                endindex = i;
                break;
            }
        }

        for (int i = endindex; i < url.Length; i++)
        {
            resourse = resourse + url[i];
        }

        Console.WriteLine("[portocol] = {0}", portocol);
        Console.WriteLine("[server] = {0}", server);
        Console.WriteLine("[resourse] = {0}", resourse);
    }
}
