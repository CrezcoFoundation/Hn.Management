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
    public class UserPermitService : IUserPermitService
    {
        private readonly IUserPermitRepository _userDonorPermitsRepository;
        private readonly IMapper _mapper;
        public UserPermitService(IUserPermitRepository userDonorPermitsRepository, IMapper mapper)
        {
            _userDonorPermitsRepository = userDonorPermitsRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<UserPermitDTO>> GetAllAsync()
        {
            var query = await _userDonorPermitsRepository.GetAllAsync();

            return _mapper.Map<List<UserPermitDTO>>(query).AsQueryable();
        }

        public async Task<UserPermitDTO> GetByConditionAsync(int userDonorPermitId)
        {
            var query = _userDonorPermitsRepository.GetByConditionAsync(x => x.Id == userDonorPermitId).Result.ToList();

            return await Task.FromResult(_mapper.Map<UserPermitDTO>(query.FirstOrDefault()));
        }

        public async Task<IQueryable<UserPermitDTO>> GetByUserAsync(int userId)
        {
            var query = _userDonorPermitsRepository.GetByConditionAsync(x => x.UserId == userId).Result.ToList();

            return await Task.FromResult(_mapper.Map<List<UserPermitDTO>>(query).AsQueryable());
        }

        public async Task<UserPermitDTO> AddAsync(UserPermitDTO userDonorPermit)
        {
            var entity = _mapper.Map<UserPermit>(userDonorPermit);
            var dto = await _userDonorPermitsRepository.AddAsync(entity);

            return _mapper.Map<UserPermitDTO>(dto);
        }

        public async Task<UserPermitDTO> UpdateAsync(UserPermitDTO userDonorPermit)
        {
            var entity = _mapper.Map<UserPermit>(userDonorPermit);
            var dto = await _userDonorPermitsRepository.UpdateAsync(entity);

            return _mapper.Map<UserPermitDTO>(dto);
        }

        public async Task<UserPermitDTO> DeleteAsync(UserPermitDTO userDonorPermit)
        {
            var entity = _mapper.Map<UserPermit>(userDonorPermit);
            var dto = await _userDonorPermitsRepository.DeleteAsync(entity);

            return _mapper.Map<UserPermitDTO>(dto);
        }
    }
}
