using Microsoft.AspNetCore.Mvc;
using HN.Management.Manager.Services.Interfaces;
using System.Net;
using HN.Management.Manager.Exceptions;
using System.Threading.Tasks;
using HN.Management.Engine.ViewModels;
using Microsoft.AspNetCore.Authorization;
using HN.Management.Manager.Services;
using AutoMapper;
using HN.ManagementEngine.Models;

namespace HN.Management.Web.Apis.V1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserService userService;
        private readonly TokenService tokenService;
        private readonly IMapper _mapper;

        public AuthController(IUserService userService, TokenService tokenService, IMapper mapper)
        {
            this.userService = userService;
            this.tokenService = tokenService;
            this._mapper = mapper;
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

            var userResponse = await this.userService.GetUserAsync(loginRequest)
                ?? throw new ApiException(AppResource.InvalidCredentials, HttpStatusCode.Unauthorized);

            var user = _mapper.Map<User>(userResponse); 
            var token = tokenService.GenerateToken(user);

            return Ok(new
            {
                AccessToken = token,
                User = user,
            });
        }
    }
}
