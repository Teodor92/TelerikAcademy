using JustWeather.Data;
using JustWeather.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace JustWeather.Pages
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class HomePage : JustWeather.Common.LayoutAwarePage
    {
        public HomePage()
        {
            this.InitializeComponent();
            this.UpdateTile();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            //this.UpdateTile();
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        private async void UpdateTile()
        {
            //DispatcherTimer myTimer = new DispatcherTimer();
            //myTimer.Interval = new TimeSpan(15);

            //myTimer.Tick += async (s, e) =>
            //{
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            if (localSettings.Values["CurrentLocName"] != null &&
                localSettings.Values["CurrentLocLat"] != null &&
                localSettings.Values["CurrentLocLon"] != null)
            {
                double lat = Convert.ToDouble(localSettings.Values["CurrentLocLat"]);
                double lon = Convert.ToDouble(localSettings.Values["CurrentLocLon"]);

                var info = await DataPersister.GetInfo(lat, lon);
                Currently currentWeather = info.Currently;


                this.UpdateImageTile(
                    string.Format("Assets/WeatherIcons/{0}", currentWeather.Icon),
                    currentWeather.Summary);
            }
            else
            {
                var helper = new JustWeather.ViewModels.Helpers();
                var coords = await helper.GetCoordinates();
                var info = await DataPersister.GetInfo(coords.Lat, coords.Lon);
                Currently currentWeather = info.Currently;
                this.UpdateImageTile(
                    string.Format("Assets/WeatherIcons/{0}", currentWeather.Icon),
                    currentWeather.Summary);
            }
            //};

            //myTimer.Start();
        }

        public void UpdateImageTile(string imagePath, string text)
        {
            XmlDocument largeTileData = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWidePeekImage01);
            XmlNodeList largeTextData = largeTileData.GetElementsByTagName("text");
            XmlNodeList imageData = largeTileData.GetElementsByTagName("image");
            largeTextData.First().InnerText = "The weather now:";
            largeTextData.ElementAt(1).InnerText = text;
            ((XmlElement)imageData.First()).SetAttribute("src", string.Format("ms-appx:///{0}.png", imagePath));

            // Small tile notification
            XmlDocument smallTileData = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquarePeekImageAndText02);
            XmlNodeList smallTileText = smallTileData.GetElementsByTagName("text");
            XmlNodeList smallTileImage = smallTileData.GetElementsByTagName("image");
            smallTileText.First().InnerText = "Weather:";
            smallTileText.ElementAt(1).InnerText = text;
            ((XmlElement)smallTileImage.First()).SetAttribute("src", string.Format("ms-appx:///{0}.png", imagePath));

            IXmlNode newNode = largeTileData.ImportNode(smallTileData.GetElementsByTagName("binding").Item(0), true);
            largeTileData.GetElementsByTagName("visual").Item(0).AppendChild(newNode);

            TileNotification notification = new TileNotification(largeTileData);
            notification.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(30);

            TileUpdateManager.CreateTileUpdaterForApplication().Update(notification);
        }
    }
}
