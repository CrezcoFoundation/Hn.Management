using HN.ManagementEngine.DTO;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.Interfaces
{
    public interface IExpenseService
    {
        Task<IQueryable<ExpenseDTO>> GetAllAsync();

        Task<ExpenseDTO> GetByConditionAsync(int id);

        Task<IQueryable<ExpenseDTO>> GetByProjectAsync(int projectId);

        Task<IQueryable<ExpenseDTO>> GetByStudentAsync(int studentId);

        Task<IQueryable<ExpenseDTO>> GetByYearAsync(int year, int projectId);

        Task<IQueryable<ExpenseDTO>> GetByMonthAsync(int month, int year, int projectId);

        Task<IQueryable<ExpenseDTO>> GetByDayAsync(int day, int month, int year, int projectId);

        Task<ExpenseDTO> AddAsync(ExpenseDTO expense);

        Task<ExpenseDTO> UpdateAsync(ExpenseDTO expense);

        Task<ExpenseDTO> DeleteAsync(ExpenseDTO expense);
    }
}
