namespace FileTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Folder : SystemObject
    {
        private List<Folder> folder;
        private List<TreeFile> file;
        private StringBuilder output = new StringBuilder();

        public Folder()
        {
            this.folder = new List<Folder>();
            this.file = new List<TreeFile>();
        }

        public Folder(string name)
        {
            this.Name = name;
            this.folder = new List<Folder>();
            this.file = new List<TreeFile>();
        }

        public void AddFolder(Folder currentFolder)
        {
            this.folder.Add(currentFolder);
        }

        public void AddFiles(List<TreeFile> currentFiles)
        {
            this.file.AddRange(currentFiles);
        }

        public void GenerateStringRepresentation(Folder currentFolder)
        {
            for (int i = 0; i < folder.Count; i++)
            {
                GenerateStringRepresentation(folder[i]);
            }

            for (int i = 0; i < file.Count; i++)
            {
                output.AppendLine(file[i].ToString());
            }  
        }

        public override string ToString()
        {
            return base.ToString();  
        }
    }
}
