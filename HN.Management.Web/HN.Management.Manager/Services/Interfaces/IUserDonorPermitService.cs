using HN.ManagementEngine.DTO;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.Interfaces
{
    public interface IUserDonorPermitService
    {
        Task<IQueryable<UserDonorPermitDTO>> GetAllAsync();

        Task<UserDonorPermitDTO> GetByConditionAsync(int userDonorPermitId);

        Task<IQueryable<UserDonorPermitDTO>> GetByUserAsync(int userId);

        Task<UserDonorPermitDTO> AddAsync(UserDonorPermitDTO userDonorPermit);

        Task<UserDonorPermitDTO> UpdateAsync(UserDonorPermitDTO userDonorPermit);

        Task<UserDonorPermitDTO> DeleteAsync(UserDonorPermitDTO userDonorPermit);
    }
}
