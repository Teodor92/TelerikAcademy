using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace AirPortSystem.Models
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "FromAirPort must be between 3-50 characters!")]
        public string FromAirPort { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "ToAirPort must be between 3-50 characters!")]
        public string ToAirPort { get; set; }

        [Required]
        [Range(typeof(DateTime), "1-Jan-1910", "1-Jan-2014", ErrorMessage = "DateTime must be between 1-Jan-1910 and 1-Jan-2014")]
        public DateTime FlightDate { get; set; }
        
        [Required]
        [Range(0, 150)]
        public int AvailableTickets { get; set; }

        [Required]
        [Range(0, 999999999, ErrorMessage = "Invalid Value (0 - 999999999")]
        public decimal Price { get; set; }
    }
}