
using System.Text.Json.Serialization;

namespace HN.ManagementEngine.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        [JsonIgnore]
        public string Password { get; set; }

        public string Image { get; set; }
    }
}
