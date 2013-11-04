using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleWebApp.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string WebSite { get; set; }

        public string ISBN { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public Category Category { get; set; }
    }
}