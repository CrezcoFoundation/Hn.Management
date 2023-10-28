using HN.ManagementEngine.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.Interfaces
{
    public interface IDonationService
    {
        Task<List<Donation>> GetAllAsync();
        Task<Donation> InsertAsync(Donation donation);
        Task<Donation> UpdateAsync(Donation donation);
        Task<bool> DeleteAsync(string id);
    }
}
