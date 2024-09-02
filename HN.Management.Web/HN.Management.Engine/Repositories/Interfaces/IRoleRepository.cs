using HN.Management.Engine.Models.Auth;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Engine.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        IQueryable<Role> GetAllQueryable();
        IEnumerable<Role> GetAll();
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role> GetAsync(string id);
        Task<Role> InsertAsync(Role item);
        Task<Role> UpdateAsync(Role item);
        Task Delete(string id);
        Task<bool> RoleExistsAsync(string id);
    }
}
