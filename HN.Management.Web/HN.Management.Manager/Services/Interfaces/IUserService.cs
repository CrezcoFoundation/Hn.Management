//using HN.Management.Engine.Models;
using HN.ManagementEngine.DTO;
using HN.ManagementEngine.Models;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.Interfaces
{
    public interface IUserService
    {
        Task<IQueryable<UserDTO>> GetAllAsync();

        Task<UserDTO> GetByConditionAsync(User user);

        Task<UserDTO> GetEmail(string email, string password);

        Task<UserDTO> AddUserAsync(UserDTO user);

        Task<UserDTO> UpdateAsync(UserDTO user);

        Task<bool> DeleteAsync(string id);

        //AuthenticateResponse AuthenticateRequest(AuthenticateRequest model);
    }
}
