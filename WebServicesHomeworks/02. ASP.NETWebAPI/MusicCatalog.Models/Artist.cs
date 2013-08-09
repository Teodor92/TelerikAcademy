using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Models
{
    [DataContract(IsReference = true)]
    public class Artist
    {
        [DataMember]
        private ICollection<Album> albums;
        [DataMember]
        private ICollection<Song> songs;

        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public DateTime? DateOfBirth { get; set; }

        public Artist()
        {
            albums = new HashSet<Album>();
            songs = new HashSet<Song>();
        }
        
        public virtual ICollection<Song> Songs
        {
            get
            {
                return this.songs;
            }

            set
            {
                this.songs = value;
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
