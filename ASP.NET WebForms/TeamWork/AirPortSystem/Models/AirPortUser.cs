using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace AirPortSystem.Models
{
    public class AirPortUser : User
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "First Name must be between 3-50 characters!")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last Name must be between 3-50 characters!")]
        public string LastName { get; set; }

        public byte[] Image { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
        public AirPortUser()
        {
            this.Tickets = new HashSet<Ticket>();
        }
    }
}