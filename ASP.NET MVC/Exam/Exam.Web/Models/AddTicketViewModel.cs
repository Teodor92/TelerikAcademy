using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Exam.Models;

namespace Exam.Web.Models
{
    public class AddTicketViewModel
    {
        public string CategoryId { get; set; }

        [ShouldNotContainBugWord(ErrorMessage = "There is a bug in yo title!")]
        public string Title { get; set; }

        public PriorityType Priority { get; set; }

        [StringLength(100, ErrorMessage = "Screen url must be between 3 and 100 characters", MinimumLength = 3)]
        public string ScreenUrl { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(50000, ErrorMessage = "Description must have atleast 12 characters", MinimumLength = 12)]
        public string Description { get; set; }

        public List<SelectListItem> CategoryDropdown { get; set; }

        public List<SelectListItem> PriorityTypeDropdown { get; set; }
    }
}