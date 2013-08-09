namespace MusicCatalog.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using MusicCatalog.Models;

    public static class XMLUtils
    {
        private static readonly HttpClient client =
            new HttpClient
            {
                BaseAddress = new Uri("http://localhost:46202")
            };

        static XMLUtils()
        {
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/xml"));
        }

        public static class SongUtils
        {
            public static void GetAllSongs()
            {
                // GET api/Song
                HttpResponseMessage response = client.GetAsync("api/Song").Result; // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    var songs = response.Content.ReadAsAsync<IEnumerable<Song>>().Result;
                    foreach (var p in songs)
                    {
                        Console.WriteLine("{0,4} {1,-20} {2}", p.Title, p.Year);
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
                    var song = response.Content.ReadAsAsync<Song>().Result;
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
                    Genre = "Rock"
                };

                HttpResponseMessage postResponse = client.PostAsXmlAsync("api/Song", postSong).Result;
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

            public static void PostSong(Song postSong)
            {
                // POST api/Song
                HttpResponseMessage postResponse = client.PostAsXmlAsync("api/Song", postSong).Result;
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
                    Title = "Greatest Hits!",
                    Year = DateTime.Now,
                };

                // PUT api/Song/5
                var result = client.PutAsXmlAsync(string.Format("api/Song/{0}", id), song).Result;

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
                var result = client.PutAsXmlAsync(string.Format("api/Song/{0}", id), song).Result;

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
                    var songs = response.Content.ReadAsAsync<IEnumerable<Album>>().Result;
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

            public static void GetAlbumByID(int id)
            {
                // GET api/Song/5
                HttpResponseMessage response = client.GetAsync(string.Format("api/Album/{0}", id)).Result; // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Album with ID: {0}", id);
                    var song = response.Content.ReadAsAsync<Album>().Result;
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

                HttpResponseMessage postResponse = client.PostAsXmlAsync("api/Album", postAlbum).Result;
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
                HttpResponseMessage postResponse = client.PostAsXmlAsync("api/Album", postAlbum).Result;
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
                    Title = "Greatest Hits!",
                    Year = DateTime.Now,
                };

                // PUT api/Song/5
                var result = client.PutAsXmlAsync(string.Format("api/Album/{0}", id), song).Result;

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
                var result = client.PutAsXmlAsync(string.Format("api/Album/{0}", id), song).Result;

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
                    var songs = response.Content.ReadAsAsync<IEnumerable<Artist>>().Result;
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
                    var song = response.Content.ReadAsAsync<Artist>().Result;
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

                HttpResponseMessage postResponse = client.PostAsXmlAsync("api/Artist", postArtist).Result;
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
                HttpResponseMessage postResponse = client.PostAsXmlAsync("api/Artist", postArtist).Result;
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
                    Name = "Bai Ivan!",
                    DateOfBirth = DateTime.Now,
                };

                // PUT api/Artist/5
                var result = client.PutAsXmlAsync(string.Format("api/Artist/{0}", id), artist).Result;

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
                var result = client.PutAsXmlAsync(string.Format("api/Album/{0}", id), song).Result;

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
