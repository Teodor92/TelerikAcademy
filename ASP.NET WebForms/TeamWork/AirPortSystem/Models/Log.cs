using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPortSystem.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }

        [StringLength(19, MinimumLength = 13, ErrorMessage = "Invalid Card Number!")]
        [Required]
        public string CardNumber { get; set; }

        [Required]
        public string CardType { get; set; }

        public DateTime DateBought { get; set; }

        public virtual AirPortUser User { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}