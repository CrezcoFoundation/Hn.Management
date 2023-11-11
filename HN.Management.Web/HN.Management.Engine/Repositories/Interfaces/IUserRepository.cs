using HN.ManagementEngine.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Engine.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> GetAllQueryable();
        IEnumerable<User> GetAll();
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetAsync(string id);
        Task<User> InsertAsync(User item);
        Task<User> UpdateAsync(User item);
        Task Delete(string id);
    }
}
