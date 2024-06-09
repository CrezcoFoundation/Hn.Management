using HN.Management.Engine.Models.Auth;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.Interfaces
{
    public interface IRoleService
    {
        IEnumerable<Role> GetAll();
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role> GetAsync(string id);
        Task<Role> InsertAsync(Role item);
        Task<Role> UpdateAsync(Role item);
        Task Delete(string id);
    }
}
