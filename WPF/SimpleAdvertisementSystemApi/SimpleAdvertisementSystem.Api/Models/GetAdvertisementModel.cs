using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SimpleAdvertisementSystem.Api.Models
{
    [DataContract]
    public class GetAdvertisementModel : AdvertisementModel
    {
        [DataMember(Name = "postDate")]
        public DateTime PostDate { get; set; }

        [DataMember(Name = "postedBy")]
        public string PostedBy { get; set; }

        [DataMember(Name = "comments")]
        public IEnumerable<CommentModel> Comments { get; set; }
    }
}