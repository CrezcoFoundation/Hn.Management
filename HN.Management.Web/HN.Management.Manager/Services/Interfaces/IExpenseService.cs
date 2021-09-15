using HN.ManagementEngine.DTO;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.Interfaces
{
    public interface IExpenseService
    {
        Task<IQueryable<ExpenseDTO>> GetAllAsync();

        Task<ExpenseDTO> GetByConditionAsync(int activityId);

        Task<IQueryable<ExpenseDTO>> GetByProjectAsync(int projectId);

        Task<IQueryable<ExpenseDTO>> GetByStudentAsync(int studentId);

        Task<IQueryable<ExpenseDTO>> GetByYearAsync(int year, int projectId);

        Task<IQueryable<ExpenseDTO>> GetByMonthAsync(int month, int year, int projectId);

        Task<IQueryable<ExpenseDTO>> GetByDayAsync(int day, int month, int year, int projectId);

        Task<ExpenseDTO> AddAsync(ExpenseDTO activity);

        Task<ExpenseDTO> UpdateAsync(ExpenseDTO activity);

        Task<ExpenseDTO> DeleteAsync(ExpenseDTO activity);
    }
}
