using HN.Management.Engine.Models.Auth;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Engine.Repositories.Interfaces
{
    public interface IRolePrivilegeRepository
    {
        IQueryable<RolePrivilege> GetAllQueryable();
        IEnumerable<RolePrivilege> GetAll();
        Task<IEnumerable<RolePrivilege>> GetAllAsync();
        Task<RolePrivilege> GetAsync(string id);
        Task<RolePrivilege> InsertAsync(RolePrivilege item);
        Task<RolePrivilege> UpdateAsync(RolePrivilege item);
        Task Delete(string id);
    }
}
