using HN.Management.Engine.Models.Auth;
using HN.Management.Engine.ViewModels;
using HN.Management.Manager.Exceptions;
using HN.Management.Manager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace HN.Management.Web.Apis.V1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdentityController : Controller
    {
        private readonly IIdentityWrapperService _identityWrapperService;
        public IdentityController(IIdentityWrapperService identityWrapperService)
        {
            _identityWrapperService = identityWrapperService;
        }

        #region Role Methods
        [HttpGet("roles")]
        public async Task<IActionResult> GetRolesAsync()
        {
            var roles = await _identityWrapperService.GetRolesAsync()
                ?? throw new ApiException(AppResource.InvalidCredentials, HttpStatusCode.Unauthorized);

            return Ok(roles);
        }

        [HttpGet("roles/{id}")]
        public async Task<IActionResult> GetRoleAsync(string id)
        {
            var role = await _identityWrapperService.GetRoleAsync(id)
                ?? throw new ApiException(AppResource.InvalidCredentials, HttpStatusCode.Unauthorized);

            return Ok(role);
        }

        [HttpPost("roles")]
        public async Task<IActionResult> InsertRoleAsync([FromBody] Role item)
        {
            var role = await _identityWrapperService.InsertRoleAsync(item)
                ?? throw new ApiException(AppResource.InvalidCredentials, HttpStatusCode.Unauthorized);

            return Ok(role);
        }

        [HttpPut("roles")]
        public async Task<IActionResult> UpdateRoleAsync([FromBody] Role item)
        {
            var role = await _identityWrapperService.UpdateRoleAsync(item)
                ?? throw new ApiException(AppResource.InvalidCredentials, HttpStatusCode.Unauthorized);

            return Ok(role);
        }

        [HttpDelete("roles/{id}")]
        public async Task DeleteRoleAsync([FromRoute] string id)
        {
            await _identityWrapperService.DeleteRole(id);
        }

        #endregion

        #region Privilege Methods
        [HttpGet("privileges")]
        public async Task<IActionResult> GetPrivilegesAsync()
        {
            var privileges = await _identityWrapperService.GetPrivilegesAsync()
                ?? throw new ApiException(AppResource.InvalidCredentials, HttpStatusCode.Unauthorized);

            return Ok(privileges);
        }

        [HttpGet("privileges/{id}")]
        public async Task<IActionResult> GetPrivilegeAsync([FromRoute] string id)
        {
            var privilege = await _identityWrapperService.GetPrivilegeAsync(id)
                ?? throw new ApiException(AppResource.InvalidCredentials, HttpStatusCode.Unauthorized);

            return Ok(privilege);
        }

        [HttpPost("privileges")]
        public async Task<IActionResult> InsertPrivilegeAsync([FromBody] Privilege item)
        {
            var privilege = await _identityWrapperService.InsertPrivilegeAsync(item)
                ?? throw new ApiException(AppResource.InvalidCredentials, HttpStatusCode.Unauthorized);

            return Ok(privilege);
        }

        [HttpPut("privileges")]
        public async Task<IActionResult> UpdatePrivilegeAsync([FromBody] Privilege item)
        {
            var privilege = await _identityWrapperService.UpdatePrivilegeAsync(item)
                ?? throw new ApiException(AppResource.InvalidCredentials, HttpStatusCode.Unauthorized);

            return Ok(privilege);
        }

        [HttpDelete("privileges/{id}")]
        public async Task DeletePrivilege([FromRoute] string id)
        {
            await _identityWrapperService.DeletePrivilege(id);
        }
        #endregion

        #region RolePrivileges Methods
        [HttpGet("role-privileges")]
        public async Task<IActionResult> GetRolePrivilegesAsync()
        {
            var rolePrivileges = await _identityWrapperService.GetRolePrivilegeListAsync()
                ?? throw new ApiException(AppResource.InvalidCredentials, HttpStatusCode.Unauthorized);

            return Ok(rolePrivileges);
        }

        [HttpGet("role-privileges/{id}")]
        public async Task<IActionResult> GetRolePrivilegeAsync([FromRoute] string id)
        {
            var rolePrivilege = await _identityWrapperService.GetRolePrivilegeAsync(id)
                ?? throw new ApiException(AppResource.InvalidCredentials, HttpStatusCode.Unauthorized);

            return Ok(rolePrivilege);
        }

        [HttpPost("role-privileges")]
        public async Task<IActionResult> AddUpdateRolePrivilegeAsync([FromBody] RolePrivilegeRequest item)
        {
            var rolePrivilege = await _identityWrapperService.AddUpdateAsync(item)
                ?? throw new ApiException(AppResource.InvalidCredentials, HttpStatusCode.Unauthorized);

            return Ok(rolePrivilege);
        }

        [HttpPut("role-privileges")]
        public async Task<IActionResult> UpdateRolePrivilegeAsync([FromBody] RolePrivilege item)
        {
            var rolePrivilege = await _identityWrapperService.UpdateRolePrivilegeAsync(item)
                ?? throw new ApiException(AppResource.InvalidCredentials, HttpStatusCode.Unauthorized);

            return Ok(rolePrivilege);
        }

        [HttpPut("role-privileges/{id}")]
        public async Task DeleteRolePrivilege([FromRoute] string id)
        {
            await _identityWrapperService.DeleteRolePrivilege(id);
        }
        #endregion

    }
}
