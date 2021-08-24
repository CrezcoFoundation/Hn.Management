using HN.Management.Manager.Enums;
using HN.Management.Manager.Services.Interfaces;
using HN.Management.Web.Exceptions.Domain;
using HN.ManagementEngine.DTO;
using HN.ManagementEngine.Models;
using Microsoft.AspNetCore.Authorization;
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
    [Route("api/activity")]
    public class ActivityController : Controller
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IActivityService _activityService;
        public ActivityController(IDistributedCache distributedCache, IActivityService activityService)
        {
            _distributedCache = distributedCache;
            _activityService = activityService;
        }

        [HttpGet]
        [Authorize]
        [Route("activities")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _activityService.GetAllAsync());
        }

        [HttpGet]
        [Route("activity")]
        public async Task<IActionResult> GetByConditionAsync(int activityId)
        {
            return Ok(await _activityService.GetByConditionAsync(activityId));
        }

        [HttpGet]
        [Route("project")]
        public async Task<IActionResult> GetByProjectAsync(int projectId)
        {
            return Ok(await _activityService.GetByProjectAsync(projectId));
        }

        [HttpGet]
        [Route("student")]
        public async Task<IActionResult> GetByStudentAsync(int studentId)
        {
            return Ok(await _activityService.GetByStudentAsync(studentId));
        }

        [HttpGet]
        [Route("year")]
        public async Task<IActionResult> GetByYearAsync(int year, int projectId)
        {
            return Ok(await _activityService.GetByYearAsync(year, projectId));
        }

        [HttpGet]
        [Route("month")]
        public async Task<IActionResult> GetByMonthAsync(int month, int year, int projectId)
        {
            return Ok(await _activityService.GetByMonthAsync(month, year, projectId));
        }

        [HttpGet]
        [Route("day")]
        public async Task<IActionResult> GetByDayAsync(int day, int month, int year, int projectId)
        {
            return Ok(await _activityService.GetByDayAsync(day, month, year, projectId));
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> AddAsync(ActivityDTO activity)
        {
            return Ok(await _activityService.AddAsync(activity));
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync(ActivityDTO activity)
        {
            return Ok(await _activityService.UpdateAsync(activity));
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteAsync(ActivityDTO activity)
        {
            return Ok(await _activityService.DeleteAsync(activity));
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
