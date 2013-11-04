using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Models
{
    public class Thread
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public User User { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public Thread()
        {
            this.Categories = new HashSet<Category>();
            this.Posts = new HashSet<Post>();
        }
    }
}
