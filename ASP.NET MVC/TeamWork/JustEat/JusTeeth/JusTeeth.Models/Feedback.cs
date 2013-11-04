namespace JusTeeth.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public EatTimeType EatTime { get; set; }

        public PriceType PriceType { get; set; }

        // User will vote with integer value
        // Overall rating will be a float value
        [Required]
        public int Rating { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Place Place { get; set; }
    }
}
