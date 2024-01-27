//using HN.Management.Engine.Models;
using HN.Management.Engine.Models.Auth;
using HN.Management.Manager.Enums;
using HN.Management.Manager.Exceptions;
using HN.Management.Manager.Services.Interfaces;
using HN.Management.Web.Attributes;
using HN.ManagementEngine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HN.Management.Web.Apis.V1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IDistributedCache distributedCache;
        private readonly IUserService userService;
        public UserController(IDistributedCache distributedCache, IUserService userService)
        {
            this.distributedCache = distributedCache;
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

        [HttpGet("redis")]
        public async Task<IActionResult> GetAllActivitiessUsingRedisCache()
        {
            var cacheKey = CacheManagerKeys.Activities.ToString();
            string serializedActivitiesList;
            var activities = new List<ManagementEngine.Models.User>();
            var redisActivitiesList = await distributedCache.GetAsync(cacheKey);

            if (redisActivitiesList != null)
            {
                serializedActivitiesList = Encoding.UTF8.GetString(redisActivitiesList);
                activities = JsonConvert.DeserializeObject<List<ManagementEngine.Models.User>>(serializedActivitiesList);
            }
            else
            {
                serializedActivitiesList = JsonConvert.SerializeObject(activities);
                redisActivitiesList = Encoding.UTF8.GetBytes(serializedActivitiesList);
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                await distributedCache.SetAsync(cacheKey, redisActivitiesList, options);
            }
            return Ok(activities);
        }

        [HttpGet]
        [Route("exception")]
        public void GetDomainException()
        {
            int product = 0;
            if (product == 0)
            {
                var ex = new Exception();
                ex.HResult = (int)HttpStatusCode.NotFound;
                throw new DomainException($"El Product with id {product} could not be found.", ex);
            }
        }
    }
}
