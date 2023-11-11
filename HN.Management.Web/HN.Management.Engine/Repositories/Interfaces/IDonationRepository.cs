using HN.ManagementEngine.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Engine.Repositories.Interfaces
{
    public interface IDonationRepository
    {
        IQueryable<Donation> GetAllQueryable();
        IEnumerable<Donation> GetAll();
        Task<IEnumerable<Donation>> GetAllAsync();
        Task<Donation> GetAsync(string id);
        Task<Donation> InsertAsync(Donation item);
        Task<Donation> UpdateAsync(Donation item);
        Task Delete(string id);
    }
}
