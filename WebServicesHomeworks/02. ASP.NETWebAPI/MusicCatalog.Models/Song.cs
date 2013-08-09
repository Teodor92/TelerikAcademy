using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace MusicCatalog.Models
{
    [DataContract(IsReference = true)]
    public class Song
    {
        [DataMember]
        private ICollection<Artist> artists;
        [DataMember]
        private ICollection<Album> albums;

        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public DateTime? Year { get; set; }

        [DataMember]
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
