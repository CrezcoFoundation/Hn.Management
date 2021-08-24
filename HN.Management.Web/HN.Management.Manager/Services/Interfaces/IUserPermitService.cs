using HN.ManagementEngine.DTO;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.Interfaces
{
    public interface IUserPermitService
    {
        Task<IQueryable<UserPermitDTO>> GetAllAsync();

        Task<UserPermitDTO> GetByConditionAsync(int userDonorPermitId);

        Task<IQueryable<UserPermitDTO>> GetByUserAsync(int userId);

        Task<UserPermitDTO> AddAsync(UserPermitDTO userDonorPermit);

        Task<UserPermitDTO> UpdateAsync(UserPermitDTO userDonorPermit);

        Task<UserPermitDTO> DeleteAsync(UserPermitDTO userDonorPermit);
    }
}
