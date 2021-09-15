using HN.ManagementEngine.DTO;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.Interfaces
{
    public interface IUserRoleService
    {
        Task<IQueryable<UserRoleDTO>> GetAllAsync();

        Task<UserRoleDTO> GetByConditionAsync(int userDonorPermitId);

        Task<IQueryable<UserRoleDTO>> GetByUserAsync(int userId);

        Task<UserRoleDTO> AddAsync(UserRoleDTO userDonorPermit);

        Task<UserRoleDTO> UpdateAsync(UserRoleDTO userDonorPermit);

        Task<UserRoleDTO> DeleteAsync(UserRoleDTO userDonorPermit);
    }
}
