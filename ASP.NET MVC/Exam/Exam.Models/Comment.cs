using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string PostedById { get; set; }

        public ApplicationUser PostedBy { get; set; }

        public int TicketId { get; set; }

        public Ticket Ticket { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }
    }
}
