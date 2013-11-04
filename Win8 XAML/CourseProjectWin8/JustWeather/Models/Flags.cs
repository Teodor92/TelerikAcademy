using System.Collections.Generic;
using System.Runtime.Serialization;

namespace JustWeather.Models
{
    [DataContract]
    public class Flags
    {
        [DataMember]
        public List<string> Sources { get; set; }

        [DataMember]
        public List<string> Isd_stations { get; set; }

        [DataMember]
        public List<string> Lamp_stations { get; set; }

        [DataMember]
        public List<string> Metar_stations { get; set; }

        [DataMember]
        public List<string> Darksky_stations { get; set; }

        [DataMember]
        public string Units { get; set; }
    }
}