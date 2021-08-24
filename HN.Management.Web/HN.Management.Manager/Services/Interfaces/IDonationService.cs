using HN.ManagementEngine.DTO;
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

        Task<IQueryable<DonationDTO>> GetByYearAsync(int year, int projectId);

        Task<IQueryable<DonationDTO>> GetByMonthAsync(int month, int year, int projectId);

        Task<IQueryable<DonationDTO>> GetByDayAsync(int day, int month, int year, int projectId);

        Task<DonationDTO> AddAsync(DonationDTO donation);

        Task<DonationDTO> UpdateAsync(DonationDTO donation);

        Task<DonationDTO> DeleteAsync(DonationDTO donation);
    }
}
