using HN.Management.Engine.CosmosDb.Interfaces;
using HN.Management.Engine.Models.Auth;
using HN.Management.Engine.Repositories.Interfaces;
using HN.ManagementEngine.Models;
using System;

namespace HN.Management.Engine.CosmosDb.DataInitializer
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IRoleRepository roleRepository;
        private readonly IRolePrivilegeRepository rolePrivilegeRepository;
        private readonly IUserRepository userRepository;

        public DataInitializer(
            IRoleRepository roleRepository,
            IRolePrivilegeRepository rolePrivilegeRepository,
            IUserRepository userRepository)
        {
            this.roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
            this.rolePrivilegeRepository = rolePrivilegeRepository ?? throw new ArgumentNullException(nameof(rolePrivilegeRepository));
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));

        }

        public void SeedDatabase()
        {
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

            roleRepository.InsertAsync(administratorRole);
            roleRepository.InsertAsync(operatorRole);

            // create privileges
            var readRolePrivilegeAdmin = new RolePrivilege
            {
                Id = Guid.NewGuid().ToString("D"),
                RoleId = administratorRole.Id,
                Privilege = PrivilegeConstants.ReadUser
            };

            rolePrivilegeRepository.InsertAsync(readRolePrivilegeAdmin);

            var createRolePrivilegeAdmin = new RolePrivilege
            {
                Id = Guid.NewGuid().ToString("D"),
                RoleId = administratorRole.Id,
                Privilege = PrivilegeConstants.CreateUser
            };

            rolePrivilegeRepository.InsertAsync(createRolePrivilegeAdmin);

            var readRolePrivilegeOperator = new RolePrivilege
            {
                Id = Guid.NewGuid().ToString("D"),
                RoleId = operatorRole.Id,
                Privilege = PrivilegeConstants.ReadUser
            };

            rolePrivilegeRepository.InsertAsync(readRolePrivilegeOperator);


            // create user
            var adminUser = new User
            {
                Id = Guid.NewGuid().ToString("D"),
                Email = "jearsoft@gmail.com",
                Username = "admin",
                Password = "CrezcoCrece@1",
                Role = administratorRole
            };

            userRepository.InsertAsync(adminUser);

            var operatorUser = new User
            {
                Id = Guid.NewGuid().ToString("D"),
                Email = "anaeltrabajo@gmail.com",
                Username = "operator",
                Password = "operator",
                Role = operatorRole
            };

            userRepository.InsertAsync(operatorUser);

        }
    }
}
