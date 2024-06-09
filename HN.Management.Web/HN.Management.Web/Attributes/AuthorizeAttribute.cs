using HN.Management.Engine.Models.Auth;
using HN.Management.Manager.Exceptions;
using HN.Management.Manager.Services.Interfaces;
using HN.Management.Manager.Services.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace HN.Management.Web.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string privilegeName;

        public AuthorizeAttribute(string privilege = "")
        {
            this.privilegeName = privilege;
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
            var identityWrapperService = context.HttpContext.RequestServices
                                        .GetService(typeof(IIdentityWrapperService)) as IdentityWrapperService;

            var fullAccessPrevilege = identityWrapperService.GetPrivilegeByName(PrivilegeConstants.FullAccess);

            var roles = identityWrapperService.GetRoles().ToList();
            var privilege = identityWrapperService.GetPrivilegeByName(privilegeName);
            var rolePrivileges = identityWrapperService.GetRolePrivilegeList().ToList();

            if (roleId is null || roles is null || privilege is null || rolePrivileges is null) return false;

            // Validate Roles
            var roleExist = roles.Any(role => role.Id == roleId);
            if (!roleExist) return false;

            if (string.IsNullOrWhiteSpace(privilegeName)) return true;

            // Check match roles and previleges
            return rolePrivileges
                .Any(rp => rp.RoleId == roleId &&
                (rp.PrivilegeId == privilege.Id ||
                 rp.PrivilegeId == fullAccessPrevilege.Id));
        }
    }
}
