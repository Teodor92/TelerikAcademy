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
    public class SongController : ApiController
    {
        private IRepository<Album> albumRepo;
        private IRepository<Artist> artistRepo;
        private IRepository<Song> songRepo;

        public SongController(
            IRepository<Album> albumRepository,
            IRepository<Artist> artistRepository,
            IRepository<Song> songRepository)
        {
            this.albumRepo = albumRepository;
            this.artistRepo = artistRepository;
            this.songRepo = songRepository;
        }

        // GET api/Song
        public IQueryable<SongModelFull> GetSongs()
        {
            var allSongs = songRepo.All();

            var songModels =
                (from song in allSongs
                 select new SongModelFull()
                 {
                     Id = song.Id,
                     Title = song.Title,
                     Genre = song.Genre,
                     Year = song.Year,

                     SongAlbums =
                     from album in song.Albums
                     select new AlbumModel()
                     {
                         Id = album.Id,
                         Title = album.Title,
                         Year = album.Year,
                         Producer = album.Producer
                     },

                     SongArtists =
                     from artists in song.Artists
                     select new ArtistModel()
                     {
                         Id = artists.Id,
                         Name = artists.Name,
                         Country = artists.Country,
                         DateOfBirth = artists.DateOfBirth
                     }
                 }).ToList();

            return songModels.AsQueryable();
        }

        // GET api/Song/5
        public SongModelFull GetSong(int id)
        {
            var searchedSong = songRepo.Get(id);
            var resultModel = new SongModelFull()
                {
                    Id = searchedSong.Id,
                    Title = searchedSong.Title,
                    Genre = searchedSong.Genre,
                    Year = searchedSong.Year,

                    SongAlbums =
                    from album in searchedSong.Albums
                    select new AlbumModel()
                    {
                        Id = album.Id,
                        Title = album.Title,
                        Year = album.Year,
                        Producer = album.Producer
                    },

                    SongArtists =
                    from artists in searchedSong.Artists
                    select new ArtistModel()
                    {
                        Id = artists.Id,
                        Name = artists.Name,
                        Country = artists.Country,
                        DateOfBirth = artists.DateOfBirth
                    }
                };

            return resultModel;
        }

        // PUT api/Song/5
        public HttpResponseMessage PutSong(int id, Song song)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != song.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                songRepo.Update(id, song);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //// POST api/Song
        public HttpResponseMessage PostSong(Song song)
        {
            songRepo.Add(song);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE api/Song/5
        public HttpResponseMessage DeleteSong(int id)
        {
            bool isOk;

            try
            {
                isOk = songRepo.Delete(id);
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