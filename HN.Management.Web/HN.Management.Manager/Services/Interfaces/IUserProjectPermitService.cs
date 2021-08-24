using HN.ManagementEngine.DTO;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.Interfaces
{
    public interface IUserProjectPermitService
    {
        Task<IQueryable<UserProjectPermitDTO>> GetAllAsync();

        Task<UserProjectPermitDTO> GetByConditionAsync(int userProjectPermitId);

        Task<IQueryable<UserProjectPermitDTO>> GetByUserAsync(int userId);

        Task<UserProjectPermitDTO> AddAsync(UserProjectPermitDTO userProjectPermit);

        Task<UserProjectPermitDTO> UpdateAsync(UserProjectPermitDTO userProjectPermit);

        Task<UserProjectPermitDTO> DeleteAsync(UserProjectPermitDTO userProjectPermit);
    }
}
