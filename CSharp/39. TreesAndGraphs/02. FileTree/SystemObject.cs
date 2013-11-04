namespace FileTree
{
    using System;

    public class SystemObject
    {
        private string name;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name can not be empty");
                }

                this.name = value;
            }
        }
    }
}
