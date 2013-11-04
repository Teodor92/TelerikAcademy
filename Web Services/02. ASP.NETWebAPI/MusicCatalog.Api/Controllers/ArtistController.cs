using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MusicCatalog.Models;
using MusicCatalog.Data;
using MusicCatalog.Repos;
using MusicCatalog.Api.Models;

namespace MusicCatalog.Api.Controllers
{
    public class ArtistController : ApiController
    {
        private IRepository<Album> albumRepo;
        private IRepository<Artist> artistRepo;
        private IRepository<Song> songRepo;

        public ArtistController(
            IRepository<Album> albumRepository,
            IRepository<Artist> artistRepository,
            IRepository<Song> songRepository)
        {
            this.albumRepo = albumRepository;
            this.artistRepo = artistRepository;
            this.songRepo = songRepository;
        }

        // GET api/Artist
        public IQueryable<ArtistModelFull> GetArtists()
        {
            var allArtists = artistRepo.All();

            var artistModels =
                (from artist in allArtists
                select new ArtistModelFull()
                {
                    Id = artist.Id,
                    Name = artist.Name,
                    Country = artist.Name,
                    DateOfBirth = artist.DateOfBirth,

                    ArtistAlbums =
                    from album in artist.Albums
                    select new AlbumModel()
                    {
                        Id = album.Id,
                        Title = album.Title,
                        Producer = album.Producer,
                        Year = album.Year
                    },

                    ArtistSongs =
                    from song in artist.Songs
                    select new SongModel()
                    {
                        Id = song.Id,
                        Title = song.Title,
                        Genre = song.Genre,
                        Year = song.Year
                    }
                }).ToList();

            return artistModels.AsQueryable();
        }

        // GET api/Artist/5
        public ArtistModelFull GetArtist(int id)
        {
            var searchedArists = artistRepo.Get(id);

            var artistModel = new ArtistModelFull()
                {
                    Id = searchedArists.Id,
                    Name = searchedArists.Name,
                    Country = searchedArists.Name,
                    DateOfBirth = searchedArists.DateOfBirth,

                    ArtistAlbums =
                    from album in searchedArists.Albums
                    select new AlbumModel()
                    {
                        Id = album.Id,
                        Title = album.Title,
                        Producer = album.Producer,
                        Year = album.Year
                    },

                    ArtistSongs =
                    from song in searchedArists.Songs
                    select new SongModel()
                    {
                        Id = song.Id,
                        Title = song.Title,
                        Genre = song.Genre,
                        Year = song.Year
                    }
                };

            return artistModel;
        }

        // PUT api/Artist/5
        public HttpResponseMessage PutArtist(int id, Artist artist)
        {
            artistRepo.Add(artist);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Artist
        public HttpResponseMessage PostArtist(Artist artist)
        {
            artistRepo.Add(artist);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //// DELETE api/Artist/5
        public HttpResponseMessage DeleteArtist(int id)
        {
            bool isOk;

            try
            {
                isOk = artistRepo.Delete(id);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            if (isOk)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
    }
}