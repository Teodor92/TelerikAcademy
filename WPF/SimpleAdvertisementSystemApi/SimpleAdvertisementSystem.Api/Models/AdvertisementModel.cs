using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace SimpleAdvertisementSystem.Api.Models
{
    [DataContract]
    public class AdvertisementModel 
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "tags")]
        public string[] Tags { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "categoryId")]
        public int CategoryId { get; set; }
    }
}
