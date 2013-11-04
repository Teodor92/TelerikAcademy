namespace FileTree
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class FileTreeUtils
    {
        public static void CreateFileTree(string pathToCopyFrom, Folder orginFolder)
        {
            try
            {
                Folder currentFodler = new Folder(pathToCopyFrom);
                orginFolder.AddFiles(GetFiles(pathToCopyFrom));
                string[] dirs = Directory.GetDirectories(pathToCopyFrom);

                if (dirs.Length > 0)
                {
                    for (int i = 0; i < dirs.Length; i++)
                    {
                        orginFolder.AddFolder(currentFodler);
                        CreateFileTree(dirs[i], currentFodler);
                    }
                }
                else
                {
                    return;
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Directory: {0}, CAN NOT be accessed!", pathToCopyFrom);
                return;
            }
        }

        private static List<File> GetFiles(string path)
        {
            List<File> files = new List<File>();
            string[] filePaths = Directory.GetFiles(path);

            for (int i = 0; i < filePaths.Length; i++)
            {
                FileInfo currentFile = new FileInfo(filePaths[i]);
                long size = currentFile.Length;
                files.Add(new File(currentFile.Name, size));
            }

            return files;
        }
    }
}
