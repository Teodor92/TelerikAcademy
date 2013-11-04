using MusicCatalog.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using MusicCatalog.Repos;
using MusicCatalog.Models;
using MusicCatalog.Data;

namespace MusicCatalog.Api.Resolvers
{
    public class DbDependencyResolver : IDependencyResolver
    {
        private static SongCatalogContext musicCatContext = new SongCatalogContext();
        private static IRepository<Song> songRepo = new DbSongRepository(musicCatContext);
        private static IRepository<Album> albumRepo = new DbAlbumRepository(musicCatContext);
        private static IRepository<Artist> artistRepo = new DbArtistRepository(musicCatContext);

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(SongController))
            {
                return new SongController(albumRepo, artistRepo, songRepo);
            }
            else if (serviceType == typeof(AlbumController))
            {
                return new AlbumController(albumRepo, artistRepo, songRepo);
            }
            else if (serviceType == typeof(ArtistController))
            {
                return new ArtistController(albumRepo, artistRepo, songRepo);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
        }
    }
}