using JustWeather.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Popups;

namespace JustWeather.ViewModels
{
    public class Helpers
    {
        public async Task<Geoposition> GetPostionAsync()
        {
            try
            {
                Geolocator gl = new Geolocator();
                return await gl.GetGeopositionAsync();
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Location get was frobiden");
            }
        }

        public async Task<Coordinate> GetCoordinates()
        {
            try
            {
                var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                Coordinate coords = new Coordinate();

                if (localSettings.Values["CurrentLocLat"] == null &&
                    localSettings.Values["CurrentLocLon"] == null)
                {
                    var data = await GetPostionAsync();
                    localSettings.Values["CurrentLocName"] = "Your Geolocation";
                    localSettings.Values["CurrentLocLat"] = data.Coordinate.Latitude;
                    localSettings.Values["CurrentLocLon"] = data.Coordinate.Longitude;
                    coords.Lat = data.Coordinate.Latitude;
                    coords.Lon = data.Coordinate.Longitude;
                    return coords;

                }
                else
                {
                    coords.Lat = Convert.ToDouble(localSettings.Values["CurrentLocLat"]);
                    coords.Lon = Convert.ToDouble(localSettings.Values["CurrentLocLon"]);

                    return coords;
                }
            }
            catch (Exception)
            {
                return GetDefault();
            }
        }

        public async void RefreshCoordinates()
        {
            AsyncCatcher.Try(async () =>
            {
                var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                var helper = new Helpers();
                Geoposition position = await helper.GetPostionAsync();

                localSettings.Values["CurrentLocName"] = "Your Geolocation";
                localSettings.Values["CurrentLocLat"] = position.Coordinate.Latitude;
                localSettings.Values["CurrentLocLon"] = position.Coordinate.Longitude;

                var msg = new MessageDialog("Success!");
                await msg.ShowAsync();
            }).Catch<Exception>(async ex =>
            {
                var msg = new MessageDialog("Refresh failed!");
                await msg.ShowAsync();
            });
        }

        private Coordinate GetDefault()
        {
            return new Coordinate() { Lat = 0, Lon = 0 };
        }
    }
}
