using System;
using System.Collections.Generic;
using System.Linq;
using Exam.Models;

namespace Exam.Web.Models
{
    public class DetailedTicketViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public PriorityType Priority { get; set; }

        public string Author { get; set; }

        public string ScreenshotUrl { get; set; }

        public string Category { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}