using HN.Management.Engine.Models.Auth;
using HN.Management.Manager.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.Wrappers
{
    public class IdentityWrapperService : IIdentityWrapperService
    {
        private readonly IRoleService _roleService;
        private readonly IPrivilegeService _privilegeService;
        private readonly IRolePrivilegeService _rolePrivilegeService;

        public IdentityWrapperService(
            IRoleService roleService,
            IPrivilegeService privilegeService,
            IRolePrivilegeService rolePrivilegeService)
        {
            _roleService = roleService;
            _privilegeService = privilegeService;
            _rolePrivilegeService = rolePrivilegeService;
        }

        #region Role

        public IEnumerable<Role> GetRoles()
        {
            return _roleService.GetAll();
        }

        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            return await _roleService.GetAllAsync();
        }

        public async Task<Role> GetRoleAsync(string id)
        {
            return await _roleService.GetAsync(id);
        }

        public async Task<Role> InsertRoleAsync(Role item)
        {
            return await _roleService.InsertAsync(item);
        }

        public async Task<Role> UpdateRoleAsync(Role item)
        {
            return await _roleService.UpdateAsync(item);
        }

        public async Task DeleteRole(string id)
        {
            await _roleService.Delete(id);
        }

        #endregion

        #region Privilege

        public List<Privilege> GetPrivilegesByRoleId(string roleId)
        {
            var privilegeIds = GetRolePrivilegesByRoleId(roleId)
                                   .Select(x => x.PrivilegeId)
                                   .ToList();

            return _privilegeService.GetPrivilegesByIds(privilegeIds);
        }

        public Privilege GetPrivilegeByName(string privilegeName)
        {
            return _privilegeService.GetPrivilegeByName(privilegeName);
        }

        public IEnumerable<Privilege> GetPrivileges()
        {
            return _privilegeService.GetAll();
        }

        public async Task<IEnumerable<Privilege>> GetPrivilegesAsync()
        {
            return await _privilegeService.GetAllAsync();
        }

        public async Task<Privilege> GetPrivilegeAsync(string id)
        {
            return await _privilegeService.GetAsync(id);
        }

        public async Task<Privilege> InsertPrivilegeAsync(Privilege item)
        {
            return await _privilegeService.InsertAsync(item);
        }

        public async Task<Privilege> UpdatePrivilegeAsync(Privilege item)
        {
            return await _privilegeService.UpdateAsync(item);
        }

        public async Task DeletePrivilege(string id)
        {
            await _privilegeService.Delete(id);
        }

        #endregion

        #region RolePrivilege
        public List<RolePrivilege> GetRolePrivilegesByRoleId(string roleId)
        {
            return _rolePrivilegeService.GetRolePrivilegesByRoleId(roleId);
        }

        public async Task<IEnumerable<RolePrivilege>> GetRolePrivilegeListAsync()
        {
            return await _rolePrivilegeService.GetAllAsync();
        }

        public async Task<RolePrivilege> GetRolePrivilegeAsync(string id)
        {
            return await _rolePrivilegeService.GetAsync(id);
        }

        public async Task<RolePrivilege> InsertRolePrivilegeAsync(RolePrivilege item)
        {
            return await _rolePrivilegeService.InsertAsync(item);
        }

        public async Task<RolePrivilege> UpdateRolePrivilegeAsync(RolePrivilege item)
        {
            return await _rolePrivilegeService.UpdateAsync(item);
        }

        public async Task DeleteRolePrivilege(string id)
        {
            await _rolePrivilegeService.Delete(id);
        }

        public IEnumerable<RolePrivilege> GetRolePrivilegeList()
        {
            return _rolePrivilegeService.GetAll();
        }
        #endregion
    }
}
