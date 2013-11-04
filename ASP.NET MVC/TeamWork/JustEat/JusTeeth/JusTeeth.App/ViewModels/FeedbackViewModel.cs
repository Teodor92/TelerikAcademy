using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using JusTeeth.Models;

namespace JusTeeth.App.ViewModels
{
    public class FeedbackViewModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public EatTimeType EatTime { get; set; }

        public PriceType PriceType { get; set; }

        [Required]
        public int Rating { get; set; }

        public LightUserViewModel User { get; set; }
    }
}