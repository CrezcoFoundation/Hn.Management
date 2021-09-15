using HN.Management.Engine.Data;
using HN.Management.Engine.Repositories.Interfaces;
using HN.ManagementEngine.Models;

namespace HN.Management.Engine.Repositories
{
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
    }
}
