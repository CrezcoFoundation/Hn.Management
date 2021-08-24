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
    public class UserProjectPermitService : IUserProjectPermitService
    {
        private readonly IUserProjectPermitRepository _userProjectPermitsRepository;
        private readonly IMapper _mapper;
        public UserProjectPermitService(IUserProjectPermitRepository userProjectPermitsRepository, IMapper mapper)
        {
            _userProjectPermitsRepository = userProjectPermitsRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<UserProjectPermitDTO>> GetAllAsync()
        {
            var query = await _userProjectPermitsRepository.GetAllAsync();

            return _mapper.Map<List<UserProjectPermitDTO>>(query).AsQueryable();
        }

        public async Task<UserProjectPermitDTO> GetByConditionAsync(int userProjectPermitId)
        {
            var query = _userProjectPermitsRepository.GetByConditionAsync(x => x.Id == userProjectPermitId).Result.ToList();

            return await Task.FromResult(_mapper.Map<UserProjectPermitDTO>(query.FirstOrDefault()));
        }

        public async Task<IQueryable<UserProjectPermitDTO>> GetByUserAsync(int userId)
        {
            var query = _userProjectPermitsRepository.GetByConditionAsync(x => x.UserId == userId).Result.ToList();

            return await Task.FromResult(_mapper.Map<List<UserProjectPermitDTO>>(query).AsQueryable());
        }

        public async Task<UserProjectPermitDTO> AddAsync(UserProjectPermitDTO userProjectPermit)
        {
            var entity = _mapper.Map<UserProjectPermit>(userProjectPermit);
            var dto = await _userProjectPermitsRepository.AddAsync(entity);

            return _mapper.Map<UserProjectPermitDTO>(dto);
        }

        public async Task<UserProjectPermitDTO> UpdateAsync(UserProjectPermitDTO userProjectPermit)
        {
            var entity = _mapper.Map<UserProjectPermit>(userProjectPermit);
            var dto = await _userProjectPermitsRepository.UpdateAsync(entity);

            return _mapper.Map<UserProjectPermitDTO>(dto);
        }

        public async Task<UserProjectPermitDTO> DeleteAsync(UserProjectPermitDTO userProjectPermit)
        {
            var entity = _mapper.Map<UserProjectPermit>(userProjectPermit);
            var dto = await _userProjectPermitsRepository.DeleteAsync(entity);

            return _mapper.Map<UserProjectPermitDTO>(dto);
        }
    }
}
