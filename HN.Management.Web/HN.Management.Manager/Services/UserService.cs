using AutoMapper;
using HN.Management.Engine.Repositories.Interfaces;
using HN.Management.Engine.Util;
using HN.Management.Engine.ViewModels;
using HN.Management.Manager.Services.Interfaces;
using LanguageExt.Pipes;
using LanguageExt.Pretty;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using User = HN.ManagementEngine.Models.User;
using UserResponse = HN.Management.Engine.ViewModels.UserResponse;

namespace HN.Management.Manager.Services
{
    public class UserService : IUserService
    {
        private readonly IBlobStorageService _blobStorageService;
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public UserService(
            IUserRepository usersRepository,
            IMapper mapper, 
            IBlobStorageService blobStorageService,
            IRoleRepository roleRepository)
        {
            userRepository = usersRepository;
            _blobStorageService = blobStorageService;
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<UserResponse>> GetAllAsync()
        {
            var users = await this.userRepository.GetAllAsync();
            var userResponses = _mapper.Map<List<UserResponse>>(users);

            return userResponses;
        }

        public async Task<UserResponse> GetByIdAsync(string id)
        {
            var result = await this.userRepository.GetAsync(id);
            var userResponse = _mapper.Map<UserResponse>(result);

            return userResponse;
        }

        public async Task<UserResponse> GetUserAsync(LoginRequest loginRequest)
        {
            var result = await userRepository.GetUserByEmailAsync(loginRequest.Email);

            var isValidPassword = PasswordHelper.VerifyPassword(loginRequest.Password, result.PasswordHash);

            if (!isValidPassword)
            {
                throw new Exception("Invalid Password");
            }

            var userResponse = _mapper.Map<UserResponse>(result);

            return userResponse;
        }

        public async Task<UserResponse> CreateUserAsync(UserRequest userRequest)
        {
            var user = _mapper.Map<User>(userRequest);

            var isUserExist = await userRepository.UserExistsAsync(userRequest.Email);
            if (isUserExist)
            {
                throw new Exception("This email is already registered. Please use a different email.");
            }

            var isRoleExist = await _roleRepository.RoleExistsAsync(userRequest.Role.Id);
            if (!isRoleExist)
            {
                throw new Exception("Invalid Role");
            }

            var now = DateTime.UtcNow;
            var blobLocation = $"profile/{now.ToString("yyyyMMdd")}.{now.Ticks}";
            using (var fileStream = userRequest.File.OpenReadStream())
            {
                if (fileStream != null || fileStream.Length > 0)
                {
                    await _blobStorageService.UploadBlobAsync(fileStream, blobLocation);
                }
            }

            user.BlobName = blobLocation;

            user.PasswordHash = PasswordHelper.HashPassword(userRequest.Password);
            var result = await userRepository.InsertAsync(user);
            var userResponse = _mapper.Map<UserResponse>(result);
            return userResponse;
        }

        public async Task<UserResponse> UpdateAsync(User user)
        {
            var result = await userRepository.UpdateAsync(user);
            var userResponse = _mapper.Map<UserResponse>(result);

            return userResponse;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            await userRepository.Delete(id);

            return true;
        }

        public IEnumerable<User> GetAll()
        {
           return userRepository.GetAll();
        }
    }
}
