using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCookBook.Models;

namespace SimpleCookBook.Data
{
    public class ApplicationDbContext : DbContext
    {
        public IDbSet<Note> Notes { get; set; }

        public ApplicationDbContext()
            : base("CookBookDb")
        {
        }
    }
}
