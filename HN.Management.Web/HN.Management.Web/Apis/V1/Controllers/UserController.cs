//using HN.Management.Engine.Models;
using HN.Management.Manager.Enums;
using HN.Management.Manager.Services.Interfaces;
using HN.Management.Web.Exceptions.Domain;
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
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IUserService _userService;
        public UsersController(IDistributedCache distributedCache, IUserService userService)
        {
            _distributedCache = distributedCache;
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _userService.GetAllAsync());
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            return Ok(await _userService.GetByIdAsync(id));
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync(User user)
        {
            return Ok(await _userService.CreateUserAsync(user));
        }

        /*[HttpPost]
        [Route("authenticate")]
        public IActionResult Aunthenticate(AuthenticateRequest entity)
        {
            var response =  _userService.AuthenticateRequest(entity);

            if(response == null)
            {
                return BadRequest(new { message = "Email or password is incorrect" });
            }

            return Ok(response);
        }*/

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync(User user)
        {
            return Ok(await _userService.UpdateAsync(user));
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            return Ok(await _userService.DeleteAsync(id));
        }

        [HttpGet]
        [Route("redis")]
        public async Task<IActionResult> GetAllActivitiessUsingRedisCache()
        {
            var cacheKey = CacheManagerKeys.Activities.ToString();
            string serializedActivitiesList;
            var activities = new List<ManagementEngine.Models.User>();
            var redisActivitiesList = await _distributedCache.GetAsync(cacheKey);

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
                await _distributedCache.SetAsync(cacheKey, redisActivitiesList, options);
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
