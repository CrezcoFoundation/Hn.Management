//using HN.Management.Engine.Models;
using HN.Management.Manager.Enums;
using HN.Management.Manager.Services.Interfaces;
using HN.Management.Web.Exceptions.Domain;
using HN.ManagementEngine.DTO;
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
    [Route("api/user")]
    public class UsersController : Controller
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IUserService _userService;
        public UsersController(IDistributedCache distributedCache, IUserService userService)
        {
            _distributedCache = distributedCache;
            _userService = userService;
        }

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _userService.GetAllAsync());
        }

        [HttpGet]
        [Route("user")]
        public async Task<IActionResult> GetByConditionAsync(int userId)
        {
            return Ok(await _userService.GetByConditionAsync(userId));
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> AddAsync(UserDTO user)
        {
            return Ok(await _userService.AddAsync(user));
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
        public async Task<IActionResult> UpdateAsync(UserDTO user)
        {
            return Ok(await _userService.UpdateAsync(user));
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteAsync(UserDTO user)
        {
            return Ok(await _userService.DeleteAsync(user));
        }

        [HttpGet]
        [Route("redis")]
        public async Task<IActionResult> GetAllActivitiessUsingRedisCache()
        {
            var cacheKey = CacheManagerKeys.Activities.ToString();
            string serializedActivitiesList;
            var activities = new List<User>();
            var redisActivitiesList = await _distributedCache.GetAsync(cacheKey);

            if (redisActivitiesList != null)
            {
                serializedActivitiesList = Encoding.UTF8.GetString(redisActivitiesList);
                activities = JsonConvert.DeserializeObject<List<User>>(serializedActivitiesList);
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
