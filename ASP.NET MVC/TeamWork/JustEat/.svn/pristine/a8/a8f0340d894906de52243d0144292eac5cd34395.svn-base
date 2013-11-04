namespace JusTeeth.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationUser : User
    {
        public ApplicationUser()
            : base()
        {
            this.LastPlaces = new HashSet<Place>();
            this.Friends = new HashSet<ApplicationUser>();
            this.GroupHistory = new HashSet<HungryGroup>();
        }

        // UserName and Password inherited from User
        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string DisplayName { get; set; }

        public string Avatar { get; set; }

        [MinLength(10)]
        [MaxLength(256)]
        public string FacebookProfile { get; set; }

        public virtual Department Department { get; set; }

        public virtual Workplace Workplace { get; set; }

        public virtual ICollection<Place> LastPlaces { get; set; }

        public virtual ICollection<ApplicationUser> Friends { get; set; }

        public virtual ICollection<HungryGroup> GroupHistory { get; set; }
    }
}