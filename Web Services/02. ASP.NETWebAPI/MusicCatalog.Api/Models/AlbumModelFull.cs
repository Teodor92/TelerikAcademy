using System.Collections.Generic;

namespace MusicCatalog.Api.Models
{
    public class AlbumModelFull : AlbumModel
    {
        public IEnumerable<ArtistModel> AlbumArtists { get; set; }

        public IEnumerable<SongModel> AlbumSongs { get; set; }
    }
}