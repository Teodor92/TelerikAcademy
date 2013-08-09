namespace MusicCatalog.Client
{
    using System;
    using System.Linq;

    internal class Program
    {

        static void Main(string[] args)
        {
            /*-----------------------------------------------------------------------------------*/
            /*-----------------------------ADD THE MISSING PACKEGES------------------------------*/
            /*-----------------------------------------------------------------------------------*/
            // Had to remove the cos the projec was too big and i couldn't upload it

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<SongCatalogContext, Configuration>());

            /*-----------------------------------*/
            /*------------ JSON ---------------- */
            /*-----------------------------------*/

            // GET api/Song
            JSONUtils.SongUtils.GetAllSongs();

            // GET api/Song/5
            JSONUtils.SongUtils.GetSongByID(7);

            // PUT api/Song/5
            //JSONUtils.SongUtils.PutSong(10);

            // POST api/Song
            //JSONUtils.SongUtils.PostSong();

            // DELETE api/Song/5
            //JSONUtils.SongUtils.DeleteSongByID(3);

            /*-----------------------------------*/
            /*------------ XML ----------------- */
            /*-----------------------------------*/

            // GET api/Song
            //XMLUtils.SongUtils.GetAllSongs();

            // GET api/Song/5
            //XMLUtils.SongUtils.GetSongByID(7);

            // PUT api/Song/5
            //XMLUtils.SongUtils.PutSong(10);

            // POST api/Song
            //XMLUtils.SongUtils.PostSong();

            // DELETE api/Song/5
            //XMLUtils.SongUtils.DeleteSongByID(6);

        }
    }
}
