using HN.Management.Engine.Repositories.Interfaces;
using HN.Management.Manager.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace HN.Management.Web.Attributes
{
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string privilege;
        private readonly IRolePrivilegeRepository rolePrivilegeRepository;
        private readonly IRoleRepository roleRepository;

        public AuthorizeAttribute(
            IRolePrivilegeRepository rolePrivilegeRepository,
            IRoleRepository roleRepository,
            string privilege = "")
        {
            this.privilege = privilege;
            this.rolePrivilegeRepository = rolePrivilegeRepository;
            this.roleRepository = roleRepository;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous) return;

            var roleId = context.HttpContext.Items["RoleId"];
            if (roleId == null)
                throw new UnauthorizedException();
             
            if (!ValidatePrivilege(Convert.ToString(roleId)))
                throw new ForbiddenException();
        }

        private bool ValidatePrivilege(string? roleId)
        {
            var roles = roleRepository.GetAll().ToList();
            var rolePrivileges = rolePrivilegeRepository.GetAll().ToList();

            if (roleId == null || roles == null) return false;

            // Validate Roles
            var roleExist = roles.Any(x => x.Id == roleId);
            if (!roleExist) return false;

            if (string.IsNullOrWhiteSpace(privilege)) return true;

            // Check match roles and previleges
            return rolePrivileges
                .Any(x => x.RoleId == roleId && x.Privilege == privilege);
        }
    }
}
