using JustWeather.Data;
using JustWeather.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Popups;

namespace JustWeather.ViewModels
{
    public class HourWeatherViewModel : BaseViewModel
    {
        private ObservableCollection<HourForecast> hourWeatherInfo;
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

        public IEnumerable<HourForecast> HourWeatherInfo
        {
            get
            {
                if (this.hourWeatherInfo == null)
                {
                    this.hourWeatherInfo = new ObservableCollection<HourForecast>();
                }
                return this.hourWeatherInfo;
            }
            set
            {
                if (this.hourWeatherInfo == null)
                {
                    this.hourWeatherInfo = new ObservableCollection<HourForecast>();
                }
                this.SetObservableValues(this.hourWeatherInfo, value);
            }
        }

        public HourWeatherViewModel()
        {
            this.GetWeatherInfo();
        }

        public async void GetWeatherInfo()
        {
            var helper = new Helpers();
            Coordinate positon = await helper.GetCoordinates();

            ForecastIOResponse info = null;
            MessageDialog msg = null;
            
            try
            {
                info = await DataPersister.GetInfo(positon.Lat, positon.Lon);
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

            this.allInfo = info;
            List<HourForecast> rawData = info.Hourly.Data;
            for (int i = 0; i < rawData.Count; i++)
            {
                rawData[i].IconPath = string.Format("/Assets/WeatherIcons/{0}.png", rawData[i].Icon);
                DateTime date = new DateTime(1970,1,1,0,0,0).AddSeconds(rawData[i].Time);
                rawData[i].FormatedDate = date;
            }
            this.HourWeatherInfo = rawData;
        }
    }
}
