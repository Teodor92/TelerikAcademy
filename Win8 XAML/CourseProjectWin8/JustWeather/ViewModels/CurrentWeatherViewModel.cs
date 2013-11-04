using JustWeather.Data;
using JustWeather.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace JustWeather.ViewModels
{
    public class CurrentWeatherViewModel : BaseViewModel
    {
        private Currently weatherInfo;
        private ForecastIOResponse allInfo;

        public ForecastIOResponse AllInfo
        {
            get
            {
                return this.allInfo;
            }
            set
            {
                this.allInfo = value;
                this.OnPropertyChanged("AllInfo");
            }
        }

        public Currently WeatherInfo
        {
            get
            {
                return this.weatherInfo;
            }
            set
            {
                this.weatherInfo = value;
                this.OnPropertyChanged("WeatherInfo");
            }
        }

        public CurrentWeatherViewModel()
        {
            this.GetWeatherInfo();
        }

        public async void GetWeatherInfo()
        {
            var helpers = new Helpers();
            Coordinate positon = await helpers.GetCoordinates();
            ForecastIOResponse info = null;
            MessageDialog msg = null;

            try
            {
                info = await DataPersister.GetInfo(positon.Lat, positon.Lon);
                Currently rawData = info.Currently;
                DateTime date = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(rawData.Time);
                rawData.FormatedTime = date.ToString("dd/MMM/yyyy hh:mm"); 
            }
            catch (Exception)
            {
                msg = new MessageDialog("Info loading failed!");
            }

            if (msg != null)
            {
                await msg.ShowAsync();
                return;
            }

            this.AllInfo = info;
            this.WeatherInfo = info.Currently;
        }
    }
}
