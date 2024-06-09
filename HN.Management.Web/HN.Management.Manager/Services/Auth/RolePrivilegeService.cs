
using HN.Management.Engine.Models.Auth;
using HN.Management.Engine.Repositories.Interfaces;
using HN.Management.Manager.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.Auth
{
    public class RolePrivilegeService : IRolePrivilegeService
    {
        private readonly IRolePrivilegeRepository _rolePrivilegeRepository;
        public RolePrivilegeService(IRolePrivilegeRepository rolePrivilegeRepository)
        {
            _rolePrivilegeRepository = rolePrivilegeRepository;
        }

        public IEnumerable<RolePrivilege> GetAll()
        {
            return _rolePrivilegeRepository.GetAll();
        }

        public async Task Delete(string id)
        {
            await _rolePrivilegeRepository.Delete(id);
        }

        public async Task<IEnumerable<RolePrivilege>> GetAllAsync()
        {
            return await _rolePrivilegeRepository.GetAllAsync();
        }

        public async Task<RolePrivilege> GetAsync(string id)
        {
            return await _rolePrivilegeRepository.GetAsync(id);
        }

        public async Task<RolePrivilege> InsertAsync(RolePrivilege item)
        {
            return await _rolePrivilegeRepository.InsertAsync(item);
        }

        public async Task<RolePrivilege> UpdateAsync(RolePrivilege item)
        {
            return await _rolePrivilegeRepository.UpdateAsync(item);
        }

        public List<RolePrivilege> GetRolePrivilegesByRoleId(string roleId)
        {
            return _rolePrivilegeRepository.GetRolePrivilegesByRoleId(roleId);
        }
    }
}
