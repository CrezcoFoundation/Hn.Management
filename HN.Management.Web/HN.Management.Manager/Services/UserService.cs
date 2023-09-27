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
        private readonly IMapper _mapper;
        public UserService(IUserRepository usersRepository, IMapper mapper)
        {
            _userRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<UserDTO>> GetAllAsync()
        {
            var query = await _userRepository.GetItemsAsync("Select * from User");

            return _mapper.Map<List<UserDTO>>(query).AsQueryable();
        }

        public async Task<UserDTO> GetByConditionAsync(User user)
        {
            var query = await this._userRepository.GetItemsAsync(string.Empty);

            return await Task.FromResult(_mapper.Map<UserDTO>(query));
        }

        public async Task<UserDTO> GetEmail(string email, string password)
        {
            var query = await _userRepository.GetUserByEmail(email);
            var user = query.FirstOrDefault();

            var result = new UserDTO();

            if (user == null)
            {
                return null;
            }
            else if (user != null)
            {
                result = new UserDTO
                {
                    Email = user.Email,
                    PasswordHash = user.PasswordHash,
                    RoleName = user.RoleName
                };
            }

            return result;
        }

        public async Task<UserDTO> AddUserAsync(UserDTO user)
        {
            var entity = _mapper.Map<User>(user);
            await _userRepository.AddItemAsync(entity);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> UpdateAsync(UserDTO user)
        {
            var entity = _mapper.Map<User>(user);
            await _userRepository.UpdateItemAsync(entity.Id, entity);

            return user;
        }

        public async Task<bool> DeleteAsync(string id)
        { 
            await _userRepository.DeleteItemAsync(id);

            return true;
        }
    }
}
