using HN.Management.Engine.Models.Auth;
using Microsoft.AspNetCore.Http;

namespace HN.Management.Engine.ViewModels
{
    public class UserRequest
    {
        public string IsDeleted { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public IFormFile File { get; set; }
    }
}
