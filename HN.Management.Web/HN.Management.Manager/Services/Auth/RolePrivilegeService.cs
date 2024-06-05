
using HN.Management.Engine.Models.Auth;
using HN.Management.Engine.Repositories.Interfaces;
using HN.Management.Manager.Services.Interfaces;
using System.Collections.Generic;

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
    }
}
