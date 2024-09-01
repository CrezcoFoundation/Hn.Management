using HN.Management.Engine.ViewModels;
using HN.ManagementEngine.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponse>> GetAllAsync();
        Task<UserResponse> GetByIdAsync(string id);
        Task<UserResponse> GetUserAsync(LoginRequest loginRequest);
        Task<UserResponse> CreateUserAsync(UserRequest user);
        Task<UserResponse> UpdateAsync(User user);
        Task<bool> DeleteAsync(string id);
    }
}
