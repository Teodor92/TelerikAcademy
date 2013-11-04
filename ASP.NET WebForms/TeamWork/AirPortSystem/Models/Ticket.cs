using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace AirPortSystem.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        public virtual Flight Flight { get; set; }

        public virtual AirPortUser User { get; set; }
    }
}