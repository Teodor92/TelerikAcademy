namespace SimpleSotre.Common
{
    using System;
    using System.Text;

    public class Content : IComparable, IContent
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public long Size { get; set; }

        private string url;

        public string Url
        {
            get
            {
                return this.url;
            }

            set
            {
                this.url = value;
                this.TextRepresentation = this.ToString(); // To update the text representation
            }
        }

        public Contents Type { get; set; }

        public string TextRepresentation { get; set; }

        public Content(Contents type, string[] commandParams)
        {
            this.Type = type;
            this.Title = commandParams[(int)Atributes.Title];
            this.Author = commandParams[(int)Atributes.Author];
            this.Size = long.Parse(commandParams[(int)Atributes.Size]);
            this.Url = commandParams[(int)Atributes.Url];
        }

        public int CompareTo(object obj)
        {
            if (null == obj)
            {
                return 1;
            }

            Content otherContent = obj as Content;
            if (otherContent != null)
            {
                int comparisonResul = this.TextRepresentation.CompareTo(otherContent.TextRepresentation);

                return comparisonResul;
            }

            throw new ArgumentException("Object is not a Content");
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendFormat(
                "{0}: {1}; {2}; {3}; {4}", 
                this.Type.ToString(), 
                this.Title, 
                this.Author, 
                this.Size, 
                this.Url);

            return output.ToString();
        }
    }
}