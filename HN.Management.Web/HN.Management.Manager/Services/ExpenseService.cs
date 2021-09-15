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
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _activityRepository;
        private readonly IMapper _mapper;
        public ExpenseService(IExpenseRepository activityRepository, IMapper mapper)
        {
            _activityRepository = activityRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<ExpenseDTO>> GetAllAsync()
        {
            var query = await _activityRepository.GetAllAsync();

            return _mapper.Map<List<ExpenseDTO>>(query).AsQueryable();
        }

        public async Task<ExpenseDTO> GetByConditionAsync(int activityId)
        {
            var query = _activityRepository.GetByConditionAsync(x => x.Id == activityId).Result.ToList();

            return await Task.FromResult(_mapper.Map<ExpenseDTO>(query.FirstOrDefault()));
        }

        public async Task<IQueryable<ExpenseDTO>> GetByProjectAsync(int projectId)
        {
            var query = _activityRepository.GetByConditionAsync(x => x.ProjectId == projectId).Result.ToList();

            return await Task.FromResult(_mapper.Map<List<ExpenseDTO>>(query).AsQueryable()); 
        }

        public async Task<IQueryable<ExpenseDTO>> GetByStudentAsync(int studentId)
        {
            var query = _activityRepository.GetByConditionAsync(x => x.StudentId == studentId).Result.ToList();

            return await Task.FromResult(_mapper.Map<List<ExpenseDTO>>(query).AsQueryable());
        }

        public async Task<IQueryable<ExpenseDTO>> GetByYearAsync(int year, int projectId)
        {
            var query = _activityRepository.GetByConditionAsync(x => x.Date.Value.Year == year && x.ProjectId == projectId).Result.ToList();

            return await Task.FromResult(_mapper.Map<List<ExpenseDTO>>(query).AsQueryable());
        }

        public async Task<IQueryable<ExpenseDTO>> GetByMonthAsync(int month, int year, int projectId)
        {
            
            var query = _activityRepository.GetByConditionAsync(x => x.Date.Value.Month ==  month && x.Date.Value.Year == year && x.ProjectId == projectId).Result.ToList();

            return await Task.FromResult(_mapper.Map<List<ExpenseDTO>>(query).AsQueryable());
        }

        public async Task<IQueryable<ExpenseDTO>> GetByDayAsync(int day, int month, int year, int projectId)
        {
            var query = _activityRepository.GetByConditionAsync(x => x.Date.Value.Day == day && x.Date.Value.Month == month && x.Date.Value.Year == year && x.ProjectId == projectId).Result.ToList();

            return await Task.FromResult(_mapper.Map<List<ExpenseDTO>>(query).AsQueryable());
        }

        public async Task<ExpenseDTO> AddAsync(ExpenseDTO activity)
        {
            var entity = _mapper.Map<Expense>(activity);
            var dto = await _activityRepository.AddAsync(entity);

            return _mapper.Map<ExpenseDTO>(dto);
        }

        public async Task<ExpenseDTO> UpdateAsync(ExpenseDTO activity)
        {
            var entity = _mapper.Map<Expense>(activity);
            var dto = await _activityRepository.UpdateAsync(entity);

            return _mapper.Map<ExpenseDTO>(dto);
        }

        public async Task<ExpenseDTO> DeleteAsync(ExpenseDTO activity)
        {
            var entity = _mapper.Map<Expense>(activity);
            var dto = await _activityRepository.DeleteAsync(entity);

            return _mapper.Map<ExpenseDTO>(dto);
        }
    }
}
