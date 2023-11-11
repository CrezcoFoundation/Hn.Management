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
    [Route("api/[controller]")]
    public class DonationController : Controller
    {
        private readonly IDistributedCache distributedCache;
        private readonly IDonationService donationService;
        public DonationController(IDistributedCache distributedCache, IDonationService donationService)
        {
            this.distributedCache = distributedCache;
            this.donationService = donationService ?? throw new ArgumentNullException(nameof(donationService));
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await donationService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByConditionAsync(string id)
        {
            return Ok(await donationService.GetByIdAsync(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(Donation donation)
        {
            return Ok(await donationService.InsertAsync(donation));
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync(Donation donation)
        {
            return Ok(await donationService.UpdateAsync(donation));
        }

        [HttpDelete("{id}")] 
        public async Task<IActionResult> DeleteAsync(string id)
        {
            return Ok(await donationService.DeleteAsync(id));
        }

        [HttpGet("redis")]
        public async Task<IActionResult> GetAllActivitiessUsingRedisCache()
        {
            var cacheKey = CacheManagerKeys.Activities.ToString();
            string serializedActivitiesList;
            var activities = new List<Donation>();
            var redisActivitiesList = await distributedCache.GetAsync(cacheKey);

            if (redisActivitiesList != null)
            {
                serializedActivitiesList = Encoding.UTF8.GetString(redisActivitiesList);
                activities = JsonConvert.DeserializeObject<List<Donation>>(serializedActivitiesList);
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
