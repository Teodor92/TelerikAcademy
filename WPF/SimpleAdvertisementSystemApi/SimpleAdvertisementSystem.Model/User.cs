using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAdvertisementSystem.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string AuthenticationCode { get; set; }

        public string AccessToken { get; set; }

        public ICollection<Advertisement> Advertisements { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public User()
        {
            this.Advertisements = new HashSet<Advertisement>();
            this.Comments = new HashSet<Comment>();
        }
    }
}
