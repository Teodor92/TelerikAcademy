using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SimpleAdvertisementSystem.Api.Models
{
    [DataContract]
    public class CommentModel
    {
        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "commentedBy")]
        public string CommentedBy { get; set; }

        [DataMember(Name = "postDate")]
        public DateTime PostDate { get; set; }
    }
}