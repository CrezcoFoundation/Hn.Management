using HN.Management.Engine.Models.Auth;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.Interfaces
{
    public interface IRolePrivilegeService
    {
        Task<IEnumerable<RolePrivilege>> GetAllAsync();
        Task<RolePrivilege> GetAsync(string id);
        Task<RolePrivilege> InsertAsync(RolePrivilege item);
        Task<RolePrivilege> UpdateAsync(RolePrivilege item);
        Task Delete(string id);
        IEnumerable<RolePrivilege> GetAll();
        List<RolePrivilege> GetRolePrivilegesByRoleId(string roleId);
    }
}