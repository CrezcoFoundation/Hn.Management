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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserPermitRepository _userPermitRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository usersRepository, IUserPermitRepository userPermitRepository, IMapper mapper)
        {
            _userRepository = usersRepository;
            _userPermitRepository = userPermitRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<UserDTO>> GetAllAsync()
        {
            var query = await _userRepository.GetAllAsync();

            return _mapper.Map<List<UserDTO>>(query).AsQueryable();
        }

        public async Task<UserDTO> GetByConditionAsync(int userId)
        {
            var query = _userRepository.GetByConditionAsync(x => x.Id == userId).Result.ToList();

            return await Task.FromResult(_mapper.Map<UserDTO>(query.FirstOrDefault()));
        }

        public UserPermitDTO GetEmail(string email, string password)
        {
            var user = _userRepository.GetByConditionAsync(x => x.Email == email && x.Password == password).Result.FirstOrDefault();
            var userPermit = _userPermitRepository.GetByConditionAsync(x => x.UserId == user.Id).Result.FirstOrDefault();
            
            if (user == null)
            {
                return null;
            }

            var result = new UserPermitDTO
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                DonorPermit = userPermit.DonorPermit,
                ProjectPermit = userPermit.ProjectPermit
            };

            return result;
        }

        public async Task<UserDTO> AddAsync(UserDTO user)
        {
            var entity = _mapper.Map<User>(user);
            var dto = await _userRepository.AddAsync(entity);

            return _mapper.Map<UserDTO>(dto);
        }

        public async Task<UserDTO> UpdateAsync(UserDTO user)
        {
            var entity = _mapper.Map<User>(user);
            var dto = await _userRepository.UpdateAsync(entity);

            return _mapper.Map<UserDTO>(dto);
        }

        public async Task<UserDTO> DeleteAsync(UserDTO user)
        {
            var entity = _mapper.Map<User>(user);
            var dto = await _userRepository.DeleteAsync(entity);

            return _mapper.Map<UserDTO>(dto);
        }
    }
}
