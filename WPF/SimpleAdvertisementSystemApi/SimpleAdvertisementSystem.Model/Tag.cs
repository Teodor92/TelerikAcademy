using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SimpleAdvertisementSystem.Model
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        [StringLength(40)]
        public string Title { get; set; }

        public ICollection<Advertisement> Advertisements { get; set; }

        public Tag()
        {
            this.Advertisements = new HashSet<Advertisement>();
        }
    }
}
