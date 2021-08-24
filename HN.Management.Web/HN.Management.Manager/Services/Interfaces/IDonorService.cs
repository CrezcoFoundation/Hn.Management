using HN.ManagementEngine.DTO;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.Interfaces
{
    public interface IDonorService
    {
        Task<IQueryable<DonorDTO>> GetAllAsync();

        Task<DonorDTO> GetByConditionAsync(int donorId);

        Task<DonorDTO> AddAsync(DonorDTO donor);

        Task<DonorDTO> UpdateAsync(DonorDTO donor);

        Task<DonorDTO> DeleteAsync(DonorDTO donor);
    }
}
