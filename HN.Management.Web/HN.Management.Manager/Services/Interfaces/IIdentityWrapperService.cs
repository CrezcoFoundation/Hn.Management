using HN.Management.Engine.Models.Auth;
using HN.Management.Engine.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.Interfaces
{
    public interface IIdentityWrapperService
    {
        // Roles
        IEnumerable<Role> GetRoles();
        Task<IEnumerable<Role>> GetRolesAsync();
        Task<Role> GetRoleAsync(string id);
        Task<Role> InsertRoleAsync(Role item);
        Task<Role> UpdateRoleAsync(Role item);
        Task DeleteRole(string id);

        // Privilege
        List<Privilege> GetPrivilegesByRoleId(string roleId);
        Privilege GetPrivilegeByName(string privilegeName);
        IEnumerable<Privilege> GetPrivileges();
        Task<IEnumerable<Privilege>> GetPrivilegesAsync();
        Task<Privilege> GetPrivilegeAsync(string id);
        Task<Privilege> InsertPrivilegeAsync(Privilege item);
        Task<Privilege> UpdatePrivilegeAsync(Privilege item);
        Task DeletePrivilege(string id);

        // RolePrivilege
        Task<IEnumerable<RolePrivilege>> GetRolePrivilegeListAsync();
        Task<RolePrivilege> GetRolePrivilegeAsync(string id);
        Task<RolePrivilegeResponse> AddUpdateAsync(RolePrivilegeRequest item);
        Task<RolePrivilege> UpdateRolePrivilegeAsync(RolePrivilege item);
        Task DeleteRolePrivilege(string id);
        IEnumerable<RolePrivilege> GetRolePrivilegeList();
        List<RolePrivilege> GetRolePrivilegesByRoleId(string roleId);
    }
}
