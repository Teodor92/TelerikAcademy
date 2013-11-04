using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyForum.Api.Models
{
    public class PostModel
    {
        public string Contetn { get; set; }

        public DateTime PostDate { get; set; }

        public string PostedBy { get; set; }

        public string Rating { get; set; }
    }
}