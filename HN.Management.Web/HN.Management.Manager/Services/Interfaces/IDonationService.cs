using HN.ManagementEngine.DTO;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.Interfaces
{
    public interface IDonationService
    {
        Task<IQueryable<DonationDTO>> GetAllAsync();

        Task<DonationDTO> GetByConditionAsync(int donationId);

        Task<IQueryable<DonationDTO>> GetByProjectAsync(int projectId);

        Task<IQueryable<DonationDTO>> GetByDonortAsync(int donorId);

        Task<IQueryable<DonationDTO>> GetByRankAsync(DateTime startDate, DateTime endDate);

        Task<DonationDTO> AddAsync(DonationDTO donation);

        Task<DonationDTO> UpdateAsync(DonationDTO donation);

        Task<DonationDTO> DeleteAsync(DonationDTO donation);
    }
}
