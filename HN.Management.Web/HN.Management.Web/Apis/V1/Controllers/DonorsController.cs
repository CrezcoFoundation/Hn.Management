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
    [Route("api/donor")]
    public class DonorsController : Controller
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IDonorService _donorService;
        public DonorsController(IDistributedCache distributedCache, IDonorService donorService)
        {
            _distributedCache = distributedCache;
            _donorService = donorService;
        }

        [HttpGet]
        [Route("donors")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _donorService.GetAllAsync());
        }

        [HttpGet]
        [Route("donor")]
        public async Task<IActionResult> GetByConditionAsync(int donorId)
        {
            return Ok(await _donorService.GetByConditionAsync(donorId));
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> AddAsync(DonorDTO donor)
        {
            return Ok(await _donorService.AddAsync(donor));
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync(DonorDTO donor)
        {
            return Ok(await _donorService.UpdateAsync(donor));
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteAsync(DonorDTO donor)
        {
            return Ok(await _donorService.DeleteAsync(donor));
        }

        [HttpGet]
        [Route("redis")]
        public async Task<IActionResult> GetAllActivitiessUsingRedisCache()
        {
            var cacheKey = CacheManagerKeys.Activities.ToString();
            string serializedActivitiesList;
            var activities = new List<Donor>();
            var redisActivitiesList = await _distributedCache.GetAsync(cacheKey);

            if (redisActivitiesList != null)
            {
                serializedActivitiesList = Encoding.UTF8.GetString(redisActivitiesList);
                activities = JsonConvert.DeserializeObject<List<Donor>>(serializedActivitiesList);
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
