namespace FileTree
{
    using System;

    public class File : SystemObject
    {
        private long size;

        public File(string name, long size)
        {
            this.Name = name;
            this.Size = size;
        }

        public long Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("File size can not be negative.");
                }

                this.size = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.Name, this.Size);
        }
    }
}
