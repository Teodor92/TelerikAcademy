namespace FileTree
{
    /* 
     * Define classes File { string name, int size } and 
     * Folder { string name, File[] files, Folder[] childFolders } 
     * and using them build a tree keeping all files and folders on 
     * the hard drive starting from C:\WINDOWS. Implement a method 
     * that calculates the sum of the file sizes in given 
     * subtree of the tree and test it accordingly. Use recursive DFS traversal. 
     */

    using System;
    using System.Linq;
    using System.Numerics;

    public class Program
    {
        public static void Main()
        {
            string dir = @"D:\SAO";
            Folder directoryCopyFolder = new Folder("D folder");

            FileTreeUtils.CreateFileTree(dir, directoryCopyFolder);
            BigInteger size = 0;

            Console.WriteLine("Note: Use small directories for faster calculation.");
            Console.WriteLine(new string('-', Console.WindowWidth - 2));
            Console.WriteLine("Calcualting folder size, pleace wait.....");
            Console.WriteLine(new string('-', Console.WindowWidth - 2));
            Console.WriteLine("Folder {0} size is {1}", dir, directoryCopyFolder.GetFolderSize(size));
        }
    }
}
