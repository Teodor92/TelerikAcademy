using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ApplicationSettings;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace JustWeather.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppCustomSettings : Page
    {
        public AppCustomSettings()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Popup parent = this.Parent as Popup;
            if (parent != null)
            {
                parent.IsOpen = false;
            }

            // If the app is not snapped, then the back button shows the Settings pane again.
            if (Windows.UI.ViewManagement.ApplicationView.Value != Windows.UI.ViewManagement.ApplicationViewState.Snapped)
            {
                SettingsPane.Show();
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.AppUnitDropbox.SelectedValue;
            ContentControl info = selectedItem as ContentControl;
            //this.SaveUnitChoiceToSettings(info);
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            string value = info.Content.ToString();

            switch (value)
            {
                case "US": localSettings.Values["AppUnit"] = "us"; break;
                case "SI": localSettings.Values["AppUnit"] = "si"; break;
                case "CA": localSettings.Values["AppUnit"] = "ca"; break;
                case "UK": localSettings.Values["AppUnit"] = "uk"; break;
                case "Auto": localSettings.Values["AppUnit"] = "auto"; break;
                default: break;
            }

            var msg = new MessageDialog("Saved!");
            await msg.ShowAsync();
        }

        private void SaveUnitChoiceToSettings(ContentControl info)
        {

        }
    }
}
