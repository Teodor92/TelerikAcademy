namespace JusTeeth.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Place
    {
        public Place()
        {
            this.Feedbacks = new HashSet<Feedback>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [MinLength(3)]
        [MaxLength(30)]
        public string AlternativeName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }

        public EatTimeType EatTime { get; set; }

        public double Rating { get; set; }

        public double MonthRating { get; set; }

        public PriceType PriceType { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }

        public virtual ICollection<ApplicationUser> Visitors { get; set; }
    }
}