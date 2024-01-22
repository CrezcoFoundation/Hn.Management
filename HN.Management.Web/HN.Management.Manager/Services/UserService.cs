using AutoMapper;
using HN.Management.Engine.Repositories.Interfaces;
using HN.Management.Manager.Services.Interfaces;
using HN.ManagementEngine.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository usersRepository, IMapper mapper)
        {
            userRepository = usersRepository;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await this.userRepository.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await this.userRepository.GetAsync(id);
        }

        public async Task<User> GetEmail(string email, string password)
        {
            var query = new List<User>() ;
            var user = query.FirstOrDefault();

            var result = new User();

            if (user == null)
            {
                return null;
            }
            else if (user != null)
            {
                result = new User
                {
                    Email = user.Email,
                    Password = user.Password
                };
            }

            return result;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            return await userRepository.InsertAsync(user);
        }

        public async Task<User> UpdateAsync(User user)
        { 
            await userRepository.UpdateAsync(user);

            return user;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            await userRepository.Delete(id);

            return true;
        }
    }
}
