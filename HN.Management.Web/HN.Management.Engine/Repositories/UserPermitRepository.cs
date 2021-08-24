using HN.Management.Engine.Data;
using HN.Management.Engine.Repositories.Interfaces;
using HN.ManagementEngine.Models;

namespace HN.Management.Engine.Repositories
{
    public class UserPermitRepository : GenericRepository<UserPermit>, IUserPermitRepository
    {
        public UserPermitRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
    }
}
