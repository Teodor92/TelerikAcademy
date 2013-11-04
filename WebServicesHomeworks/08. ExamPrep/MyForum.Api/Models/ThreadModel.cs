using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyForum.Api.Models
{
    public class ThreadModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string Title { get; set; }

        public string CreatedBy { get; set; }

        public IEnumerable<PostModel> Posts { get; set; }

        public IEnumerable<string> Categories { get; set; }
    }
}
