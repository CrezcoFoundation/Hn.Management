using AutoMapper;
using HN.Management.Engine.Repositories.Interfaces;
using HN.Management.Engine.ViewModels;
using HN.Management.Manager.Exceptions;
using HN.Management.Manager.Services.Interfaces;
using HN.ManagementEngine.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services
{
    public class UserService : IUserService
    {
        private readonly IBlobStorageService _blobStorageService;
        private readonly IUserRepository userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository usersRepository, IMapper mapper, IBlobStorageService blobStorageService)
        {
            userRepository = usersRepository;
            _blobStorageService = blobStorageService;
            _mapper = mapper;
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
            var result = await this.userRepository.GetUserAsync(loginRequest)
                 ?? throw new ApiException("Invalid Credentials", HttpStatusCode.Unauthorized);
            var userResponse = _mapper.Map<UserResponse>(result);

            return userResponse;
        }

        public async Task<UserResponse> CreateUserAsync(UserRequest userRequest)
        {
            var user = _mapper.Map<User>(userRequest);
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
    }
}
