using System.Collections.Generic;
using System.Threading.Tasks;
using HN.Management.Engine.Repositories.Generic;
using HN.ManagementEngine.Models;

namespace HN.Management.Engine.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetUserByEmail(string email);
        Task<IEnumerable<User>> FilterUsers(User user);
    }
}
