using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAdvertisementSystem.Model
{
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

        public virtual Advertisement Post { get; set; }
    }
}
