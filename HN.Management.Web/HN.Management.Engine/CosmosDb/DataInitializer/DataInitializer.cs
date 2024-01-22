using HN.Management.Engine.Models.Auth;
using HN.ManagementEngine.Models;

namespace HN.Management.Engine.CosmosDb.DataInitializer
{
    public static class DataInitializer
    {
        public static void Run()
        {
            var adminRole = new Role
            {
                Name = "Administrator"
            };

            var operatorRole = new Role
            {
                Name = "Operator"
            };


            // create privileges
            db.RolePrivilege.Add(new RolePrivilege
            {
                RoleId = adminRole.Id,
                Privilege = PrivilegeConstants.ReadUser
            });

            db.RolePrivilege.Add(new RolePrivilege
            {
                RoleId = adminRole.Id,
                Privilege = PrivilegeConstants.CreateUser
            });

            db.RolePrivilege.Add(new RolePrivilege
            {
                RoleId = operatorRole.Id,
                Privilege = PrivilegeConstants.ReadUser
            });


            // create user
            var adminUser = new User
            {
                Username = "admin",
                Password = "CrezcoCrece@1",
                RoleId = adminRole.Id
            };
            db.User.Add(adminUser);

            var operatorUser = new User
            {
                Username = "operator",
                Password = "operator",
                RoleId = operatorRole.Id
            };
            db.User.Add(operatorUser);
        }
    }
}
