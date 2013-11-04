namespace MusicCatalog.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using MusicCatalog.Models;
    using System.Threading;
    using MusicCatalog.Api.Models;

    public class JsonClient
    {
        private static HttpClient client;
            

        static JsonClient()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:46202")
            };
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static class SongUtils
        {
            public static void GetAllSongs()
            {
                // GET api/Song
                HttpResponseMessage response = client.GetAsync("api/Song").Result;

                if (response.IsSuccessStatusCode)
                {
                    var songs = response.Content.ReadAsAsync<IEnumerable<SongModelFull>>().Result;
                    foreach (var p in songs)
                    {
                        Console.WriteLine("{0,4} {1,-20} {2}", p.Id, p.Title, p.Year);
                    }
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }

            public static void GetSongByID(int id)
            {
                // GET api/Song/5
                HttpResponseMessage response = client.GetAsync(string.Format("api/Song/{0}", id)).Result; // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Song with ID: {0}", id);
                    var song = response.Content.ReadAsAsync<SongModelFull>().Result;
                    Console.WriteLine("{0,4} {1,-20} {2}", song.Id, song.Title, song.Year);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }

            public static void PostSong()
            {
                // POST api/Song
                var postSong = new Song
                {
                    Title = "MoarTest",
                    Year = DateTime.Now,
                    Genre = "Rock",
                    Artists = new List<Artist>() 
                    { 
                        new Artist() 
                        {
                            Id = 202,
                            Name = "llll"
                        },
                        new Artist() 
                        {
                            Id = 233,
                            Name = "ppppp"
                        },
                        new Artist() 
                        {
                            Id = 212,
                            Name = "gggg"
                        } 
                    },
                    Albums = new List<Album>() 
                    { 
                        new Album()
                        {
                            Id = 7,
                            Title = "nested album 1",
                            Year = DateTime.Now
                        },
                        new Album()
                        {
                            Id = 11,
                            Title = "nested album 2",
                            Year = DateTime.Now

                        },
                        new Album()
                        {
                            Id = 22,
                            Title = "nested album 3",
                            Year = DateTime.Now

                        },
                    }
                };

                HttpResponseMessage postResponse = client.PostAsJsonAsync("api/Song", postSong).Result;

                if (postResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine("Post ok!");
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)postResponse.StatusCode, postResponse.ReasonPhrase);
                }
            }

            public static void PostSong(Song postSong)
            {
                // POST api/Song
                HttpResponseMessage postResponse = client.PostAsJsonAsync("api/Song", postSong).Result;
                //.ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

                if (postResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine("Post ok!");
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)postResponse.StatusCode, postResponse.ReasonPhrase);
                }
            }

            public static void PutSong(int id)
            {
                Song song = new Song
                {
                    Id = id,
                    Title = "THIS IS A PUT UPDATE",
                    Year = DateTime.Now,
                };

                // PUT api/Song/5
                var result = client.PutAsJsonAsync(string.Format("api/Song/{0}", id), song).Result;

                if (result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Song is put!", id);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)result.StatusCode, result.ReasonPhrase);
                }
            }

            public static void PutSong(int id, Song song)
            {
                // PUT api/Song/5
                var result = client.PutAsJsonAsync(string.Format("api/Song/{0}", id), song).Result;

                if (result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Song is put!", id);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)result.StatusCode, result.ReasonPhrase);
                }
            }

            public static void DeleteSongByID(int id)
            {
                HttpResponseMessage result = client.DeleteAsync(string.Format("api/Song/{0}", id)).Result;

                if (result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Song with id: {0}, deleted", id);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)result.StatusCode, result.ReasonPhrase);
                }
            }
        }

        public static class AlbumUtils
        {
            public static void GetAllAlbums()
            {
                // GET api/Song
                HttpResponseMessage response = client.GetAsync("api/Album").Result; // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    var songs = response.Content.ReadAsAsync<IEnumerable<AlbumModelFull>>().Result;
                    foreach (var p in songs)
                    {
                        Console.WriteLine("{0,4} {1,-20} {2}, {3}", p.Id, p.Title, p.Year, string.Join(", ", p.AlbumSongs.ToList()));
                    }
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }

            public static void GetAlbumByID(int id)
            {
                // GET api/Song/5
                HttpResponseMessage response = client.GetAsync(string.Format("api/Album/{0}", id)).Result; // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Album with ID: {0}", id);
                    var song = response.Content.ReadAsAsync<AlbumModelFull>().Result;
                    Console.WriteLine("{0,4} {1,-20} {2}", song.Id, song.Title, song.Year);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }

            public static void PostAlbum()
            {
                // POST api/Song
                var postAlbum = new Album
                {
                    Title = "AlbumTEsting",
                    Year = DateTime.Now,
                    Producer = "Pesho"
                };

                HttpResponseMessage postResponse = client.PostAsJsonAsync("api/Album", postAlbum).Result;
                //.ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

                if (postResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine("Post ok!");
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)postResponse.StatusCode, postResponse.ReasonPhrase);
                }
            }

            public static void PostAlbum(Album postAlbum)
            {
                // POST api/Song
                HttpResponseMessage postResponse = client.PostAsJsonAsync("api/Album", postAlbum).Result;
                //.ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

                if (postResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine("Post ok!");
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)postResponse.StatusCode, postResponse.ReasonPhrase);
                }
            }

            public static void PutAlbum(int id)
            {
                Album song = new Album
                {
                    Id = id,
                    Title = "Greatest Hits!",
                    Year = DateTime.Now,
                };

                // PUT api/Song/5
                var result = client.PutAsJsonAsync(string.Format("api/Album/{0}", id), song).Result;

                if (result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Song is put!", id);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)result.StatusCode, result.ReasonPhrase);
                }
            }

            public static void PutAlbum(int id, Album song)
            {
                // PUT api/Song/5
                var result = client.PutAsJsonAsync(string.Format("api/Album/{0}", id), song).Result;

                if (result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Song is put!", id);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)result.StatusCode, result.ReasonPhrase);
                }
            }

            public static void DeleteAlbumByID(int id)
            {
                HttpResponseMessage result = client.DeleteAsync(string.Format("api/Album/{0}", id)).Result;

                if (result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Song with id: {0}, deleted", id);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)result.StatusCode, result.ReasonPhrase);
                }
            }
        }

        public static class ArtistUtils
        {
            public static void GetAllArtists()
            {
                // GET api/Song
                HttpResponseMessage response = client.GetAsync("api/Artist").Result; // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    var songs = response.Content.ReadAsAsync<IEnumerable<ArtistModelFull>>().Result;
                    foreach (var p in songs)
                    {
                        Console.WriteLine("{0,4} {1,-20} {2}", p.Id, p.Name, p.DateOfBirth);
                    }
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }

            public static void GetArtistByID(int id)
            {
                // GET api/Artist/5
                HttpResponseMessage response = client.GetAsync(string.Format("api/Artist/{0}", id)).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Artist with ID: {0}", id);
                    var song = response.Content.ReadAsAsync<ArtistModelFull>().Result;
                    Console.WriteLine("{0,4} {1,-20} {2}", song.Id, song.Name, song.DateOfBirth);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }

            public static void PostArtist()
            {
                // POST api/Artist
                var postArtist = new Artist
                {
                    Name = "ArtistTEsting",
                    DateOfBirth = DateTime.Now,
                    Country = "Pesho"
                };

                HttpResponseMessage postResponse = client.PostAsJsonAsync("api/Artist", postArtist).Result;
                //.ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

                if (postResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine("Post ok!");
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)postResponse.StatusCode, postResponse.ReasonPhrase);
                }
            }

            public static void PostArtist(Artist postArtist)
            {
                // POST api/Artist
                HttpResponseMessage postResponse = client.PostAsJsonAsync("api/Artist", postArtist).Result;
                //.ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

                if (postResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine("Post ok!");
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)postResponse.StatusCode, postResponse.ReasonPhrase);
                }
            }

            public static void PutArtist(int id)
            {
                Artist artist = new Artist
                {
                    Id = id,
                    Name = "Bai Ivan!",
                    DateOfBirth = DateTime.Now,
                };

                // PUT api/Artist/5
                var result = client.PutAsJsonAsync(string.Format("api/Artist/{0}", id), artist).Result;

                if (result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Song is put!", id);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)result.StatusCode, result.ReasonPhrase);
                }
            }

            public static void PutArtist(int id, Album song)
            {
                // PUT api/Artist/5
                var result = client.PutAsJsonAsync(string.Format("api/Album/{0}", id), song).Result;

                if (result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Song is put!", id);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)result.StatusCode, result.ReasonPhrase);
                }
            }

            public static void DeleteArtistByID(int id)
            {
                HttpResponseMessage result = client.DeleteAsync(string.Format("api/Artist/{0}", id)).Result;

                if (result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Artist with id: {0}, deleted", id);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)result.StatusCode, result.ReasonPhrase);
                }
            }
        }
    }
}
