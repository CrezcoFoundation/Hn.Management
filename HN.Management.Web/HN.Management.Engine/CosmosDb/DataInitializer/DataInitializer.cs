using HN.Management.Engine.Models.Auth;
using HN.Management.Engine.Repositories;
using HN.Management.Engine.Repositories.Auth;
using HN.Management.Engine.Repositories.Interfaces;
using HN.ManagementEngine.Models;
using System;

namespace HN.Management.Engine.CosmosDb.DataInitializer
{
    public static class DataInitializer
    {

        private static IRoleRepository _roleRepository;
        private static IRolePrivilegeRepository _rolePrivilegeRepository;
        private static IUserRepository _userRepository;

        private static IRoleRepository roleRepository
        {
            get { return _roleRepository; }
        }

        private static IRolePrivilegeRepository rolePrivilegeRepository
        {
            get { return _rolePrivilegeRepository; }
        }

        private static IUserRepository userRepository
        {
            get { return _userRepository; }
        }

        public static void Run()
        {

            _roleRepository = roleRepository;
            _rolePrivilegeRepository = rolePrivilegeRepository;
            _userRepository = userRepository;

            var administratorRole = new Role
            {
                Id = Guid.NewGuid().ToString("D"),
                Name = "Administrator"
            };

            var operatorRole = new Role
            {
                Id = Guid.NewGuid().ToString("D"),
                Name = "Operator"
            };

            _roleRepository.InsertAsync(administratorRole);
            _roleRepository.InsertAsync(operatorRole);

            // create privileges
            var readRolePrivilegeAdmin = new RolePrivilege
            {
                Id = Guid.NewGuid().ToString("D"),
                RoleId = administratorRole.Id,
                Privilege = PrivilegeConstants.ReadUser
            };

            _rolePrivilegeRepository.InsertAsync(readRolePrivilegeAdmin);

            var createRolePrivilegeAdmin = new RolePrivilege
            {
                Id = Guid.NewGuid().ToString("D"),
                RoleId = administratorRole.Id,
                Privilege = PrivilegeConstants.CreateUser
            };

            _rolePrivilegeRepository.InsertAsync(createRolePrivilegeAdmin);

            var readRolePrivilegeOperator = new RolePrivilege
            {
                Id = Guid.NewGuid().ToString("D"),
                RoleId = operatorRole.Id,
                Privilege = PrivilegeConstants.ReadUser
            };

            _rolePrivilegeRepository.InsertAsync(readRolePrivilegeOperator);


            // create user
            var adminUser = new User
            {
                Id = Guid.NewGuid().ToString("D"),
                Email = "jearsoft@gmail.com",
                Username = "admin",
                Password = "CrezcoCrece@1",
                Role = administratorRole
            };

            _userRepository.InsertAsync(adminUser);

            var operatorUser = new User
            {
                Id = Guid.NewGuid().ToString("D"),
                Email = "anaeltrabajo@gmail.com",
                Username = "operator",
                Password = "operator",
                Role = operatorRole
            };

            _userRepository.InsertAsync(operatorUser);

        }
    }
}
