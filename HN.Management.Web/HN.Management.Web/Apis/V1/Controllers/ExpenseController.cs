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
    [Route("api/expense")]
    public class ExpenseController : Controller
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IExpenseService _expenseService;
        public ExpenseController(IDistributedCache distributedCache, IExpenseService expenseService)
        {
            _distributedCache = distributedCache;
            _expenseService = expenseService;
        }

        [HttpGet]
        [Authorize]
        [Route("expenses")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _expenseService.GetAllAsync());
        }

        [HttpGet]
        [Route("expense")]
        public async Task<IActionResult> GetByConditionAsync(int activityId)
        {
            return Ok(await _expenseService.GetByConditionAsync(activityId));
        }

        [HttpGet]
        [Route("project")]
        public async Task<IActionResult> GetByProjectAsync(int projectId)
        {
            return Ok(await _expenseService.GetByProjectAsync(projectId));
        }

        [HttpGet]
        [Route("student")]
        public async Task<IActionResult> GetByStudentAsync(int studentId)
        {
            return Ok(await _expenseService.GetByStudentAsync(studentId));
        }

        [HttpGet]
        [Route("year")]
        public async Task<IActionResult> GetByYearAsync(int year, int projectId)
        {
            return Ok(await _expenseService.GetByYearAsync(year, projectId));
        }

        [HttpGet]
        [Route("month")]
        public async Task<IActionResult> GetByMonthAsync(int month, int year, int projectId)
        {
            return Ok(await _expenseService.GetByMonthAsync(month, year, projectId));
        }

        [HttpGet]
        [Route("day")]
        public async Task<IActionResult> GetByDayAsync(int day, int month, int year, int projectId)
        {
            return Ok(await _expenseService.GetByDayAsync(day, month, year, projectId));
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
