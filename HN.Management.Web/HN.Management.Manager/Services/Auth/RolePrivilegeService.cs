
using HN.Management.Engine.Models.Auth;
using HN.Management.Engine.Repositories.Interfaces;
using HN.Management.Engine.ViewModels;
using HN.Management.Manager.Services.Interfaces;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.Auth
{
    public class RolePrivilegeService : IRolePrivilegeService
    {
        private readonly IRolePrivilegeRepository _rolePrivilegeRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IPrivilegeRepository _previlegeRepository;
        public RolePrivilegeService(IRolePrivilegeRepository rolePrivilegeRepository, IRoleRepository roleRepository,
            IPrivilegeRepository previlegeRepository)
        {
            _rolePrivilegeRepository = rolePrivilegeRepository;
            _roleRepository = roleRepository;
            _previlegeRepository = previlegeRepository;
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

        public async Task<RolePrivilegeResponse> AddUpdateAsync(RolePrivilegeRequest item)
        {
            var response = new RolePrivilegeResponse();
            var role = await _roleRepository.GetAsync(item.RoleId);
            var rolePrivileges = _rolePrivilegeRepository
                                        .GetRolePrivilegesByRoleId(item.RoleId);

            var privilegeIdsDb = rolePrivileges
                                    .Select(pid => pid.PrivilegeId)
                                    .ToList();

            var rolePrivilegeIdsDb = rolePrivileges
                                    .Select(pid => pid.Id)
                                    .ToList();
            if (role is null)
            {
                throw new Exception("Invalid Role");
            }

            // Remove unused role privileges
            await RemoveRolePrivilegesByPrevilegeAsync(rolePrivileges, item.PrivilegesIds);

            // Add new Role Privileges
            var rolePrivilegesToAdd = item.PrivilegesIds.Where(x => !privilegeIdsDb.Contains(x));
            foreach (var privilegeId in rolePrivilegesToAdd)
            {
                _ = await AddRolePrivilege(role.Id, privilegeId);
            }
              
            response.Role = role;
            response.PrivilegeDetails = await this.GetPrivilegeDetails(role.Id);
            return response;
        }

        public async Task<RolePrivilege> UpdateAsync(RolePrivilege item)
        {
            return await _rolePrivilegeRepository.UpdateAsync(item);
        }

        public List<RolePrivilege> GetRolePrivilegesByRoleId(string roleId)
        {
            return _rolePrivilegeRepository.GetRolePrivilegesByRoleId(roleId);
        }

        private async Task<List<PrivilegeDetails>> GetPrivilegeDetails(string roleId)
        {
            var details = new List<PrivilegeDetails>();
            var rolePrivilegesAssigned = _rolePrivilegeRepository
                                        .GetRolePrivilegesByRoleId(roleId);

            var rolePrivilegeIds = rolePrivilegesAssigned.Select(x => x.Id).ToList();

            foreach (var rolePrivilege in rolePrivilegesAssigned)
            {
                var privilege = await _previlegeRepository.GetAsync(rolePrivilege.PrivilegeId);
                // Fill Privilegedetails assigned
                details.Add(new PrivilegeDetails
                {
                    PrivilegeName = privilege.Name,
                    PrivilegeId = rolePrivilege.PrivilegeId,
                    RolePrivilegeId = rolePrivilege.Id,
                    IsAssigned = true,
                });
            }

            // Fill Privilegedetails unassigned
            var allPrivileges = await _previlegeRepository.GetAllAsync();
            var privilegesUnassigned = allPrivileges.Where(p => !details.Any(x => x.PrivilegeId.Contains(p.Id)));

            foreach (var unassigned in privilegesUnassigned)
            {
                details.Add(new PrivilegeDetails
                {
                    PrivilegeName = unassigned.Name,
                    PrivilegeId = unassigned.Id,
                    IsAssigned = false
                });
            }

            return details;
        }

        private async Task<RolePrivilege> AddRolePrivilege(string roleId, string privilegeId)
        {
            var rolePrivilege = new RolePrivilege
            {
                RoleId = roleId,
                PrivilegeId = privilegeId,
                Id = Guid.NewGuid().ToString("D")
            };

            return await _rolePrivilegeRepository.InsertAsync(rolePrivilege);
        }


        private async Task RemoveRolePrivilegesByPrevilegeAsync(List<RolePrivilege> rolePrivileges, List<string> privilegeIds)
        {
            var rolePrivilegesToRemove = rolePrivileges.Where(x => !privilegeIds.Contains(x.PrivilegeId));
            foreach (var rolePrivilege in rolePrivilegesToRemove)
            {
                await _rolePrivilegeRepository.Delete(rolePrivilege.Id);
            }
        }
    }
}
