using JusTeeth.App.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JusTeeth.App.ViewModels
{
    public class CreateGroupViewModel
    {
        [Display(Name = "Place")]
        [Required(ErrorMessage = "Please specify place!")]
        public string Place { get; set; }

        [Display(Name = "Starting time")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Pleace specify starting time!")]
        [DateTimeRangeAttribute(ErrorMessage="Please choose valid starting time!")]
        public DateTime StartingTime { get; set; }

        public List<PlaceViewModel> PushPinPlaces { get; set; }
    }
}