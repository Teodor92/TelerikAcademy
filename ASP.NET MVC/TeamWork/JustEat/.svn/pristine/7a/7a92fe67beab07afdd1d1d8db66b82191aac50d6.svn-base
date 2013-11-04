namespace JusTeeth.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using JusTeeth.Models;

    public class UnitOfWorkData : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UnitOfWorkData()
            : this(new ApplicationDbContext())
        {
        }

        public UnitOfWorkData(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IRepository<Image> Image
        {
            get
            {
                return this.GetRepository<Image>();
            }
        }

        public IUsersRepository UsersRepository
        {
            get
            {
                return (UsersRepository)this.GetRepository<ApplicationUser>();
            }
        }

        public IRepository<Department> DepartmentRepository
        {
            get
            {
                return this.GetRepository<Department>();
            }
        }

        public IRepository<Feedback> FeedbackRepository
        {
            get
            {
                return this.GetRepository<Feedback>();
            }
        }

        public IRepository<HungryGroup> HungryGroupRepository
        {
            get
            {
                return this.GetRepository<HungryGroup>();
            }
        }

        public IRepository<Place> PlaceRepository
        {
            get
            {
                return this.GetRepository<Place>();
            }
        }

        public IRepository<Workplace> WorkplaceRepository
        {
            get
            {
                return this.GetRepository<Workplace>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                if (typeof(T).IsAssignableFrom(typeof(ApplicationUser)))
                {
                    type = typeof (UsersRepository);
                }

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
