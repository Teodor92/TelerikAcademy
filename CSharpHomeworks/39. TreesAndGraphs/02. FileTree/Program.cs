namespace FileTree
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            FileTree dCopy = new FileTree();
            Folder dPart = new Folder("D folder");

            dCopy.CreateFileTree(@"D:\", dPart);

            Console.WriteLine(dPart.ToString());

            Stack<int> test = new Stack<int>();
        }
    }
}
