using System;
using System.Runtime.Serialization;

namespace JustWeather.Models
{
    [DataContract]
    public class Currently
    {
        [DataMember]
        public long Time { get; set; }

        [DataMember]
        public string Summary { get; set; }

        [DataMember]
        public string Icon { get; set; }

        [DataMember]
        public float PrecipIntensity { get; set; }

        [DataMember]
        public float PrecipProbability { get; set; }

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

        public string FormatedTime { get; set; }
    }
}