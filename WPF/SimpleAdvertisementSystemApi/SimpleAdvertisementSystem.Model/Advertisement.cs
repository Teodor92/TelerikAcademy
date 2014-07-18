using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAdvertisementSystem.Model
{
    public class Advertisement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [MinLength(12)]
        [Column(TypeName = "ntext")]
        public string Text { get; set; }

        [Required]
        public DateTime PostDate { get; set; }

        public DateTime ExparationDate { get; set; }

        public virtual User User { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public Advertisement()
        {
            this.Tags = new HashSet<Tag>();
            this.Comments = new HashSet<Comment>();
        }
    }
}
