using HN.Management.Engine.Data;
using HN.Management.Engine.Repositories.Interfaces;
using HN.ManagementEngine.Models;

namespace HN.Management.Engine.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            
        }
    }
}
