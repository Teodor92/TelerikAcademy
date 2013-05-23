using System;

namespace SimpleSotre.Common
{
    public interface IContent : IComparable
    {
        string Title { get; set; }

        string Author { get; set; }

        Int64 Size { get; set; }

        string Url { get; set; }

        Contents Type { get; set; }

        string TextRepresentation { get; set; }
    }
}
