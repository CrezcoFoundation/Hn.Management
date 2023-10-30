using HN.Management.Engine.Repositories.Interfaces;
using HN.Management.Manager.Services.Interfaces;
using HN.ManagementEngine.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services
{
    public class DonationService : IDonationService
    {
        private readonly IDonationRepository donationsRepository;
        public DonationService(IDonationRepository donationsRepository)
        {
            this.donationsRepository = donationsRepository;
        }

        public async Task<List<Donation>> GetAllAsync()
        {
            var result = await donationsRepository.GetAllAsync();
            return result.ToList();
        }

        public async Task<Donation> GetByIdAsync(string id)
        {
            return await donationsRepository.GetAsync(id);
        }

        public async Task<Donation> InsertAsync(Donation donation)
        {
            return await donationsRepository.InsertAsync(donation);
        }

        public async Task<Donation> UpdateAsync(Donation donation)
        {
            return await donationsRepository.UpdateAsync(donation);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            await donationsRepository.Delete(id);

            return true;
        }
    }
}
