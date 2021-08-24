//using HN.Management.Engine.Models;
using HN.ManagementEngine.DTO;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.Interfaces
{
    public interface IUserService
    {
        Task<IQueryable<UserDTO>> GetAllAsync();

        Task<UserDTO> GetByConditionAsync(int userId);

        UserPermitDTO GetEmail(string email, string password);

        Task<UserDTO> AddAsync(UserDTO user);

        Task<UserDTO> UpdateAsync(UserDTO user);

        Task<UserDTO> DeleteAsync(UserDTO user);

        //AuthenticateResponse AuthenticateRequest(AuthenticateRequest model);
    }
}
