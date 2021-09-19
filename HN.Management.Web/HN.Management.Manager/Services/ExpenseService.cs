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
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;
        public ExpenseService(IExpenseRepository expenseRepository, IMapper mapper)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<ExpenseDTO>> GetAllAsync()
        {
            var query = await _expenseRepository.GetAllAsync();

            return _mapper.Map<List<ExpenseDTO>>(query).AsQueryable();
        }

        public async Task<ExpenseDTO> GetByConditionAsync(int id)
        {
            var query = _expenseRepository.GetByConditionAsync(x => x.Id == id).Result.ToList();

            return await Task.FromResult(_mapper.Map<ExpenseDTO>(query.FirstOrDefault()));
        }

        public async Task<IQueryable<ExpenseDTO>> GetByProjectAsync(int projectId)
        {
            var query = _expenseRepository.GetByConditionAsync(x => x.ProjectId == projectId).Result.ToList();

            return await Task.FromResult(_mapper.Map<List<ExpenseDTO>>(query).AsQueryable()); 
        }

        public async Task<IQueryable<ExpenseDTO>> GetByStudentAsync(string studentName)
        {
            var query = _expenseRepository.GetByConditionAsync(x => x.Name == studentName).Result.ToList();

            return await Task.FromResult(_mapper.Map<List<ExpenseDTO>>(query).AsQueryable());
        }

        public async Task<IQueryable<ExpenseDTO>> GetByRankAsync(DateTime startDate, DateTime endDate)
        {
            var query = _expenseRepository.GetByConditionAsync(x => x.Date.Value >= startDate && x.Date.Value <= endDate).Result.ToList();

            return await Task.FromResult(_mapper.Map<List<ExpenseDTO>>(query).AsQueryable());
        }

        public async Task<ExpenseDTO> AddAsync(ExpenseDTO expense)
        {
            var entity = _mapper.Map<Expense>(expense);
            var dto = await _expenseRepository.AddAsync(entity);

            return _mapper.Map<ExpenseDTO>(dto);
        }

        public async Task<ExpenseDTO> UpdateAsync(ExpenseDTO expense)
        {
            var entity = _mapper.Map<Expense>(expense);
            var dto = await _expenseRepository.UpdateAsync(entity);

            return _mapper.Map<ExpenseDTO>(dto);
        }

        public async Task<ExpenseDTO> DeleteAsync(ExpenseDTO expense)
        {
            var entity = _mapper.Map<Expense>(expense);
            var dto = await _expenseRepository.DeleteAsync(entity);

            return _mapper.Map<ExpenseDTO>(dto);
        }
    }
}
