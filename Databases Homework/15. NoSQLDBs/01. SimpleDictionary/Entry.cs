namespace SimpleDictionary
{
    using MongoDB.Bson;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Entry
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string Translation { get; set; }

        public Entry(string name, string translation)
        {
            this.Name = name;
            this.Translation = translation;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Translation: {1}", this.Name, this.Translation);
        }
    }
}
