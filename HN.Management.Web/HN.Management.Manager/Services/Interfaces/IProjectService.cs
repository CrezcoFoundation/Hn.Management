using HN.ManagementEngine.DTO;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.Interfaces
{
    public interface IProjectService
    {
        Task<IQueryable<ProjectDTO>> GetAllAsync();

        Task<ProjectDTO> GetByConditionAsync(int id);

        Task<ProjectDTO> AddAsync(ProjectDTO Proyect);

        Task<ProjectDTO> UpdateAsync(ProjectDTO Proyect);

        Task<ProjectDTO> DeleteAsync(ProjectDTO Proyect);
    }
}
