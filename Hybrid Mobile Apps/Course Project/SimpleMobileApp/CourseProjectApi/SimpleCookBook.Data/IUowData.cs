using SimpleCookBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCookBook.Data
{
    public interface IUowData
    {
        // IRepository<Appli> Votes { get; }

        IRepository<Note> Notes { get; }

        int SaveChanges();
    }
}
