namespace Exam.Web.Models
{
    using System;
    using System.Linq;

    public class HomeTicketViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CategoryName { get; set; }

        public string Author { get; set; }

        public int NumberOfComments { get; set; }
    }
}