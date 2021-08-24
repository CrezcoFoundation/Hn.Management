using AutoMapper;
using HN.Management.Engine.Repositories.Interfaces;
using HN.Management.Manager.Services.Interfaces;
using HN.ManagementEngine.DTO;
using HN.ManagementEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IMapper _mapper;
        public ActivityService(IActivityRepository activityRepository, IMapper mapper)
        {
            _activityRepository = activityRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<ActivityDTO>> GetAllAsync()
        {
            var query = await _activityRepository.GetAllAsync();

            return _mapper.Map<List<ActivityDTO>>(query).AsQueryable();
        }

        public async Task<ActivityDTO> GetByConditionAsync(int activityId)
        {
            var query = _activityRepository.GetByConditionAsync(x => x.Id == activityId).Result.ToList();

            return await Task.FromResult(_mapper.Map<ActivityDTO>(query.FirstOrDefault()));
        }

        public async Task<IQueryable<ActivityDTO>> GetByProjectAsync(int projectId)
        {
            var query = _activityRepository.GetByConditionAsync(x => x.ProjectId == projectId).Result.ToList();

            return await Task.FromResult(_mapper.Map<List<ActivityDTO>>(query).AsQueryable()); 
        }

        public async Task<IQueryable<ActivityDTO>> GetByStudentAsync(int studentId)
        {
            var query = _activityRepository.GetByConditionAsync(x => x.StudentId == studentId).Result.ToList();

            return await Task.FromResult(_mapper.Map<List<ActivityDTO>>(query).AsQueryable());
        }

        public async Task<IQueryable<ActivityDTO>> GetByYearAsync(int year, int projectId)
        {
            var query = _activityRepository.GetByConditionAsync(x => x.Date.Value.Year == year && x.ProjectId == projectId).Result.ToList();

            return await Task.FromResult(_mapper.Map<List<ActivityDTO>>(query).AsQueryable());
        }

        public async Task<IQueryable<ActivityDTO>> GetByMonthAsync(int month, int year, int projectId)
        {
            
            var query = _activityRepository.GetByConditionAsync(x => x.Date.Value.Month ==  month && x.Date.Value.Year == year && x.ProjectId == projectId).Result.ToList();

            return await Task.FromResult(_mapper.Map<List<ActivityDTO>>(query).AsQueryable());
        }

        public async Task<IQueryable<ActivityDTO>> GetByDayAsync(int day, int month, int year, int projectId)
        {
            var query = _activityRepository.GetByConditionAsync(x => x.Date.Value.Day == day && x.Date.Value.Month == month && x.Date.Value.Year == year && x.ProjectId == projectId).Result.ToList();

            return await Task.FromResult(_mapper.Map<List<ActivityDTO>>(query).AsQueryable());
        }

        public async Task<ActivityDTO> AddAsync(ActivityDTO activity)
        {
            var entity = _mapper.Map<Activity>(activity);
            var dto = await _activityRepository.AddAsync(entity);

            return _mapper.Map<ActivityDTO>(dto);
        }

        public async Task<ActivityDTO> UpdateAsync(ActivityDTO activity)
        {
            var entity = _mapper.Map<Activity>(activity);
            var dto = await _activityRepository.UpdateAsync(entity);

            return _mapper.Map<ActivityDTO>(dto);
        }

        public async Task<ActivityDTO> DeleteAsync(ActivityDTO activity)
        {
            var entity = _mapper.Map<Activity>(activity);
            var dto = await _activityRepository.DeleteAsync(entity);

            return _mapper.Map<ActivityDTO>(dto);
        }
    }
}
