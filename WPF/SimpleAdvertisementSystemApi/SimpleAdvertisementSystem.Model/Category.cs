using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAdvertisementSystem.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Advertisement> Advertisements { get; set; }

        public Category()
        {
            this.Advertisements = new HashSet<Advertisement>();
        }
    }
}
