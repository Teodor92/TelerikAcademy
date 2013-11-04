using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Models
{
    public class Album
    {
        private ICollection<Artist> artists;

        private ICollection<Song> songs;

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Year { get; set; }

        public string Producer { get; set; }

        public Album()
        {
            artists = new HashSet<Artist>();
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
    }
}
