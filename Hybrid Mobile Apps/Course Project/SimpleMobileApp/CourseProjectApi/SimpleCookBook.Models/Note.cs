using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCookBook.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(400), MinLength(3)]
        public string Title { get; set; }

        [Required]
        [MinLength(12)]
        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        [MaxLength(50), MinLength(3)]
        public string Author { get; set; }

        public string DeviceId { get; set; }

        public string PostAddress { get; set; }

        [Required]
        public DateTime PostDate { get; set; }

        public decimal Latitude { get; set; }

        public decimal Lontitude { get; set; }

        public Note()
        {
            this.Author = "Anonymous";
        }
    }
}
