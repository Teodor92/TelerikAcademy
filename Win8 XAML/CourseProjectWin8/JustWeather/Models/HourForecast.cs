using JustWeather.Behavor;
using JustWeather.Pages;
using System;
using System.Runtime.Serialization;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace JustWeather.Models
{
    [DataContract]
    public class HourForecast
    {
        [DataMember]
        public Int64 Time { get; set; }

        [DataMember]
        public string Summary { get; set; }

        [DataMember]
        public string Icon { get; set; }

        [DataMember]
        public float PrecipIntensity { get; set; }

        [DataMember]
        public float PrecipProbability { get; set; }

        [DataMember]
        public string PrecipType { get; set; }

        [DataMember]
        public float Temperature { get; set; }

        [DataMember]
        public float ApparentTemperature { get; set; }

        [DataMember]
        public float DewPoint { get; set; }

        [DataMember]
        public float WindSpeed { get; set; }

        [DataMember]
        public float WindBearing { get; set; }

        [DataMember]
        public float CloudCover { get; set; }

        [DataMember]
        public float Humidity { get; set; }

        [DataMember]
        public float Pressure { get; set; }

        [DataMember]
        public float Visibility { get; set; }

        [DataMember]
        public float Ozone { get; set; }

        public string IconPath { get; set; }

        public DateTime FormatedDate { get; set; }

        private ICommand navToDetailsCommand;

        public ICommand NavToDetails
        {
            get
            {
                if (this.navToDetailsCommand == null)
                {
                    this.navToDetailsCommand = new DelegateCommand<object>(this.HandleNavToDetailsCommand);
                }
                return this.navToDetailsCommand;
            }
        }

        private void HandleNavToDetailsCommand(object parameter)
        {
            ((Frame)Window.Current.Content).Navigate(typeof(HourWeatherDetails), parameter);
        }
    }
}