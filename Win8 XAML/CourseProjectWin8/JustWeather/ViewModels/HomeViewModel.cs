using JustWeather.Behavor;
using JustWeather.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace JustWeather.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private ICommand navToWeatherByHourCommand;
        private ICommand navToCurrentWeatherCommand;
        private ICommand navToWeekWeatherCommand;
        private ICommand navToLocationsCommand;

        public ICommand NavToLocations
        {
            get
            {
                if (this.navToLocationsCommand == null)
                {
                    this.navToLocationsCommand = new DelegateCommand<object>(this.HandleNavToLocationsCommand);
                }
                return this.navToLocationsCommand;
            }
        }

        public ICommand NavToCurrentWeather
        {
            get
            {
                if (this.navToCurrentWeatherCommand == null)
                {
                    this.navToCurrentWeatherCommand = new DelegateCommand<object>(this.HandleNavToCurrentWeatherCommand);
                }
                return this.navToCurrentWeatherCommand;
            }
        }

        public ICommand NavToWeekWeather
        {
            get
            {
                if (this.navToWeekWeatherCommand == null)
                {
                    this.navToWeekWeatherCommand = new DelegateCommand<object>(this.HandleNavToWeekWeatherCommand);
                }
                return this.navToWeekWeatherCommand;
            }
        }

        public ICommand NavToWeatherByHour
        {
            get
            {
                if (this.navToWeatherByHourCommand == null)
                {
                    this.navToWeatherByHourCommand = new DelegateCommand<object>(this.HandleNavigateToWeatherByHourCommand);
                }
                return this.navToWeatherByHourCommand;
            }
        }

        private void HandleNavToLocationsCommand(object parameter)
        {
            this.Navigate(typeof(LocationsPage));
        }

        public void HandleNavigateToWeatherByHourCommand(object param)
        {
            this.Navigate(typeof(WeatherByHourPage));
        }

        private void HandleNavToCurrentWeatherCommand(object parameter)
        {
            this.Navigate(typeof(CurrentWeatherPage));
        }

        private void HandleNavToWeekWeatherCommand(object parameter)
        {
            this.Navigate(typeof(WeekWeather));
        }
    }
}
