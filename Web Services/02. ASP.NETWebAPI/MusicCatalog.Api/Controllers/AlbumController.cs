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
    public class AlbumController : ApiController
    {
        private IRepository<Album> albumRepo;
        private IRepository<Artist> artistRepo;
        private IRepository<Song> songRepo;

        public AlbumController(
            IRepository<Album> albumRepository,
            IRepository<Artist> artistRepository,
            IRepository<Song> songRepository)
        {
            this.albumRepo = albumRepository;
            this.artistRepo = artistRepository;
            this.songRepo = songRepository;
        }

        // GET api/Album
        public IQueryable<AlbumModelFull> GetAlbums()
        {
            var allEntities = albumRepo.All();

            var albumModels =
                (from album in allEntities
                select new AlbumModelFull()
                {
                    Id = album.Id,
                    Title = album.Title,
                    Producer = album.Producer,
                    Year = album.Year,
                    AlbumArtists =
                    from artist in album.Artists
                    select new ArtistModel()
                    {
                        Id = artist.Id,
                        Name = artist.Name,
                        Country = artist.Country,
                        DateOfBirth = artist.DateOfBirth
                    },
                    AlbumSongs =
                    from song in album.Songs
                    select new SongModel() 
                    {
                        Id = song.Id,
                        Title = song.Title,
                        Genre = song.Genre,
                        Year = song.Year
                    }
                }).ToList();

            return albumModels.AsQueryable();
        }

        // GET api/Album/5
        public AlbumModelFull GetAlbum(int id)
        {
            var searchedAlbum = albumRepo.Get(id);
            var resultModel = new AlbumModelFull()
                {
                    Id = searchedAlbum.Id,
                    Title = searchedAlbum.Title,
                    Producer = searchedAlbum.Producer,
                    Year = searchedAlbum.Year,
                    AlbumArtists =
                    from artist in searchedAlbum.Artists
                    select new ArtistModel()
                    {
                        Id = artist.Id,
                        Name = artist.Name,
                        Country = artist.Country,
                        DateOfBirth = artist.DateOfBirth
                    },
                    AlbumSongs =
                    from song in searchedAlbum.Songs
                    select new SongModel()
                    {
                        Id = song.Id,
                        Title = song.Title,
                        Genre = song.Genre,
                        Year = song.Year
                    }
                };

            return resultModel;
        }

        // PUT api/Album/5
        public HttpResponseMessage PutAlbum(int id, Album album)
        {
            albumRepo.Add(album);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Album
        public HttpResponseMessage PostAlbum(Album album)
        {
            albumRepo.Add(album);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //// DELETE api/Album/5
        public HttpResponseMessage DeleteAlbum(int id)
        {
            bool isOk;

            try
            {
                isOk = albumRepo.Delete(id);
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