namespace FileTree
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class FileTree
    {
        private List<TreeFile> GetFiles(string path)
        {
            List<TreeFile> files = new List<TreeFile>();
            string[] filePaths = Directory.GetFiles(path);

            for (int i = 0; i < filePaths.Length; i++)
            {
                FileInfo fileSize = new FileInfo(filePaths[i]);
                long size = fileSize.Length;
                files.Add(new TreeFile(filePaths[i], size));
            }

            return files;
        }

        public void CreateFileTree(string pathToCopyFrom, Folder orginFolder)
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
    }
}
