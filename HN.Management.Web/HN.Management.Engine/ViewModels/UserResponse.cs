using HN.Management.Engine.Models.Auth;

namespace HN.Management.Engine.ViewModels
{
    public class UserResponse
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string ImageUrl { get; set; }
        public Role Role { get; set; }
    }
}
