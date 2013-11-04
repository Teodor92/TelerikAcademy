using JusTeeth.Models;

namespace JusTeeth.Data
{
    public interface IUsersRepository : IRepository<ApplicationUser>
    {
        ApplicationUser GetUserByUserId(string userId);

        ApplicationUser GetUserByUsername(string username);
    }
}
