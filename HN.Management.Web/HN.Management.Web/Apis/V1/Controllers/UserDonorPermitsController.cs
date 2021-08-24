﻿using HN.Management.Manager.Enums;
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
    [Route("api/userdonorpermit")]
    public class UserDonorPermitsController : Controller
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IUserDonorPermitService _userDonorPermitService;
        public UserDonorPermitsController(IDistributedCache distributedCache, IUserDonorPermitService userDonorPermitService)
        {
            _distributedCache = distributedCache;
            _userDonorPermitService = userDonorPermitService;
        }

        [HttpGet]
        [Route("userdonorpermits")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _userDonorPermitService.GetAllAsync());
        }

        [HttpGet]
        [Route("userdonorpermit")]
        public async Task<IActionResult> GetByConditionAsync(int userDonorPermitId)
        {
            return Ok(await _userDonorPermitService.GetByConditionAsync(userDonorPermitId));
        }

        [HttpGet]
        [Route("user")]
        public async Task<IActionResult> GetByUserAsync(int userId)
        {
            return Ok(await _userDonorPermitService.GetByUserAsync(userId));
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> AddAsync(UserDonorPermitDTO userDonorPermit)
        {
            return Ok(await _userDonorPermitService.AddAsync(userDonorPermit));
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync(UserDonorPermitDTO userDonorPermit)
        {
            return Ok(await _userDonorPermitService.UpdateAsync(userDonorPermit));
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteAsync(UserDonorPermitDTO userDonorPermit)
        {
            return Ok(await _userDonorPermitService.DeleteAsync(userDonorPermit));
        }

        [HttpGet]
        [Route("redis")]
        public async Task<IActionResult> GetAllActivitiessUsingRedisCache()
        {
            var cacheKey = CacheManagerKeys.Activities.ToString();
            string serializedActivitiesList;
            var activities = new List<Activity>();
            var redisActivitiesList = await _distributedCache.GetAsync(cacheKey);

            if (redisActivitiesList != null)
            {
                serializedActivitiesList = Encoding.UTF8.GetString(redisActivitiesList);
                activities = JsonConvert.DeserializeObject<List<Activity>>(serializedActivitiesList);
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
