using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MusicCatalog.Api.Models
{
    [DataContract]
    public class SongModelFull : SongModel
    {
        [DataMember]
        public IEnumerable<ArtistModel> SongArtists { get; set; }

        [DataMember]
        public IEnumerable<AlbumModel> SongAlbums { get; set; }
    }
}