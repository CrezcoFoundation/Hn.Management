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
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userDonorPermitsRepository;
        private readonly IMapper _mapper;
        public UserRoleService(IUserRoleRepository userDonorPermitsRepository, IMapper mapper)
        {
            _userDonorPermitsRepository = userDonorPermitsRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<UserRoleDTO>> GetAllAsync()
        {
            var query = await _userDonorPermitsRepository.GetAllAsync();

            return _mapper.Map<List<UserRoleDTO>>(query).AsQueryable();
        }

        public async Task<UserRoleDTO> GetByConditionAsync(int userDonorPermitId)
        {
            var query = _userDonorPermitsRepository.GetByConditionAsync(x => x.Id == userDonorPermitId).Result.ToList();

            return await Task.FromResult(_mapper.Map<UserRoleDTO>(query.FirstOrDefault()));
        }

        public async Task<IQueryable<UserRoleDTO>> GetByUserAsync(int userId)
        {
            var query = _userDonorPermitsRepository.GetByConditionAsync(x => x.UserId == userId).Result.ToList();

            return await Task.FromResult(_mapper.Map<List<UserRoleDTO>>(query).AsQueryable());
        }

        public async Task<UserRoleDTO> AddAsync(UserRoleDTO userDonorPermit)
        {
            var entity = _mapper.Map<UserRole>(userDonorPermit);
            var dto = await _userDonorPermitsRepository.AddAsync(entity);

            return _mapper.Map<UserRoleDTO>(dto);
        }

        public async Task<UserRoleDTO> UpdateAsync(UserRoleDTO userDonorPermit)
        {
            var entity = _mapper.Map<UserRole>(userDonorPermit);
            var dto = await _userDonorPermitsRepository.UpdateAsync(entity);

            return _mapper.Map<UserRoleDTO>(dto);
        }

        public async Task<UserRoleDTO> DeleteAsync(UserRoleDTO userDonorPermit)
        {
            var entity = _mapper.Map<UserRole>(userDonorPermit);
            var dto = await _userDonorPermitsRepository.DeleteAsync(entity);

            return _mapper.Map<UserRoleDTO>(dto);
        }
    }
}
