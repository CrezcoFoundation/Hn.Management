using AutoMapper;
using HN.Management.Engine.Repositories.Interfaces;
using HN.Management.Manager.Services.Interfaces;
using HN.ManagementEngine.DTO;
using HN.ManagementEngine.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services
{
    public class EvidenceService : IEvidenceService
    {
        private readonly IEvidenceRepository _evidenceRepository;
        private readonly IMapper _mapper;
        public EvidenceService(IEvidenceRepository evidencesRepository, IMapper mapper)
        {
            _evidenceRepository = evidencesRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<EvidenceDTO>> GetAllAsync()
        {
            var query = await _evidenceRepository.GetAllAsync();

            return _mapper.Map<List<EvidenceDTO>>(query).AsQueryable();
        }

        public async Task<EvidenceDTO> GetByConditionAsync(int evidenceId)
        {
            var query = _evidenceRepository.GetByConditionAsync(x => x.Id == evidenceId).Result.ToList();

            return await Task.FromResult(_mapper.Map<EvidenceDTO>(query.FirstOrDefault()));
        }

        public async Task<IQueryable<EvidenceDTO>> GetByExpenseAsync(int expenseId)
        {
            var query = _evidenceRepository.GetByConditionAsync(x => x.ExpenseId == expenseId).Result.ToList();

            return await Task.FromResult(_mapper.Map<List<EvidenceDTO>>(query).AsQueryable());
        }

        public async Task<EvidenceDTO> AddAsync(EvidenceDTO evidence)
        {
            var entity = _mapper.Map<Evidence>(evidence);
            var dto = await _evidenceRepository.AddAsync(entity);

            return  _mapper.Map<EvidenceDTO>(dto);
        }

        public async Task<EvidenceDTO> UpdateAsync(EvidenceDTO evidence)
        {
            var entity = _mapper.Map<Evidence>(evidence);
            var dto = await _evidenceRepository.UpdateAsync(entity);

            return _mapper.Map<EvidenceDTO>(dto);
        }

        public async Task<EvidenceDTO> DeleteAsync(EvidenceDTO evidence)
        {
            var entity = _mapper.Map<Evidence>(evidence);
            var dto = await _evidenceRepository.DeleteAsync(entity);

            return _mapper.Map<EvidenceDTO>(dto);
        }
    }
}
