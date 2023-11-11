using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using HN.Management.Manager.Services.Interfaces;
using HN.Management.Engine.Models.Auth;
using System.Net;
using HN.Management.Manager.Exceptions;
using System.Threading.Tasks;

namespace HN.Management.Web.Apis.V1.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        public LoginController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("auth")]
        public async Task<IActionResult> AuthenticateAsync([FromBody]LoginRequest loginRequest)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(loginRequest == null)
            {
                throw new ApiException(AppResource.InvalidCredentials, HttpStatusCode.Unauthorized);
            }

            var result = await this._userService.GetEmail(loginRequest.Email, loginRequest.Password);

            if(result == null)
            {
                throw new ApiException(AppResource.InvalidCredentials, HttpStatusCode.Unauthorized);
            }

            var token = _tokenService.GenerateToken(result);
            return Ok(token);
        }
               
    }
}
