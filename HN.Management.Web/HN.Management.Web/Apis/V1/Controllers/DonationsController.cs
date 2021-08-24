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
    [Route("api/donation")]
    public class DonationsController : Controller
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IDonationService _donationService;
        public DonationsController(IDistributedCache distributedCache, IDonationService donationService)
        {
            _distributedCache = distributedCache;
            _donationService = donationService;
        }

        [HttpGet]
        [Route("donations")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _donationService.GetAllAsync());
        }

        [HttpGet]
        [Route("donation")]
        public async Task<IActionResult> GetByConditionAsync(int donationId)
        {
            return Ok(await _donationService.GetByConditionAsync(donationId));
        }

        [HttpGet]
        [Route("project")]
        public async Task<IActionResult> GetByProjectAsync(int projectId)
        {
            return Ok(await _donationService.GetByProjectAsync(projectId));
        }

        [HttpGet]
        [Route("donor")]
        public async Task<IActionResult> GetByStudentAsync(int donorId)
        {
            return Ok(await _donationService.GetByDonortAsync(donorId));
        }

        [HttpGet]
        [Route("year")]
        public async Task<IActionResult> GetByYearAsync(int year, int projectId)
        {
            return Ok(await _donationService.GetByYearAsync(year, projectId));
        }

        [HttpGet]
        [Route("month")]
        public async Task<IActionResult> GetByMonthAsync(int month, int year, int projectId)
        {
            return Ok(await _donationService.GetByMonthAsync(month, year, projectId));
        }

        [HttpGet]
        [Route("day")]
        public async Task<IActionResult> GetByDayAsync(int day, int month, int year, int projectId)
        {
            return Ok(await _donationService.GetByDayAsync(day, month, year, projectId));
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> AddAsync(DonationDTO donation)
        {
            return Ok(await _donationService.AddAsync(donation));
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync(DonationDTO donation)
        {
            return Ok(await _donationService.UpdateAsync(donation));
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteAsync(DonationDTO donation)
        {
            return Ok(await _donationService.DeleteAsync(donation));
        }

        [HttpGet]
        [Route("redis")]
        public async Task<IActionResult> GetAllActivitiessUsingRedisCache()
        {
            var cacheKey = CacheManagerKeys.Activities.ToString();
            string serializedActivitiesList;
            var activities = new List<Donation>();
            var redisActivitiesList = await _distributedCache.GetAsync(cacheKey);

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
