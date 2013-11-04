using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public virtual User User { get; set; }

        public virtual Post Post { get; set; }

        public DateTime CommentDate { get; set; }
    }
}
