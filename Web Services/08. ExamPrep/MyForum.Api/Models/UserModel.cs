using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MyForum.Api.Models
{
    [DataContract]
    public class UserModel
    {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Nickname { get; set; }

        [DataMember]
        public string AuthCode { get; set; }
    }
}