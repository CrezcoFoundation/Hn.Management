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
    [Route("api/students")]
    public class StudentsController : Controller
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IStudentService _studentService;
        public StudentsController(IDistributedCache distributedCache, IStudentService studentService)
        {
            _distributedCache = distributedCache;
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _studentService.GetAllAsync());
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetByConditionAsync(int studentId)
        {
            return Ok(await _studentService.GetByConditionAsync(studentId));
        }

        [HttpGet]
        [Route("projects/{projectId}")]
        public async Task<IActionResult> GetByProjectAsync(int projectId)
        {
            return Ok(await _studentService.GetByProjectAsync(projectId));
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> AddAsync(StudentDTO student)
        {
            return Ok(await _studentService.AddAsync(student));
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync(StudentDTO student)
        {
            return Ok(await _studentService.UpdateAsync(student));
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteAsync(StudentDTO student)
        {
            return Ok(await _studentService.DeleteAsync(student));
        }

        [HttpGet]
        [Route("redis")]
        public async Task<IActionResult> GetAllActivitiessUsingRedisCache()
        {
            var cacheKey = CacheManagerKeys.Activities.ToString();
            string serializedActivitiesList;
            var activities = new List<Student>();
            var redisActivitiesList = await _distributedCache.GetAsync(cacheKey);

            if (redisActivitiesList != null)
            {
                serializedActivitiesList = Encoding.UTF8.GetString(redisActivitiesList);
                activities = JsonConvert.DeserializeObject<List<Student>>(serializedActivitiesList);
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
