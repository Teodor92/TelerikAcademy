using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleAdvertisementSystem.Model;

namespace SimpleAdvertisementSystem.Data
{
    public class AdvertisementSystemContext : DbContext
    {
        public AdvertisementSystemContext()
            : base("SimpleAdSystemDb")
        {
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Tag> Tags { get; set; }

        public IDbSet<Advertisement> Advertisements { get; set; }

        public IDbSet<Category> Categories { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Configurations.Add(new AppointmentMap());
        //    modelBuilder.Configurations.Add(new StateMap());
        //    modelBuilder.Configurations.Add(new TodoListMap());
        //    modelBuilder.Configurations.Add(new TodoMap());
        //    modelBuilder.Configurations.Add(new UserMap());


        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
