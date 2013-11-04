namespace BloggingSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(12)]
        [Column(TypeName = "ntext")]
        public string Text { get; set; }

        [Required]
        public DateTime CommentDate { get; set; }

        public virtual User User { get; set; }

        public virtual Post Post { get; set; }
    }
}
