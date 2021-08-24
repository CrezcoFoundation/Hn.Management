using HN.ManagementEngine.DTO;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IQueryable<StudentDTO>> GetAllAsync();

        Task<StudentDTO> GetByConditionAsync(int studentId);

        Task<IQueryable<StudentDTO>> GetByProjectAsync(int projectId);

        Task<StudentDTO> AddAsync(StudentDTO student);

        Task<StudentDTO> UpdateAsync(StudentDTO student);

        Task<StudentDTO> DeleteAsync(StudentDTO student);
    }
}
