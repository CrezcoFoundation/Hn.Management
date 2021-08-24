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
    public class UserDonorPermitService : IUserDonorPermitService
    {
        private readonly IUserDonorPermitRepository _userDonorPermitsRepository;
        private readonly IMapper _mapper;
        public UserDonorPermitService(IUserDonorPermitRepository userDonorPermitsRepository, IMapper mapper)
        {
            _userDonorPermitsRepository = userDonorPermitsRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<UserDonorPermitDTO>> GetAllAsync()
        {
            var query = await _userDonorPermitsRepository.GetAllAsync();

            return _mapper.Map<List<UserDonorPermitDTO>>(query).AsQueryable();
        }

        public async Task<UserDonorPermitDTO> GetByConditionAsync(int userDonorPermitId)
        {
            var query = _userDonorPermitsRepository.GetByConditionAsync(x => x.Id == userDonorPermitId).Result.ToList();

            return await Task.FromResult(_mapper.Map<UserDonorPermitDTO>(query.FirstOrDefault()));
        }

        public async Task<IQueryable<UserDonorPermitDTO>> GetByUserAsync(int userId)
        {
            var query = _userDonorPermitsRepository.GetByConditionAsync(x => x.UserId == userId).Result.ToList();

            return await Task.FromResult(_mapper.Map<List<UserDonorPermitDTO>>(query).AsQueryable());
        }

        public async Task<UserDonorPermitDTO> AddAsync(UserDonorPermitDTO userDonorPermit)
        {
            var entity = _mapper.Map<UserDonorPermit>(userDonorPermit);
            var dto = await _userDonorPermitsRepository.AddAsync(entity);

            return _mapper.Map<UserDonorPermitDTO>(dto);
        }

        public async Task<UserDonorPermitDTO> UpdateAsync(UserDonorPermitDTO userDonorPermit)
        {
            var entity = _mapper.Map<UserDonorPermit>(userDonorPermit);
            var dto = await _userDonorPermitsRepository.UpdateAsync(entity);

            return _mapper.Map<UserDonorPermitDTO>(dto);
        }

        public async Task<UserDonorPermitDTO> DeleteAsync(UserDonorPermitDTO userDonorPermit)
        {
            var entity = _mapper.Map<UserDonorPermit>(userDonorPermit);
            var dto = await _userDonorPermitsRepository.DeleteAsync(entity);

            return _mapper.Map<UserDonorPermitDTO>(dto);
        }
    }
}
