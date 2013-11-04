using System.Collections.Generic;

namespace MusicCatalog.Api.Models
{
    public class ArtistModelFull : ArtistModel
    {
        public IEnumerable<AlbumModel> ArtistAlbums { get; set; }

        public IEnumerable<SongModel> ArtistSongs { get; set; }
    }
}