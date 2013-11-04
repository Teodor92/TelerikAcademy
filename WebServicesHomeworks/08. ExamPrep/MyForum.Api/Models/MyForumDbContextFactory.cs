using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MyForum.Data;

namespace MyForum.Api.Models
{
    public class MyForumDbContextFactory : IDbContextFactory<DbContext>
    {
        public DbContext Create()
        {
            return new MyForumContext();
        }
    }
}
