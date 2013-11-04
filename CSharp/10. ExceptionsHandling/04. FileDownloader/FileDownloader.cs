/* Write a program that downloads a file from Internet
 * (e.g. http://www.devbg.org/img/Logo-BASD.jpg) and stores 
 * it the current directory. Find in Google how to download 
 * files in C#. Be sure to catch all exceptions and to free 
 * any used resources in the finally block.
 */

using System;
using System.Net;

public class FileDownloader
{
    public static void Main()
    {
        WebClient downloader = new WebClient();
        using (downloader)
        {
            try
            {

                downloader.DownloadFile("http://www.devbg.org/img/Logo-BASD.jpg", @"c:\Users\Teodor\Desktop\New folder\test.jpg");

            }
            catch (ArgumentException ae)
            {
                Console.WriteLine("{0} - {1}", ae.GetType(), ae.Message);
            }
            catch (WebException webEx)
            {
                Console.WriteLine("{0} - {1}", webEx.GetType(), webEx.Message);
                Console.WriteLine("Destination not found!");
            }
            catch (NotSupportedException supportEx)
            {
                Console.WriteLine("{0} - {1}", supportEx.GetType(), supportEx.Message);
                Console.WriteLine(supportEx.Message);
            }
            catch (Exception allExp)
            {
                Console.WriteLine("{0} - {1}", allExp.GetType(), allExp.Message);
            }
        }
    }
}
