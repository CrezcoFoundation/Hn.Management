using HN.Management.Engine.Models.Auth;
using HN.Management.Engine.Repositories.Interfaces;
using HN.Management.Engine.Util;
using HN.Management.Engine.ViewModels;
using HN.Management.Manager.Exceptions;
using HN.Management.Manager.Services.Interfaces;
using HN.ManagementEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.DataInitializer
{
    public class DataInitializerService : IDataInitializerService
    {
        private const string createdByName = "System";
        private readonly IIdentityWrapperService _identityWrapperService;
        private readonly IUserRepository _userRepository;
        public DataInitializerService(
            IIdentityWrapperService identityWrapperService,
            IUserRepository userRepository)
        {
            _identityWrapperService = identityWrapperService;
            _userRepository = userRepository;
        }

        public async Task SeedDatabase()
        {
            // Create Roles
            var roles = await CreateRoles();

            // create privileges
            var privileges = await CreatePrivileges();

            // create RolePrivileges
            await CreateRolePrivileges(roles, privileges);

            // create CreateUsers
            await CreateUsers(roles);
        }

        private async Task<List<Role>> CreateRoles()
        {
            var adminRole = new Role
            {
                Id = Guid.NewGuid().ToString("D"),
                Name = RoleConstant.Administrator,
                CreatedByName = createdByName,
            };

            var donorRole = new Role
            {
                Id = Guid.NewGuid().ToString("D"),
                Name = RoleConstant.Donor,
                CreatedByName = createdByName,
            };

            var roles = _identityWrapperService.GetRoles();

            if (!roles.Any())
            {
                var newRoles = new List<Role>();

                adminRole = await _identityWrapperService.InsertRoleAsync(adminRole);
                newRoles.Add(adminRole);

                donorRole = await _identityWrapperService.InsertRoleAsync(donorRole);
                newRoles.Add(donorRole);

                return newRoles;
            }

            return roles.ToList();
        }

        private async Task<List<Privilege>> CreatePrivileges()
        {
            var fullAccess = new Privilege
            {
                Id = Guid.NewGuid().ToString("D"),
                Name = PrivilegeConstants.FullAccess,
                CreatedByName = createdByName,
            };

            var readUser = new Privilege
            {
                Id = Guid.NewGuid().ToString("D"),
                Name = PrivilegeConstants.ReadUser,
                CreatedByName = createdByName,
            };

            var readUsers = new Privilege
            {
                Id = Guid.NewGuid().ToString("D"),
                Name = PrivilegeConstants.ReadUsers,
                CreatedByName = createdByName,
            };

            var createUser = new Privilege
            {
                Id = Guid.NewGuid().ToString("D"),
                Name = PrivilegeConstants.CreateUser,
                CreatedByName = createdByName,
            };

            var updateUser = new Privilege
            {
                Id = Guid.NewGuid().ToString("D"),
                Name = PrivilegeConstants.UpdateUser,
                CreatedByName = createdByName,
            };

            var privileges = _identityWrapperService.GetPrivileges().ToList();

            if (!privileges.Any())
            {
                var newPrivileges = new List<Privilege>();

                fullAccess = await _identityWrapperService.InsertPrivilegeAsync(fullAccess);
                readUser = await _identityWrapperService.InsertPrivilegeAsync(readUser);
                readUsers = await _identityWrapperService.InsertPrivilegeAsync(readUsers);
                createUser = await _identityWrapperService.InsertPrivilegeAsync(createUser);
                updateUser = await _identityWrapperService.InsertPrivilegeAsync(updateUser);

                newPrivileges.Add(readUsers);
                newPrivileges.Add(createUser);
                newPrivileges.Add(fullAccess);
                newPrivileges.Add(readUser);
                newPrivileges.Add(updateUser);

                return newPrivileges;
            }

            return privileges.ToList();
        }

        private async Task CreateRolePrivileges(List<Role> roles, List<Privilege> privileges)
        {
            var rolePrivileges = _identityWrapperService.GetRolePrivilegeList();

            if (!rolePrivileges.Any())
            {
                foreach (var role in roles)
                {
                    // Create Role Privileges for:
                    // Administrator role privileges
                    if (role.Name.Equals(RoleConstant.Administrator))
                    {
                        var privilegesIds = privileges.Where(x => x.Name == PrivilegeConstants.FullAccess)
                                                      .Select(p => p.Id)
                                                      .ToList()
                                                     ?? throw new ApiException("Error seeeding database...");

                        await CreateRolePrivileges(role.Id, privilegesIds);
                    }

                    // Donor Privileges
                    if (role.Name.Equals(RoleConstant.Donor))
                    {
                        var privilegesIds = privileges.Where(x => x.Name.Contains(PrivilegeConstants.ReadUser) ||
                                                                  x.Name.Contains(PrivilegeConstants.CreateUser) ||
                                                                  x.Name.Contains(PrivilegeConstants.UpdateUser) ||
                                                                  x.Name.Contains(PrivilegeConstants.CreateDonation) ||
                                                                  x.Name.Contains(PrivilegeConstants.ReadDonation) ||
                                                                  x.Name.Contains(PrivilegeConstants.UpdateDonation))
                                                      .Select(p => p.Id)
                                                      .ToList()
                                                     ?? throw new ApiException("Error seeeding database...");

                        await CreateRolePrivileges(role.Id, privilegesIds);
                    }
                }
            }
        }

        private async Task CreateRolePrivileges(string roleId, List<string> privilegesIds)
        {
            var rolePrivilegeRequest = new RolePrivilegeRequest()
            {
                RoleId = roleId,
                PrivilegesIds = privilegesIds
            };

            _ = await _identityWrapperService.AddUpdateAsync(rolePrivilegeRequest);
        }

        private async Task CreateUsers(List<Role> roles)
        {
            var adminUser = new User
            {
                Id = Guid.NewGuid().ToString("D"),
                Email = "admin@gmail.com",
                Username = "admin",
                PasswordHash = PasswordHelper.HashPassword("CrezcoCrece@1"),
                Role = roles.FirstOrDefault(x => x.Name == RoleConstant.Administrator),
            };

            var donorUser = new User
            {
                Id = Guid.NewGuid().ToString("D"),
                Email = "donor@gmail.com",
                Username = "donor01",
                PasswordHash = PasswordHelper.HashPassword("CrezcoCrece@1"),
                Role = roles.FirstOrDefault(x => x.Name == RoleConstant.Donor),
            };

            var users = _userRepository.GetAll().ToList();
            if (!users.Any())
            {
                _ = _userRepository.InsertAsync(adminUser);
                _ = _userRepository.InsertAsync(donorUser);
            }
        }
    }
}
