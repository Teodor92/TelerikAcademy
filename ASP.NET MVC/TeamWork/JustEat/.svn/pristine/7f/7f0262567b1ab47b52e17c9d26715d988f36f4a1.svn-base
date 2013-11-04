namespace JusTeeth.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Workplace
    {
        public Workplace()
        {
            this.Departments = new HashSet<Department>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public virtual ICollection<Department> Departments { get; set; }

        public virtual ICollection<ApplicationUser> Employees { get; set; }
    }
}
