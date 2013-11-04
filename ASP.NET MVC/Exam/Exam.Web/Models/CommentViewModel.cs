using System;
using System.Linq;

namespace Exam.Web.Models
{
    public class CommentViewModel
    {
        public string Author { get; set; }

        public string Content { get; set; }

        public int TicketId { get; set; }
    }
}