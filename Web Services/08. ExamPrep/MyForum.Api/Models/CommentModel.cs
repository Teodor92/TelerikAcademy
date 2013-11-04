using MyForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyForum.Api.Models
{
    public class CommentModel
    {
        public string Content { get; set; }

        public DateTime CommentDate { get; set; }
    }
}