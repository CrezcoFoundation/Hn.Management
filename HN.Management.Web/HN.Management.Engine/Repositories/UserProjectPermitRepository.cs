using HN.Management.Engine.Data;
using HN.Management.Engine.Repositories.Interfaces;
using HN.ManagementEngine.Models;

namespace HN.Management.Engine.Repositories
{
    public class UserProjectPermitRepository : GenericRepository<UserProjectPermit>, IUserProjectPermitRepository
    {
        public UserProjectPermitRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
    }
}
