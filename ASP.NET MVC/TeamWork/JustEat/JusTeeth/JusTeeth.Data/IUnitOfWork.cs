namespace JusTeeth.Data
{
    using System;
    using System.Linq;
    using JusTeeth.Models;

    public interface IUnitOfWork : IDisposable
    {
        IUsersRepository UsersRepository { get; }

        IRepository<Department> DepartmentRepository { get; }

        IRepository<Feedback> FeedbackRepository { get; }

        IRepository<HungryGroup> HungryGroupRepository { get; }

        IRepository<Place> PlaceRepository { get; }

        IRepository<Workplace> WorkplaceRepository { get; }

        IRepository<Image> Image { get; }

        int SaveChanges();
    }
}
