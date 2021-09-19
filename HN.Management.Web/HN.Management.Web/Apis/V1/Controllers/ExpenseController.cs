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
    [Route("api/expenses")]
    public class ExpenseController : Controller
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IExpenseService _expenseService;
        public ExpenseController(IDistributedCache distributedCache, IExpenseService expenseService)
        {
            _distributedCache = distributedCache;
            _expenseService = expenseService ?? throw new ArgumentNullException(nameof(expenseService));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _expenseService.GetAllAsync());
        }

        [HttpGet("expenseId")]
        public async Task<IActionResult> GetByConditionAsync(int expenseId)
        {
            return Ok(await _expenseService.GetByConditionAsync(expenseId));
        }

        [HttpGet]
        [Route("projects/{projectId}")]
        public async Task<IActionResult> GetByProjectAsync(int projectId)
        {
            return Ok(await _expenseService.GetByProjectAsync(projectId));
        }

        [HttpGet]
        [Route("students/{studentName}")]
        public async Task<IActionResult> GetByStudentAsync(string studentName)
        {
            return Ok(await _expenseService.GetByStudentAsync(studentName));
        }

        [HttpGet]
        [Route("ranks/{startDate}/{endDate}")]
        public async Task<IActionResult> GetByRankAsync(DateTime startDate, DateTime endDate)
        {
            return Ok(await _expenseService.GetByRankAsync(startDate, endDate));
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> AddAsync(ExpenseDTO activity)
        {
            return Ok(await _expenseService.AddAsync(activity));
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync(ExpenseDTO activity)
        {
            return Ok(await _expenseService.UpdateAsync(activity));
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteAsync(ExpenseDTO activity)
        {
            return Ok(await _expenseService.DeleteAsync(activity));
        }

        [HttpGet]
        [Route("redis")]
        public async Task<IActionResult> GetAllActivitiessUsingRedisCache()
        {
            var cacheKey = CacheManagerKeys.Activities.ToString();
            string serializedActivitiesList;
            var activities = new List<Expense>();
            var redisActivitiesList = await _distributedCache.GetAsync(cacheKey);

            if (redisActivitiesList != null)
            {
                serializedActivitiesList = Encoding.UTF8.GetString(redisActivitiesList);
                activities = JsonConvert.DeserializeObject<List<Expense>>(serializedActivitiesList);
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
