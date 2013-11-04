using JustWeather.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;

namespace JustWeather.Data
{
    public class DataPersister
    {
        public async static Task<ForecastIOResponse> GetInfo(double lat, double lon)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            string units = string.Empty;
            if (localSettings.Values["AppUnit"] != null)
            {
                units = localSettings.Values["AppUnit"].ToString();
            }
            else
            {
                units = "auto";
            }

            return await HttpRequester.Get<ForecastIOResponse>(
                string.Format(
                    @"https://api.forecast.io/forecast/7636fd8089d1ea1ec0f9c037548e8a8a/{0},{1}?units={2}", 
                    lat, 
                    lon,
                    units));
        }

        //public async static Task<string> GetFileStyles()
        //{
        //    return await ReadTextFileAsync(@"styles.txt");
        //}


        //private static async Task<string> ReadTextFileAsync(string path)
        //{
        //    var folder = Package.Current.InstalledLocation;
        //    var neededFolder = await folder.GetFolderAsync("ExportFileStyles");
        //    var file = await folder.GetFileAsync(path);
        //    var read = await FileIO.ReadTextAsync(file);
        //    return read;
        //}
    }


}
