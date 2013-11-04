using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace JustWeather.Models
{
    [DataContract]
    public class ForecastIOResponse
    {
        [DataMember]
        public float Latitude { get; set; }

        [DataMember]
        public float Longitude { get; set; }

        [DataMember]
        public string Timezone { get; set; }

        [DataMember]
        public float Offset { get; set; }

        [DataMember]
        public Currently Currently { get; set; }

        [DataMember]
        public Minutely Minutely { get; set; }

        [DataMember]
        public Hourly Hourly { get; set; }

        [DataMember]
        public Daily Daily { get; set; }

        [DataMember]
        public List<Alert> Alerts { get; set; }

        [DataMember]
        public Flags Flags { get; set; }
    }
}
