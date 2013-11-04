namespace JusTeeth.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class HungryGroup
    {
        public HungryGroup()
        {
            this.HungryUsers = new HashSet<ApplicationUser>();
        }

        [Key]
        public int Id { get; set; }

        public virtual ApplicationUser Creator { get; set; }

        public DateTime StartingTime { get; set; }

        public EatTimeType EatTime { get; set; }

        public virtual Place Place { get; set; }

        public virtual ICollection<ApplicationUser> HungryUsers { get; set; }
    }
}