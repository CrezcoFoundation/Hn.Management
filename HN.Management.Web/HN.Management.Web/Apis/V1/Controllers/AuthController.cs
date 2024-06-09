using Microsoft.AspNetCore.Mvc;
using HN.Management.Manager.Services.Interfaces;
using System.Net;
using HN.Management.Manager.Exceptions;
using System.Threading.Tasks;
using HN.Management.Engine.ViewModels;
using Microsoft.AspNetCore.Authorization;
using HN.Management.Manager.Services;
using System.Linq;

namespace HN.Management.Web.Apis.V1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserService userService;
        private readonly TokenService tokenService;
        private readonly IIdentityWrapperService identityWrapperService;
        public AuthController(
            IUserService userService,
            TokenService tokenService,
            IIdentityWrapperService identityWrapperService)
        {
            this.userService = userService;
            this.tokenService = tokenService;
            this.identityWrapperService = identityWrapperService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (loginRequest == null)
            {
                throw new ApiException(AppResource.InvalidCredentials, HttpStatusCode.Unauthorized);
            }

            var user = await this.userService.GetUserAsync(loginRequest)
                ?? throw new ApiException(AppResource.InvalidCredentials, HttpStatusCode.Unauthorized);

            var privileges = identityWrapperService.GetPrivilegesByRoleId(user?.Role.Id)
                                                   .Select(x => x.Name)
                                                   .ToList();

            if (privileges is null)
            {
                throw new ApiException(AppResource.InvalidCredentials, HttpStatusCode.NotFound);
            }

            var token = tokenService.GenerateToken(user, privileges);

            return Ok(new
            {
                AccessToken = token,
            });
        }
    }
}
