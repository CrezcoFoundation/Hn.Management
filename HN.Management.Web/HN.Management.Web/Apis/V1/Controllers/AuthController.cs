using Microsoft.AspNetCore.Mvc;
using HN.Management.Manager.Services.Interfaces;
using System.Net;
using HN.Management.Manager.Exceptions;
using System.Threading.Tasks;
using HN.Management.Engine.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace HN.Management.Web.Apis.V1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        public AuthController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost]
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

            var user = await this._userService.GetUserAsync(loginRequest);

            if (user == null)
            {
                throw new ApiException(AppResource.InvalidCredentials, HttpStatusCode.Unauthorized);
            }

            var token = _tokenService.GenerateToken(user);
            return Ok(token);
        }

    }
}
