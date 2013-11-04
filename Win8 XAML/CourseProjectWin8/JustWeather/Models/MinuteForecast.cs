using System.Runtime.Serialization;

namespace JustWeather.Models
{
    [DataContract]
    public class MinuteForecast
    {
        [DataMember]
        public long Time { get; set; }

        [DataMember]
        public float PrecipIntensity { get; set; }
    }
}