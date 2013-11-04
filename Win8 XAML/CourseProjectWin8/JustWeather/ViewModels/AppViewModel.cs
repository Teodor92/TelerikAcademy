using JustWeather.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JustWeather.Models;

namespace JustWeather.ViewModels
{
    public class AppViewModel : BaseViewModel
    {
        private readonly string apiKey = "7636fd8089d1ea1ec0f9c037548e8a8a";
        public ForecastIOResponse Data { get; set; }
        private string content;


        public AppViewModel()
        {
            this.GetData();
        }

        public string Content
        {
            get
            {
                return this.content;
            }
            set
            {
                this.content = value;
                this.OnPropertyChanged("Content");
            }
        }

        public async void GetData()
        {
            this.Data = await HttpRequester.Get<ForecastIOResponse>(@"https://api.forecast.io/forecast/7636fd8089d1ea1ec0f9c037548e8a8a/37.8267,-122.423");
            this.Content = JsonConvert.SerializeObject(this.Data);
        }
    }
}
