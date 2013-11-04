using System.Collections.Generic;
using System.Runtime.Serialization;

namespace JustWeather.Models
{
    [DataContract]
    public class Daily
    {
        [DataMember]
        public string Summary { get; set; }

        [DataMember]
        public string Icon { get; set; }

        [DataMember]
        public List<DailyForecast> Data { get; set; }
    }
}