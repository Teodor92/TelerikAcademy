namespace BloggingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        [StringLength(40)]
        public string Title { get; set; }

        public ICollection<Post> Posts { get; set; } 

        public Tag()
        {
            this.Posts = new HashSet<Post>();
        }
    }
}
