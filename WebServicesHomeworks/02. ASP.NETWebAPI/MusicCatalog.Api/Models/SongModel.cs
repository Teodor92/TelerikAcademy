using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MusicCatalog.Api.Models
{
    [DataContract]
    public class SongModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public DateTime? Year { get; set; }

        [DataMember]
        public string Genre { get; set; }
    }
}