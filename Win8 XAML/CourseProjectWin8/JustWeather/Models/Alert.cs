using System;
using System.Runtime.Serialization;

namespace JustWeather.Models
{
    [DataContract]
    public class Alert
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public Int64 Expires { get; set; }

        [DataMember]
        public string Uri { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}