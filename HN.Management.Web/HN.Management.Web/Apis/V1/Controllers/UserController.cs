using HN.Management.Engine.Models.Auth;
using HN.Management.Manager.Services.Interfaces;
using HN.Management.Web.Attributes;
using HN.ManagementEngine.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HN.Management.Web.Apis.V1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [Authorize(PrivilegeConstants.ReadUser)]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await userService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            return Ok(await userService.GetByIdAsync(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(User user)
        {
            return Ok(await userService.CreateUserAsync(user));
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync(User user)
        {
            return Ok(await userService.UpdateAsync(user));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            return Ok(await userService.DeleteAsync(id));
        }
    }
}
