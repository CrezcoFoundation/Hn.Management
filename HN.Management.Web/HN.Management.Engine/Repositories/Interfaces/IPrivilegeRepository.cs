using HN.Management.Engine.Models.Auth;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Engine.Repositories.Interfaces
{
    public interface IPrivilegeRepository
    {
        IQueryable<Privilege> GetAllQueryable();
        IEnumerable<Privilege> GetAll();
        Task<IEnumerable<Privilege>> GetAllAsync();
        Task<Privilege> GetAsync(string id);
        Task<Privilege> InsertAsync(Privilege item);
        Task<Privilege> UpdateAsync(Privilege item);
        Task Delete(string id);
        Privilege GetPrivilegeByName(string privilegeName);
        List<Privilege> GetPrivilegesByIds(List<string> ids);
    }
}