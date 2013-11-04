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
            JsonClient.SongUtils.GetAllSongs();

            // GET api/Song/5
            //JsonClient.SongUtils.GetSongByID(7);

            // PUT api/Song/5
            //JsonClient.SongUtils.PutSong(15);

            // POST api/Song
            //JsonClient.SongUtils.PostSong();

            // DELETE api/Song/5
            //JsonClient.SongUtils.DeleteSongByID(3);

            /*-----------------------------------*/
            /*------------ XML ----------------- */
            /*-----------------------------------*/

            // GET api/Song
            XmlClient.SongUtils.GetAllSongs();

            // GET api/Song/5
            //XmlClient.SongUtils.GetSongByID(7);

            // PUT api/Song/5
            //XmlClient.SongUtils.PutSong(10);

            // POST api/Song
            //XmlClient.SongUtils.PostSong();

            // DELETE api/Song/5
            //XmlClient.SongUtils.DeleteSongByID(6);


        }
    }
}
