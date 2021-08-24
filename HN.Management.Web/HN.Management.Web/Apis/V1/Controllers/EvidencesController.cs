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
    [Route("api/evidence")]
    public class EvidencesController : Controller
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IEvidenceService _evidenceService;
        public EvidencesController(IDistributedCache distributedCache, IEvidenceService evidenceService)
        {
            _distributedCache = distributedCache;
            _evidenceService = evidenceService;
        }

        [HttpGet]
        [Route("evidences")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _evidenceService.GetAllAsync());
        }

        [HttpGet]
        [Route("evidence")]
        public async Task<IActionResult> GetByConditionAsync(int evideceId)
        {
            return Ok(await _evidenceService.GetByConditionAsync(evideceId));
        }

        [HttpGet]
        [Route("activity")]
        public async Task<IActionResult> GetByActivityAsync(int activityId)
        {
            return Ok(await _evidenceService.GetByActivityAsync(activityId));
        }
        
        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> AddAsync(EvidenceDTO evidence)
        {
            return Ok(await _evidenceService.AddAsync(evidence));
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync(EvidenceDTO evidence)
        {
            return Ok(await _evidenceService.UpdateAsync(evidence));
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteAsync(EvidenceDTO evidence)
        {
            return Ok(await _evidenceService.DeleteAsync(evidence));
        }

        [HttpGet]
        [Route("redis")]
        public async Task<IActionResult> GetAllActivitiessUsingRedisCache()
        {
            var cacheKey = CacheManagerKeys.Activities.ToString();
            string serializedActivitiesList;
            var activities = new List<Evidence>();
            var redisActivitiesList = await _distributedCache.GetAsync(cacheKey);

            if (redisActivitiesList != null)
            {
                serializedActivitiesList = Encoding.UTF8.GetString(redisActivitiesList);
                activities = JsonConvert.DeserializeObject<List<Evidence>>(serializedActivitiesList);
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
