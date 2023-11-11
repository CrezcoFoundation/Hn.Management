
namespace HN.ManagementEngine.DTO
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string RoleName { get; set; }

        public int RoleId { get; set; }
    }
}
