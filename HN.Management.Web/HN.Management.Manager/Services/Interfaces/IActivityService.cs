using HN.ManagementEngine.DTO;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.Interfaces
{
    public interface IActivityService
    {
        Task<IQueryable<ActivityDTO>> GetAllAsync();

        Task<ActivityDTO> GetByConditionAsync(int activityId);

        Task<IQueryable<ActivityDTO>> GetByProjectAsync(int projectId);

        Task<IQueryable<ActivityDTO>> GetByStudentAsync(int studentId);

        Task<IQueryable<ActivityDTO>> GetByYearAsync(int year, int projectId);

        Task<IQueryable<ActivityDTO>> GetByMonthAsync(int month, int year, int projectId);

        Task<IQueryable<ActivityDTO>> GetByDayAsync(int day, int month, int year, int projectId);

        Task<ActivityDTO> AddAsync(ActivityDTO activity);

        Task<ActivityDTO> UpdateAsync(ActivityDTO activity);

        Task<ActivityDTO> DeleteAsync(ActivityDTO activity);
    }
}
