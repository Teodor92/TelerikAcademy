using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace MusicCatalog.Models
{
    public class Song
    {
        private ICollection<Artist> artists;
        private ICollection<Album> albums;

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime? Year { get; set; }

        public string Genre { get; set; }

        public Song()
        {
            artists = new HashSet<Artist>();
            albums = new HashSet<Album>();
        }

        public virtual ICollection<Artist> Artists
        {
            get
            {
                return this.artists;
            }

            set
            {
                this.artists = value;
            }
        }

        public virtual ICollection<Album> Albums
        {
            get
            {
                return this.albums;
            }

            set
            {
                this.albums = value;
            }
        }
    }
}
