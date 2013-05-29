namespace DirectorySearch
{
    using System;
    using System.IO;
    using System.Text;

    public class ExeFilePrinter
    {
        private void ShowExes(string path)
        {
            StringBuilder output = new StringBuilder();

            string[] exes = Directory.GetFiles(path, @"*.exe");

            for (int i = 0; i < exes.Length; i++)
            {
                output.AppendLine(exes[i]);
            }

            Console.Write(output.ToString());
        }

        public void GetSubDirs(string path)
        {
            try
            {
                ShowExes(path);

                string[] dirs = Directory.GetDirectories(path);

                if (dirs.Length > 0)
                {
                    for (int i = 0; i < dirs.Length; i++)
                    {
                        GetSubDirs(dirs[i]);
                    }
                }
                else
                {
                    return;
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Directory: {0}, CAN NOT be accessed!", path);
                return;
            }
        }
    }
}
