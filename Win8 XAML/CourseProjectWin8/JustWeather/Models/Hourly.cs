using System.Collections.Generic;
using System.Runtime.Serialization;

namespace JustWeather.Models
{
    [DataContract]
    public class Hourly
    {
        [DataMember]
        public string Summary { get; set; }

        [DataMember]
        public string Icon { get; set; }

        [DataMember]
        public List<HourForecast> Data { get; set; }
    }
}