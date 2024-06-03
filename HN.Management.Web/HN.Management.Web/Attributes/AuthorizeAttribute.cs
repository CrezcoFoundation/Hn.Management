using HN.Management.Manager.Exceptions;
using HN.Management.Manager.Services.Auth;
using HN.Management.Manager.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace HN.Management.Web.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string privilege;

        public AuthorizeAttribute(string privilege = "")
        {
            this.privilege = privilege;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous) return;

            var roleId = context.HttpContext.Items["RoleId"];
            var userId = context.HttpContext.Items["UserId"];
            if (roleId is null || userId is null)
                throw new UnauthorizedException();

            if (!ValidatePrivilege(Convert.ToString(roleId), context))
                throw new ForbiddenException();
        }

        private bool ValidatePrivilege(string? roleId, AuthorizationFilterContext context)
        {
            var roleService = context.HttpContext.RequestServices.GetService(typeof(IRoleService)) as RoleService;
            var rolePrivilegeService = context.HttpContext.RequestServices.GetService(typeof(IRolePrivilegeService)) as RolePrivilegeService;

            var roles = roleService.GetAll().ToList();
            var rolePrivileges = rolePrivilegeService.GetAll().ToList();

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
