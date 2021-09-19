using HN.ManagementEngine.DTO;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services.Interfaces
{
    public interface IEvidenceService
    {
        Task<IQueryable<EvidenceDTO>> GetAllAsync();

        Task<EvidenceDTO> GetByConditionAsync(int evidenceId);

        Task<IQueryable<EvidenceDTO>> GetByExpenseAsync(int expenseId);

        Task<EvidenceDTO> AddAsync(EvidenceDTO evidence);

        Task<EvidenceDTO> UpdateAsync(EvidenceDTO evidence);

        Task<EvidenceDTO> DeleteAsync(EvidenceDTO evidence);
    }
}
