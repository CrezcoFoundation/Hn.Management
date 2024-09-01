
using HN.Management.Engine.Models.Auth;
using HN.Management.Engine.Repositories.Interfaces;
using HN.Management.Engine.ViewModels;
using HN.Management.Manager.Services.Interfaces;
using System;
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

        public async Task<List<RolePrivilege>> InsertAsync(RolePrivilegeRequest item)
        {
            var rolePrivileges = new List<RolePrivilege>();
            foreach (var privilegesId in item.PrivilegesIds)
            {
                var rolePrivilege = new RolePrivilege
                {
                    RoleId = item.RoleId,
                    PrivilegeId = privilegesId,
                    Id = Guid.NewGuid().ToString("D")
                };

                var result = await _rolePrivilegeRepository.InsertAsync(rolePrivilege);
                rolePrivileges.Add(result);
            }

            return rolePrivileges;
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
