using Bing.Maps;
using System;
using Windows.Devices.Geolocation;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Popups;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace JustWeather.Pages
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class LocationsPage : JustWeather.Common.LayoutAwarePage
    {
        public LocationsPage()
        {
            this.InitializeComponent();

            this.LocationMap.PointerPressedOverride += LocationMap_PointerPressedOverride;
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            if (localSettings.Values["CurrentLocName"] != null &&
                localSettings.Values["CurrentLocLat"] != null &&
                localSettings.Values["CurrentLocLon"] != null)
            {
                Location myLocation = new Location();
                myLocation.Latitude = Convert.ToDouble(localSettings.Values["CurrentLocLat"]);
                myLocation.Longitude = Convert.ToDouble(localSettings.Values["CurrentLocLon"]);
                Pushpin myPoint = new Pushpin();
                myPoint.SetValue(MapLayer.PositionProperty, myLocation);
                myPoint.Selected = true;
                this.LocationMap.Children.Add(myPoint);
                this.LocationMap.Center = myLocation;
                this.LocationMap.ZoomLevel = 10;

                this.LatBox.Text = myLocation.Latitude.ToString();
                this.LonBox.Text = myLocation.Longitude.ToString();
                this.NameBox.Text = localSettings.Values["CurrentLocName"].ToString();
            }
        }

        private void LocationMap_PointerPressedOverride(object sender, PointerRoutedEventArgs e)
        {
            Location location = new Location();
            Point point = e.GetCurrentPoint(this.LocationMap).Position;
            this.LocationMap.TryPixelToLocation(point, out location);

            this.LatBox.Text = location.Latitude.ToString();
            this.LonBox.Text = location.Longitude.ToString();
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
            if (pageState != null)
            {
                this.NameBox.Text = pageState["nameLocInput"].ToString();
            }
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
            pageState["nameLocInput"] = this.NameBox.Text;
        }

        private async void LocationSaveButton_Click(object sender, RoutedEventArgs e)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            string lat = this.LatBox.Text;
            string lon = this.LonBox.Text;
            string name = this.NameBox.Text;

            if (string.IsNullOrWhiteSpace(lat) ||
                string.IsNullOrWhiteSpace(lon) ||
                string.IsNullOrWhiteSpace(name) ||
                name.Length < 3 || 
                name.Length > 30)
            {
                var msg = new MessageDialog("Input was invalid. Please try again.");
                await msg.ShowAsync();
            }
            else
            {
                localSettings.Values["CurrentLocName"] = name;
                localSettings.Values["CurrentLocLat"] = lat;
                localSettings.Values["CurrentLocLon"] = lon;

                var msg = new MessageDialog("Saved.");
                await msg.ShowAsync();

                var _Frame = Window.Current.Content as Frame;
                _Frame.Navigate(_Frame.Content.GetType());
                _Frame.GoBack();
            }
        }
    }
}
