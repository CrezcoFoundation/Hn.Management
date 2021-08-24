using HN.Management.Engine.Data;
using HN.Management.Engine.Repositories.Interfaces;
using HN.ManagementEngine.Models;

namespace HN.Management.Engine.Repositories
{
    public class UserDonorPermitRepository : GenericRepository<UserDonorPermit>, IUserDonorPermitRepository
    {
        public UserDonorPermitRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
    }
}
