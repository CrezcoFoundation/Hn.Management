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
    [Route("api/userprojectpermit")]
    public class UserPermitsController : Controller
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IUserPermitService _userPermitService;
        public UserPermitsController(IDistributedCache distributedCache, IUserPermitService userPermitService)
        {
            _distributedCache = distributedCache;
            _userPermitService = userPermitService;
        }

        [HttpGet]
        [Route("userdonorpermits")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _userPermitService.GetAllAsync());
        }

        [HttpGet]
        [Route("userdonorpermit")]
        public async Task<IActionResult> GetByConditionAsync(int userDonorPermitId)
        {
            return Ok(await _userPermitService.GetByConditionAsync(userDonorPermitId));
        }

        [HttpGet]
        [Route("user")]
        public async Task<IActionResult> GetByUserAsync(int userId)
        {
            return Ok(await _userPermitService.GetByUserAsync(userId));
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> AddAsync(UserPermitDTO userProjectPermit)
        {
            return Ok(await _userPermitService.AddAsync(userProjectPermit));
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync(UserPermitDTO userProjectPermit)
        {
            return Ok(await _userPermitService.UpdateAsync(userProjectPermit));
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteAsync(UserPermitDTO userProjectPermit)
        {
            return Ok(await _userPermitService.DeleteAsync(userProjectPermit));
        }

        [HttpGet]
        [Route("redis")]
        public async Task<IActionResult> GetAllActivitiessUsingRedisCache()
        {
            var cacheKey = CacheManagerKeys.Activities.ToString();
            string serializedActivitiesList;
            var activities = new List<UserPermitDTO>();
            var redisActivitiesList = await _distributedCache.GetAsync(cacheKey);

            if (redisActivitiesList != null)
            {
                serializedActivitiesList = Encoding.UTF8.GetString(redisActivitiesList);
                activities = JsonConvert.DeserializeObject<List<UserPermitDTO>>(serializedActivitiesList);
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
