namespace FileTree
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class Folder : SystemObject
    {
        private readonly List<Folder> folders;
        private readonly List<File> files;

        public Folder()
        {
            this.folders = new List<Folder>();
            this.files = new List<File>();
        }

        public Folder(string name)
        {
            this.Name = name;
            this.folders = new List<Folder>();
            this.files = new List<File>();
        }

        public List<Folder> Folders
        {
            get
            {
                return this.folders;
            }
        }

        public List<File> Files
        {
            get
            {
                return this.files;
            }
        }

        public void AddFolder(Folder currentFolder)
        {
            this.folders.Add(currentFolder);
        }

        public void AddFiles(List<File> currentFiles)
        {
            this.files.AddRange(currentFiles);
        }

        public BigInteger GetFolderSize(BigInteger size)
        {
            for (int i = 0; i < this.files.Count; i++)
            {
                size += this.files[i].Size;
            }

            for (int i = 0; i < this.folders.Count; i++)
            {
                size += this.folders[i].GetFolderSize(size);
            }

            return size;
        }

    }
}
